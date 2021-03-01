using Core.Models.Configurations;
using Data.Contexts.AppDb;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services;
using System.IO;
using System.Reflection;
using System.Text;
using Web.API.Configurations;
using Web.API.Middlewares;

namespace Web.API
{
    /// <summary>
    /// startup/entrypoint
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        public const string _corsPolicy = "CORS_Production";

        /// <summary>
        /// 
        /// </summary>
        public IConfigurationRoot Configuration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="env"></param>
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(env.ContentRootPath)
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                            .AddEnvironmentVariables();

            Configuration = builder.Build();
        }
               
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            var configurationSection = Configuration.GetSection(nameof(AppSettings));
            services.Configure<AppSettings>(configurationSection);
            var settings = configurationSection.Get<AppSettings>();

            ConfigureData(services, settings);
            services.ConfigureAppServices();
            services.AddHttpContextAccessor();

            ConfigureAuthorizationSchemes(services, settings);
            ConfigureCors(services, settings);
            ConfigureSwagger(services);
            ConfigureApiVersioning(services);

            services.AddControllers();
        }

        private void ConfigureAuthorizationSchemes(IServiceCollection services, AppSettings appSettings)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ValidIssuer = appSettings.Jwt.Issuer,
                        ValidAudience = appSettings.Jwt.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.Jwt.Key))
                    };
                });
        }

        private void ConfigureData(IServiceCollection services, AppSettings appSettings)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(appSettings.AppDbConnectionString));
            services.AddScoped<IAppDbContext, AppDbContext>();
        }

        private void ConfigureCors(IServiceCollection services, AppSettings appSettings)
        {
            services.AddCors(options => options.AddPolicy(_corsPolicy, builder =>
            {
                builder.WithOrigins(appSettings.AllowedOrigins)
                       .WithMethods("GET", "POST", "PUT", "DELETE");
            }));
        }

        //
        // for reference with regards to API versioning and swagger: 
        // https://dejanstojanovic.net/aspnet/2018/november/setting-up-swagger-to-support-versioned-api-endpoints-in-aspnet-core/
        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    var assemblyDescriptionAttribute = GetType().Assembly.GetCustomAttribute<AssemblyDescriptionAttribute>().Description;
                    options.SwaggerDoc(description.GroupName, new OpenApiInfo
                    {
                        Title = $"{GetType().Assembly.GetCustomAttribute<AssemblyProductAttribute>().Product} {description.ApiVersion}",
                        Version = description.ApiVersion.ToString(),
                        Description = description.IsDeprecated ? $"{assemblyDescriptionAttribute} - DEPRECATED" : assemblyDescriptionAttribute,
                        Contact = new OpenApiContact
                        {
                            Name = "RJ Rosopa"
                        }
                    });
                }

                options.OperationFilter<SwaggerDefaultValues>();
                options.IncludeXmlComments(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"{GetType().Assembly.GetName().Name}.xml"));
            });
        }

        //
        // for reference with regards to API versioning and swagger: 
        // https://dejanstojanovic.net/aspnet/2018/november/setting-up-swagger-to-support-versioned-api-endpoints-in-aspnet-core/
        private void ConfigureApiVersioning(IServiceCollection services)
        {
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="provider">injected from AddVersionedApiExplorer</param>
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env, 
            IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors(options => options.AllowAnyOrigin());

                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    foreach(var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });
            }
            else
            {
                app.UseCors(_corsPolicy);
                app.UseHsts();
            }

            app.UseMiddleware<HttpResponseMiddleware>();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

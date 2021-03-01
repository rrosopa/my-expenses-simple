using Microsoft.Extensions.DependencyInjection;
using Services.Auth;
using Services.Expenses;

namespace Services
{
    public static class ServiceConfiguration
    {
        public static void ConfigureAppServices(this IServiceCollection services)
        {
            // NOTE: Add services alphabetically so that it's easy to check

            services.AddScoped<IClaimsService, ClaimsService>();
            services.AddScoped<IExpenseService, ExpenseService>();
        }
    }
}

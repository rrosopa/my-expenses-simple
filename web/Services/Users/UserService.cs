using Core.Constants;
using Core.Extensions;
using Core.Models.ActionResults;
using Core.Models.Errors;
using Data.Contexts.AppDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Users
{
    public class UserService : IUserService
    {
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger<UserService> _logger;

        public UserService(
            IAppDbContext appDbContext,
            ILogger<UserService> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task<AddResult<User>> CreateUserAsync(UserCreateOptions createOptions)
        {
            var addResult = new AddResult<User>();

            try
            {
                
            }
            catch (Exception ex)
            {

            }

            return addResult;
        }

        public async Task<FetchResult<User>> GetUserAsync(int userId)
        {
            var fetchResult = new FetchResult<User>();

            try
            {
                fetchResult.Result = await _appDbContext.Users.GetUserAsync(userId);
                if (fetchResult.Result == null)
                {
                    _logger.LogDebug($"[{ErrorCode.UserService001}] User with Id:{userId} does not exist.");
                    fetchResult.Errors.Add(new Error(ErrorCode.UserService001, $"User with Id:{userId} does not exist."));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[{ErrorCode.UserService002}] {ex.Message}");
            }

            return fetchResult;
        }

        public async Task<SearchResult<User>> SearchUsersAsync(UserSearchOptions searchOptions)
        {
            var searchResult = new SearchResult<User>();

            try
            {
                if (searchOptions == null)
                    return searchResult;

                var userQuery = _appDbContext.Users.AsQueryable();

                if (searchOptions.Name.HasValue())
                {
                    userQuery = userQuery.Where(x =>
                                x.FirstName.ToLowerInvariant().Contains(searchOptions.Name)
                                || x.MiddleName.ToLowerInvariant().Contains(searchOptions.Name)
                                || x.LastName.ToLowerInvariant().Contains(searchOptions.Name));
                }

                userQuery = userQuery.OrderBy(x => x.LastName);

                searchResult.Page = searchOptions.Page;
                searchResult.PageSize = searchOptions.PageSize;
                searchResult.TotalResult = await userQuery.CountAsync();
                searchResult.Result = UserEntityMapper.MapUsers(await userQuery.TakeItems(searchOptions.Page, searchOptions.PageSize).ToListAsync());
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"[{ErrorCode.UserService003}] {ex.Message}");
            }

            return searchResult;
        }

        public async Task<UpdateResult<User>> UpdateUserAsync(UserUpdateOptions updateOptions)
        {
            var updateResult = new UpdateResult<User>();

            try
            {

            }
            catch (Exception ex)
            {

            }

            return updateResult;
        }
    }
}

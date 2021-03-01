using Core.Models.ActionResults;
using Core.Models.Users;
using System;
using System.Threading.Tasks;

namespace Services.Users
{
    public interface IUserService
    {
        Task<AddResult<User>> CreateUserAsync(UserCreateOptions createOptions);
        Task<UpdateResult<User>> UpdateUserAsync(UserUpdateOptions updateOptions);


        Task<FetchResult<User>> GetUserAsync(int userId);
        Task<SearchResult<User>> SearchUsersAsync(UserSearchOptions searchOptions);
    }
}

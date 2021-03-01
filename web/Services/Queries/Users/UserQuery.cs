using Core.Models.Users;
using Data.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Queries.Users
{
    internal static class UserQuery
    {
        internal async static Task<List<User>> GetUsersAsync(this IQueryable<UserEntity> query)
        {
            return await query
                .AsNoTracking()
                .Select(user => new User
                {
                    Id = user.Id,
                    PublicId = user.PublicId,
                    Email = user.Email,

                    FirstName = user.FirstName,
                    MiddleName = user.MiddleName,
                    LastName = user.LastName,

                    IsEnabled = user.IsEnabled,
                    IsLocked = user.IsLocked,

                    CreatedById = user.CreatedById,  
                    CreatedBy = user.CreatedBy.FirstName + " " + user.CreatedBy.LastName,
                    CreatedDate = user.CreatedDate,
                    ModifiedById = user.ModifiedById,
                    ModifiedBy = user.ModifiedBy.FirstName + " " + user.ModifiedBy.LastName,
                    ModifiedDate = user.ModifiedDate,
                })
                .ToListAsync();
        }

        internal async static Task<User> GetUserAsync(this IQueryable<UserEntity> query, int id) 
            => (await query.Where(user => user.Id == id).GetUsersAsync()).SingleOrDefault();
    }
}

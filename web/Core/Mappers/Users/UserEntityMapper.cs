using Core.Models.Users;
using Data.Models.Users;
using System.Collections.Generic;
using System.Linq;

namespace Core.Mappers.Users
{
    public static class UserEntityMapper
    {
        public static User MapUser(UserEntity userEntity)
        {
            if (userEntity == null)
                return null;

            var user = new User
            {
                Email = userEntity.Email,
                FirstName = userEntity.FirstName,
                MiddleName = userEntity.MiddleName,
                LastName = userEntity.LastName
            };

            BaseMapper.MapAuditableEntity(user, userEntity);
            return user;
        }

        public static List<User> MapUsers(ICollection<UserEntity> userEntities) => userEntities?.Select(x => MapUser(x)).ToList();
    }
}

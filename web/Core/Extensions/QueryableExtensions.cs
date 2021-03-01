using System.Linq;

namespace Core.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<TEntity> TakeItems<TEntity>(this IQueryable<TEntity> queryable, int pageNo, int pageSize) where TEntity : class
        {
            if (pageNo == 0 || pageSize == 0)
                return queryable;

            int skip = (pageNo - 1) * pageSize;
            return queryable.Skip(skip).Take(pageSize);
        }
    }
}

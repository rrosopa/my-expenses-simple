using Core.Models;
using Data.Models;

namespace Core.Mappers
{
    public static class BaseMapper
    {
        public static void MapAuditableEntity<TModel, TEntity>(TModel model, TEntity entity) 
            where TModel : AuditableModel
            where TEntity : AuditableEntity
        {
            model.Id = entity.Id;
            model.CreatedById = entity.CreatedById;
            model.ModifiedById = entity.ModifiedById;
            model.CreatedDate = entity.CreatedDate;
            model.ModifiedDate = entity.ModifiedDate;
        }
    }
}

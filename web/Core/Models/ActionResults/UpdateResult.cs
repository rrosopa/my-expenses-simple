using Core.Models.Errors;
using System.Collections.Generic;

namespace Core.Models.ActionResults
{
    public class UpdateResult<T> : ActionResult<T> where T : BaseModel
    {
    }
}

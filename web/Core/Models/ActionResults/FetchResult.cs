using Core.Models.Errors;
using System.Collections.Generic;

namespace Core.Models.ActionResults
{
    public class FetchResult<T> : ActionResult<T> where T : class
    {
    }
}

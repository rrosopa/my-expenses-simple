using Core.Models.Errors;
using System.Collections.Generic;

namespace Core.Models.ActionResults
{
    public class ActionResult<T>
    {
        public ActionResult()
        {
            this.Errors = new List<Error>();
        }

        public T Result { get; set; }
        public List<Error> Errors { get; set; }
    }
}

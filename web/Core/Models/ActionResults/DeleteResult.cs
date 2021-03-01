using Core.Models.Errors;
using System.Collections.Generic;

namespace Core.Models.ActionResults
{
    public class DeleteResult
    {
        public DeleteResult()
        {
            this.Errors = new List<Error>();
        }

        public List<Error> Errors { get; set; }
    }
}

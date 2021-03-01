using Core.Models.Errors;
using System;
using System.Collections.Generic;

namespace Core.Models.ActionResults
{
    public class SearchResult<T> : ActionResult<ICollection<T>> where T : BaseModel
    {
        public SearchResult()
        {
            this.Result = new List<T>();
            this.Errors = new List<Error>();
        }

        public int Page { get; set; }

        private int _pageSize = 0;
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = value < 1 ? 0 : value;
                SetPageTotalCount();
            }
        }

        private int _totalResult = 0;
        public int TotalResult
        {
            get { return _totalResult; }
            set
            {
                _totalResult = value < 0 ? 0 : value;
                SetPageTotalCount();
            }
        }
        public int PageTotalCount { get; private set; }

        private void SetPageTotalCount()
        {
            if (_pageSize > 0)
                PageTotalCount = (int)Math.Ceiling(_totalResult / (double)_pageSize);
        }
    }
}

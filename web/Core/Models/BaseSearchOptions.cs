namespace Core.Models
{
    public class BaseSearchOptions
    {
        private int _page;
        public int Page
        {
            get { return _page; }
            set { _page = value < 1 ? 0 : value; }
        }
        public int PageSize { get; set; }
    }
}

namespace Common.Pagination
{
    public class PagingFilter
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public string OrderByName { get; set; }

        public string OrderByType { get; set; }

        public string Search { get; set; }
    }
}

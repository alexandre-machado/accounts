using System.Collections.Generic;

namespace Common.Pagination
{
    public class Bag<T>
    {
        public IEnumerable<T> Rows { get; set; }

        public int TotalRecords { get; set; }
    }
}
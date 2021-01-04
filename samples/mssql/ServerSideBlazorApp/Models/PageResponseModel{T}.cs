using System.Collections.Generic;
using System.Linq;

namespace ServerSideBlazorApp.Models
{
    public class Page<T>
    {
        public PagingParameters PagingParameters { get; set; }
        public IEnumerable<T> Data { get; set; } = new List<T>();
        public int? TotalCount { get; set; }

        public Page()
        { 
        }

        public Page(PagingParameters parameters, IEnumerable<T> page, int totalCount)
        {
            PagingParameters = parameters;
            Data = page;
            TotalCount = totalCount;
        }

        public static Page<T> CreateDefault()
            => new Page<T>(new PagingParameters(0, 10), Enumerable.Empty<T>(), 0);
    }
}

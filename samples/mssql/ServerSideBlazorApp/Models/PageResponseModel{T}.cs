using System.Collections.Generic;
using System.Linq;

namespace ServerSideBlazorApp.Models
{
    public class PageResponseModel<T> : PageModel
    {
        public IEnumerable<T> Page { get; set; } = new List<T>();
        public int TotalCount { get; set; }

        public PageResponseModel()
        { 
        }

        public PageResponseModel(int offset, int limit, string searchPhrase, IEnumerable<T> page, int totalCount) : base(offset, limit, searchPhrase)
        {
            Page = page;
            TotalCount = totalCount;
        }

        public static PageResponseModel<T> CreateDefault()
            => new PageResponseModel<T>(0, 10, null, Enumerable.Empty<T>(), 0);
    }
}

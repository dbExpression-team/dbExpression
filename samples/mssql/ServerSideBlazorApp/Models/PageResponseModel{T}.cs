using System.Collections.Generic;

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
    }
}

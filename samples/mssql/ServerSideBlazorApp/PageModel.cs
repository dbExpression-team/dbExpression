using System.Collections.Generic;

namespace ServerSideBlazorApp
{
    public abstract class PageModel
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
        public string SearchPhrase { get; set; }

        protected PageModel()
        {
        }

        protected PageModel(int offset, int limit, string searchPhrase)
        {
            Offset = offset;
            Limit = limit;
            SearchPhrase = searchPhrase;
        }
    }

    public class PageRequestModel : PageModel 
    {
        public PageRequestModel() 
        {
        }

        public PageRequestModel(int offset, int limit, string searchPhrase) : base(offset, limit, searchPhrase)
        {
        }
    }

    public class PageResponseModel<T> : PageModel
    { 
        public IEnumerable<T> Page { get; set; }
        public int TotalCount { get; set; }

        public PageResponseModel(int offset, int limit, string searchPhrase, IEnumerable<T> page, int totalCount) : base(offset, limit, searchPhrase)
        {
            Page = page;
            TotalCount = totalCount;
        }
    }
}

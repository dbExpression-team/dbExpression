using System.Collections.Generic;

namespace ServerSideBlazorApp.Models
{
    public abstract class PageModel
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
        public string SearchPhrase { get; set; }
        public IEnumerable<Sort> Sorting {get; set; }

        protected PageModel()
        {
        }

        protected PageModel(int offset, int limit)
        {
            Offset = offset;
            Limit = limit;
        }

        protected PageModel(int offset, int limit, string searchPhrase)
        {
            Offset = offset;
            Limit = limit;
            SearchPhrase = searchPhrase;
        }

        protected PageModel(int offset, int limit, string searchPhrase, Sort sort)
        {
            Offset = offset;
            Limit = limit;
            SearchPhrase = searchPhrase;
            Sorting = new List<Sort> { sort };
        }

        protected PageModel(int offset, int limit, string searchPhrase, IEnumerable<Sort> sorting)
        {
            Offset = offset;
            Limit = limit;
            SearchPhrase = searchPhrase;
            Sorting = sorting;
        }
    }
}

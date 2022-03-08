using System.Collections.Generic;

namespace ServerSideBlazorApp.Models
{
    public class PagingParametersWithSearch : PagingParameters
    { 
        public string? SearchPhrase { get; set; }

        public PagingParametersWithSearch()
        {

        }

        private PagingParametersWithSearch(int offset, int limit, Sort sort) : base(offset, limit, sort)
        {

        }

        public PagingParametersWithSearch(int offset, int limit, string searchPhrase) : base(offset, limit)
        {
            SearchPhrase = searchPhrase;
        }

        public PagingParametersWithSearch(int offset, int limit, Sort sort, string searchPhrase) : base(offset, limit, sort)
        {
            SearchPhrase = searchPhrase;
        }

        public PagingParametersWithSearch(int offset, int limit, IEnumerable<Sort> sorting, string searchPhrase) : base(offset, limit, sorting)
        {
            SearchPhrase = searchPhrase;
        }

        public new static PagingParametersWithSearch CreateDefault(Sort defaultSort)
            => new(0, 10, defaultSort);
    }
}

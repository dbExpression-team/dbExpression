using Blazorise;
using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;
using System.Linq;

namespace ServerSideBlazorApp.Models
{
    public class PagingParameters 
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
        public IEnumerable<Sort> Sorting { get; set; } = Enumerable.Empty<Sort>();

        public PagingParameters()
        {
        }

        public PagingParameters(int offset, int limit)
        {
            Offset = offset;
            Limit = limit;
        }

        public PagingParameters(int offset, int limit, Sort sort)
        {
            Offset = offset;
            Limit = limit;
            Sorting = new List<Sort> { sort };
        }

        public PagingParameters(int offset, int limit, IEnumerable<Sort> sorting)
        {
            Offset = offset;
            Limit = limit;
            Sorting = sorting;
        }

        public static PagingParameters CreateDefault(string defaultSortField, SortDirection defaultSortDirection)
            => new PagingParameters(0, 10, CreateDefaultSort(defaultSortField, defaultSortDirection));

        public static PagingParameters CreateDefault(int pageSize, Sort defaultSort)
            => new PagingParameters(0, pageSize, defaultSort);

        public static PagingParameters CreateDefault(Sort defaultSort)
            => new PagingParameters(0, 10, defaultSort);

        public static Sort CreateDefaultSort(string defaultSortField, SortDirection defaultSortDirection)
            => new Sort(defaultSortField, defaultSortDirection == SortDirection.Ascending ? OrderExpressionDirection.ASC : OrderExpressionDirection.DESC);
    }
}

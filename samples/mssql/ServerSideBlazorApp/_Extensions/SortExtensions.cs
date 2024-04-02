using Blazorise;
using DbExpression.Sql.Expression;

namespace ServerSideBlazorApp
{
    public static class SortExtensions
    {
        public static OrderExpressionDirection? ConvertSortDirection(this SortDirection direction)
            => direction switch
            {
                SortDirection.Ascending => OrderExpressionDirection.ASC,
                SortDirection.Descending => OrderExpressionDirection.DESC,
                _ => null
            };

        public static SortDirection ConvertSortDirection(this OrderExpressionDirection direction)
            => direction switch
            {
                OrderExpressionDirection.ASC => SortDirection.Ascending,
                OrderExpressionDirection.DESC => SortDirection.Descending,
                _ => SortDirection.Default
            };
    }
}

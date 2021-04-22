using HatTrick.DbEx.Sql.Expression;

namespace ServerSideBlazorApp.Models
{
    public class Sort
    {
        public string Field { get; set; }
        public OrderExpressionDirection Direction { get; set; }

        public Sort()
        {
        }

        public Sort(string field, OrderExpressionDirection direction)
        {
            Field = field;
            Direction = direction;
        }
    }
}

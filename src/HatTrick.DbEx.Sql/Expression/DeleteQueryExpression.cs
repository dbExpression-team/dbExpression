using System.Text;

namespace HatTrick.DbEx.Sql.Expression
{
    public class DeleteQueryExpression : QueryExpression
    {

        #region interface
        public int? Top { get; set; }
        public FilterExpressionSet Where { get; set; }
        public JoinExpressionSet Joins { get; set; }
        #endregion

        #region to string
        public override string ToString()
        {
            var sb = new StringBuilder("DELETE ");
            if (Top.HasValue)
            {
                sb.Append("TOP ");
                sb.Append(Top);
            }
            sb.Append("FROM ");
            sb.Append(BaseEntity);
            sb.Append(" ");
            sb.Append(Joins);
            sb.Append(" ");
            if (Where?.LeftArg is object)
            {
                sb.Append("WHERE ");
                sb.Append(Where);
            }

            return sb.ToString();
        }
        #endregion

        #region operators
        public static DeleteQueryExpression operator &(DeleteQueryExpression query, JoinExpression join)
        {
            if (query is object)
            {
                if (query.Joins is null) { query.Joins = new JoinExpressionSet(join); }
                else { query.Joins &= join; }
            }
            return query;
        }

        public static DeleteQueryExpression operator &(DeleteQueryExpression query, FilterExpression filter)
        {
            if (query is object)
            {
                if (query.Where is null) { query.Where = new FilterExpressionSet(filter); }
                else { query.Where &= filter; }
            }
            return query;
        }

        public static DeleteQueryExpression operator &(DeleteQueryExpression query, FilterExpressionSet filter)
        {
            if (query is object)
            {
                if (query.Where is null) { query.Where = filter; }
                else { query.Where &= filter; }
            }
            return query;
        }
        #endregion
    }

}

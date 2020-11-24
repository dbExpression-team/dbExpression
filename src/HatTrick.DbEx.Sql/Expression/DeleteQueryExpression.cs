namespace HatTrick.DbEx.Sql.Expression
{
    public class DeleteQueryExpression : QueryExpression
    {

        #region interface
        public int? Top { get; set; }
        public FilterExpressionSet Where { get; set; }
        public JoinExpressionSet Joins { get; set; }
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

namespace HatTrick.DbEx.Sql.Expression
{
    public class SelectQueryExpression : QueryExpression
    {
        public SelectExpressionSet Select { get; set; } = new SelectExpressionSet();

        public static SelectQueryExpression operator &(SelectQueryExpression query, SelectExpression select)
        {
            if (query is object)
            {
                if (query.Select is null) { query.Select = new SelectExpressionSet(select); }
                else { query.Select &= select; }
            }
            return query;
        }

        public static SelectQueryExpression operator &(SelectQueryExpression query, SelectExpressionSet select)
        {
            if (query is object)
            {
                if (query.Select is null) { query.Select = select; }
                else { query.Select &= select; }
            }
            return query;
        }
    }
    
}

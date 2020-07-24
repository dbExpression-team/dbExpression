namespace HatTrick.DbEx.Sql.Expression
{
    public class InsertQueryExpression : QueryExpression
    {
        public IDbEntity Instance { get; set; }
        public InsertExpressionSet Insert { get; set; } = new InsertExpressionSet();

        public static InsertQueryExpression operator &(InsertQueryExpression query, InsertExpression insert)
        {
            if (query is object)
            {
                if (query.Insert is null) { query.Insert = new InsertExpressionSet(insert); }
                else { query.Insert &= insert; }
            }
            return query;
        }

        public static InsertQueryExpression operator &(InsertQueryExpression query, InsertExpressionSet insert)
        {
            if (query is object)
            {
                if (query.Insert is null) { query.Insert = insert; }
                else { query.Insert &= insert; }
            }
            return query;
        }
    }
    
}

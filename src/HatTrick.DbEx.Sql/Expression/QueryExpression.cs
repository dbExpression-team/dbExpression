namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class QueryExpression : IExpressionElement
    {
        public EntityExpression BaseEntity { get; set; }
    }    
}

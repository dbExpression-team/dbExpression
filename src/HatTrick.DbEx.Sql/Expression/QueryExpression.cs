namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class QueryExpression : IExpressionElement
    {
        public IEntityExpression BaseEntity { get; set; }
    }    
}

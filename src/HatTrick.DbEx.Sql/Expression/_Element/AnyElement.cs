namespace HatTrick.DbEx.Sql.Expression
{
#pragma warning disable IDE1006 // Naming Styles
    public interface AnyElement : IExpressionElement
#pragma warning restore IDE1006 // Naming Styles
    {
        OrderByExpression Asc { get; }
        OrderByExpression Desc { get; }
    }

}

using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface AnyElement : IExpressionElement
#pragma warning restore IDE1006 // Naming Styles
    {
        OrderByExpression Asc { get; }
        OrderByExpression Desc { get; }
    }

}

using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.Sql.Extensions.Expression
{
    public static class IDBExpressionSelectPartExtensions
    {
        public static DBSelectExpression ToSelectExpression(this IDBExpressionSelectClausePart part)
            => part as DBExpressionField ?? part as DBArithmeticExpression ?? part as DBSelectExpression;
    }
}

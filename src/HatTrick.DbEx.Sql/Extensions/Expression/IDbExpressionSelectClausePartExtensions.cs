using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Extensions.Expression
{
    public static class IDbExpressionSelectClausePartExtensions
    {
        public static SelectExpression ToSelectExpression(this IDbExpressionSelectClausePart part)
            => part as FieldExpression ?? part as ArithmeticExpression ?? part as SelectExpression;
    }
}

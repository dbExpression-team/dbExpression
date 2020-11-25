using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public static class ExpressionElementExtensions
    {
        public static bool IsDBNull(this IExpressionElement expression)
        {
            if (expression is LiteralExpression literal)
                return literal.Expression is DBNull;

            if (expression is SelectExpression select)
                return IsDBNull(select.Expression);

            if (expression is ExpressionMediator mediator)
                return IsDBNull(mediator.Expression);

            return false;
        }

        public static FieldExpression AsFieldExpression(this IExpressionElement expression)
        {
            if (expression is FieldExpression field)
                return field;

            if (expression is SelectExpression select)
                return AsFieldExpression(select.Expression);

            if (expression is ExpressionMediator mediator)
                return AsFieldExpression(mediator.Expression);

            return null;
        }
    }
}

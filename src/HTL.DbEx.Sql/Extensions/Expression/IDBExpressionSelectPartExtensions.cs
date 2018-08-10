using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.Sql.Extensions.Expression
{
    public static class IDBExpressionSelectPartExtensions
    {
        public static DBSelectExpression ToSelectExpression(this IDBExpressionSelectClausePart part)
        {
            var field = part as DBExpressionField;
            if (!Equals(field, null))
                return field;
            var arithmetic = part as DBArithmeticExpression;
            if (!Equals(arithmetic, null))
                return arithmetic;
            var select = part as DBSelectExpression;
            if (!Equals(select, null))
                return select;
            return null;
        }
    }
}

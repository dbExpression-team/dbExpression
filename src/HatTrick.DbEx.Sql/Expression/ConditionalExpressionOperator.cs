using HatTrick.DbEx.Sql.Attribute;

namespace HatTrick.DbEx.Sql.Expression
{
    public enum ConditionalExpressionOperator
    {
        [ExpressionOperator(" AND ")]
        And = 0,
        [ExpressionOperator(" OR ")]
        Or = 1
    }
}

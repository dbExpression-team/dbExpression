using HTL.DbEx.Sql.Attribute;

namespace HTL.DbEx.Sql.Expression
{
    public enum DBConditionalExpressionOperator
    {
        [ExpressionOperator(" AND ")]
        And = 0,
        [ExpressionOperator(" OR ")]
        Or = 1
    }
}

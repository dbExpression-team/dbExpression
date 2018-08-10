using HTL.DbEx.Sql.Attribute;

namespace HTL.DbEx.Sql.Expression
{
    public enum DBFilterExpressionOperator
    {
        [ExpressionOperator(" = ")]
        Equal = 0,
        [ExpressionOperator(" <> ")]
        NotEqual = 1,
        [ExpressionOperator(" < ")]
        LessThan = 2,
        [ExpressionOperator(" <= ")]
        LessThanOrEqual = 3,
        [ExpressionOperator(" > ")]
        GreaterThan = 4,
        [ExpressionOperator(" >= ")]
        GreaterThanOrEqual = 5,
        [ExpressionOperator(" LIKE ")]
        Like = 6,
        [ExpressionOperator(" IN ")]
        In = 7
    }
}

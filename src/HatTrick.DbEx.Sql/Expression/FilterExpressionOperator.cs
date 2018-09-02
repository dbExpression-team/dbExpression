using HatTrick.DbEx.Sql.Attribute;

namespace HatTrick.DbEx.Sql.Expression
{
    public enum FilterExpressionOperator
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

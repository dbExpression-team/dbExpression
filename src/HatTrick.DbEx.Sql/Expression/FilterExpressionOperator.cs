using HatTrick.DbEx.Sql.Attribute;

namespace HatTrick.DbEx.Sql.Expression
{
    public enum FilterExpressionOperator
    {
        [ExpressionOperator("")]
        None = 0,
        [ExpressionOperator("=")]
        Equal = 1,
        [ExpressionOperator("<>")]
        NotEqual = 2,
        [ExpressionOperator("<")]
        LessThan = 3,
        [ExpressionOperator("<=")]
        LessThanOrEqual = 4,
        [ExpressionOperator(">")]
        GreaterThan = 5,
        [ExpressionOperator(">=")]
        GreaterThanOrEqual = 6,
    }
}

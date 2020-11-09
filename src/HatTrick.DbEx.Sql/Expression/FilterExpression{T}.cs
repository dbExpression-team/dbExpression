namespace HatTrick.DbEx.Sql.Expression
{
    public class FilterExpression<T> : FilterExpression
    {
        #region constructors
        public FilterExpression(ExpressionMediator leftArg, ExpressionMediator rightArg, FilterExpressionOperator expressionOperator)
            : base(leftArg, rightArg, expressionOperator)
        {
        }

        public FilterExpression(ExpressionMediator leftArg, NullableExpressionMediator<T> rightArg, FilterExpressionOperator expressionOperator)
            : base(leftArg, rightArg, expressionOperator)
        {
        }
        #endregion

        #region implicit operators
        public static implicit operator FilterExpressionSet(FilterExpression<T> a)
            => a is null ? null : new FilterExpressionSet(a);

        public static implicit operator HavingExpression(FilterExpression<T> a)
            => new HavingExpression(a);

        public static implicit operator JoinOnExpressionSet(FilterExpression<T> a)
            => a is null ? null : a.ConvertToJoinOnExpressionSet();
        #endregion
    }
}

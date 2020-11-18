namespace HatTrick.DbEx.Sql.Expression
{
    public class FilterExpression<T> : FilterExpression
    {
        #region constructors
        public FilterExpression(IExpressionElement leftArg, IExpressionElement rightArg, FilterExpressionOperator expressionOperator)
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
            => a?.ConvertToJoinOnExpressionSet();
        #endregion
    }
}

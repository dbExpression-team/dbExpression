namespace HatTrick.DbEx.Sql.Expression
{
    public static class FilterExpressionExtensions
    {
        public static JoinOnExpressionSet ConvertToJoinOnExpressionSet(this FilterExpression filter)
        {
            return ConvertToJoinOnExpressionSet(new FilterExpressionSet(filter));
        }

        public static JoinOnExpressionSet ConvertToJoinOnExpressionSet(this FilterExpressionSet filterSet)
        {
            return ConvertToJoinOnExpressionSet(filterSet.LeftArg, filterSet.RightArg, filterSet.ConditionalOperator, filterSet.Negate);
        }

        private static JoinOnExpressionSet ConvertToJoinOnExpressionSet(IExpression leftArg, IExpression rightArg, ConditionalExpressionOperator conditionalOperator, bool negate)
        {
            //left
            if (leftArg is FilterExpressionSet leftSet)
            {
                leftArg = leftSet.ConvertToJoinOnExpressionSet();
            }
            else if (leftArg is FilterExpression leftExp)
            {
                leftArg = new JoinOnExpression(leftExp.LeftArg, leftExp.RightArg, leftExp.ExpressionOperator);
            }

            //right
            if (rightArg is FilterExpressionSet rightSet)
            {
                rightArg = rightSet.ConvertToJoinOnExpressionSet();
            }
            else if (rightArg is FilterExpression rightExp)
            {
                rightArg = new JoinOnExpression(rightExp.LeftArg, rightExp.RightArg, rightExp.ExpressionOperator);
            }

            return new JoinOnExpressionSet(leftArg, rightArg, conditionalOperator, negate);
        }
    }
}

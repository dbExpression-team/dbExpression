using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class ExpressionPair : IExpression
    {
        public IExpression LeftPart { get; private set; }
        public IExpression RightPart { get; private set; }

        public ExpressionPair(IExpression leftPart)
        {
            LeftPart = leftPart ?? throw new ArgumentNullException($"{nameof(leftPart)} is required.");
        }

        public ExpressionPair(IExpression leftPart, IExpression rightPart)
        {
            LeftPart = leftPart ?? throw new ArgumentNullException($"{nameof(leftPart)} is required.");
            RightPart = rightPart ?? throw new ArgumentNullException($"{nameof(rightPart)} is required.");
        }
    }
}

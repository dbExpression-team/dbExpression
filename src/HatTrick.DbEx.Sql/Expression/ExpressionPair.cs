using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class ExpressionPair : IExpressionElement
    {
        public IExpressionElement LeftPart { get; private set; }
        public IExpressionElement RightPart { get; private set; }

        public ExpressionPair(IExpressionElement leftPart)
        {
            LeftPart = leftPart ?? throw new ArgumentNullException($"{nameof(leftPart)} is required.");
        }

        public ExpressionPair(IExpressionElement leftPart, IExpressionElement rightPart)
        {
            LeftPart = leftPart ?? throw new ArgumentNullException($"{nameof(leftPart)} is required.");
            RightPart = rightPart ?? throw new ArgumentNullException($"{nameof(rightPart)} is required.");
        }
    }
}

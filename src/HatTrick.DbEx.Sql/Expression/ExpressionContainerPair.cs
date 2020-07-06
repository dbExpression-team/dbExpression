using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class ExpressionContainerPair
    {
        public ExpressionContainer LeftPart { get; private set; }
        public ExpressionContainer RightPart { get; private set; }

        public ExpressionContainerPair(ExpressionMediator leftPart)
        {
            LeftPart = new ExpressionContainer(leftPart ?? throw new ArgumentNullException($"{nameof(leftPart)} is required."));
        }

        public ExpressionContainerPair(ExpressionMediator leftPart, ExpressionMediator rightPart)
        {
            LeftPart = new ExpressionContainer(leftPart ?? throw new ArgumentNullException($"{nameof(leftPart)} is required."));
            RightPart = new ExpressionContainer(rightPart ?? throw new ArgumentNullException($"{nameof(rightPart)} is required."));
        }
        public ExpressionContainerPair(ExpressionContainer leftPart)
        {
            LeftPart = leftPart ?? throw new ArgumentNullException($"{nameof(leftPart)} is required.");
        }

        public ExpressionContainerPair(ExpressionContainer leftPart, ExpressionContainer rightPart)
        {
            LeftPart = leftPart ?? throw new ArgumentNullException($"{nameof(leftPart)} is required.");
            RightPart = rightPart ?? throw new ArgumentNullException($"{nameof(rightPart)} is required.");
        }

        public ExpressionContainerPair(ExpressionContainer leftPart, ExpressionMediator rightPart)
        {
            LeftPart = leftPart ?? throw new ArgumentNullException($"{nameof(leftPart)} is required.");
            RightPart = new ExpressionContainer(rightPart ?? throw new ArgumentNullException($"{nameof(rightPart)} is required."));
        }

        public ExpressionContainerPair(ExpressionMediator leftPart, ExpressionContainer rightPart)
        {
            LeftPart = new ExpressionContainer(leftPart ?? throw new ArgumentNullException($"{nameof(leftPart)} is required."));
            RightPart = rightPart ?? throw new ArgumentNullException($"{nameof(rightPart)} is required.");
        }
    }
}

using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class AssignmentExpression : 
        IDbExpression
    {
        #region interface
        public ExpressionContainerPair Expression { get; private set; }
        #endregion

        #region constructors
        internal AssignmentExpression(ExpressionContainer assignee, ExpressionContainer assignment)
        {
            Expression = new ExpressionContainerPair(assignee ?? throw new ArgumentNullException($"{nameof(assignee)} is required."), assignment ?? throw new ArgumentNullException($"{nameof(assignment)} is required."));
        }
        #endregion

        #region to string
        public override string ToString() => $"{Expression.LeftPart} = {Expression.RightPart}";
        #endregion

        #region implicit assignment expression set operator
        public static implicit operator AssignmentExpressionSet(AssignmentExpression a) => new AssignmentExpressionSet(a);
        #endregion
    }
    
}

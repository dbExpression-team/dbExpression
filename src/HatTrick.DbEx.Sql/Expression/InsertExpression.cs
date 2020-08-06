using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class InsertExpression :
        IDbExpression,
        IDbAssignmentExpressionProvider
    {
        #region internals
        private readonly FieldExpression assignee;
        private readonly ExpressionMediator assignment;
        #endregion

        #region interface
        FieldExpression IDbAssignmentExpressionProvider.Assignee => assignee;
        ExpressionMediator IDbAssignmentExpressionProvider.Assignment => assignment;
        #endregion

        #region constructors
        public InsertExpression(FieldExpression field, ExpressionMediator assignment)
        {
            assignee = field ?? throw new ArgumentNullException($"{nameof(field)} is required.");
            this.assignment = assignment ?? throw new ArgumentNullException($"{nameof(assignment)} is required.");
        }
        #endregion
    }    
}

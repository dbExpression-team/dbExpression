using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class InsertExpression :
        IExpression,
        IAssignmentExpressionProvider
    {
        #region internals
        private readonly FieldExpression assignee;
        private readonly IExpressionElement assignment;
        #endregion

        #region interface
        FieldExpression IAssignmentExpressionProvider.Assignee => assignee;
        IExpressionElement IAssignmentExpressionProvider.Assignment => assignment;
        #endregion

        #region constructors
        public InsertExpression(FieldExpression field, IExpressionElement assignment)
        {
            assignee = field ?? throw new ArgumentNullException($"{nameof(field)} is required.");
            this.assignment = assignment ?? throw new ArgumentNullException($"{nameof(assignment)} is required.");
        }
        #endregion
    }    
}

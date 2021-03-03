using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class InsertExpression :
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
        protected InsertExpression(FieldExpression field, IExpressionElement assignment)
        {
            this.assignee = field ?? throw new ArgumentNullException(nameof(field));
            this.assignment = assignment ?? throw new ArgumentNullException(nameof(assignment));
        }
        #endregion
    }
}

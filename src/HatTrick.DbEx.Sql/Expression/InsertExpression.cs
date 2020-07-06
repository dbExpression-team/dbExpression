using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class InsertExpression :
        IDbExpression,
        IDbInsertExpressionProvider
    {
        #region internals
        public FieldExpression assignee;
        public ExpressionMediator assignment;
        #endregion

        #region interface
        FieldExpression IDbInsertExpressionProvider.Assignee => assignee;
        ExpressionMediator IDbInsertExpressionProvider.Assignment => assignment;
        #endregion

        #region constructors
        public InsertExpression(FieldExpression field, ExpressionMediator assignment)
        {
            assignee = field ?? throw new ArgumentNullException($"{nameof(field)} is required.");
            this.assignment = assignment ?? throw new ArgumentNullException($"{nameof(assignment)} is required.");
        }
        #endregion

        #region logical & operator
        public static InsertExpressionSet operator &(InsertExpression a, InsertExpression b) => new InsertExpressionSet(a, b);
        #endregion

        #region implicit insert expression set operator
        public static implicit operator InsertExpressionSet(InsertExpression a) => new InsertExpressionSet(a);
        #endregion
    }    
}

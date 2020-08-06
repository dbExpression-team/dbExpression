using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class GroupByExpression : 
        IExpression
    {
        #region interface
        public ExpressionMediator Expression { get; private set; }
        #endregion

        #region constructors
        public GroupByExpression(ExpressionMediator expression)
        {
            Expression = expression ?? throw new ArgumentNullException($"{nameof(expression)} is required.");
        }
        #endregion

        #region to string
        public override string ToString() => Expression.ToString();
        #endregion

        #region conditional & operator
        public static GroupByExpressionSet operator &(GroupByExpression a, GroupByExpression b) => new GroupByExpressionSet(a, b);
        #endregion

        #region implicit group by expression set operator
        public static implicit operator GroupByExpressionSet(GroupByExpression a) => new GroupByExpressionSet(a);
        #endregion
    }
    
}

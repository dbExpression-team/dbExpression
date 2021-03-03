using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class GroupByExpression :
        AnyGroupByClause
    {
        #region interface
        public IExpressionElement Expression { get; private set; }
        #endregion

        #region constructors
        public GroupByExpression(IExpressionElement expression)
        {
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
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

using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class GroupByExpression : 
        IDbExpression,
        IAssemblyPart
    {
        #region interface
        public ExpressionContainer Expression { get; private set; }
        #endregion

        #region constructors
        public GroupByExpression(ExpressionContainer expression)
        {
            Expression = expression ?? throw new ArgumentNullException($"{nameof(expression)} is required.");
        }
        #endregion

        #region to string
        public override string ToString() => Expression.Object.ToString();
        #endregion

        #region conditional & operator
        public static GroupByExpressionSet operator &(GroupByExpression a, GroupByExpression b) => new GroupByExpressionSet(a, b);
        #endregion

        #region implicit group by expression set operator
        public static implicit operator GroupByExpressionSet(GroupByExpression a) => new GroupByExpressionSet(a);
        #endregion
    }
    
}

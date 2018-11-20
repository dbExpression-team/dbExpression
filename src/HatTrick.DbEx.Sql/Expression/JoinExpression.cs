using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class JoinExpression : DbExpression, IAssemblyPart
    {
        #region interface
        public JoinOnExpression JoinOnExpression { get; private set; }
        public (Type,object) JoinToo { get; private set; }
        public JoinOperationExpressionOperator JoinType { get; private set; }
        #endregion

        #region constructors
        public JoinExpression(EntityExpression entity, JoinOperationExpressionOperator joinType, JoinOnExpression onCondition)
        {
            JoinToo = (typeof(EntityExpression), entity);
            JoinType = joinType;
            JoinOnExpression = onCondition;
        }

        public JoinExpression(ExpressionSet subquery, JoinOperationExpressionOperator joinType, JoinOnExpression onCondition)
        {
            JoinToo = (typeof(ExpressionSet), subquery);
            JoinType = joinType;
            JoinOnExpression = onCondition;
        }

        public JoinExpression((Type,object) joinToo, JoinOperationExpressionOperator joinType, JoinOnExpression onCondition)
        {
            JoinToo = joinToo;
            JoinType = joinType;
            JoinOnExpression = onCondition;
        }
        #endregion

        #region to string
        public override string ToString() => JoinType == JoinOperationExpressionOperator.CROSS ? $"{JoinType} JOIN {JoinToo.Item2}" : $"{JoinType} JOIN {JoinToo.Item2} ON {JoinOnExpression}";
        #endregion

        #region logical & operator
        public static JoinExpressionSet operator &(JoinExpression a, JoinExpression b)
        {
            if (a == null && b != null) { return new JoinExpressionSet(b); }
            if (a != null && b == null) { return new JoinExpressionSet(a); }
            if (a == null && b == null) { return null; }

            return new JoinExpressionSet(a, b);
        }
        #endregion
    }
    
}

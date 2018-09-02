using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class JoinExpression : DbExpression
    {
        #region interface
        public (Type,object) Expression { get; private set; }
        public EntityExpression Entity { get; private set; }
        public JoinOperationExpressionOperator JoinType { get; private set; }
        #endregion

        #region constructors
        public JoinExpression(EntityExpression entity, JoinOperationExpressionOperator joinType, JoinOnExpression onCondition)
        {
            Entity = entity;
            JoinType = joinType;
            Expression = (typeof(JoinOnExpression), onCondition);
        }
        #endregion

        #region to string
        public override string ToString() => JoinType == JoinOperationExpressionOperator.CROSS ? $"{JoinType} JOIN {Entity}" : $"{JoinType} JOIN {Entity} ON {Expression.Item2}";
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

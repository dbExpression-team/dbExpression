using System;

namespace HTL.DbEx.Sql.Expression
{
    public class DBJoinExpression : DBExpression
    {
        #region interface
        public (Type,object) Expression { get; private set; }
        public DBExpressionEntity Entity { get; private set; }
        public DBExpressionJoinType JoinType { get; private set; }
        #endregion

        #region constructors
        public DBJoinExpression(DBExpressionEntity entity, DBExpressionJoinType joinType, DBJoinOnExpression onCondition)
        {
            Entity = entity;
            JoinType = joinType;
            Expression = (typeof(DBJoinOnExpression), onCondition);
        }
        #endregion

        #region to string
        public override string ToString() => JoinType == DBExpressionJoinType.CROSS ? $"{JoinType} JOIN {Entity}" : $"{JoinType} JOIN {Entity} ON {Expression.Item2}";
        #endregion

        #region logical & operator
        public static DBJoinExpressionSet operator &(DBJoinExpression a, DBJoinExpression b)
        {
            if (a == null && b != null) { return new DBJoinExpressionSet(b); }
            if (a != null && b == null) { return new DBJoinExpressionSet(a); }
            if (a == null && b == null) { return null; }

            return new DBJoinExpressionSet(a, b);
        }
        #endregion
    }
    
}

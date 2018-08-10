using System;

namespace HTL.DbEx.Sql.Expression
{
    public class DBOrderByExpression : DBExpression
    {
        #region interface
        public (Type,object) Expression { get; private set; }
        public DBOrderExpressionDirection Direction { get; private set; }
        #endregion

        #region constructors
        internal DBOrderByExpression(DBExpressionField field, DBOrderExpressionDirection direction)
        {
            Expression = (typeof(DBExpressionField),field);
            Direction = direction;
        }

        internal DBOrderByExpression(DBExpression expression, DBOrderExpressionDirection direction)
        {
            Expression = (typeof(DBExpression), expression);
            Direction = direction;
        }
        #endregion

        #region to string
        public override string ToString() => $"{Expression.Item2} {Direction}";
        #endregion

        #region conditional & operator
        public static DBOrderByExpressionSet operator &(DBOrderByExpression a, DBOrderByExpression b) => new DBOrderByExpressionSet(a, b);
        #endregion

        #region implicit order by expression set operator
        public static implicit operator DBOrderByExpressionSet(DBOrderByExpression a) => new DBOrderByExpressionSet(a);
        #endregion
    }
    
}

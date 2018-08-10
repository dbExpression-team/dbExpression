using System;

namespace HTL.DbEx.Sql.Expression
{
    public class DBGroupByExpression : DBExpression
    {
        #region internals
        public (Type,object) Expression { get; private set; }
        #endregion

        #region constructors
        internal DBGroupByExpression(DBExpressionField field)
        {
            Expression = (typeof(DBExpressionField),field);
        }

        internal DBGroupByExpression(DBSelectExpression expression)
        {
            Expression = (typeof(DBSelectExpression), expression);
        }
        #endregion

        #region to string
        public override string ToString() => Expression.Item2.ToString();
        #endregion

        #region conditional & operator
        public static DBGroupByExpressionSet operator &(DBGroupByExpression a, DBGroupByExpression b) => new DBGroupByExpressionSet(a, b);
        #endregion

        #region implicit group by expression set operator
        public static implicit operator DBGroupByExpressionSet(DBGroupByExpression a) => new DBGroupByExpressionSet(a);
        #endregion
    }
    
}

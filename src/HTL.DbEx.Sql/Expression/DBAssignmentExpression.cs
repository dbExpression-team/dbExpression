using System;

namespace HTL.DbEx.Sql.Expression
{
    public class DBAssignmentExpression : DBExpression
    {
        #region interface
        public (Type,object) Expression { get; private set; }
        public (Type, object) Value => ((DBExpressionPartPair)Expression.Item2).RightPart;
        #endregion

        #region constructors
        internal DBAssignmentExpression(DBExpressionField field, object value)
        {
            Expression = (typeof(DBExpressionPartPair), new DBExpressionPartPair((typeof(DBExpressionField), field), (value.GetType(), value)));
        }
        #endregion

        #region to string
        public override string ToString() => $"{Expression.Item2} = {Value.Item2}";
        #endregion
        
        #region logical & operator
        public static DBAssignmentExpressionSet operator &(DBAssignmentExpression a, DBAssignmentExpression b) => new DBAssignmentExpressionSet(a, b);
        #endregion

        #region implicit assignment expression set operator
        public static implicit operator DBAssignmentExpressionSet(DBAssignmentExpression a) => new DBAssignmentExpressionSet(a);
        #endregion
    }
    
}

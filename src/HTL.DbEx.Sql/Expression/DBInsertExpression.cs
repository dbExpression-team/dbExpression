using System;

namespace HTL.DbEx.Sql.Expression
{
    public class DBInsertExpression : DBExpression
    {
        #region internals
        public readonly DBExpressionField _field;
        public readonly object _value;
        public readonly Type _type;
        #endregion

        #region constructors
        public DBInsertExpression(DBExpressionField field, object value, Type type)
        {
            _field = field;
            _value = value;
            _type = type;
        }
        #endregion

        #region logical & operator
        public static DBInsertExpressionSet operator &(DBInsertExpression a, DBInsertExpression b) => new DBInsertExpressionSet(a, b);
        #endregion

        #region implicit insert expression set operator
        public static implicit operator DBInsertExpressionSet(DBInsertExpression a) => new DBInsertExpressionSet(a);
        #endregion
    }    
}

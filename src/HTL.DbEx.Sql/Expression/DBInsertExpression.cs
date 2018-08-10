using System;

namespace HTL.DbEx.Sql.Expression
{
    public class DBInsertExpression : DBExpression, IDBExpression
    {
        #region internals
        public readonly (Type, object) Part;
        public readonly (Type, object) PartValue;
        #endregion

        #region constructors
        public DBInsertExpression(DBExpressionField field, object value, Type type)
        {
            Part = (typeof(DBExpressionField), field);
            PartValue = (type, value);
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

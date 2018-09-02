using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class InsertExpression : DbExpression
    {
        #region internals
        public readonly (Type, object) Part;
        public readonly (Type, object) PartValue;
        #endregion

        #region constructors
        public InsertExpression(FieldExpression field, object value, Type type)
        {
            Part = (typeof(FieldExpression), field);
            PartValue = (type, value);
        }
        #endregion

        #region logical & operator
        public static InsertExpressionSet operator &(InsertExpression a, InsertExpression b) => new InsertExpressionSet(a, b);
        #endregion

        #region implicit insert expression set operator
        public static implicit operator InsertExpressionSet(InsertExpression a) => new InsertExpressionSet(a);
        #endregion
    }    
}

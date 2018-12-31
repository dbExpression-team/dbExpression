using System;
using System.Data;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class FieldExpression<T> :
        FieldExpression,
        IDbExpressionColumnExpression<T>
    {
        #region constructors
        public FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata) : base(entity, metadata)
        {
        }

        protected FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, string alias) : base(entity, metadata, alias)
        {
        }
        #endregion

        #region as
        public virtual FieldExpression<T> As(string alias) => new FieldExpression<T>(base.Entity, base.Metadata, alias);
        #endregion

        #region in value set
        public FilterExpression In(params T[] value) => value != null ? new FilterExpression(this, value, FilterExpressionOperator.In) : null;
        #endregion

        #region set value
        public AssignmentExpression Set(T value) => new AssignmentExpression(this, value);
        #endregion

        public static implicit operator SelectExpression(FieldExpression<T> field) => new SelectExpression(field);


        #region set field
        public AssignmentExpression Set(FieldExpression<T> field) => new AssignmentExpression(this, field);
        #endregion

        #region insert value
        public InsertExpression Insert(T value) => new InsertExpression(this, value, typeof(T));
        #endregion

        #region field to value relational operators
        public static FilterExpression operator ==(FieldExpression<T> field, T value) => new FilterExpression(field, value, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(FieldExpression<T> field, T value) => new FilterExpression(field, value, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(FieldExpression<T> field, T value) => new FilterExpression(field, value, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(FieldExpression<T> field, T value) => new FilterExpression(field, value, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(FieldExpression<T> field, T value) => new FilterExpression(field, value, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(FieldExpression<T> field, T value) => new FilterExpression(field, value, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region field to field relational operators
        public static FilterExpression operator ==(FieldExpression<T> a, FieldExpression b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(FieldExpression<T> a, FieldExpression b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(FieldExpression<T> a, FieldExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(FieldExpression<T> a, FieldExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(FieldExpression<T> a, FieldExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(FieldExpression<T> a, FieldExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region field to value arithmetic operators
        public static ArithmeticExpression<T> operator +(FieldExpression<T> a, T b) => new ArithmeticExpression<T>(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression<T> operator -(FieldExpression<T> a, T b) => new ArithmeticExpression<T>(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression<T> operator *(FieldExpression<T> a, T b) => new ArithmeticExpression<T>(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression<T> operator /(FieldExpression<T> a, T b) => new ArithmeticExpression<T>(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression<T> operator %(FieldExpression<T> a, T b) => new ArithmeticExpression<T>(a, b, ArithmeticExpressionOperator.Modulo);
        #endregion

        #region field to field arithmetic operators
        public static ArithmeticExpression<T> operator +(FieldExpression<T> a, FieldExpression<T> b) => new ArithmeticExpression<T>(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression<T> operator -(FieldExpression a, FieldExpression<T> b) => new ArithmeticExpression<T>(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression<T> operator *(FieldExpression a, FieldExpression<T> b) => new ArithmeticExpression<T>(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression<T> operator /(FieldExpression a, FieldExpression<T> b) => new ArithmeticExpression<T>(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression<T> operator %(FieldExpression a, FieldExpression<T> b) => new ArithmeticExpression<T>(a, b, ArithmeticExpressionOperator.Modulo);

        public static ArithmeticExpression<T> operator +(ArithmeticExpression<T> a, FieldExpression<T> b) => new ArithmeticExpression<T>(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression<T> operator -(ArithmeticExpression a, FieldExpression<T> b) => new ArithmeticExpression<T>(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression<T> operator *(ArithmeticExpression a, FieldExpression<T> b) => new ArithmeticExpression<T>(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression<T> operator /(ArithmeticExpression a, FieldExpression<T> b) => new ArithmeticExpression<T>(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression<T> operator %(ArithmeticExpression a, FieldExpression<T> b) => new ArithmeticExpression<T>(a, b, ArithmeticExpressionOperator.Modulo);
        #endregion

        #region equals
        public override bool Equals(object obj) => base.Equals(obj);
        #endregion

        #region override get hash code
        public override int GetHashCode() => base.GetHashCode();
        #endregion
    }

}

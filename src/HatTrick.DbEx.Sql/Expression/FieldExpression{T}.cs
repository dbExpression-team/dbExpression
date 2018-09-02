using System;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class FieldExpression<T> : FieldExpression
    {
        #region constructors
        public FieldExpression(EntityExpression parentEntity, string name) : base(parentEntity, name)
        {
        }

        public FieldExpression(EntityExpression parentEntity, string name, int size) : base(parentEntity, name, size)
        {
        }
        #endregion

        #region in value set
        public FilterExpression In(params T[] value) => value != null ? new FilterExpression(this, value, FilterExpressionOperator.In) : null;
        #endregion

        #region set value
        public AssignmentExpression Set(T value) => new AssignmentExpression(this, value);
        #endregion

        #region set field
        public AssignmentExpression Set(FieldExpression<T> field) => new AssignmentExpression(this, field);
        #endregion

        #region insert (init) value
        public InsertExpression Insert(T value) => new InsertExpression(this, value, typeof(T));
        #endregion

        #region implicit select operator
        public static implicit operator SelectExpression(FieldExpression<T> field) => new SelectExpression(field);
        #endregion

        #region implicit group by expression operator
        public static implicit operator GroupByExpression(FieldExpression<T> a) => new GroupByExpression(a);
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
        public static ArithmeticExpression operator +(FieldExpression<T> a, T b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator -(FieldExpression<T> a, T b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression operator *(FieldExpression<T> a, T b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression operator /(FieldExpression<T> a, T b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression operator %(FieldExpression<T> a, T b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo);
        #endregion

        #region field to field arithmetic operators
        public static ArithmeticExpression operator +(ArithmeticExpression a, FieldExpression<T> b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator -(ArithmeticExpression a, FieldExpression<T> b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression operator *(ArithmeticExpression a, FieldExpression<T> b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression operator /(ArithmeticExpression a, FieldExpression<T> b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression operator %(ArithmeticExpression a, FieldExpression<T> b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo);
        #endregion

        #region equals
        public override bool Equals(object obj) => base.Equals(obj);
        #endregion

        #region override get hash code
        public override int GetHashCode() => base.GetHashCode();
        #endregion
    }

}

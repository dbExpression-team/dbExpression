using System;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class FieldExpression<TEntity, TValue> :
        FieldExpression,
        ISupportedForSelectFieldExpression<TValue>
        where TEntity : IDbEntity
    {
        public virtual Lazy<Action<TEntity, TValue>> Mapper { get; private set; }

        #region constructors
        protected FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<TEntity, TValue>> map) : this(entity, metadata, map, null)
        {
        }

        protected FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<TEntity, TValue>> mapExpression, string alias) : base(entity, metadata, alias)
        {
            Mapper = new Lazy<Action<TEntity, TValue>>(() =>
            {
                var propertyInfo = (mapExpression.Body as MemberExpression)?.Member as PropertyInfo;
                if (propertyInfo == null)
                    throw new ArgumentException($"Property expression '{nameof(mapExpression)}' does not refer to a public property.");
                return (obj, value) => propertyInfo.SetValue(obj, value);
            });
        }

        protected FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, string alias) : base(entity, metadata, alias)
        {
        }

        protected FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<TEntity, TValue>> mapExpression, string alias) : base(entity, metadata, alias)
        {
            Mapper = mapExpression;
        }
        #endregion

        #region map
        public override void Map(object instance, object value)
            => Map((TEntity)instance, (TValue)value);

        public virtual void Map(TEntity instance, TValue value)
        {
            Mapper.Value(instance, value);
        }
        #endregion

        #region in value set
        public FilterExpression In(params TValue[] value) => value != null ? new FilterExpression(this, value, FilterExpressionOperator.In) : null;
        #endregion

        #region set value
        public AssignmentExpression Set(TValue value) => new AssignmentExpression(this, value);
        #endregion

        #region set field
        public AssignmentExpression Set(FieldExpression<TEntity, TValue> field) => new AssignmentExpression(this, field);
        #endregion

        #region insert value
        public InsertExpression Insert(TValue value) => new InsertExpression(this, value, typeof(TValue));
        #endregion

        #region field to value relational operators
        public static FilterExpression operator ==(FieldExpression<TEntity, TValue> field, TValue value) => new FilterExpression(field, value, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(FieldExpression<TEntity, TValue> field, TValue value) => new FilterExpression(field, value, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(FieldExpression<TEntity, TValue> field, TValue value) => new FilterExpression(field, value, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(FieldExpression<TEntity, TValue> field, TValue value) => new FilterExpression(field, value, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(FieldExpression<TEntity, TValue> field, TValue value) => new FilterExpression(field, value, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(FieldExpression<TEntity, TValue> field, TValue value) => new FilterExpression(field, value, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region field to field relational operators
        public static FilterExpression operator ==(FieldExpression<TEntity, TValue> a, FieldExpression b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(FieldExpression<TEntity, TValue> a, FieldExpression b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(FieldExpression<TEntity, TValue> a, FieldExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(FieldExpression<TEntity, TValue> a, FieldExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(FieldExpression<TEntity, TValue> a, FieldExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(FieldExpression<TEntity, TValue> a, FieldExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region field to value arithmetic operators
        public static ArithmeticExpression<TValue> operator +(FieldExpression<TEntity, TValue> a, TValue b) => new ArithmeticExpression<TValue>(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression<TValue> operator -(FieldExpression<TEntity, TValue> a, TValue b) => new ArithmeticExpression<TValue>(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression<TValue> operator *(FieldExpression<TEntity, TValue> a, TValue b) => new ArithmeticExpression<TValue>(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression<TValue> operator /(FieldExpression<TEntity, TValue> a, TValue b) => new ArithmeticExpression<TValue>(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression<TValue> operator %(FieldExpression<TEntity, TValue> a, TValue b) => new ArithmeticExpression<TValue>(a, b, ArithmeticExpressionOperator.Modulo);
        #endregion

        #region field to field arithmetic operators
        public static ArithmeticExpression<TValue> operator +(FieldExpression<TEntity, TValue> a, FieldExpression<TEntity, TValue> b) => new ArithmeticExpression<TValue>(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression<TValue> operator -(FieldExpression a, FieldExpression<TEntity, TValue> b) => new ArithmeticExpression<TValue>(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression<TValue> operator *(FieldExpression a, FieldExpression<TEntity, TValue> b) => new ArithmeticExpression<TValue>(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression<TValue> operator /(FieldExpression a, FieldExpression<TEntity, TValue> b) => new ArithmeticExpression<TValue>(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression<TValue> operator %(FieldExpression a, FieldExpression<TEntity, TValue> b) => new ArithmeticExpression<TValue>(a, b, ArithmeticExpressionOperator.Modulo);

        public static ArithmeticExpression<TValue> operator +(ArithmeticExpression<TValue> a, FieldExpression<TEntity, TValue> b) => new ArithmeticExpression<TValue>(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression<TValue> operator -(ArithmeticExpression a, FieldExpression<TEntity, TValue> b) => new ArithmeticExpression<TValue>(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression<TValue> operator *(ArithmeticExpression a, FieldExpression<TEntity, TValue> b) => new ArithmeticExpression<TValue>(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression<TValue> operator /(ArithmeticExpression a, FieldExpression<TEntity, TValue> b) => new ArithmeticExpression<TValue>(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression<TValue> operator %(ArithmeticExpression a, FieldExpression<TEntity, TValue> b) => new ArithmeticExpression<TValue>(a, b, ArithmeticExpressionOperator.Modulo);
        #endregion

        #region equals
        public override bool Equals(object obj) => base.Equals(obj);
        #endregion

        #region override get hash code
        public override int GetHashCode() => base.GetHashCode();
        #endregion
    }

}

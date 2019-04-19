using System;
using System.Linq.Expressions;
using System.Reflection;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class NullableFieldExpression<TEntity, TValue> : FieldExpression<TEntity, TValue>
        where TEntity : IDbEntity
        where TValue : struct, IComparable
    {
        public new Lazy<Action<TEntity, TValue?>> Mapper { get; set; }

        #region constructors
        protected NullableFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<TEntity, TValue?>> mapExpression) : base(entity, metadata, (Expression<Func<TEntity, TValue>>)null, null)
        {
            Mapper = new Lazy<Action<TEntity, TValue?>>(() =>
            {
                var propertyInfo = (mapExpression.Body as MemberExpression)?.Member as PropertyInfo;
                if (propertyInfo == null)
                    throw new ArgumentException($"Property expression '{nameof(mapExpression)}' does not refer to a public property.");
                return (obj, value) => propertyInfo.SetValue(obj, value);
            });
        }

        protected NullableFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<TEntity, TValue?>> mapExpression, string alias) : base(entity, metadata, alias)
        {
            Mapper = mapExpression;
        }
        #endregion

        #region set value
        public AssignmentExpression Set(TValue? value) => new AssignmentExpression(this, value);
        #endregion

        #region insert value
        public InsertExpression Insert(TValue? value) => new InsertExpression(this, value, typeof(TValue));
        #endregion

        #region field to value relational operators
        public static FilterExpression operator ==(NullableFieldExpression<TEntity, TValue> field, TValue? value) => new FilterExpression(field, value, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableFieldExpression<TEntity, TValue> field, TValue? value) => new FilterExpression(field, value, FilterExpressionOperator.NotEqual);
        #endregion

        #region equals
        public override bool Equals(object obj) => base.Equals(obj);
        #endregion

        #region override get hash code
        public override int GetHashCode() => base.GetHashCode();
        #endregion
    }
}

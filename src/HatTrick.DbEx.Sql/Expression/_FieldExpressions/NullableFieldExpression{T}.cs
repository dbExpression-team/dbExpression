using System;
using System.Linq.Expressions;
using System.Reflection;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class NullableFieldExpression<TValue> : FieldExpression<TValue>

        where TValue : struct, IComparable
    {
        public new Lazy<Action<IDbEntity, TValue?>> Mapper { get; set; }

        #region constructors
        protected NullableFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, TValue?>> mapExpression) : base(entity, metadata, (Expression<Func<IDbEntity, TValue>>)null, null)
        {
            Mapper = new Lazy<Action<IDbEntity, TValue?>>(() =>
            {
                var propertyInfo = (mapExpression.Body as MemberExpression)?.Member as PropertyInfo;
                if (propertyInfo == null)
                    throw new ArgumentException($"Property expression '{nameof(mapExpression)}' does not refer to a public property.");
                return (obj, value) => propertyInfo.SetValue(obj, value);
            });
        }

        protected NullableFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, TValue?>> mapExpression, string alias) : base(entity, metadata, alias)
        {
            Mapper = mapExpression;
        }
        #endregion

        public FilterExpression<TValue?> IsNull() => new FilterExpression<TValue?>(this, DBNull.Value, FilterExpressionOperator.Equal);
        public FilterExpression<TValue> IsNotNull() => new FilterExpression<TValue>(this, DBNull.Value, FilterExpressionOperator.NotEqual);

        #region set value
        public AssignmentExpression Set(TValue? value) => new AssignmentExpression(this, value);
        #endregion

        #region insert value
        public InsertExpression Insert(TValue? value) => new InsertExpression(this, value, typeof(TValue?));
        #endregion

        #region equals
        public override bool Equals(object obj) => base.Equals(obj);
        #endregion

        #region override get hash code
        public override int GetHashCode() => base.GetHashCode();
        #endregion

        public static implicit operator ExpressionMediator<TValue?>(NullableFieldExpression<TValue> average) => new ExpressionMediator<TValue?>((average.GetType(), average));
    }
}

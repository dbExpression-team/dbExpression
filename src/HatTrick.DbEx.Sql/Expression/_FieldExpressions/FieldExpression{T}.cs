using System;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class FieldExpression<TValue> :
        FieldExpression
    {
        public virtual Lazy<Action<IDbEntity, TValue>> Mapper { get; private set; }

        #region constructors
        protected FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, TValue>> map) : this(entity, metadata, map, null)
        {
        }

        protected FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, TValue>> mapExpression, string alias) : base(entity, metadata, alias)
        {
            Mapper = new Lazy<Action<IDbEntity, TValue>>(() =>
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

        protected FieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, TValue>> mapExpression, string alias) : base(entity, metadata, alias)
        {
            Mapper = mapExpression;
        }
        #endregion

        #region map
        public override void Map(object instance, object value)
            => Map((IDbEntity)instance, (TValue)value);

        public virtual void Map(IDbEntity instance, TValue value)
        {
            Mapper.Value(instance, value);
        }
        #endregion

        #region in value set
        public FilterExpression In(params TValue[] value) => value != null ? new FilterExpression<TValue>(this, new LiteralExpression<TValue[]>(value), FilterExpressionOperator.In) : null;
        #endregion

        #region set value
        public AssignmentExpression Set(TValue value) => new AssignmentExpression(this, value);
        #endregion

        #region set field
        public AssignmentExpression Set(FieldExpression<TValue> field) => new AssignmentExpression(this, field);
        #endregion

        #region insert value
        public InsertExpression Insert(TValue value) => new InsertExpression(this, value, typeof(TValue));
        #endregion

        #region equals
        public override bool Equals(object obj) => base.Equals(obj);
        #endregion

        #region override get hash code
        public override int GetHashCode() => base.GetHashCode();
        #endregion

        #region implicit operators
        public static implicit operator ExpressionMediator<TValue>(FieldExpression<TValue> field) => new ExpressionMediator<TValue>((field.GetType(), field));
        #endregion
    }
}

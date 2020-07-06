using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class EnumFieldExpression<TEntity, TEnum> : EnumFieldExpression<TEnum>,
        IEquatable<EnumFieldExpression<TEntity, TEnum>>
        where TEntity : IDbEntity
        where TEnum : struct, Enum, IComparable
    {
        #region constructors
        public EnumFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(identifier, entity, metadata)
        {
        }

        protected EnumFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(identifier, entity, metadata, alias)
        {

        }
        #endregion

        #region as
        public new EnumFieldExpression<TEntity, TEnum> As(string alias) 
            => new EnumFieldExpression<TEntity,TEnum>(base.Identifier, base.Entity, base.MetadataResolver, alias);
        #endregion

        #region in value set
        public override FilterExpression In(params TEnum[] value) => value != null ? new FilterExpression<TEnum>(new EnumExpressionMediator<TEnum>(this), new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum[]>(value)), FilterExpressionOperator.In) : null;
        #endregion

        #region set
        public override AssignmentExpression Set(TEnum value) => new AssignmentExpression(new EnumExpressionMediator<TEnum>(this), new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(value)));
        public override AssignmentExpression Set(ExpressionMediator<TEnum> value) => new AssignmentExpression(new EnumExpressionMediator<TEnum>(this), value);
        #endregion

        #region insert
        public override InsertExpression Insert(TEnum value) => new InsertExpression(this, new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(value)));
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new EnumExpressionMediator<TEnum>(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new EnumExpressionMediator<TEnum>(this), OrderExpressionDirection.DESC);
        #endregion

        #region equals
        public bool Equals(EnumFieldExpression<TEntity, TEnum> obj)
            => obj is EnumFieldExpression<TEntity, TEnum> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is EnumFieldExpression<TEntity, TEnum> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit operators
        public static implicit operator EnumExpressionMediator<TEnum>(EnumFieldExpression<TEntity, TEnum> a) => new EnumExpressionMediator<TEnum>(a);
        public static implicit operator SelectExpression<long>(EnumFieldExpression<TEntity, TEnum> a) => new SelectExpression<long>(new EnumExpressionMediator<TEnum>(a));
        public static implicit operator OrderByExpression(EnumFieldExpression<TEntity, TEnum> a) => new OrderByExpression(new EnumExpressionMediator<TEnum>(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(EnumFieldExpression<TEntity, TEnum> a) => new GroupByExpression(new EnumExpressionMediator<TEnum>(a));
        #endregion

        #region filter operators
        #region TEnum
        public static FilterExpression<TEnum> operator ==(EnumFieldExpression<TEntity, TEnum> a, TEnum b) => new FilterExpression<TEnum>(new EnumExpressionMediator<TEnum>(a), new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum> operator !=(EnumFieldExpression<TEntity, TEnum> a, TEnum b) => new FilterExpression<TEnum>(new EnumExpressionMediator<TEnum>(a), new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(b)), FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum> operator ==(TEnum a, EnumFieldExpression<TEntity, TEnum> b) => new FilterExpression<TEnum>(new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(a)), new EnumExpressionMediator<TEnum>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum> operator !=(TEnum a, EnumFieldExpression<TEntity, TEnum> b) => new FilterExpression<TEnum>(new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(a)), new EnumExpressionMediator<TEnum>(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum?> operator ==(EnumFieldExpression<TEntity, TEnum> a, TEnum? b) => new FilterExpression<TEnum?>(new EnumExpressionMediator<TEnum>(a), new NullableEnumExpressionMediator<TEnum>(new LiteralExpression<TEnum?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum?> operator !=(EnumFieldExpression<TEntity, TEnum> a, TEnum? b) => new FilterExpression<TEnum?>(new EnumExpressionMediator<TEnum>(a), new NullableEnumExpressionMediator<TEnum>(new LiteralExpression<TEnum?>(b)), FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum?> operator ==(TEnum? a, EnumFieldExpression<TEntity, TEnum> b) => new FilterExpression<TEnum?>(new NullableEnumExpressionMediator<TEnum>(new LiteralExpression<TEnum?>(a)), new EnumExpressionMediator<TEnum>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum?> operator !=(TEnum? a, EnumFieldExpression<TEntity, TEnum> b) => new FilterExpression<TEnum?>(new NullableEnumExpressionMediator<TEnum>(new LiteralExpression<TEnum?>(a)), new EnumExpressionMediator<TEnum>(b), FilterExpressionOperator.NotEqual);
        #endregion

        #region mediator
        public static FilterExpression<TEnum> operator ==(EnumFieldExpression<TEntity, TEnum> a, EnumExpressionMediator<TEnum> b) => new FilterExpression<TEnum>(new EnumExpressionMediator<TEnum>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum> operator !=(EnumFieldExpression<TEntity, TEnum> a, EnumExpressionMediator<TEnum> b) => new FilterExpression<TEnum>(new EnumExpressionMediator<TEnum>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum?> operator ==(EnumFieldExpression<TEntity, TEnum> a, NullableEnumExpressionMediator<TEnum> b) => new FilterExpression<TEnum?>(new EnumExpressionMediator<TEnum>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum?> operator !=(EnumFieldExpression<TEntity, TEnum> a, NullableEnumExpressionMediator<TEnum> b) => new FilterExpression<TEnum?>(new EnumExpressionMediator<TEnum>(a), b, FilterExpressionOperator.NotEqual);
        #endregion
        #endregion
    }
}

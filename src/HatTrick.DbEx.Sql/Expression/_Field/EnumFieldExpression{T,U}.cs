using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public class EnumFieldExpression<TEntity, TEnum> : EnumFieldExpression<TEnum>,
        IEquatable<EnumFieldExpression<TEntity, TEnum>>
        where TEntity : IDbEntity
        where TEnum : struct, Enum, IComparable
    {
        #region constructors
        public EnumFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {
        }

        protected EnumFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {

        }
        #endregion

        #region as
        public new EnumFieldExpression<TEntity, TEnum> As(string alias) 
            => new EnumFieldExpression<TEntity,TEnum>(base.Entity, base.MetadataResolver, alias);
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
        public static implicit operator EnumExpressionMediator<TEnum>(EnumFieldExpression<TEntity, TEnum> a) => new EnumExpressionMediator<TEnum>(new ExpressionContainer(a));
        public static implicit operator SelectExpression<long>(EnumFieldExpression<TEntity, TEnum> a) => new SelectExpression<long>(new ExpressionContainer(a));
        public static implicit operator OrderByExpression(EnumFieldExpression<TEntity, TEnum> a) => new OrderByExpression(new ExpressionContainer(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(EnumFieldExpression<TEntity, TEnum> a) => new GroupByExpression(new ExpressionContainer(a));
        #endregion

        #region filter operators
        #region TEnum
        public static FilterExpression<TEnum> operator ==(EnumFieldExpression<TEntity, TEnum> a, TEnum b) => new FilterExpression<TEnum>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<TEnum>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum> operator !=(EnumFieldExpression<TEntity, TEnum> a, TEnum b) => new FilterExpression<TEnum>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<TEnum>(b)), FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum> operator ==(TEnum a, EnumFieldExpression<TEntity, TEnum> b) => new FilterExpression<TEnum>(new ExpressionContainer(new LiteralExpression<TEnum>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum> operator !=(TEnum a, EnumFieldExpression<TEntity, TEnum> b) => new FilterExpression<TEnum>(new ExpressionContainer(new LiteralExpression<TEnum>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum?> operator ==(EnumFieldExpression<TEntity, TEnum> a, TEnum? b) => new FilterExpression<TEnum?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<TEnum?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum?> operator !=(EnumFieldExpression<TEntity, TEnum> a, TEnum? b) => new FilterExpression<TEnum?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<TEnum?>(b)), FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum?> operator ==(TEnum? a, EnumFieldExpression<TEntity, TEnum> b) => new FilterExpression<TEnum?>(new ExpressionContainer(new LiteralExpression<TEnum?>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum?> operator !=(TEnum? a, EnumFieldExpression<TEntity, TEnum> b) => new FilterExpression<TEnum?>(new ExpressionContainer(new LiteralExpression<TEnum?>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        #endregion

        #region mediator
        public static FilterExpression<TEnum> operator ==(EnumFieldExpression<TEntity, TEnum> a, EnumExpressionMediator<TEnum> b) => new FilterExpression<TEnum>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum> operator !=(EnumFieldExpression<TEntity, TEnum> a, EnumExpressionMediator<TEnum> b) => new FilterExpression<TEnum>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum?> operator ==(EnumFieldExpression<TEntity, TEnum> a, NullableEnumExpressionMediator<TEnum> b) => new FilterExpression<TEnum?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum?> operator !=(EnumFieldExpression<TEntity, TEnum> a, NullableEnumExpressionMediator<TEnum> b) => new FilterExpression<TEnum?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        #endregion
        #endregion
    }
}

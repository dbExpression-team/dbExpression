using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public class NullableEnumFieldExpression<TEntity, TEnum> : NullableEnumFieldExpression<TEnum>,
        IEquatable<NullableEnumFieldExpression<TEntity, TEnum>>
        where TEntity : IDbEntity
        where TEnum : struct, Enum, IComparable
    {
        public NullableEnumFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {
        }

        protected NullableEnumFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {

        }

        #region as
        public new NullableEnumFieldExpression<TEntity, TEnum> As(string alias) 
            => new NullableEnumFieldExpression<TEntity, TEnum>(base.Entity, base.MetadataResolver, alias);
        #endregion

        #region equals
        public bool Equals(NullableEnumFieldExpression<TEntity, TEnum> obj)
            => obj is EnumFieldExpression<TEntity, TEnum> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableEnumFieldExpression<TEntity, TEnum> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit operators
        public static implicit operator NullableEnumExpressionMediator<TEnum>(NullableEnumFieldExpression<TEntity, TEnum> a) => new NullableEnumExpressionMediator<TEnum>(new ExpressionContainer(a));
        public static implicit operator SelectExpression<TEnum?>(NullableEnumFieldExpression<TEntity, TEnum> a) => new SelectExpression<TEnum?>(new ExpressionContainer(a));
        public static implicit operator OrderByExpression(NullableEnumFieldExpression<TEntity, TEnum> a) => new OrderByExpression(new ExpressionContainer(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableEnumFieldExpression<TEntity, TEnum> a) => new GroupByExpression(new ExpressionContainer(a));
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpression<TEnum?> operator ==(NullableEnumFieldExpression<TEntity, TEnum> a, DBNull b) => new FilterExpression<TEnum?>(new ExpressionContainer(a), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum?> operator !=(NullableEnumFieldExpression<TEntity, TEnum> a, DBNull b) => new FilterExpression<TEnum?>(new ExpressionContainer(a), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<TEnum?> operator ==(DBNull a, NullableEnumFieldExpression<TEntity, TEnum> b) => new FilterExpression<TEnum?>(new ExpressionContainer(a), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum?> operator !=(DBNull a, NullableEnumFieldExpression<TEntity, TEnum> b) => new FilterExpression<TEnum?>(new ExpressionContainer(a), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        #endregion

        #region TEnum
        public static FilterExpression<TEnum?> operator ==(NullableEnumFieldExpression<TEntity, TEnum> a, TEnum b) => new FilterExpression<TEnum?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<TEnum?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum?> operator !=(NullableEnumFieldExpression<TEntity, TEnum> a, TEnum b) => new FilterExpression<TEnum?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<TEnum?>(b)), FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum?> operator ==(TEnum a, NullableEnumFieldExpression<TEntity, TEnum> b) => new FilterExpression<TEnum?>(new ExpressionContainer(new LiteralExpression<TEnum?>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum?> operator !=(TEnum a, NullableEnumFieldExpression<TEntity, TEnum> b) => new FilterExpression<TEnum?>(new ExpressionContainer(new LiteralExpression<TEnum?>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum?> operator ==(NullableEnumFieldExpression<TEntity, TEnum> a, TEnum? b) => new FilterExpression<TEnum?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<TEnum?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum?> operator !=(NullableEnumFieldExpression<TEntity, TEnum> a, TEnum? b) => new FilterExpression<TEnum?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<TEnum?>(b)), FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum?> operator ==(TEnum? a, NullableEnumFieldExpression<TEntity, TEnum> b) => new FilterExpression<TEnum?>(new ExpressionContainer(new LiteralExpression<TEnum?>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum?> operator !=(TEnum? a, NullableEnumFieldExpression<TEntity, TEnum> b) => new FilterExpression<TEnum?>(new ExpressionContainer(new LiteralExpression<TEnum?>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        #endregion

        #region mediator
        public static FilterExpression<TEnum?> operator ==(NullableEnumFieldExpression<TEntity, TEnum> a, EnumExpressionMediator<TEnum> b) => new FilterExpression<TEnum?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum?> operator !=(NullableEnumFieldExpression<TEntity, TEnum> a, EnumExpressionMediator<TEnum> b) => new FilterExpression<TEnum?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum?> operator ==(NullableEnumFieldExpression<TEntity, TEnum> a, NullableEnumExpressionMediator<TEnum> b) => new FilterExpression<TEnum?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum?> operator !=(NullableEnumFieldExpression<TEntity, TEnum> a, NullableEnumExpressionMediator<TEnum> b) => new FilterExpression<TEnum?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        #endregion
        #endregion
    }
}

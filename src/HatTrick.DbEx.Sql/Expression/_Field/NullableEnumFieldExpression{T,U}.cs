using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class NullableEnumFieldExpression<TEntity, TEnum> : NullableEnumFieldExpression<TEnum>,
        IEquatable<NullableEnumFieldExpression<TEntity, TEnum>>
        where TEntity : IDbEntity
        where TEnum : struct, Enum, IComparable
    {
        public NullableEnumFieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(TEnum), entity)
        {
        }

        protected NullableEnumFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(TEnum), entity, alias)
        {

        }

        #region as
        public NullableEnumFieldExpression<TEntity, TEnum> As(string alias) 
            => new NullableEnumFieldExpression<TEntity, TEnum>(base.identifier, base.entity, alias);
        #endregion

        #region isnull
        public override FilterExpression<bool> IsNull() => new FilterExpression<bool>(new NullableEnumExpressionMediator<TEnum>(this), new NullableEnumExpressionMediator<TEnum>(new NullableLiteralExpression<TEnum>()), FilterExpressionOperator.Equal);
        public override FilterExpression<bool> IsNotNull() => new FilterExpression<bool>(new NullableEnumExpressionMediator<TEnum>(this), new NullableEnumExpressionMediator<TEnum>(new NullableLiteralExpression<TEnum>()), FilterExpressionOperator.NotEqual);
        #endregion

        #region set
        public override AssignmentExpression Set(TEnum value) => new AssignmentExpression(this, new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(value)));
        public override AssignmentExpression Set(TEnum? value) => new AssignmentExpression(this, new NullableEnumExpressionMediator<TEnum>(new NullableLiteralExpression<TEnum?>(value)));
        public override AssignmentExpression Set(ExpressionMediator<TEnum> value) => new AssignmentExpression(this, value);
        public override AssignmentExpression Set(NullableExpressionMediator<TEnum> value) => new AssignmentExpression(this, value);
        #endregion

        #region insert
        public override InsertExpression Insert(TEnum value) => new InsertExpression(this, new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(value)));
        public override InsertExpression Insert(TEnum? value) => new InsertExpression(this, new NullableEnumExpressionMediator<TEnum>(new NullableLiteralExpression<TEnum?>(value)));
        #endregion

        #region in value set
        public override FilterExpression In(params TEnum[] value) => value is object ? new FilterExpression<TEnum>(new NullableEnumExpressionMediator<TEnum>(this), new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum[]>(value)), FilterExpressionOperator.In) : null;
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new Int16ExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new Int16ExpressionMediator(this), OrderExpressionDirection.DESC);
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
        public static implicit operator NullableEnumExpressionMediator<TEnum>(NullableEnumFieldExpression<TEntity, TEnum> a) => new NullableEnumExpressionMediator<TEnum>(a);
        public static implicit operator SelectExpression<TEnum?>(NullableEnumFieldExpression<TEntity, TEnum> a) => new SelectExpression<TEnum?>(new NullableEnumExpressionMediator<TEnum>(a));
        public static implicit operator OrderByExpression(NullableEnumFieldExpression<TEntity, TEnum> a) => new OrderByExpression(new NullableEnumExpressionMediator<TEnum>(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableEnumFieldExpression<TEntity, TEnum> a) => new GroupByExpression(new NullableEnumExpressionMediator<TEnum>(a));
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpression<TEnum> operator ==(NullableEnumFieldExpression<TEntity, TEnum> a, DBNull b) => new FilterExpression<TEnum>(new NullableEnumExpressionMediator<TEnum>(a), new NullableEnumExpressionMediator<TEnum>(new NullableLiteralExpression<TEnum>()), FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum> operator !=(NullableEnumFieldExpression<TEntity, TEnum> a, DBNull b) => new FilterExpression<TEnum>(new NullableEnumExpressionMediator<TEnum>(a), new NullableEnumExpressionMediator<TEnum>(new NullableLiteralExpression<TEnum>()), FilterExpressionOperator.NotEqual);
        public static FilterExpression<TEnum> operator ==(DBNull a, NullableEnumFieldExpression<TEntity, TEnum> b) => new FilterExpression<TEnum>(new NullableEnumExpressionMediator<TEnum>(new NullableLiteralExpression<TEnum>()), new NullableEnumExpressionMediator<TEnum>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum> operator !=(DBNull a, NullableEnumFieldExpression<TEntity, TEnum> b) => new FilterExpression<TEnum>(new NullableEnumExpressionMediator<TEnum>(new NullableLiteralExpression<TEnum>()), new NullableEnumExpressionMediator<TEnum>(b), FilterExpressionOperator.NotEqual);
        #endregion

        #region TEnum
        public static FilterExpression<TEnum> operator ==(NullableEnumFieldExpression<TEntity, TEnum> a, TEnum b) => new FilterExpression<TEnum>(new NullableEnumExpressionMediator<TEnum>(a), new EnumExpressionMediator<TEnum>(new NullableLiteralExpression<TEnum>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum> operator !=(NullableEnumFieldExpression<TEntity, TEnum> a, TEnum b) => new FilterExpression<TEnum>(new NullableEnumExpressionMediator<TEnum>(a), new EnumExpressionMediator<TEnum>(new NullableLiteralExpression<TEnum>(b)), FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum> operator ==(TEnum a, NullableEnumFieldExpression<TEntity, TEnum> b) => new FilterExpression<TEnum>(new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(a)), new NullableEnumExpressionMediator<TEnum>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum> operator !=(TEnum a, NullableEnumFieldExpression<TEntity, TEnum> b) => new FilterExpression<TEnum>(new EnumExpressionMediator<TEnum>(new LiteralExpression<TEnum>(a)), new NullableEnumExpressionMediator<TEnum>(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum> operator ==(NullableEnumFieldExpression<TEntity, TEnum> a, TEnum? b) => new FilterExpression<TEnum>(new NullableEnumExpressionMediator<TEnum>(a), new NullableEnumExpressionMediator<TEnum>(new NullableLiteralExpression<TEnum?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum> operator !=(NullableEnumFieldExpression<TEntity, TEnum> a, TEnum? b) => new FilterExpression<TEnum>(new NullableEnumExpressionMediator<TEnum>(a), new NullableEnumExpressionMediator<TEnum>(new NullableLiteralExpression<TEnum?>(b)), FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum> operator ==(TEnum? a, NullableEnumFieldExpression<TEntity, TEnum> b) => new FilterExpression<TEnum>(new NullableEnumExpressionMediator<TEnum>(new NullableLiteralExpression<TEnum?>(a)), new NullableEnumExpressionMediator<TEnum>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum> operator !=(TEnum? a, NullableEnumFieldExpression<TEntity, TEnum> b) => new FilterExpression<TEnum>(new NullableEnumExpressionMediator<TEnum>(new NullableLiteralExpression<TEnum?>(a)), new NullableEnumExpressionMediator<TEnum>(b), FilterExpressionOperator.NotEqual);
        #endregion

        #region mediator
        public static FilterExpression<TEnum> operator ==(NullableEnumFieldExpression<TEntity, TEnum> a, EnumExpressionMediator<TEnum> b) => new FilterExpression<TEnum>(new NullableEnumExpressionMediator<TEnum>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum> operator !=(NullableEnumFieldExpression<TEntity, TEnum> a, EnumExpressionMediator<TEnum> b) => new FilterExpression<TEnum>(new NullableEnumExpressionMediator<TEnum>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<TEnum> operator ==(NullableEnumFieldExpression<TEntity, TEnum> a, NullableEnumExpressionMediator<TEnum> b) => new FilterExpression<TEnum>(new NullableEnumExpressionMediator<TEnum>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<TEnum> operator !=(NullableEnumFieldExpression<TEntity, TEnum> a, NullableEnumExpressionMediator<TEnum> b) => new FilterExpression<TEnum>(new NullableEnumExpressionMediator<TEnum>(a), b, FilterExpressionOperator.NotEqual);
        #endregion
        #endregion
    }
}

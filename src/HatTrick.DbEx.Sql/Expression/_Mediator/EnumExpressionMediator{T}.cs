using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class EnumExpressionMediator<TEnum> :
        ExpressionMediator<TEnum>,
        EnumElement<TEnum>,
        AnyEnumElement<TEnum>,
        IEquatable<EnumExpressionMediator<TEnum>>
        where TEnum : struct, Enum, IComparable
    {
        #region constructors
        protected EnumExpressionMediator()
        {
        }

        public EnumExpressionMediator(IExpressionElement expression) : base(expression)
        {
        }

        protected EnumExpressionMediator(IExpressionElement expression, string alias) : base(expression, alias)
        {
        }

        protected EnumExpressionMediator(IExpressionElement expression, Type declaredType, string alias) : base(expression, declaredType, alias)
        {
        }
        #endregion

        #region as
        public EnumElement<TEnum> As(string alias)
            => new EnumExpressionMediator<TEnum>(base.Expression, alias);
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new EnumExpressionMediator<TEnum>(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new EnumExpressionMediator<TEnum>(this), OrderExpressionDirection.DESC);
        #endregion

        #region equals
        public bool Equals(EnumExpressionMediator<TEnum> obj)
            => obj is EnumExpressionMediator<TEnum> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is EnumExpressionMediator<TEnum> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit operators
        public static implicit operator SelectExpression<TEnum>(EnumExpressionMediator<TEnum> a) => new SelectExpression<TEnum>(a);
        public static implicit operator OrderByExpression(EnumExpressionMediator<TEnum> a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(EnumExpressionMediator<TEnum> a) => new GroupByExpression(a);
        #endregion

        #region filter operators
        public static FilterExpressionSet operator ==(EnumExpressionMediator<TEnum> a, EnumExpressionMediator<TEnum> b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(EnumExpressionMediator<TEnum> a, EnumExpressionMediator<TEnum> b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(EnumExpressionMediator<TEnum> a, NullableEnumExpressionMediator<TEnum> b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(EnumExpressionMediator<TEnum> a, NullableEnumExpressionMediator<TEnum> b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, EnumExpressionMediator<TEnum> b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, EnumExpressionMediator<TEnum> b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(EnumExpressionMediator<TEnum> a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(EnumExpressionMediator<TEnum> a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        #endregion

    }
}

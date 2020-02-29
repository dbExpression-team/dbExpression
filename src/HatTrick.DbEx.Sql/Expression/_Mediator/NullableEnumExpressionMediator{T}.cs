using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableEnumExpressionMediator<TEnum> :
        NullableExpressionMediator<TEnum>,
        IEquatable<NullableEnumExpressionMediator<TEnum>>
        where TEnum : struct, Enum, IComparable
    {
        #region constructors
        private NullableEnumExpressionMediator()
        {
        }

        public NullableEnumExpressionMediator(ExpressionContainer expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new NullableEnumExpressionMediator<TEnum> As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableEnumExpressionMediator<TEnum> obj)
            => obj is NullableEnumExpressionMediator<TEnum> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableEnumExpressionMediator<TEnum> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit operators
        public static implicit operator SelectExpression<TEnum>(NullableEnumExpressionMediator<TEnum> a) => new SelectExpression<TEnum>(new ExpressionContainer(a));
        public static implicit operator OrderByExpression(NullableEnumExpressionMediator<TEnum> a) => new OrderByExpression(new ExpressionContainer(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableEnumExpressionMediator<TEnum> a) => new GroupByExpression(new ExpressionContainer(a));
        #endregion
    }
}

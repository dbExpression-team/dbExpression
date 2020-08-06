using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class EnumExpressionMediator<TEnum> :
        ExpressionMediator<TEnum>,
        IEquatable<EnumExpressionMediator<TEnum>>
        where TEnum : struct, Enum, IComparable
    {
        #region constructors
        private EnumExpressionMediator()
        {
        }

        public EnumExpressionMediator(IExpression expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new EnumExpressionMediator<TEnum> As(string alias)
        {
            base.As(alias);
            return this;
        }
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
    }
}

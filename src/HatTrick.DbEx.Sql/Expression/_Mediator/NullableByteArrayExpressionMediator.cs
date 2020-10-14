using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteArrayExpressionMediator :
        ExpressionMediator<byte[]>,
        IEquatable<NullableByteArrayExpressionMediator>
    {
        #region constructors
        private NullableByteArrayExpressionMediator()
        {
        }

        public NullableByteArrayExpressionMediator(IExpression expression) : base(expression)
        {
        }

        protected NullableByteArrayExpressionMediator(IExpression expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public new NullableByteArrayExpressionMediator As(string alias)
            => new NullableByteArrayExpressionMediator(this.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableByteArrayExpressionMediator obj)
            => obj is NullableByteArrayExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableByteArrayExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit operators
        public static implicit operator SelectExpression<byte[]>(NullableByteArrayExpressionMediator a) => new SelectExpression<byte[]>(a);
        public static implicit operator OrderByExpression(NullableByteArrayExpressionMediator a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableByteArrayExpressionMediator a) => new GroupByExpression(a);
        #endregion
    }
}

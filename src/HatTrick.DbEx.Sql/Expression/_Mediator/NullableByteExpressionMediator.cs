using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteExpressionMediator :
        NullableExpressionMediator<byte>,
        IEquatable<NullableByteExpressionMediator>
    {
        #region constructors
        private NullableByteExpressionMediator()
        {
        }

        public NullableByteExpressionMediator(IExpression expression) : base(expression, typeof(byte?))
        {
        }

        protected NullableByteExpressionMediator(IExpression expression, string alias) : base(expression, typeof(byte?), alias)
        {
        }
        #endregion

        #region as
        public new NullableByteExpressionMediator As(string alias)
            => new NullableByteExpressionMediator(this.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableByteExpressionMediator obj)
            => obj is NullableByteExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableByteExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

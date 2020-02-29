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

        public NullableByteExpressionMediator(ExpressionContainer expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new NullableByteExpressionMediator As(string alias)
        {
            base.As(alias);
            return this;
        }
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

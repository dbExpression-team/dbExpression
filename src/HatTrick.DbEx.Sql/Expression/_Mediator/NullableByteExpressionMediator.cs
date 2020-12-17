using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteExpressionMediator :
        NullableExpressionMediator<byte,byte?>,
        NullableByteElement,
        AnyByteElement,
        IEquatable<NullableByteExpressionMediator>
    {
        #region constructors
        private NullableByteExpressionMediator()
        {
        }

        public NullableByteExpressionMediator(IExpressionElement expression) : base(expression, typeof(byte?))
        {
        }

        protected NullableByteExpressionMediator(IExpressionElement expression, string alias) : base(expression, typeof(byte?), alias)
        {
        }
        #endregion

        #region as
        public NullableByteElement As(string alias)
            => new NullableByteSelectExpression(this).As(alias);
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

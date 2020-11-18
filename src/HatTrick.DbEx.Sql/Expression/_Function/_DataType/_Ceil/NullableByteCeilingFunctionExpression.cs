using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteCeilingFunctionExpression :
        NullableCeilFunctionExpression<byte,byte?>,
        NullByteElement,
        AnyByteElement,
        IEquatable<NullableByteCeilingFunctionExpression>
    {
        #region constructors
        public NullableByteCeilingFunctionExpression(NullByteElement expression) 
            : base(expression)
        {

        }

        protected NullableByteCeilingFunctionExpression(IExpressionElement expression, string alias) 
            : base(expression, alias)
        {

        }
        #endregion

        #region as
        public NullByteElement As(string alias)
            => new NullableByteCeilingFunctionExpression(base.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableByteCeilingFunctionExpression obj)
            => obj is NullableByteCeilingFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableByteCeilingFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ByteMaximumFunctionExpression :
        MaximumFunctionExpression<byte>,
        ByteElement,
        AnyByteElement,
        IEquatable<ByteMaximumFunctionExpression>
    {
        #region constructors
        public ByteMaximumFunctionExpression(ByteElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public ByteElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region distinct
        public ByteMaximumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(ByteMaximumFunctionExpression obj)
            => obj is ByteMaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ByteMaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ByteMinimumFunctionExpression :
        MinimumFunctionExpression<byte>,
        ByteElement,
        AnyByteElement,
        IEquatable<ByteMinimumFunctionExpression>
    {
        #region constructors
        public ByteMinimumFunctionExpression(ByteElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public ByteElement As(string alias)
            => new ByteSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public ByteMinimumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(ByteMinimumFunctionExpression obj)
            => obj is ByteMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ByteMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteMinimumFunctionExpression :
        NullableMinimumFunctionExpression<byte,byte?>,
        NullableByteElement,
        AnyByteElement,
        IEquatable<NullableByteMinimumFunctionExpression>
    {
        #region constructors
        public NullableByteMinimumFunctionExpression(NullableByteElement expression) 
            : base(expression)
        {

        }
        #endregion

        #region as
        public NullableByteElement As(string alias)
            => new NullableByteSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public NullableByteMinimumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableByteMinimumFunctionExpression obj)
            => obj is NullableByteMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableByteMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteMaximumFunctionExpression :
        NullableMaximumFunctionExpression<byte,byte?>,
        NullableByteElement,
        AnyByteElement,
        IEquatable<NullableByteMaximumFunctionExpression>
    {
        #region constructors
        public NullableByteMaximumFunctionExpression(NullableByteElement expression) 
            : base(expression)
        {

        }
        #endregion

        #region as
        public NullableByteElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region distinct
        public NullableByteMaximumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableByteMaximumFunctionExpression obj)
            => obj is NullableByteMaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableByteMaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

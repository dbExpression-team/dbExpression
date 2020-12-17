using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleSumFunctionExpression :
        NullableSumFunctionExpression<double,double?>,
        NullableDoubleElement,
        AnyDoubleElement,
        IEquatable<NullableDoubleSumFunctionExpression>
    {
        #region constructors
        public NullableDoubleSumFunctionExpression(NullableDoubleElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public NullableDoubleElement As(string alias)
            => new NullableDoubleSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public NullableDoubleSumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDoubleSumFunctionExpression obj)
            => obj is NullableDoubleSumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDoubleSumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

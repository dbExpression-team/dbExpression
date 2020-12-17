using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleMaximumFunctionExpression :
        NullableMaximumFunctionExpression<double,double?>,
        NullableDoubleElement,
        AnyDoubleElement,
        IEquatable<NullableDoubleMaximumFunctionExpression>
    {
        #region constructors
        public NullableDoubleMaximumFunctionExpression(NullableDoubleElement expression) 
            : base(expression)
        {

        }
        #endregion

        #region as
        public NullableDoubleElement As(string alias)
            => new NullableDoubleSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public NullableDoubleMaximumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion
        #region equals
        public bool Equals(NullableDoubleMaximumFunctionExpression obj)
            => obj is NullableDoubleMaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDoubleMaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

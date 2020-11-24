using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleMinimumFunctionExpression :
        NullableMinimumFunctionExpression<double,double?>,
        NullableDoubleElement,
        AnyDoubleElement,
        IEquatable<NullableDoubleMinimumFunctionExpression>
    {
        #region constructors
        public NullableDoubleMinimumFunctionExpression(NullableDoubleElement expression) 
            : base(expression)
        {

        }
        #endregion

        #region as
        public NullableDoubleElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region distinct
        public NullableDoubleMinimumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDoubleMinimumFunctionExpression obj)
            => obj is NullableDoubleMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDoubleMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

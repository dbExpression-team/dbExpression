using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleAverageFunctionExpression :
        NullableAverageFunctionExpression<double,double?>,
        NullableDoubleElement,
        AnyDoubleElement,
        IEquatable<NullableDoubleAverageFunctionExpression>
    {
        #region constructors
        public NullableDoubleAverageFunctionExpression(NullableDoubleElement expression) : base(expression)
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
        public NullableDoubleAverageFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDoubleAverageFunctionExpression obj)
            => obj is NullableDoubleAverageFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDoubleAverageFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

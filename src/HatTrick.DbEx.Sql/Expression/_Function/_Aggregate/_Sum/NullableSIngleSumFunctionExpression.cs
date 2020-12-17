using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleSumFunctionExpression :
        NullableSumFunctionExpression<float,float?>,
        NullableSingleElement,
        AnySingleElement,
        IEquatable<NullableSingleSumFunctionExpression>
    {
        #region constructors
        public NullableSingleSumFunctionExpression(NullableSingleElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public NullableSingleElement As(string alias)
            => new NullableSingleSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public NullableSingleSumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableSingleSumFunctionExpression obj)
            => obj is NullableSingleSumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleSumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

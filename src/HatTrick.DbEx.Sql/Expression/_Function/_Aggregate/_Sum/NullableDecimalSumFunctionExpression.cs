using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDecimalSumFunctionExpression :
        NullableSumFunctionExpression<decimal,decimal?>,
        NullableDecimalElement,
        AnyDecimalElement,
        IEquatable<NullableDecimalSumFunctionExpression>
    {
        #region constructors
        public NullableDecimalSumFunctionExpression(NullableDecimalElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public NullableDecimalElement As(string alias)
            => new NullableDecimalSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public NullableDecimalSumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDecimalSumFunctionExpression obj)
            => obj is NullableDecimalSumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDecimalSumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

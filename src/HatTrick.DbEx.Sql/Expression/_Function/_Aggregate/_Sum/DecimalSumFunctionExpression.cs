using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DecimalSumFunctionExpression :
        SumFunctionExpression<decimal>,
        DecimalElement,
        AnyDecimalElement,
        IEquatable<DecimalSumFunctionExpression>
    {
        #region constructors
        public DecimalSumFunctionExpression(DecimalElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public DecimalElement As(string alias)
            => new DecimalSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public DecimalSumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DecimalSumFunctionExpression obj)
            => obj is DecimalSumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DecimalSumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

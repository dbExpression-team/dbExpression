using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DecimalMaximumFunctionExpression :
        MaximumFunctionExpression<decimal>,
        DecimalElement,
        AnyDecimalElement,
        IEquatable<DecimalMaximumFunctionExpression>
    {
        #region constructors
        public DecimalMaximumFunctionExpression(DecimalElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public DecimalElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region distinct
        public DecimalMaximumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DecimalMaximumFunctionExpression obj)
            => obj is DecimalMaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DecimalMaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

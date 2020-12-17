using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DecimalMinimumFunctionExpression :
        MinimumFunctionExpression<decimal>,
        DecimalElement,
        AnyDecimalElement,
        IEquatable<DecimalMinimumFunctionExpression>
    {
        #region constructors
        public DecimalMinimumFunctionExpression(DecimalElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public DecimalElement As(string alias)
            => new DecimalSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public DecimalMinimumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DecimalMinimumFunctionExpression obj)
            => obj is DecimalMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DecimalMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

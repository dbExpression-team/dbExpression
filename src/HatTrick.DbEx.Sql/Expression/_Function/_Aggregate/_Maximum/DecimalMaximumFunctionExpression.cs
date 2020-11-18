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
        public DecimalMaximumFunctionExpression(DecimalElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected DecimalMaximumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public DecimalElement As(string alias)
            => new DecimalMaximumFunctionExpression(base.Expression, base.IsDistinct, alias);
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

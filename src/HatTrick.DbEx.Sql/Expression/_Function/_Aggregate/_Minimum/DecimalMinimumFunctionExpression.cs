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
        public DecimalMinimumFunctionExpression(DecimalElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected DecimalMinimumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public DecimalElement As(string alias)
            => new DecimalMinimumFunctionExpression(base.Expression, base.IsDistinct, alias);
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

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
        public DecimalSumFunctionExpression(DecimalElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected DecimalSumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public DecimalElement As(string alias)
            => new DecimalSumFunctionExpression(base.Expression, base.IsDistinct, alias);
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

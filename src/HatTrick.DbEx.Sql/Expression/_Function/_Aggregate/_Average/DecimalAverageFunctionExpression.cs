using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DecimalAverageFunctionExpression :
        AverageFunctionExpression<decimal>,
        DecimalElement,
        AnyDecimalElement,
        IEquatable<DecimalAverageFunctionExpression>
    {
        #region constructors
        public DecimalAverageFunctionExpression(DecimalElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected DecimalAverageFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public DecimalElement As(string alias)
            => new DecimalAverageFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(DecimalAverageFunctionExpression obj)
            => obj is DecimalAverageFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DecimalAverageFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

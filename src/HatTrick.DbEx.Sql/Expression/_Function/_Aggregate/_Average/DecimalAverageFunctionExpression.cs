using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DecimalAverageFunctionExpression :
        AverageFunctionExpression<decimal>,
        IEquatable<DecimalAverageFunctionExpression>
    {
        #region constructors
        public DecimalAverageFunctionExpression(ExpressionMediator<decimal> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new DecimalAverageFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
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

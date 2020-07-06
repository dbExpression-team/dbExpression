using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DecimalSumFunctionExpression :
        SumFunctionExpression<decimal>,
        IEquatable<DecimalSumFunctionExpression>
    {
        #region constructors
        public DecimalSumFunctionExpression(ExpressionMediator<decimal> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new DecimalSumFunctionExpression As(string alias)
        {
            base.As(alias);
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

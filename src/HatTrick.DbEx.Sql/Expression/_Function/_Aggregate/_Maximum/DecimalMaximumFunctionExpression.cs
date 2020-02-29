using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DecimalMaximumFunctionExpression :
        MaximumFunctionExpression<decimal>,
        IEquatable<DecimalMaximumFunctionExpression>
    {
        #region constructors
        public DecimalMaximumFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new DecimalMaximumFunctionExpression As(string alias)
        {
            base.As(alias);
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

using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DecimalMinimumFunctionExpression :
        MinimumFunctionExpression<decimal>,
        IEquatable<DecimalMinimumFunctionExpression>
    {
        #region constructors
        public DecimalMinimumFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new DecimalMinimumFunctionExpression As(string alias)
        {
            base.As(alias);
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

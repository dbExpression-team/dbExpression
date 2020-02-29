using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DoubleMaximumFunctionExpression :
        MaximumFunctionExpression<double>,
        IEquatable<DoubleMaximumFunctionExpression>
    {
        #region constructors
        public DoubleMaximumFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new DoubleMaximumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DoubleMaximumFunctionExpression obj)
            => obj is DoubleMaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DoubleMaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

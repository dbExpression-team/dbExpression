using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DoubleMinimumFunctionExpression :
        MinimumFunctionExpression<double>,
        IEquatable<DoubleMinimumFunctionExpression>
    {
        #region constructors
        public DoubleMinimumFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new DoubleMinimumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DoubleMinimumFunctionExpression obj)
            => obj is DoubleMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DoubleMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

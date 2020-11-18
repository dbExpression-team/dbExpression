using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DoubleMaximumFunctionExpression :
        MaximumFunctionExpression<double>,
        DoubleElement,
        AnyDoubleElement,
        IEquatable<DoubleMaximumFunctionExpression>
    {
        #region constructors
        public DoubleMaximumFunctionExpression(DoubleElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected DoubleMaximumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public DoubleElement As(string alias)
            => new DoubleMaximumFunctionExpression(base.Expression, base.IsDistinct, alias);
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

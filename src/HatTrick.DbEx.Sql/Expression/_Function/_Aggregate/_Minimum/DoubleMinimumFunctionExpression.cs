using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DoubleMinimumFunctionExpression :
        MinimumFunctionExpression<double>,
        DoubleElement,
        AnyDoubleElement, 
        IEquatable<DoubleMinimumFunctionExpression>
    {
        #region constructors
        public DoubleMinimumFunctionExpression(DoubleElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected DoubleMinimumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public DoubleElement As(string alias)
            => new DoubleMinimumFunctionExpression(base.Expression, base.IsDistinct, alias);
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

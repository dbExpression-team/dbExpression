using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DoubleAverageFunctionExpression :
        AverageFunctionExpression<double>,
        DoubleElement,
        AnyDoubleElement,
        IEquatable<DoubleAverageFunctionExpression>
    {
        #region constructors
        public DoubleAverageFunctionExpression(DoubleElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected DoubleAverageFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public DoubleElement As(string alias)
            => new DoubleAverageFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(DoubleAverageFunctionExpression obj)
            => obj is DoubleAverageFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DoubleAverageFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

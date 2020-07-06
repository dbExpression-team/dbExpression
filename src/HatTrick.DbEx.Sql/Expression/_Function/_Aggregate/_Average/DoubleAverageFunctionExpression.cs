using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DoubleAverageFunctionExpression :
        AverageFunctionExpression<double>,
        IEquatable<DoubleAverageFunctionExpression>
    {
        #region constructors
        public DoubleAverageFunctionExpression(ExpressionMediator<double> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new DoubleAverageFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
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

using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleAverageFunctionExpression :
        AverageFunctionExpression<float>,
        IEquatable<SingleAverageFunctionExpression>
    {
        #region constructors
        public SingleAverageFunctionExpression(ExpressionMediator<float> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new SingleAverageFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(SingleAverageFunctionExpression obj)
            => obj is SingleAverageFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleAverageFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleAverageFunctionExpression :
        AverageFunctionExpression<float>,
        SingleElement,
        AnySingleElement,
        IEquatable<SingleAverageFunctionExpression>
    {
        #region constructors
        public SingleAverageFunctionExpression(SingleElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected SingleAverageFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public SingleElement As(string alias)
            => new SingleAverageFunctionExpression(base.Expression, base.IsDistinct, alias);
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

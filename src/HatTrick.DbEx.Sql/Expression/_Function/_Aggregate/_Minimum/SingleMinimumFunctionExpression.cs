using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleMinimumFunctionExpression :
        MinimumFunctionExpression<float>,
        SingleElement,
        AnySingleElement,
        IEquatable<SingleMinimumFunctionExpression>
    {
        #region constructors
        public SingleMinimumFunctionExpression(SingleElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected SingleMinimumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public SingleElement As(string alias)
            => new SingleMinimumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(SingleMinimumFunctionExpression obj)
            => obj is SingleMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

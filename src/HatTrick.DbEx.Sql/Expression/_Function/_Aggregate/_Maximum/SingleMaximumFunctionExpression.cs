using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleMaximumFunctionExpression :
        MaximumFunctionExpression<float>,
        SingleElement,
        AnySingleElement,
        IEquatable<SingleMaximumFunctionExpression>
    {
        #region constructors
        public SingleMaximumFunctionExpression(SingleElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected SingleMaximumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public SingleElement As(string alias)
            => new SingleMaximumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(SingleMaximumFunctionExpression obj)
            => obj is SingleMaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleMaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

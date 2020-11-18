using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleSumFunctionExpression :
        SumFunctionExpression<float>,
        SingleElement,
        AnySingleElement,
        IEquatable<SingleSumFunctionExpression>
    {
        #region constructors
        public SingleSumFunctionExpression(SingleElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected SingleSumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public SingleElement As(string alias)
            => new SingleSumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(SingleSumFunctionExpression obj)
            => obj is SingleSumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleSumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

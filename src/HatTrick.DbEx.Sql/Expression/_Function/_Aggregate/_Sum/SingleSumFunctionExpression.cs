using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleSumFunctionExpression :
        SumFunctionExpression<float>,
        IEquatable<SingleSumFunctionExpression>
    {
        #region constructors
        public SingleSumFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new SingleSumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
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

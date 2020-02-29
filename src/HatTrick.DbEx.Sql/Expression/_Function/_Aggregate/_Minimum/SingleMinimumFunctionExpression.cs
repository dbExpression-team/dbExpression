using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleMinimumFunctionExpression :
        MinimumFunctionExpression<float>,
        IEquatable<SingleMinimumFunctionExpression>
    {
        #region constructors
        public SingleMinimumFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new SingleMinimumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
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

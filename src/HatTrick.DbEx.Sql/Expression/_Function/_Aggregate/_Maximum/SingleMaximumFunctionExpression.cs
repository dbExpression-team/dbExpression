using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleMaximumFunctionExpression :
        MaximumFunctionExpression<float>,
        IEquatable<SingleMaximumFunctionExpression>
    {
        #region constructors
        public SingleMaximumFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new SingleMaximumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
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

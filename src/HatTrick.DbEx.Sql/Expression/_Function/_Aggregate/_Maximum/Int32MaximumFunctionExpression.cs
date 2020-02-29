using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int32MaximumFunctionExpression :
        MaximumFunctionExpression<int>,
        IEquatable<Int32MaximumFunctionExpression>
    {
        #region constructors
        public Int32MaximumFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new Int32MaximumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int32MaximumFunctionExpression obj)
            => obj is Int32MaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int32MaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

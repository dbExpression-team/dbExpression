using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int16MinimumFunctionExpression :
        MinimumFunctionExpression<short>,
        IEquatable<Int16MinimumFunctionExpression>
    {
        #region constructors
        public Int16MinimumFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new Int16MinimumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int16MinimumFunctionExpression obj)
            => obj is Int16MinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int16MinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

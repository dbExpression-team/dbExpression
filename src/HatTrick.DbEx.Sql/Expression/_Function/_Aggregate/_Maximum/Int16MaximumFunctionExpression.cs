using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int16MaximumFunctionExpression :
        MaximumFunctionExpression<short>,
        IEquatable<Int16MaximumFunctionExpression>
    {
        #region constructors
        public Int16MaximumFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new Int16MaximumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int16MaximumFunctionExpression obj)
            => obj is Int16MaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int16MaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

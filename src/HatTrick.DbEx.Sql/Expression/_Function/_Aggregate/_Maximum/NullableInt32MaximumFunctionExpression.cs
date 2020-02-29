using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt32MaximumFunctionExpression :
        NullableMaximumFunctionExpression<int>,
        IEquatable<NullableInt32MaximumFunctionExpression>
    {
        #region constructors
        public NullableInt32MaximumFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableInt32MaximumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt32MaximumFunctionExpression obj)
            => obj is NullableInt32MaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt32MaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

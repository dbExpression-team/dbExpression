using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt16MaximumFunctionExpression :
        NullableMaximumFunctionExpression<short>,
        IEquatable<NullableInt16MaximumFunctionExpression>
    {
        #region constructors
        public NullableInt16MaximumFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableInt16MaximumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt16MaximumFunctionExpression obj)
            => obj is NullableInt16MaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt16MaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

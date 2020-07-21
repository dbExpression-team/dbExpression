using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64CeilingFunctionExpression :
        NullableCeilFunctionExpression<long>,
        IEquatable<NullableInt64CeilingFunctionExpression>
    {
        #region constructors
        public NullableInt64CeilingFunctionExpression(NullableExpressionMediator<long> expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new NullableInt64CeilingFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt64CeilingFunctionExpression obj)
            => obj is NullableInt64CeilingFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt64CeilingFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

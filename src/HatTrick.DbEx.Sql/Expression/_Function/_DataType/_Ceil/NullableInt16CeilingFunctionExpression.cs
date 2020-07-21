using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt16CeilingFunctionExpression :
        NullableCeilFunctionExpression<short>,
        IEquatable<NullableInt16CeilingFunctionExpression>
    {
        #region constructors
        public NullableInt16CeilingFunctionExpression(NullableExpressionMediator<short> expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new NullableInt16CeilingFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt16CeilingFunctionExpression obj)
            => obj is NullableInt16CeilingFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt16CeilingFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

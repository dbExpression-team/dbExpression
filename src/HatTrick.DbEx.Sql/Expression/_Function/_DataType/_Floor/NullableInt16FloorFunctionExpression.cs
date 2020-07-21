using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt16FloorFunctionExpression :
        NullableFloorFunctionExpression<short>,
        IEquatable<NullableInt16FloorFunctionExpression>
    {
        #region constructors
        public NullableInt16FloorFunctionExpression(NullableExpressionMediator<short> expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new NullableInt16FloorFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt16FloorFunctionExpression obj)
            => obj is NullableInt16FloorFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt16FloorFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

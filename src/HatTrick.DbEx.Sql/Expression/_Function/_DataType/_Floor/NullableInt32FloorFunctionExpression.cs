using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt32FloorFunctionExpression :
        NullableFloorFunctionExpression<int>,
        IEquatable<NullableInt32FloorFunctionExpression>
    {
        #region constructors
        public NullableInt32FloorFunctionExpression(NullableExpressionMediator<int> expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new NullableInt32FloorFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt32FloorFunctionExpression obj)
            => obj is NullableInt32FloorFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt32FloorFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

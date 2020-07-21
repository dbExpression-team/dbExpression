using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64FloorFunctionExpression :
        NullableFloorFunctionExpression<long>,
        IEquatable<NullableInt64FloorFunctionExpression>
    {
        #region constructors
        public NullableInt64FloorFunctionExpression(NullableExpressionMediator<long> expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new NullableInt64FloorFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt64FloorFunctionExpression obj)
            => obj is NullableInt64FloorFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt64FloorFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

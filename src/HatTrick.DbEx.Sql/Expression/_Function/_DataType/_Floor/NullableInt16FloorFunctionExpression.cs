using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt16FloorFunctionExpression :
        NullableFloorFunctionExpression<short,short?>,
        NullableInt16Element,
        AnyInt16Element,
        IEquatable<NullableInt16FloorFunctionExpression>
    {
        #region constructors
        public NullableInt16FloorFunctionExpression(NullableInt16Element expression) : base(expression)
        {

        }
        #endregion

        #region as
        public NullableInt16Element As(string alias)
        {
            Alias = alias;
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

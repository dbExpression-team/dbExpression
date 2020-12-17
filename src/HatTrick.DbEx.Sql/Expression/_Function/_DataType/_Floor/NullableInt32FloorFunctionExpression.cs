using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt32FloorFunctionExpression :
        NullableFloorFunctionExpression<int,int?>,
        NullableInt32Element,
        AnyInt32Element,
        IEquatable<NullableInt32FloorFunctionExpression>
    {
        #region constructors
        public NullableInt32FloorFunctionExpression(NullableInt32Element expression) : base(expression)
        {

        }
        #endregion

        #region as
        public NullableInt32Element As(string alias)
            => new NullableInt32SelectExpression(this).As(alias);
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

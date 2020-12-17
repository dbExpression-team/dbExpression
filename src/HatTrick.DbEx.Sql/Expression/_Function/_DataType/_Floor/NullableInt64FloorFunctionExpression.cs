using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64FloorFunctionExpression :
        NullableFloorFunctionExpression<long,long?>,
        NullableInt64Element,
        AnyInt64Element,
        IEquatable<NullableInt64FloorFunctionExpression>
    {
        #region constructors
        public NullableInt64FloorFunctionExpression(NullableInt64Element expression) : base(expression)
        {

        }
        #endregion

        #region as
        public NullableInt64Element As(string alias)
            => new NullableInt64SelectExpression(this).As(alias);
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

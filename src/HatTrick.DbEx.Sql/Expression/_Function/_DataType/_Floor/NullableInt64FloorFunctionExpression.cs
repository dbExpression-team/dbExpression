using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64FloorFunctionExpression :
        NullableFloorFunctionExpression<long,long?>,
        NullInt64Element,
        AnyInt64Element,
        IEquatable<NullableInt64FloorFunctionExpression>
    {
        #region constructors
        public NullableInt64FloorFunctionExpression(NullInt64Element expression) : base(expression)
        {

        }

        public NullableInt64FloorFunctionExpression(IExpressionElement expression, string alias) : base(expression, alias)
        {

        }
        #endregion

        #region as
        public NullInt64Element As(string alias)
            => new NullableInt64FloorFunctionExpression(base.Expression, alias);
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

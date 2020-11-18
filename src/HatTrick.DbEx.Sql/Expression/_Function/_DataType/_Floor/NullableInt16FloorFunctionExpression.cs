using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt16FloorFunctionExpression :
        NullableFloorFunctionExpression<short,short?>,
        NullInt16Element,
        AnyInt16Element,
        IEquatable<NullableInt16FloorFunctionExpression>
    {
        #region constructors
        public NullableInt16FloorFunctionExpression(NullInt16Element expression) : base(expression)
        {

        }

        public NullableInt16FloorFunctionExpression(IExpressionElement expression, string alias) : base(expression, alias)
        {

        }
        #endregion

        #region as
        public NullInt16Element As(string alias)
            => new NullableInt16FloorFunctionExpression(base.Expression, alias);
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

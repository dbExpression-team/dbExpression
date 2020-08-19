using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt16CastFunctionExpression :
        NullableCastFunctionExpression<short>,
        IEquatable<NullableInt16CastFunctionExpression>
    {
        #region constructors
        public NullableInt16CastFunctionExpression(ExpressionMediator expression, DbTypeExpression convertToDbType) : base(expression, convertToDbType)
        {
        }
        #endregion

        #region as
        public new NullableInt16CastFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt16CastFunctionExpression obj)
            => obj is NullableInt16CastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt16CastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

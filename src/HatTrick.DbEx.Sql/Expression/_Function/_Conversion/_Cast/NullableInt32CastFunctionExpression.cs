using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt32CastFunctionExpression :
        NullableCastFunctionExpression<int>,
        IEquatable<NullableInt32CastFunctionExpression>
    {
        #region constructors
        public NullableInt32CastFunctionExpression(ExpressionMediator expression, DbTypeExpression convertToDbType) : base(expression, convertToDbType)
        {
        }
        #endregion

        #region as
        public new NullableInt32CastFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt32CastFunctionExpression obj)
            => obj is NullableInt32CastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt32CastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

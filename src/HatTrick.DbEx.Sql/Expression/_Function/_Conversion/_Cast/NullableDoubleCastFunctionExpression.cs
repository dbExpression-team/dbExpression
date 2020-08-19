using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleCastFunctionExpression :
        NullableCastFunctionExpression<double>,
        IEquatable<NullableDoubleCastFunctionExpression>
    {
        #region constructors
        public NullableDoubleCastFunctionExpression(NullableExpressionMediator<double> expression, DbTypeExpression convertToDbType) : base(expression, convertToDbType)
        {
        }
        #endregion

        #region as
        public new NullableDoubleCastFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDoubleCastFunctionExpression obj)
            => obj is NullableDoubleCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDoubleCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

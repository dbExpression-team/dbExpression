using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DecimalCastFunctionExpression :
        CastFunctionExpression<decimal>,
        IEquatable<DecimalCastFunctionExpression>
    {
        #region constructors
        public DecimalCastFunctionExpression(ExpressionMediator expression, ExpressionContainer convertToDbType) : base(expression, convertToDbType)
        {
        }
        #endregion

        #region as
        public new DecimalCastFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DecimalCastFunctionExpression obj)
            => obj is DecimalCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DecimalCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

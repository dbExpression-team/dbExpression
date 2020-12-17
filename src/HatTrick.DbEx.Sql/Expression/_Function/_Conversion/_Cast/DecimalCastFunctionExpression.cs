using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DecimalCastFunctionExpression :
        CastFunctionExpression<decimal>,
        DecimalElement,
        AnyDecimalElement,
        IEquatable<DecimalCastFunctionExpression>
    {
        #region constructors
        public DecimalCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, int precision, int? scale)
            : base(expression, convertToDbType, precision, scale)
        {

        }
        #endregion

        #region as
        public DecimalElement As(string alias)
            => new DecimalSelectExpression(this).As(alias);
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

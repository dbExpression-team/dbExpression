using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDecimalCastFunctionExpression :
        NullableCastFunctionExpression<decimal,decimal?>,
        NullableDecimalElement,
        AnyDecimalElement,
        IEquatable<NullableDecimalCastFunctionExpression>
    {
        #region constructors
        public NullableDecimalCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType)
        {

        }
        #endregion

        #region as
        public NullableDecimalElement As(string alias)
            => new NullableDecimalSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableDecimalCastFunctionExpression obj)
            => obj is NullableDecimalCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDecimalCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

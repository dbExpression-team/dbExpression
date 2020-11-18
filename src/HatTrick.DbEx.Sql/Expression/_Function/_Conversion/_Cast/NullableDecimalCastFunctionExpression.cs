using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDecimalCastFunctionExpression :
        NullableCastFunctionExpression<decimal,decimal?>,
        NullDecimalElement,
        AnyDecimalElement,
        IEquatable<NullableDecimalCastFunctionExpression>
    {
        #region constructors
        public NullableDecimalCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType)
        {

        }

        protected NullableDecimalCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, int? size, int? precision, int? scale, string alias)
            : base(expression, convertToDbType, size, precision, scale, alias)
        {

        }
        #endregion

        #region as
        public NullDecimalElement As(string alias)
            => new NullableDecimalCastFunctionExpression(base.Expression, base.ConvertToDbType, base.Size, base.Precision, base.Scale, alias);
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

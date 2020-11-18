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
        public DecimalCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType, typeof(decimal))
        {

        }

        protected DecimalCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, int? size, int? precision, int? scale, string alias)
            : base(expression, convertToDbType, typeof(decimal), size, precision, scale, alias)
        {

        }
        #endregion

        #region as
        public DecimalElement As(string alias)
            => new DecimalCastFunctionExpression(base.Expression, base.ConvertToDbType, base.Size, base.Precision, base.Scale, alias);
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

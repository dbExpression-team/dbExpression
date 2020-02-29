using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeOffsetCastFunctionExpression :
        CastFunctionExpression<DateTimeOffset>,
        IEquatable<DateTimeOffsetCastFunctionExpression>
    {
        #region constructors
        public DateTimeOffsetCastFunctionExpression(ExpressionContainer expression, ExpressionContainer convertToDbType) : base(expression, convertToDbType)
        {
        }
        #endregion

        #region as
        public new DateTimeOffsetCastFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DateTimeOffsetCastFunctionExpression obj)
            => obj is DateTimeOffsetCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DateTimeOffsetCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

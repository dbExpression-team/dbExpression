using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeOffsetCastFunctionExpression :
        CastFunctionExpression<DateTimeOffset>,
        DateTimeOffsetElement,
        AnyDateTimeOffsetElement,
        IEquatable<DateTimeOffsetCastFunctionExpression>
    {
        #region constructors
        public DateTimeOffsetCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType)
        {

        }
        #endregion

        #region as
        public DateTimeOffsetElement As(string alias)
        {
            Alias = alias;
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

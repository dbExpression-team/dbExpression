using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeCastFunctionExpression :
        CastFunctionExpression<DateTime>,
        IEquatable<DateTimeCastFunctionExpression>
    {
        #region constructors
        public DateTimeCastFunctionExpression(ExpressionContainer expression, ExpressionContainer convertToDbType) : base(expression, convertToDbType)
        {
        }
        #endregion

        #region as
        public new DateTimeCastFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DateTimeCastFunctionExpression obj)
            => obj is DateTimeCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DateTimeCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

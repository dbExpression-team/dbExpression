using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeCastFunctionExpression :
        CastFunctionExpression<DateTime>,
        DateTimeElement,
        AnyDateTimeElement,
        IEquatable<DateTimeCastFunctionExpression>
    {
        #region constructors
        public DateTimeCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType) 
            : base(expression, convertToDbType)
        {

        }
        #endregion

        #region as
        public DateTimeElement As(string alias)
        {
            Alias = alias;
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

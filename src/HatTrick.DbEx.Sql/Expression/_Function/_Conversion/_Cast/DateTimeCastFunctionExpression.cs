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
            : base(expression, convertToDbType, typeof(DateTime))
        {

        }

        protected DateTimeCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, int? size, int? precision, int? scale, string alias)
            : base(expression, convertToDbType, typeof(DateTime), size, precision, scale, alias)
        {

        }
        #endregion

        #region as
        public DateTimeElement As(string alias)
            => new DateTimeCastFunctionExpression(base.Expression, base.ConvertToDbType, base.Size, base.Precision, base.Scale, alias);
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

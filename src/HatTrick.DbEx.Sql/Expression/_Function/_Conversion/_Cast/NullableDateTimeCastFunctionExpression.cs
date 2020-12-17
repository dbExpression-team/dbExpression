using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeCastFunctionExpression :
        NullableCastFunctionExpression<DateTime,DateTime?>,
        NullableDateTimeElement,
        AnyDateTimeElement,
        IEquatable<NullableDateTimeCastFunctionExpression>
    {
        #region constructors
        public NullableDateTimeCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType)
        {

        }
        #endregion

        #region as
        public NullableDateTimeElement As(string alias)
            => new NullableDateTimeSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableDateTimeCastFunctionExpression obj)
            => obj is NullableDateTimeCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class TimeSpanCastFunctionExpression :
        CastFunctionExpression<TimeSpan>,
        IEquatable<TimeSpanCastFunctionExpression>
    {
        #region constructors
        public TimeSpanCastFunctionExpression(ExpressionMediator expression, DbTypeExpression convertToDbType) : base(expression, convertToDbType)
        {
        }
        #endregion

        #region as
        public new TimeSpanCastFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(TimeSpanCastFunctionExpression obj)
            => obj is TimeSpanCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is TimeSpanCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

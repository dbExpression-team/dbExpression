using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class TimeSpanCastFunctionExpression :
        CastFunctionExpression<TimeSpan>,
        TimeSpanElement,
        AnyTimeSpanElement,
        IEquatable<TimeSpanCastFunctionExpression>
    {
        #region constructors
        public TimeSpanCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType)
        {

        }
        #endregion

        #region as
        public TimeSpanElement As(string alias)
            => new TimeSpanSelectExpression(this).As(alias);
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

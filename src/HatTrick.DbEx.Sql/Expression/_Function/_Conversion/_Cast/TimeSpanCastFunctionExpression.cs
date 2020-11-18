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
            : base(expression, convertToDbType, typeof(TimeSpan))
        {

        }

        protected TimeSpanCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, int? size, int? precision, int? scale, string alias)
            : base(expression, convertToDbType, typeof(TimeSpan), size, precision, scale, alias)
        {

        }
        #endregion

        #region as
        public TimeSpanElement As(string alias)
            => new TimeSpanCastFunctionExpression(base.Expression, base.ConvertToDbType, base.Size, base.Precision, base.Scale, alias);
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

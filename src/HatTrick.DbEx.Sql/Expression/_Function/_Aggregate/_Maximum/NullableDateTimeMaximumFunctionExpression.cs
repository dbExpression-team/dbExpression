using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeMaximumFunctionExpression :
        NullableMaximumFunctionExpression<DateTime,DateTime?>,
        NullDateTimeElement,
        AnyDateTimeElement,
        IEquatable<NullableDateTimeMaximumFunctionExpression>
    {
        #region constructors
        public NullableDateTimeMaximumFunctionExpression(NullDateTimeElement expression, bool isDistinct) 
            : base(expression, isDistinct)
        {

        }

        protected NullableDateTimeMaximumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias)
            : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullDateTimeElement As(string alias)
            => new NullableDateTimeMaximumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(NullableDateTimeMaximumFunctionExpression obj)
            => obj is NullableDateTimeMaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeMaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

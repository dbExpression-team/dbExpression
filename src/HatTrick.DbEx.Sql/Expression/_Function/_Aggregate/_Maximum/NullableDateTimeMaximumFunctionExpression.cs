using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeMaximumFunctionExpression :
        NullableMaximumFunctionExpression<DateTime>,
        IEquatable<NullableDateTimeMaximumFunctionExpression>
    {
        #region constructors
        public NullableDateTimeMaximumFunctionExpression(NullableExpressionMediator<DateTime> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableDateTimeMaximumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
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

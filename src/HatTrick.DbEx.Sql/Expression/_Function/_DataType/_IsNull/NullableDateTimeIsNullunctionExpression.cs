using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeIsNullFunctionExpression :
        NullableIsNullFunctionExpression<DateTime>,
        IEquatable<NullableDateTimeIsNullFunctionExpression>
    {
        #region constructors
        public NullableDateTimeIsNullFunctionExpression(NullableExpressionMediator<DateTime> expression, ExpressionMediator<DateTime> value) : base(expression, value)
        {
        }
        #endregion

        #region as
        public new NullableDateTimeIsNullFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDateTimeIsNullFunctionExpression obj)
            => obj is NullableDateTimeIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

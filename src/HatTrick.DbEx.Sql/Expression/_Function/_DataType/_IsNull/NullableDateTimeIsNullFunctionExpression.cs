using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeIsNullFunctionExpression :
        NullableIsNullFunctionExpression<DateTime,DateTime?>,
        NullableDateTimeElement,
        AnyDateTimeElement,
        IEquatable<NullableDateTimeIsNullFunctionExpression>
    {
        #region constructors
        public NullableDateTimeIsNullFunctionExpression(AnyDateTimeElement expression, NullableDateTimeElement value)
            : base(expression, value)
        {

        }
        #endregion

        #region as
        public NullableDateTimeElement As(string alias)
        {
            Alias = alias;
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

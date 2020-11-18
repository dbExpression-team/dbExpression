using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeIsNullFunctionExpression :
        NullableIsNullFunctionExpression<DateTime,DateTime?>,
        NullDateTimeElement,
        AnyDateTimeElement,
        IEquatable<NullableDateTimeIsNullFunctionExpression>
    {
        #region constructors
        public NullableDateTimeIsNullFunctionExpression(AnyDateTimeElement expression, NullDateTimeElement value)
            : base(expression, value)
        {

        }

        protected NullableDateTimeIsNullFunctionExpression(IExpressionElement expression, IExpressionElement value, string alias)
            : base(expression, value, alias)
        {

        }
        #endregion

        #region as
        public NullDateTimeElement As(string alias)
            => new NullableDateTimeIsNullFunctionExpression(base.Expression, base.Value, alias);
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

using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeMaximumFunctionExpression :
        NullableMaximumFunctionExpression<DateTime,DateTime?>,
        NullableDateTimeElement,
        AnyDateTimeElement,
        IEquatable<NullableDateTimeMaximumFunctionExpression>
    {
        #region constructors
        public NullableDateTimeMaximumFunctionExpression(NullableDateTimeElement expression) 
            : base(expression)
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

        #region distinct
        public NullableDateTimeMaximumFunctionExpression Distinct()
        {
            IsDistinct = true;
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

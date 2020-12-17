using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeMinimumFunctionExpression :
        NullableMinimumFunctionExpression<DateTime,DateTime?>,
        NullableDateTimeElement,
        AnyDateTimeElement,
        IEquatable<NullableDateTimeMinimumFunctionExpression>
    {
        #region constructors
        public NullableDateTimeMinimumFunctionExpression(NullableDateTimeElement expression) 
            : base(expression)
        {

        }
        #endregion

        #region as
        public NullableDateTimeElement As(string alias)
            => new NullableDateTimeSelectExpression(this).As(alias);
        #endregion
        #region distinct
        public NullableDateTimeMinimumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDateTimeMinimumFunctionExpression obj)
            => obj is NullableDateTimeMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

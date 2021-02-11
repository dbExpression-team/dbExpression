using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class DateTimeOffsetFieldExpression : 
        FieldExpression<DateTimeOffset>,
        DateTimeOffsetElement,
        AnyDateTimeOffsetElement,
        IEquatable<DateTimeOffsetFieldExpression>
    {
        #region constructors
        protected DateTimeOffsetFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, typeof(DateTimeOffset), entity)
        {

        }
        #endregion

        #region as
        public abstract DateTimeOffsetElement As(string alias);
        #endregion

        #region equals
        public bool Equals(DateTimeOffsetFieldExpression obj)
            => obj is DateTimeOffsetFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DateTimeOffsetFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

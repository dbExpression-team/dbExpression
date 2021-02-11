using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableDateTimeOffsetFieldExpression : 
        NullableFieldExpression<DateTimeOffset,DateTimeOffset?>,
        NullableDateTimeOffsetElement,
        AnyDateTimeOffsetElement,
        IEquatable<NullableDateTimeOffsetFieldExpression>
    {
        #region constructors
        protected NullableDateTimeOffsetFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public abstract NullableDateTimeOffsetElement As(string alias);
        #endregion

        #region equals
        public bool Equals(NullableDateTimeOffsetFieldExpression obj)
            => obj is NullableDateTimeOffsetFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeOffsetFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

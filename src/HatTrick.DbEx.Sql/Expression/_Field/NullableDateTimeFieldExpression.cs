using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableDateTimeFieldExpression : 
        NullableFieldExpression<DateTime,DateTime?>,
        NullableDateTimeElement,
        AnyDateTimeElement,
        IEquatable<NullableDateTimeFieldExpression>
    {
        #region constructors
        protected NullableDateTimeFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public abstract NullableDateTimeElement As(string alias);
        #endregion

        #region equals
        public bool Equals(NullableDateTimeFieldExpression obj)
            => obj is NullableDateTimeFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

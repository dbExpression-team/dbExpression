using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableDateTimeOffsetFieldExpression : 
        NullableFieldExpression<DateTimeOffset>,
        IEquatable<NullableDateTimeOffsetFieldExpression>
    {
        #region constructors
        protected NullableDateTimeOffsetFieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        protected NullableDateTimeOffsetFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
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

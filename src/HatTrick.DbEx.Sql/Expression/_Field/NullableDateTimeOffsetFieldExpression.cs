using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableDateTimeOffsetFieldExpression : 
        NullableFieldExpression<DateTimeOffset>,
        IEquatable<NullableDateTimeOffsetFieldExpression>
    {
        #region constructors
        protected NullableDateTimeOffsetFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {

        }

        protected NullableDateTimeOffsetFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
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

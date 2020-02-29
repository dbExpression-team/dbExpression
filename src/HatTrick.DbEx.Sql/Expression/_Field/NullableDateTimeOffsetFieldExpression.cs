using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableDateTimeOffsetFieldExpression : 
        NullableFieldExpression<DateTimeOffset>,
        IEquatable<NullableDateTimeOffsetFieldExpression>
    {
        #region constructors
        protected NullableDateTimeOffsetFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(identifier, entity, metadata)
        {

        }

        protected NullableDateTimeOffsetFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(identifier, entity, metadata, alias)
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

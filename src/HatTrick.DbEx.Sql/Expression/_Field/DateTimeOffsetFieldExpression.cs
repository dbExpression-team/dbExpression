using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class DateTimeOffsetFieldExpression : 
        FieldExpression<DateTimeOffset>,
        IEquatable<DateTimeOffsetFieldExpression>
    {
        #region constructors
        protected DateTimeOffsetFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {

        }

        protected DateTimeOffsetFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {

        }
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

using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class DateTimeOffsetFieldExpression : 
        FieldExpression<DateTimeOffset>,
        IEquatable<DateTimeOffsetFieldExpression>
    {
        #region constructors
        protected DateTimeOffsetFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(identifier, entity, metadata)
        {

        }

        protected DateTimeOffsetFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(identifier, entity, metadata, alias)
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

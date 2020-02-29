using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableDateTimeFieldExpression : 
        NullableFieldExpression<DateTime>,
        IEquatable<NullableDateTimeFieldExpression>
    {
        #region constructors
        protected NullableDateTimeFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {

        }

        protected NullableDateTimeFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {

        }
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

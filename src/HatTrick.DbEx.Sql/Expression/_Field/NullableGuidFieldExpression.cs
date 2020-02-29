using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableGuidFieldExpression : 
        NullableFieldExpression<Guid>,
        IEquatable<NullableGuidFieldExpression>
    {
        #region constructors
        protected NullableGuidFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {

        }

        protected NullableGuidFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(NullableGuidFieldExpression obj)
            => obj is NullableGuidFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableGuidFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

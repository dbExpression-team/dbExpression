using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class GuidFieldExpression : 
        FieldExpression<Guid>,
        IEquatable<GuidFieldExpression>
    {
        #region constructors
        protected GuidFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {

        }

        protected GuidFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(GuidFieldExpression obj)
            => obj is GuidFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is GuidFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

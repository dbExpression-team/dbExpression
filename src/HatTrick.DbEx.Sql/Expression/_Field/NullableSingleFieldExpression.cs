using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableSingleFieldExpression : 
        NullableFieldExpression<float>,
        IEquatable<NullableSingleFieldExpression>
    {
        #region constructors
        protected NullableSingleFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(identifier, entity, metadata)
        {

        }

        protected NullableSingleFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(identifier, entity, metadata, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(NullableSingleFieldExpression obj)
            => obj is NullableSingleFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

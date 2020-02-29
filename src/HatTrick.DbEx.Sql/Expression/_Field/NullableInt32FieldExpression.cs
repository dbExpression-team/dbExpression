using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableInt32FieldExpression : 
        NullableFieldExpression<int>,
        IEquatable<NullableInt32FieldExpression>
    {
        #region constructors
        protected NullableInt32FieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(identifier, entity, metadata)
        {

        }

        protected NullableInt32FieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(identifier, entity, metadata, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(NullableInt32FieldExpression obj)
            => obj is NullableInt32FieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt32FieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableByteFieldExpression : 
        NullableFieldExpression<byte>,
        IEquatable<NullableByteFieldExpression>
    {
        #region constructors
        protected NullableByteFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {

        }

        protected NullableByteFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(NullableByteFieldExpression obj)
            => obj is NullableByteFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableByteFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

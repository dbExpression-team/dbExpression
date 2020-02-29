using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class ByteFieldExpression : 
        FieldExpression<byte>,
        IEquatable<ByteFieldExpression>
    {
        #region constructors
        protected ByteFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {

        }

        protected ByteFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(ByteFieldExpression obj)
            => obj is ByteFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ByteFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

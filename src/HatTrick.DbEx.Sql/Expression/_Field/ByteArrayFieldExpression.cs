using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class ByteArrayFieldExpression : 
        FieldExpression<byte[]>,
        IEquatable<ByteArrayFieldExpression>
    {
        #region constructors
        protected ByteArrayFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {
        }

        protected ByteArrayFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {
        }
        #endregion

        #region as
        public new ByteArrayFieldExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(ByteArrayFieldExpression obj)
            => obj is ByteArrayFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ByteArrayFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

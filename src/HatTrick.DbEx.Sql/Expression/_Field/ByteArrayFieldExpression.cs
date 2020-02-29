using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class ByteArrayFieldExpression : 
        FieldExpression<byte[]>,
        IEquatable<ByteArrayFieldExpression>
    {
        #region constructors
        protected ByteArrayFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(identifier, entity, metadata)
        {
        }

        protected ByteArrayFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(identifier, entity, metadata, alias)
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

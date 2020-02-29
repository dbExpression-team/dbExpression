using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class ByteFieldExpression : 
        FieldExpression<byte>,
        IEquatable<ByteFieldExpression>
    {
        #region constructors
        protected ByteFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(identifier, entity, metadata)
        {

        }

        protected ByteFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(identifier, entity, metadata, alias)
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

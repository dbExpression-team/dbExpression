using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class Int64FieldExpression : 
        FieldExpression<long>,
        IEquatable<Int64FieldExpression>
    {
        #region constructors
        protected Int64FieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {

        }

        protected Int64FieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(Int64FieldExpression obj)
            => obj is Int64FieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int64FieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

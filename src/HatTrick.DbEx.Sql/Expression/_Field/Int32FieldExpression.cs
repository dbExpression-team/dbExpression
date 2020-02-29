using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class Int32FieldExpression : 
        FieldExpression<int>,
        IEquatable<Int32FieldExpression>
    {
        #region constructors
        protected Int32FieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(identifier, entity, metadata)
        {

        }

        protected Int32FieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(identifier, entity, metadata, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(Int32FieldExpression obj)
            => obj is Int32FieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int32FieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

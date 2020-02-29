using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class Int16FieldExpression : 
        FieldExpression<short>,
        IEquatable<Int16FieldExpression>
    {
        #region constructors
        protected Int16FieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {

        }

        protected Int16FieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(Int16FieldExpression obj)
            => obj is Int16FieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int16FieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

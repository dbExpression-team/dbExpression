using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableInt16FieldExpression : 
        NullableFieldExpression<short>,
        IEquatable<NullableInt16FieldExpression>
    {
        #region constructors
        protected NullableInt16FieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {

        }

        protected NullableInt16FieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(NullableInt16FieldExpression obj)
            => obj is NullableInt16FieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt16FieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

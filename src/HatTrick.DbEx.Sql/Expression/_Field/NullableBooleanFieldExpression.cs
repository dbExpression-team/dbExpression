using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableBooleanFieldExpression : 
        NullableFieldExpression<bool>,
        IEquatable<NullableBooleanFieldExpression>
    {
        #region constructors
        protected NullableBooleanFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {

        }

        protected NullableBooleanFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(NullableBooleanFieldExpression obj)
            => obj is NullableBooleanFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableBooleanFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

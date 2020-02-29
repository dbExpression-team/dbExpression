using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableDoubleFieldExpression : 
        NullableFieldExpression<double>,
        IEquatable<NullableDoubleFieldExpression>
    {
        #region constructors
        protected NullableDoubleFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {

        }

        protected NullableDoubleFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(NullableDoubleFieldExpression obj)
            => obj is NullableDoubleFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDoubleFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

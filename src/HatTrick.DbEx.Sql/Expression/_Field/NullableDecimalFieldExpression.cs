using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableDecimalFieldExpression : 
        NullableFieldExpression<decimal>,
        IEquatable<NullableDecimalFieldExpression>
    {
        #region constructors
        protected NullableDecimalFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {

        }

        protected NullableDecimalFieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(NullableDecimalFieldExpression obj)
            => obj is NullableDecimalFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDecimalFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

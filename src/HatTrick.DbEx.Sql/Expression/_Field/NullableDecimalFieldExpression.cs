using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableDecimalFieldExpression : 
        NullableFieldExpression<decimal>,
        IEquatable<NullableDecimalFieldExpression>
    {
        #region constructors
        protected NullableDecimalFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(identifier, entity, metadata)
        {

        }

        protected NullableDecimalFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(identifier, entity, metadata, alias)
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

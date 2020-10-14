using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteArrayFieldExpression<TEntity> :
        NullableByteArrayFieldExpression,
        IEquatable<NullableByteArrayFieldExpression<TEntity>>
        where TEntity : IDbEntity
    {
        #region constructors
        public NullableByteArrayFieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        private NullableByteArrayFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion

        #region as
        public NullableByteArrayFieldExpression<TEntity> As(string alias)
            => new NullableByteArrayFieldExpression<TEntity>(base.identifier, base.entity, alias);
        #endregion

        #region equals
        public bool Equals(NullableByteArrayFieldExpression<TEntity> obj)
            => obj is NullableByteArrayFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableByteArrayFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

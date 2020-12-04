using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteArrayFieldExpression<TEntity> :
        NullableByteArrayFieldExpression,
        IEquatable<NullableByteArrayFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public NullableByteArrayFieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        protected NullableByteArrayFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion

        #region as
        public override NullableByteArrayElement As(string alias)
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

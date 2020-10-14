using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableStringFieldExpression<TEntity> :
        NullableStringFieldExpression,
        IEquatable<NullableStringFieldExpression<TEntity>>
        where TEntity : IDbEntity
    {
        #region constructors
        public NullableStringFieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        private NullableStringFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion

        #region as
        public NullableStringFieldExpression<TEntity> As(string alias)
            => new NullableStringFieldExpression<TEntity>(base.identifier, base.entity, alias);
        #endregion

        #region equals
        public bool Equals(NullableStringFieldExpression<TEntity> obj)
            => obj is NullableStringFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableStringFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

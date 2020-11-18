using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableGuidFieldExpression<TEntity> : 
        NullableGuidFieldExpression,
        IEquatable<NullableGuidFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public NullableGuidFieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        private NullableGuidFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion

        #region as
        public override NullGuidElement As(string alias)
            => new NullableGuidFieldExpression<TEntity>(base.identifier, base.entity, alias);
        #endregion

        #region equals
        public bool Equals(NullableGuidFieldExpression<TEntity> obj)
            => obj is NullableGuidFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableGuidFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class GuidFieldExpression<TEntity> : 
        GuidFieldExpression,
        IEquatable<GuidFieldExpression<TEntity>>
        where TEntity : IDbEntity
    {
        #region constructors
        public GuidFieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        private GuidFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion
        
        #region as
        public GuidFieldExpression<TEntity> As(string alias)
            => new GuidFieldExpression<TEntity>(base.identifier, base.entity, alias);
        #endregion

        #region equals
        public bool Equals(GuidFieldExpression<TEntity> obj)
            => obj is GuidFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is GuidFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

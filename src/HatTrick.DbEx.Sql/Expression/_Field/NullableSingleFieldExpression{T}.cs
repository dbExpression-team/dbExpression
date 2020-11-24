using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleFieldExpression<TEntity> : 
        NullableSingleFieldExpression,
        IEquatable<NullableSingleFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public NullableSingleFieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        private NullableSingleFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion

        #region as
        public override NullableSingleElement As(string alias)
            => new NullableSingleFieldExpression<TEntity>(base.identifier, base.entity, alias);
        #endregion

        #region equals
        public bool Equals(NullableSingleFieldExpression<TEntity> obj)
            => obj is NullableSingleFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

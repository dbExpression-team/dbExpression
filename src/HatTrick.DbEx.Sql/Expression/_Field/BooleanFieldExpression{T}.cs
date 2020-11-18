using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class BooleanFieldExpression<TEntity> : 
        BooleanFieldExpression,
        IEquatable<BooleanFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public BooleanFieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        private BooleanFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion

        #region as
        public override BooleanElement As(string alias)
            => new BooleanFieldExpression<TEntity>(base.identifier, base.entity, alias);
        #endregion

        #region equals
        public bool Equals(BooleanFieldExpression<TEntity> obj)
            => obj is BooleanFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is BooleanFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleFieldExpression<TEntity> : 
        SingleFieldExpression,
        IEquatable<SingleFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public SingleFieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        private SingleFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion

        #region as
        public override SingleElement As(string alias)
            => new SingleFieldExpression<TEntity>(base.identifier, base.entity, alias);
        #endregion

        #region equals
        public bool Equals(SingleFieldExpression<TEntity> obj)
            => obj is SingleFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

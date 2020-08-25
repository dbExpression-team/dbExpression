using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DoubleFieldExpression<TEntity> : 
        DoubleFieldExpression,
        IEquatable<DoubleFieldExpression<TEntity>>
        where TEntity : IDbEntity
    {
        #region constructors
        public DoubleFieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        private DoubleFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion
        
        #region as
        public DoubleFieldExpression<TEntity> As(string alias)
            => new DoubleFieldExpression<TEntity>(base.identifier, base.entity, alias);
        #endregion

        #region equals
        public bool Equals(DoubleFieldExpression<TEntity> obj)
            => obj is DoubleFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DoubleFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

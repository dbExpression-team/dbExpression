using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DecimalFieldExpression<TEntity> : 
        DecimalFieldExpression,
        IEquatable<DecimalFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public DecimalFieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        protected DecimalFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion

        #region as
        public override DecimalElement As(string alias)
            => new DecimalFieldExpression<TEntity>(base.identifier, base.entity, alias);
        #endregion

        #region equals
        public bool Equals(DecimalFieldExpression<TEntity> obj)
            => obj is DecimalFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DecimalFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

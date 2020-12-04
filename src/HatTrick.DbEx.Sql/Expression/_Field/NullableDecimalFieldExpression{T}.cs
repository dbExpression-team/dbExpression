using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDecimalFieldExpression<TEntity> : 
        NullableDecimalFieldExpression,
        IEquatable<NullableDecimalFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public NullableDecimalFieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        protected NullableDecimalFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion

        #region as
        public override NullableDecimalElement As(string alias)
            => new NullableDecimalFieldExpression<TEntity>(base.identifier, base.entity, alias);
        #endregion

        #region equals
        public bool Equals(NullableDecimalFieldExpression<TEntity> obj)
            => obj is NullableDecimalFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDecimalFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

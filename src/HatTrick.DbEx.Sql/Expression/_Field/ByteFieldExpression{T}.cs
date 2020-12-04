using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ByteFieldExpression<TEntity> : 
        ByteFieldExpression,
        IEquatable<ByteFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public ByteFieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        protected ByteFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion

        #region as
        public override ByteElement As(string alias)
            => new ByteFieldExpression<TEntity>(base.identifier, base.entity, alias);
        #endregion

        #region equals
        public bool Equals(ByteFieldExpression<TEntity> obj)
            => obj is ByteFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ByteFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

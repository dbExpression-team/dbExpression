using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteFieldExpression<TEntity> : 
        NullableByteFieldExpression,
        IEquatable<NullableByteFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public NullableByteFieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        private NullableByteFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion

        #region as
        public override NullableByteElement As(string alias)
            => new NullableByteFieldExpression<TEntity>(base.identifier, base.entity, alias);
        #endregion

        #region equals
        public bool Equals(NullableByteFieldExpression<TEntity> obj)
            => obj is NullableByteFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableByteFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

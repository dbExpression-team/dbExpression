using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt32FieldExpression<TEntity> : 
        NullableInt32FieldExpression,
        IEquatable<NullableInt32FieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public NullableInt32FieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        private NullableInt32FieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion

        #region as
        public override NullInt32Element As(string alias)
            => new NullableInt32FieldExpression<TEntity>(base.identifier, base.entity, alias);
        #endregion

        #region equals
        public bool Equals(NullableInt32FieldExpression<TEntity> obj)
            => obj is NullableInt32FieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt32FieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

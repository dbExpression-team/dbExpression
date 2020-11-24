using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt16FieldExpression<TEntity> : 
        NullableInt16FieldExpression,
        IEquatable<NullableInt16FieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public NullableInt16FieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        private NullableInt16FieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion

        #region as
        public override NullableInt16Element As(string alias)
            => new NullableInt16FieldExpression<TEntity>(base.identifier, base.entity, alias);
        #endregion

        #region equals
        public bool Equals(NullableInt16FieldExpression<TEntity> obj)
            => obj is NullableInt16FieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt16FieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

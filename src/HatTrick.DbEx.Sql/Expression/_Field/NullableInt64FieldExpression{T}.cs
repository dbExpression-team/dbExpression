using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64FieldExpression<TEntity> : 
        NullableInt64FieldExpression,
        IEquatable<NullableInt64FieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public NullableInt64FieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public override NullableInt64Element As(string alias)
            => new NullableInt64SelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableInt64FieldExpression<TEntity> obj)
            => obj is NullableInt64FieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt64FieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

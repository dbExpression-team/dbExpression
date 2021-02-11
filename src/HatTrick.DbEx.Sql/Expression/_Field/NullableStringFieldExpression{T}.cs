using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableStringFieldExpression<TEntity> :
        NullableStringFieldExpression,
        IEquatable<NullableStringFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public NullableStringFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public override NullableStringElement As(string alias)
            => new NullableStringSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableStringFieldExpression<TEntity> obj)
            => obj is NullableStringFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableStringFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

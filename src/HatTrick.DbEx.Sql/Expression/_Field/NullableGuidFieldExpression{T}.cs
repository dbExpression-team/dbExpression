using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableGuidFieldExpression<TEntity> : 
        NullableGuidFieldExpression,
        IEquatable<NullableGuidFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public NullableGuidFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public override NullableGuidElement As(string alias)
            => new NullableGuidSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableGuidFieldExpression<TEntity> obj)
            => obj is NullableGuidFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableGuidFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class GuidFieldExpression<TEntity> : 
        GuidFieldExpression,
        IEquatable<GuidFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public GuidFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public override GuidElement As(string alias) 
            => new GuidSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(GuidFieldExpression<TEntity> obj)
            => obj is GuidFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is GuidFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleFieldExpression<TEntity> : 
        NullableSingleFieldExpression,
        IEquatable<NullableSingleFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public NullableSingleFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public override NullableSingleElement As(string alias)
            => new NullableSingleSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableSingleFieldExpression<TEntity> obj)
            => obj is NullableSingleFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

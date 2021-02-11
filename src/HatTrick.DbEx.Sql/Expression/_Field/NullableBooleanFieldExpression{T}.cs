using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableBooleanFieldExpression<TEntity> : 
        NullableBooleanFieldExpression,
        IEquatable<NullableBooleanFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public NullableBooleanFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public override NullableBooleanElement As(string alias)
            => new NullableBooleanSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableBooleanFieldExpression<TEntity> obj)
            => obj is NullableBooleanFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableBooleanFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

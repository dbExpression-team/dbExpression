using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class BooleanFieldExpression<TEntity> : 
        BooleanFieldExpression,
        IEquatable<BooleanFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public BooleanFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public override BooleanElement As(string alias)
            => new BooleanSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(BooleanFieldExpression<TEntity> obj)
            => obj is BooleanFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is BooleanFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

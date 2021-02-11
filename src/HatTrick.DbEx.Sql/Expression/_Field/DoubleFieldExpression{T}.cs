using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DoubleFieldExpression<TEntity> : 
        DoubleFieldExpression,
        IEquatable<DoubleFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public DoubleFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public override DoubleElement As(string alias)
            => new DoubleSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(DoubleFieldExpression<TEntity> obj)
            => obj is DoubleFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DoubleFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

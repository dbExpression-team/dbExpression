using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleFieldExpression<TEntity> : 
        SingleFieldExpression,
        IEquatable<SingleFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public SingleFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public override SingleElement As(string alias)
            => new SingleSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(SingleFieldExpression<TEntity> obj)
            => obj is SingleFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

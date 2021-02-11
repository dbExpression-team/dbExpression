using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DecimalFieldExpression<TEntity> : 
        DecimalFieldExpression,
        IEquatable<DecimalFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public DecimalFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public override DecimalElement As(string alias)
            => new DecimalSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(DecimalFieldExpression<TEntity> obj)
            => obj is DecimalFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DecimalFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

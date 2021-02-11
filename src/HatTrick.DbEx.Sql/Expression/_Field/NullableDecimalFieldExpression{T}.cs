using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDecimalFieldExpression<TEntity> : 
        NullableDecimalFieldExpression,
        IEquatable<NullableDecimalFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public NullableDecimalFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public override NullableDecimalElement As(string alias)
            => new NullableDecimalSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableDecimalFieldExpression<TEntity> obj)
            => obj is NullableDecimalFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDecimalFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

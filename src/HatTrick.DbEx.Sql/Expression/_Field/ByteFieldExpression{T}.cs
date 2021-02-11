using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ByteFieldExpression<TEntity> : 
        ByteFieldExpression,
        IEquatable<ByteFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public ByteFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public override ByteElement As(string alias)
            => new ByteSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(ByteFieldExpression<TEntity> obj)
            => obj is ByteFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ByteFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

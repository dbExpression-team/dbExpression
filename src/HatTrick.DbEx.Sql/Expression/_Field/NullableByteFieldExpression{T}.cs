using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteFieldExpression<TEntity> : 
        NullableByteFieldExpression,
        IEquatable<NullableByteFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public NullableByteFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public override NullableByteElement As(string alias)
            => new NullableByteSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableByteFieldExpression<TEntity> obj)
            => obj is NullableByteFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableByteFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

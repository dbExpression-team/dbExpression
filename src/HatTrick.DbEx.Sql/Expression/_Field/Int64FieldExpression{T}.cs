using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int64FieldExpression<TEntity> : 
        Int64FieldExpression,
        IEquatable<Int64FieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public Int64FieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public override Int64Element As(string alias)
            => new Int64SelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(Int64FieldExpression<TEntity> obj)
            => obj is Int64FieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int64FieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

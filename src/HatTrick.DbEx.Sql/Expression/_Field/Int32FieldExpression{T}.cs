using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int32FieldExpression<TEntity> : 
        Int32FieldExpression,
        IEquatable<Int32FieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public Int32FieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public override Int32Element As(string alias)
            => new Int32SelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(Int32FieldExpression<TEntity> obj)
            => obj is Int32FieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int32FieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

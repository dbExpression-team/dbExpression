using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int16FieldExpression<TEntity> : 
        Int16FieldExpression,
        IEquatable<Int16FieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public Int16FieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public override Int16Element As(string alias)
            => new Int16SelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(Int16FieldExpression<TEntity> obj)
            => obj is Int16FieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int16FieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

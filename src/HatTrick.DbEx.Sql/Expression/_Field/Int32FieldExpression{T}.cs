using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int32FieldExpression<TEntity> : 
        Int32FieldExpression,
        IEquatable<Int32FieldExpression<TEntity>>
        where TEntity : IDbEntity
    {
        #region constructors
        public Int32FieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        private Int32FieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion
        
        #region as
        public Int32FieldExpression<TEntity> As(string alias)
            => new Int32FieldExpression<TEntity>(base.identifier, base.entity, alias);
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

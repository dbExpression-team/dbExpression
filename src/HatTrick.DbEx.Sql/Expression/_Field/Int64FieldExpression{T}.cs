using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int64FieldExpression<TEntity> : 
        Int64FieldExpression,
        IEquatable<Int64FieldExpression<TEntity>>
        where TEntity : IDbEntity
    {
        #region constructors
        public Int64FieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        private Int64FieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion
        
        #region as
        public Int64FieldExpression<TEntity> As(string alias)
            => new Int64FieldExpression<TEntity>(base.identifier, base.entity, alias);
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

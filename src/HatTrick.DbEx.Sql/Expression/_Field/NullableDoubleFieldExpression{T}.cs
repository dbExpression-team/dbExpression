using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleFieldExpression<TEntity> : 
        NullableDoubleFieldExpression,
        IEquatable<NullableDoubleFieldExpression<TEntity>>
        where TEntity : IDbEntity
    {
        #region constructors
        public NullableDoubleFieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        private NullableDoubleFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion
        
        #region as
        public NullableDoubleFieldExpression<TEntity> As(string alias)
            => new NullableDoubleFieldExpression<TEntity>(base.identifier, base.entity, alias);
        #endregion

        #region equals
        public bool Equals(NullableDoubleFieldExpression<TEntity> obj)
            => obj is NullableDoubleFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDoubleFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

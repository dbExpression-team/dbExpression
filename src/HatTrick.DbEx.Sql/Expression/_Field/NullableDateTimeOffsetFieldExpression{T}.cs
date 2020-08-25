using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeOffsetFieldExpression<TEntity> : 
        NullableDateTimeOffsetFieldExpression,
        IEquatable<NullableDateTimeOffsetFieldExpression<TEntity>>
        where TEntity : IDbEntity
    {
        #region constructors
        public NullableDateTimeOffsetFieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        private NullableDateTimeOffsetFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion
        
        #region as
        public NullableDateTimeOffsetFieldExpression<TEntity> As(string alias)
            => new NullableDateTimeOffsetFieldExpression<TEntity>(base.identifier, base.entity, alias);
        #endregion

        #region equals
        public bool Equals(NullableDateTimeOffsetFieldExpression<TEntity> obj)
            => obj is NullableDateTimeOffsetFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeOffsetFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

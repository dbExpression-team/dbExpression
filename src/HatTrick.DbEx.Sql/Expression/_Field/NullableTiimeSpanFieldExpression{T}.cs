using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableTimeSpanFieldExpression<TEntity> : 
        NullableTimeSpanFieldExpression,
        IEquatable<NullableTimeSpanFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public NullableTimeSpanFieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        private NullableTimeSpanFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion

        #region as
        public override NullTimeSpanElement As(string alias)
            => new NullableTimeSpanFieldExpression<TEntity>(base.identifier, base.entity, alias);
        #endregion

        #region equals
        public bool Equals(NullableTimeSpanFieldExpression<TEntity> obj)
            => obj is NullableTimeSpanFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableTimeSpanFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

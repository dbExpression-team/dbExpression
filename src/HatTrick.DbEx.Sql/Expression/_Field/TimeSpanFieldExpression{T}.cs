using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class TimeSpanFieldExpression<TEntity> : 
        TimeSpanFieldExpression,
        IEquatable<TimeSpanFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public TimeSpanFieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        private TimeSpanFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion

        #region as
        public override TimeSpanElement As(string alias)
            => new TimeSpanFieldExpression<TEntity>(base.identifier, base.entity, alias);
        #endregion

        #region equals
        public bool Equals(TimeSpanFieldExpression<TEntity> obj)
            => obj is TimeSpanFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is TimeSpanFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

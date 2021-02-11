using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableTimeSpanFieldExpression<TEntity> : 
        NullableTimeSpanFieldExpression,
        IEquatable<NullableTimeSpanFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public NullableTimeSpanFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public override NullableTimeSpanElement As(string alias)
            => new NullableTimeSpanSelectExpression(this).As(alias);
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

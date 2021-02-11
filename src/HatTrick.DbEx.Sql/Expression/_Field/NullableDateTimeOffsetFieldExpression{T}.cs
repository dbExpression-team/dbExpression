using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeOffsetFieldExpression<TEntity> : 
        NullableDateTimeOffsetFieldExpression,
        IEquatable<NullableDateTimeOffsetFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public NullableDateTimeOffsetFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public override NullableDateTimeOffsetElement As(string alias)
            => new NullableDateTimeOffsetSelectExpression(this).As(alias);
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

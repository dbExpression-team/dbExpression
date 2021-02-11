using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeFieldExpression<TEntity> : 
        NullableDateTimeFieldExpression,
        IEquatable<NullableDateTimeFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public NullableDateTimeFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public override NullableDateTimeElement As(string alias)
            => new NullableDateTimeSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableDateTimeFieldExpression<TEntity> obj)
            => obj is NullableDateTimeFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

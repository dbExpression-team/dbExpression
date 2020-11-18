using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableInt64FieldExpression : 
        NullableFieldExpression<long,long?>,
        NullInt64Element,
        AnyInt64Element,
        IEquatable<NullableInt64FieldExpression>
    {
        #region constructors
        protected NullableInt64FieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        protected NullableInt64FieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion

        #region as
        public abstract NullInt64Element As(string alias);
        #endregion

        #region equals
        public bool Equals(NullableInt64FieldExpression obj)
            => obj is NullableInt64FieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt64FieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

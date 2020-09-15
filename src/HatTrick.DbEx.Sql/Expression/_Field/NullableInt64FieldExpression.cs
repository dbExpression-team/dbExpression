using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableInt64FieldExpression : 
        NullableFieldExpression<long>,
        IEquatable<NullableInt64FieldExpression>
    {
        #region constructors
        protected NullableInt64FieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(long), entity)
        {

        }

        protected NullableInt64FieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(long), entity, alias)
        {

        }
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

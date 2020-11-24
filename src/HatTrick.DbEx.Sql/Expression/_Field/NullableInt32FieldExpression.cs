using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableInt32FieldExpression : 
        NullableFieldExpression<int,int?>,
        NullableInt32Element,
        AnyInt32Element,
        IEquatable<NullableInt32FieldExpression>
    {
        #region constructors
        protected NullableInt32FieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        protected NullableInt32FieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion

        #region as
        public abstract NullableInt32Element As(string alias);
        #endregion

        #region equals
        public bool Equals(NullableInt32FieldExpression obj)
            => obj is NullableInt32FieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt32FieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

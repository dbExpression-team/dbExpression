using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableInt16FieldExpression : 
        NullableFieldExpression<short,short?>,
        NullableInt16Element,
        AnyInt16Element,
        IEquatable<NullableInt16FieldExpression>
    {
        #region constructors
        protected NullableInt16FieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public abstract NullableInt16Element As(string alias);
        #endregion

        #region equals
        public bool Equals(NullableInt16FieldExpression obj)
            => obj is NullableInt16FieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt16FieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

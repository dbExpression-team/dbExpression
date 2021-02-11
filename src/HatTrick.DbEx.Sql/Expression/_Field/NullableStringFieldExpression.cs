using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableStringFieldExpression :
        FieldExpression<string>,
        NullableStringElement,
        AnyStringElement,
        IEquatable<NullableStringFieldExpression>
    {
        #region constructors
        protected NullableStringFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, typeof(string), entity)
        {

        }
        #endregion

        #region as
        public abstract NullableStringElement As(string alias);
        #endregion

        #region equals
        public bool Equals(NullableStringFieldExpression obj)
            => obj is NullableStringFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableStringFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

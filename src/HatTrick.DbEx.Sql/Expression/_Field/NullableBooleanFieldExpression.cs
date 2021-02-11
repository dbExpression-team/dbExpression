using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableBooleanFieldExpression : 
        NullableFieldExpression<bool,bool?>,
        NullableBooleanElement,
        AnyBooleanElement,
        IEquatable<NullableBooleanFieldExpression>
    {
        #region constructors
        protected NullableBooleanFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public abstract NullableBooleanElement As(string alias);
        #endregion

        #region equals
        public bool Equals(NullableBooleanFieldExpression obj)
            => obj is NullableBooleanFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableBooleanFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

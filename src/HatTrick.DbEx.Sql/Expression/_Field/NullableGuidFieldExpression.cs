using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableGuidFieldExpression : 
        NullableFieldExpression<Guid,Guid?>,
        NullableGuidElement,
        AnyGuidElement,
        IEquatable<NullableGuidFieldExpression>
    {
        #region constructors
        protected NullableGuidFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public abstract NullableGuidElement As(string alias);
        #endregion

        #region equals
        public bool Equals(NullableGuidFieldExpression obj)
            => obj is NullableGuidFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableGuidFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

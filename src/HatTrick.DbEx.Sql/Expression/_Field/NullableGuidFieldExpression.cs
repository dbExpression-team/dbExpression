using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableGuidFieldExpression : 
        NullableFieldExpression<Guid>,
        IEquatable<NullableGuidFieldExpression>
    {
        #region constructors
        protected NullableGuidFieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        protected NullableGuidFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
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

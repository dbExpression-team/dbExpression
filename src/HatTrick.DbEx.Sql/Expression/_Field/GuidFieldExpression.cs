using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class GuidFieldExpression : 
        FieldExpression<Guid>,
        GuidElement,
        AnyGuidElement,
        IEquatable<GuidFieldExpression>
    {
        #region constructors
        protected GuidFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, typeof(Guid), entity)
        {

        }
        #endregion

        #region as
        public abstract GuidElement As(string alias);
        #endregion

        #region equals
        public bool Equals(GuidFieldExpression obj)
            => obj is GuidFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is GuidFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

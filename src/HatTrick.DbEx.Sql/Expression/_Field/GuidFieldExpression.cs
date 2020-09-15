using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class GuidFieldExpression : 
        FieldExpression<Guid>,
        IEquatable<GuidFieldExpression>
    {
        #region constructors
        protected GuidFieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(Guid), entity)
        {

        }

        protected GuidFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(Guid), entity, alias)
        {

        }
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

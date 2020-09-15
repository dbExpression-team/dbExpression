using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class BooleanFieldExpression : 
        FieldExpression<bool>,
        IEquatable<BooleanFieldExpression>
    {
        #region constructors
        protected BooleanFieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(bool), entity)
        {

        }

        protected BooleanFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(bool), entity, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(BooleanFieldExpression obj)
            => obj is BooleanFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is BooleanFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

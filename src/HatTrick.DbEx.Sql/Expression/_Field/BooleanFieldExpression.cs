using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class BooleanFieldExpression : 
        FieldExpression<bool>,
        BooleanElement,
        AnyBooleanElement,
        IEquatable<BooleanFieldExpression>
    {
        #region constructors
        protected BooleanFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, typeof(bool), entity)
        {

        }
        #endregion

        #region as
        public abstract BooleanElement As(string alias);
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

using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class StringFieldExpression : 
        FieldExpression<string>,
        StringElement,
        AnyStringElement,
        IEquatable<StringFieldExpression>
    {
        #region constructors
        protected StringFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, typeof(string), entity)
        {

        }
        #endregion

        #region as
        public abstract StringElement As(string alias);
        #endregion

        #region equals
        public bool Equals(StringFieldExpression obj)
            => obj is StringFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is StringFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

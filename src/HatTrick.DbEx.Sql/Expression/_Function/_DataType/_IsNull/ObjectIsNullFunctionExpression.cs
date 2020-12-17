using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ObjectIsNullFunctionExpression :
        IsNullFunctionExpression<object>,
        ObjectElement,
        AnyObjectElement,
        IEquatable<ObjectIsNullFunctionExpression>
    {
        #region constructors
        public ObjectIsNullFunctionExpression(AnyObjectElement expression, AnyObjectElement value) : base(expression, value)
        {

        }
        #endregion

        #region as
        public ObjectElement As(string alias)
            => new ObjectSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(ObjectIsNullFunctionExpression obj)
            => obj is ObjectIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ObjectIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

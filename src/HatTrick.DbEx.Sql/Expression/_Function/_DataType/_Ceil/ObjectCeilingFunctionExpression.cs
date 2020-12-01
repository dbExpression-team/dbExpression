using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ObjectCeilingFunctionExpression :
        CeilingFunctionExpression<object>,
        ObjectElement,
        AnyObjectElement,
        IEquatable<ObjectCeilingFunctionExpression>
    {
        #region constructors
        public ObjectCeilingFunctionExpression(AnyObjectElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public ObjectElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(ObjectCeilingFunctionExpression obj)
            => obj is ObjectCeilingFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ObjectCeilingFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

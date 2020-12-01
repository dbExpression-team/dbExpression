using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ObjectFloorFunctionExpression :
        FloorFunctionExpression<object>,
        ObjectElement,
        AnyObjectElement,
        IEquatable<ObjectFloorFunctionExpression>
    {
        #region constructors
        public ObjectFloorFunctionExpression(AnyObjectElement expression) : base(expression)
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
        public bool Equals(ObjectFloorFunctionExpression obj)
            => obj is ObjectFloorFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ObjectFloorFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

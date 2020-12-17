using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ObjectMaximumFunctionExpression :
        MaximumFunctionExpression<object>,
        ObjectElement,
        AnyObjectElement,
        IEquatable<ObjectMaximumFunctionExpression>
    {
        #region constructors
        public ObjectMaximumFunctionExpression(AnyObjectElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public ObjectElement As(string alias)
            => new ObjectSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public ObjectMaximumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(ObjectMaximumFunctionExpression obj)
            => obj is ObjectMaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ObjectMaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

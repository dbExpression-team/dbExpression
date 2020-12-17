using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ObjectMinimumFunctionExpression :
        MinimumFunctionExpression<object>,
        ObjectElement,
        AnyObjectElement,
        IEquatable<ObjectMinimumFunctionExpression>
    {
        #region constructors
        public ObjectMinimumFunctionExpression(AnyObjectElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public ObjectElement As(string alias)
            => new ObjectSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public ObjectMinimumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(ObjectMinimumFunctionExpression obj)
            => obj is ObjectMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ObjectMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

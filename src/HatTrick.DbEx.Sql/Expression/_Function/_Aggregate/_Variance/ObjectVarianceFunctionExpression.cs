using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ObjectVarianceFunctionExpression :
        VarianceFunctionExpression<object>,
        ObjectElement,
        AnyObjectElement,
        IEquatable<ObjectVarianceFunctionExpression>
    {
        #region constructors
        public ObjectVarianceFunctionExpression(AnyObjectElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public ObjectElement As(string alias)
            => new ObjectSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public ObjectVarianceFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(ObjectVarianceFunctionExpression obj)
            => obj is ObjectVarianceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ObjectVarianceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ObjectStandardDeviationFunctionExpression :
        StandardDeviationFunctionExpression<object>,
        ObjectElement,
        AnyObjectElement,
        IEquatable<ObjectStandardDeviationFunctionExpression>
    {
        #region constructors
        public ObjectStandardDeviationFunctionExpression(AnyObjectElement expression) : base(expression)
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

        #region distinct
        public ObjectStandardDeviationFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(ObjectStandardDeviationFunctionExpression obj)
            => obj is ObjectStandardDeviationFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ObjectStandardDeviationFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

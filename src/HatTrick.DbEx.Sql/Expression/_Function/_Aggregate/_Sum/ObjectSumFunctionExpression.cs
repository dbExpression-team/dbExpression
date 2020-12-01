using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ObjectSumFunctionExpression :
        SumFunctionExpression<object>,
        ObjectElement,
        AnyObjectElement,
        IEquatable<ObjectSumFunctionExpression>
    {
        #region constructors
        public ObjectSumFunctionExpression(AnyObjectElement expression) : base(expression)
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
        public ObjectSumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(ObjectSumFunctionExpression obj)
            => obj is ObjectSumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ObjectSumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

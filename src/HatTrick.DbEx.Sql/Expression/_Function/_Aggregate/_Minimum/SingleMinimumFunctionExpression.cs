using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleMinimumFunctionExpression :
        MinimumFunctionExpression<float>,
        SingleElement,
        AnySingleElement,
        IEquatable<SingleMinimumFunctionExpression>
    {
        #region constructors
        public SingleMinimumFunctionExpression(SingleElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public SingleElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region distinct
        public SingleMinimumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(SingleMinimumFunctionExpression obj)
            => obj is SingleMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

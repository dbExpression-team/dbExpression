using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleMaximumFunctionExpression :
        MaximumFunctionExpression<float>,
        SingleElement,
        AnySingleElement,
        IEquatable<SingleMaximumFunctionExpression>
    {
        #region constructors
        public SingleMaximumFunctionExpression(SingleElement expression) : base(expression)
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
        public SingleMaximumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(SingleMaximumFunctionExpression obj)
            => obj is SingleMaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleMaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

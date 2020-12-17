using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DoubleMaximumFunctionExpression :
        MaximumFunctionExpression<double>,
        DoubleElement,
        AnyDoubleElement,
        IEquatable<DoubleMaximumFunctionExpression>
    {
        #region constructors
        public DoubleMaximumFunctionExpression(DoubleElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public DoubleElement As(string alias)
            => new DoubleSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public DoubleMaximumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DoubleMaximumFunctionExpression obj)
            => obj is DoubleMaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DoubleMaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

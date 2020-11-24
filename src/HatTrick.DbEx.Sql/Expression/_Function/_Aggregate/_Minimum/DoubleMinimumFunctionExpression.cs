using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DoubleMinimumFunctionExpression :
        MinimumFunctionExpression<double>,
        DoubleElement,
        AnyDoubleElement, 
        IEquatable<DoubleMinimumFunctionExpression>
    {
        #region constructors
        public DoubleMinimumFunctionExpression(DoubleElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public DoubleElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region distinct
        public DoubleMinimumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DoubleMinimumFunctionExpression obj)
            => obj is DoubleMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DoubleMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

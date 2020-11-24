using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DoubleSumFunctionExpression :
        SumFunctionExpression<double>,
        DoubleElement,
        AnyDoubleElement,
        IEquatable<DoubleSumFunctionExpression>
    {
        #region constructors
        public DoubleSumFunctionExpression(DoubleElement expression) : base(expression)
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
        public DoubleSumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DoubleSumFunctionExpression obj)
            => obj is DoubleSumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DoubleSumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

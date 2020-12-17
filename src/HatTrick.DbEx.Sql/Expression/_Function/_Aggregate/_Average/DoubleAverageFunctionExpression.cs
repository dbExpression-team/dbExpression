using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DoubleAverageFunctionExpression :
        AverageFunctionExpression<double>,
        DoubleElement,
        AnyDoubleElement,
        IEquatable<DoubleAverageFunctionExpression>
    {
        #region constructors
        public DoubleAverageFunctionExpression(DoubleElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public DoubleElement As(string alias)
            => new DoubleSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public DoubleAverageFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DoubleAverageFunctionExpression obj)
            => obj is DoubleAverageFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DoubleAverageFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

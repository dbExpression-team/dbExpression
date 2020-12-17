using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleSumFunctionExpression :
        SumFunctionExpression<float>,
        SingleElement,
        AnySingleElement,
        IEquatable<SingleSumFunctionExpression>
    {
        #region constructors
        public SingleSumFunctionExpression(SingleElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public SingleElement As(string alias)
            => new SingleSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public SingleSumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(SingleSumFunctionExpression obj)
            => obj is SingleSumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleSumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

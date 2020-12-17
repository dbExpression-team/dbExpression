using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleAverageFunctionExpression :
        AverageFunctionExpression<float>,
        SingleElement,
        AnySingleElement,
        IEquatable<SingleAverageFunctionExpression>
    {
        #region constructors
        public SingleAverageFunctionExpression(SingleElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public SingleElement As(string alias)
            => new SingleSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public SingleAverageFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(SingleAverageFunctionExpression obj)
            => obj is SingleAverageFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleAverageFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

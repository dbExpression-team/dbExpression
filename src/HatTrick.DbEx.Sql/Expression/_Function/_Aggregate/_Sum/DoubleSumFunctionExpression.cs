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
        public DoubleSumFunctionExpression(DoubleElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected DoubleSumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public DoubleElement As(string alias)
            => new DoubleSumFunctionExpression(base.Expression, base.IsDistinct, alias);
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

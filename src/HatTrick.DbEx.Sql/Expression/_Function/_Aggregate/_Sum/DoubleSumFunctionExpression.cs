using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DoubleSumFunctionExpression :
        SumFunctionExpression<double>,
        IEquatable<DoubleSumFunctionExpression>
    {
        #region constructors
        public DoubleSumFunctionExpression(ExpressionMediator<double> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new DoubleSumFunctionExpression As(string alias)
        {
            base.As(alias);
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

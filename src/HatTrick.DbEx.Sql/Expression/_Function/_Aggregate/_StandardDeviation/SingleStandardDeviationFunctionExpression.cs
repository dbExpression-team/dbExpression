using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleStandardDeviationFunctionExpression :
        StandardDeviationFunctionExpression<float>,
        IEquatable<SingleStandardDeviationFunctionExpression>
    {
        #region constructors
        public SingleStandardDeviationFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new SingleStandardDeviationFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(SingleStandardDeviationFunctionExpression obj)
            => obj is SingleStandardDeviationFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleStandardDeviationFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int64AverageFunctionExpression :
        AverageFunctionExpression<long>,
        IEquatable<Int64AverageFunctionExpression>
    {
        #region constructors
        public Int64AverageFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new Int64AverageFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int64AverageFunctionExpression obj)
            => obj is Int64AverageFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int64AverageFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

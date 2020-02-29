using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int32AverageFunctionExpression :
        AverageFunctionExpression<int>,
        IEquatable<Int32AverageFunctionExpression>
    {
        #region constructors
        public Int32AverageFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new Int32AverageFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int32AverageFunctionExpression obj)
            => obj is Int32AverageFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int32AverageFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

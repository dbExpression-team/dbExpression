using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int64AverageFunctionExpression :
        AverageFunctionExpression<long>,
        Int64Element,
        AnyInt64Element,
        IEquatable<Int64AverageFunctionExpression>
    {
        #region constructors
        public Int64AverageFunctionExpression(Int64Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected Int64AverageFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public Int64Element As(string alias)
            => new Int64AverageFunctionExpression(base.Expression, base.IsDistinct, alias);
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

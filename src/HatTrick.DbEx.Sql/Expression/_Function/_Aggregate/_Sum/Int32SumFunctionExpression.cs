using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int32SumFunctionExpression :
        SumFunctionExpression<int>,
        IEquatable<Int32SumFunctionExpression>
    {
        #region constructors
        public Int32SumFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new Int32SumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int32SumFunctionExpression obj)
            => obj is Int32SumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int32SumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

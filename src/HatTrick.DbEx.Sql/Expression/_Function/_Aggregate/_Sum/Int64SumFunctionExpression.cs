using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int64SumFunctionExpression :
        SumFunctionExpression<long>,
        IEquatable<Int64SumFunctionExpression>
    {
        #region constructors
        public Int64SumFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new Int64SumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int64SumFunctionExpression obj)
            => obj is Int64SumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int64SumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

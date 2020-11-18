using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int64SumFunctionExpression :
        SumFunctionExpression<long>,
        Int64Element,
        AnyInt64Element,
        IEquatable<Int64SumFunctionExpression>
    {
        #region constructors
        public Int64SumFunctionExpression(Int64Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected Int64SumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public Int64Element As(string alias)
            => new Int64SumFunctionExpression(base.Expression, base.IsDistinct, alias);
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

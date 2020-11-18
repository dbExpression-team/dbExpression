using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int32SumFunctionExpression :
        SumFunctionExpression<int>,
        Int32Element,
        AnyInt32Element,
        IEquatable<Int32SumFunctionExpression>
    {
        #region constructors
        public Int32SumFunctionExpression(ByteElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public Int32SumFunctionExpression(Int16Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public Int32SumFunctionExpression(Int32Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected Int32SumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public Int32Element As(string alias)
            => new Int32SumFunctionExpression(base.Expression, base.IsDistinct, alias);
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

using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int16IsNullFunctionExpression :
        IsNullFunctionExpression<short>,
        Int16Element,
        AnyInt16Element,
        IEquatable<Int16IsNullFunctionExpression>
    {
        #region constructors
        public Int16IsNullFunctionExpression(AnyInt16Element expression, Int16Element value) : base(expression, value)
        {

        }

        protected Int16IsNullFunctionExpression(IExpressionElement expression, IExpressionElement value, string alias) : base(expression, value, alias)
        {

        }
        #endregion

        #region as
        public Int16Element As(string alias)
            => new Int16IsNullFunctionExpression(base.Expression, base.Value, alias);
        #endregion

        #region equals
        public bool Equals(Int16IsNullFunctionExpression obj)
            => obj is Int16IsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int16IsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

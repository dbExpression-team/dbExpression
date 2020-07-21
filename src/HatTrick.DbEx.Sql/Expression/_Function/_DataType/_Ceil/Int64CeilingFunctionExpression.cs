using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int64CeilingFunctionExpression :
        CeilFunctionExpression<long>,
        IEquatable<Int64CeilingFunctionExpression>
    {
        #region constructors
        public Int64CeilingFunctionExpression(ExpressionMediator<long> expression) : base(expression)
        {

        }
        #endregion

        #region as
        public new Int64CeilingFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int64CeilingFunctionExpression obj)
            => obj is Int64CeilingFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int64CeilingFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

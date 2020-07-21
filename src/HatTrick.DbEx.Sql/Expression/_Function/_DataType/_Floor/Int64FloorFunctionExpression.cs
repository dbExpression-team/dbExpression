using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int64FloorFunctionExpression :
        FloorFunctionExpression<long>,
        IEquatable<Int64FloorFunctionExpression>
    {
        #region constructors
        public Int64FloorFunctionExpression(ExpressionMediator<long> expression) : base(expression)
        {

        }
        #endregion

        #region as
        public new Int64FloorFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int64FloorFunctionExpression obj)
            => obj is Int64FloorFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int64FloorFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

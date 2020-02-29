using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int32DatePartFunctionExpression :
        DatePartFunctionExpression<int>,
        IEquatable<Int32DatePartFunctionExpression>
    {
        #region constructors
        public Int32DatePartFunctionExpression(ExpressionContainer datePart, ExpressionContainer expression) : base(datePart, expression)
        {
        }
        #endregion

        #region as
        public new Int32DatePartFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int32DatePartFunctionExpression obj)
            => obj is Int32DatePartFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int32DatePartFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

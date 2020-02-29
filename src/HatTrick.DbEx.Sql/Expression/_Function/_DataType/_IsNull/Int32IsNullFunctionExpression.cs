using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int32IsNullFunctionExpression :
        IsNullFunctionExpression<int>,
        IEquatable<Int32IsNullFunctionExpression>
    {
        #region constructors
        public Int32IsNullFunctionExpression(ExpressionContainer expression, ExpressionContainer value) : base(expression, value)
        {
        }
        #endregion

        #region as
        public new Int32IsNullFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int32IsNullFunctionExpression obj)
            => obj is Int32IsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int32IsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

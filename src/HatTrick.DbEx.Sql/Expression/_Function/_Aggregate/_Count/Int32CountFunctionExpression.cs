using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int32CountFunctionExpression :
        CountFunctionExpression<int>,
        IEquatable<Int32CountFunctionExpression>
    {
        #region constructors
        public Int32CountFunctionExpression()
        {
        }

        public Int32CountFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new Int32CountFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int32CountFunctionExpression obj)
            => obj is Int32CountFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int32CountFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int32IsNullFunctionExpression :
        IsNullFunctionExpression<int>,
        Int32Element,
        AnyInt32Element,
        IEquatable<Int32IsNullFunctionExpression>
    {
        #region constructors
        public Int32IsNullFunctionExpression(AnyInt32Element expression, Int32Element value) : base(expression, value)
        {

        }
        #endregion

        #region as
        public Int32Element As(string alias)
            => new Int32SelectExpression(this).As(alias);
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

using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int16CeilingFunctionExpression :
        CeilingFunctionExpression<short>,
        Int16Element,
        AnyInt16Element,
        IEquatable<Int16CeilingFunctionExpression>
    {
        #region constructors
        public Int16CeilingFunctionExpression(Int16Element expression) : base(expression)
        {

        }
        #endregion

        #region as
        public Int16Element As(string alias)
            => new Int16SelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(Int16CeilingFunctionExpression obj)
            => obj is Int16CeilingFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int16CeilingFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

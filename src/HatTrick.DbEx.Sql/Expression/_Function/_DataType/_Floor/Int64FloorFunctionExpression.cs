using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int64FloorFunctionExpression :
        FloorFunctionExpression<long>,
        Int64Element,
        AnyInt64Element,
        IEquatable<Int64FloorFunctionExpression>
    {
        #region constructors
        public Int64FloorFunctionExpression(Int64Element expression) : base(expression)
        {

        }
        #endregion

        #region as
        public Int64Element As(string alias)
            => new Int64SelectExpression(this).As(alias);
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

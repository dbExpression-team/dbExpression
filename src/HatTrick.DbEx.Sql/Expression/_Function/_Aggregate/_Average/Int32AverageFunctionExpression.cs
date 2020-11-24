using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int32AverageFunctionExpression :
        AverageFunctionExpression<int>,
        Int32Element,
        AnyInt32Element,
        IEquatable<Int32AverageFunctionExpression>
    {
        #region constructors
        public Int32AverageFunctionExpression(ByteElement expression) : base(expression)
        {

        }

        public Int32AverageFunctionExpression(Int16Element expression) : base(expression)
        {

        }

        public Int32AverageFunctionExpression(Int32Element expression) : base(expression)
        {

        }
        #endregion

        #region as
        public Int32Element As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region distinct
        public Int32AverageFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int32AverageFunctionExpression obj)
            => obj is Int32AverageFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int32AverageFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

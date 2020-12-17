using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int32SumFunctionExpression :
        SumFunctionExpression<int>,
        Int32Element,
        AnyInt32Element,
        IEquatable<Int32SumFunctionExpression>
    {
        #region constructors
        public Int32SumFunctionExpression(ByteElement expression) : base(expression)
        {

        }

        public Int32SumFunctionExpression(Int16Element expression) : base(expression)
        {

        }

        public Int32SumFunctionExpression(Int32Element expression) : base(expression)
        {

        }
        #endregion

        #region as
        public Int32Element As(string alias)
            => new Int32SelectExpression(this).As(alias);
        #endregion

        #region distinct
        public Int32SumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(Int32SumFunctionExpression obj)
            => obj is Int32SumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int32SumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

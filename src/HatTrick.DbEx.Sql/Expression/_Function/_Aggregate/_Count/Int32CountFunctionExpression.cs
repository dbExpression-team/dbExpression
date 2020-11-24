using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int32CountFunctionExpression :
        CountFunctionExpression<int>,
        Int32Element,
        AnyInt32Element,
        IEquatable<Int32CountFunctionExpression>
    {
        #region constructors
        public Int32CountFunctionExpression() : base()
        {

        }

        public Int32CountFunctionExpression(IExpressionElement expression) : base(expression)
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
        public Int32CountFunctionExpression Distinct()
        {
            IsDistinct = true;
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

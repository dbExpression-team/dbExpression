using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DoubleCeilingFunctionExpression :
        CeilFunctionExpression<double>,
        DoubleElement,
        AnyDoubleElement,
        IEquatable<DoubleCeilingFunctionExpression>
    {
        #region constructors
        public DoubleCeilingFunctionExpression(DoubleElement expression) : base(expression)
        {

        }

        protected DoubleCeilingFunctionExpression(IExpressionElement expression, string alias) : base(expression, alias)
        {

        }
        #endregion

        #region as
        public DoubleElement As(string alias)
            => new DoubleCeilingFunctionExpression(base.Expression, alias);
        #endregion

        #region equals
        public bool Equals(DoubleCeilingFunctionExpression obj)
            => obj is DoubleCeilingFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DoubleCeilingFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

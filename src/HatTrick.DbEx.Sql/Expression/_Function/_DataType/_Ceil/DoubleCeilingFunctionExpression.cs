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
        #endregion

        #region as
        public DoubleElement As(string alias)
        {
            Alias = alias;
            return this;
        }
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

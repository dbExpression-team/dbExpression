using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DoubleCeilingFunctionExpression :
        CeilFunctionExpression<double>,
        IEquatable<DoubleCeilingFunctionExpression>
    {
        #region constructors
        public DoubleCeilingFunctionExpression(ExpressionMediator<double> expression) : base(expression)
        {

        }
        #endregion

        #region as
        public new DoubleCeilingFunctionExpression As(string alias)
        {
            base.As(alias);
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

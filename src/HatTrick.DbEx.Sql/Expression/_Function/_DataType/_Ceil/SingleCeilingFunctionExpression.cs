using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleCeilingFunctionExpression :
        CeilFunctionExpression<float>,
        IEquatable<SingleCeilingFunctionExpression>
    {
        #region constructors
        public SingleCeilingFunctionExpression(ExpressionMediator<float> expression) : base(expression)
        {

        }
        #endregion

        #region as
        public new SingleCeilingFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(SingleCeilingFunctionExpression obj)
            => obj is SingleCeilingFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleCeilingFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

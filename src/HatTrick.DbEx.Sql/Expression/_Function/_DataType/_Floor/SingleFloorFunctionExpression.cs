using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleFloorFunctionExpression :
        FloorFunctionExpression<float>,
        IEquatable<SingleFloorFunctionExpression>
    {
        #region constructors
        public SingleFloorFunctionExpression(ExpressionMediator<float> expression) : base(expression)
        {

        }
        #endregion

        #region as
        public new SingleFloorFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(SingleFloorFunctionExpression obj)
            => obj is SingleFloorFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleFloorFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

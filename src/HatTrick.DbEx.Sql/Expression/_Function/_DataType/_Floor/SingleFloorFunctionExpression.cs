using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleFloorFunctionExpression :
        FloorFunctionExpression<float>,
        SingleElement,
        AnySingleElement,
        IEquatable<SingleFloorFunctionExpression>
    {
        #region constructors
        public SingleFloorFunctionExpression(SingleElement expression) : base(expression)
        {

        }

        public SingleFloorFunctionExpression(IExpressionElement expression, string alias) : base(expression, alias)
        {

        }
        #endregion

        #region as
        public SingleElement As(string alias)
            => new SingleFloorFunctionExpression(base.Expression, alias);
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

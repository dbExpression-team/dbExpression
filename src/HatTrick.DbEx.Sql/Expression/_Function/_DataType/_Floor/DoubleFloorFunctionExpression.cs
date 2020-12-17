using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DoubleFloorFunctionExpression :
        FloorFunctionExpression<double>,
        DoubleElement,
        AnyDoubleElement,
        IEquatable<DoubleFloorFunctionExpression>
    {
        #region constructors
        public DoubleFloorFunctionExpression(DoubleElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public DoubleElement As(string alias)
            => new DoubleSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(DoubleFloorFunctionExpression obj)
            => obj is DoubleFloorFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DoubleFloorFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

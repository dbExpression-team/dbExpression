using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ByteFloorFunctionExpression : 
        FloorFunctionExpression<byte>,
        IEquatable<ByteFloorFunctionExpression>
    {
        #region constructors
        public ByteFloorFunctionExpression(ExpressionMediator<byte> expression) : base(expression)
        { 
        
        }
        #endregion

        #region as
        public new ByteFloorFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(ByteFloorFunctionExpression obj)
            => obj is ByteFloorFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ByteFloorFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

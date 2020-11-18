using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class FloorFunctionExpression : DataTypeFunctionExpression,
        IFunctionExpression,
        IEquatable<FloorFunctionExpression>
    {
        #region constructors
        protected FloorFunctionExpression(IExpressionElement expression, Type declaredType) : base(expression, declaredType)
        {

        }

        protected FloorFunctionExpression(IExpressionElement expression, Type declaredType, string alias) : base(expression, declaredType, alias)
        {

        }
        #endregion

        #region to string
        public override string ToString() => $"FLOOR({Expression})";
        #endregion

        #region equals
        public bool Equals(FloorFunctionExpression obj)
        {
            return base.Equals(obj);
        }

        public override bool Equals(object obj)
         => obj is FloorFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}

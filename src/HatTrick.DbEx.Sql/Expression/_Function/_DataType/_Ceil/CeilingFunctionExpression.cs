using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class CeilingFunctionExpression : DataTypeFunctionExpression,
        IEquatable<CeilingFunctionExpression>
    {
        #region constructors
        protected CeilingFunctionExpression(IExpressionElement expression, Type declaredType) : base(expression, declaredType)
        {

        }

        protected CeilingFunctionExpression(IExpressionElement expression, Type declaredType, string alias) : base(expression, declaredType, alias)
        {

        }
        #endregion

        #region to string
        public override string ToString() => $"FLOOR({Expression})";
        #endregion

        #region equals
        public bool Equals(CeilingFunctionExpression obj)
        {
            return base.Equals(obj);
        }

        public override bool Equals(object obj)
         => obj is CeilingFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}

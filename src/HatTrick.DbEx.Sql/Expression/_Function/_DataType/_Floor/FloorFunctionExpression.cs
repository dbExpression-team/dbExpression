using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class FloorFunctionExpression : DataTypeFunctionExpression,
        IFunctionExpression,
        IExpressionAliasProvider,
        IEquatable<FloorFunctionExpression>
    {
        #region interface        
        string IExpressionAliasProvider.Alias => Alias;
        #endregion

        #region constructors
        protected FloorFunctionExpression(ExpressionMediator expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new FloorFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
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

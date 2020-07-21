using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class CeilingFunctionExpression : DataTypeFunctionExpression,
        IDbFunctionExpression,
        IDbExpressionAliasProvider,
        IEquatable<CeilingFunctionExpression>
    {
        #region interface        
        string IDbExpressionAliasProvider.Alias => Alias;
        #endregion

        #region constructors
        protected CeilingFunctionExpression(ExpressionMediator expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new CeilingFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
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

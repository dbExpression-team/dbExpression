using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ByteCeilingFunctionExpression : 
        CeilFunctionExpression<byte>,
        IEquatable<ByteCeilingFunctionExpression>
    {
        #region constructors
        public ByteCeilingFunctionExpression(ExpressionMediator<byte> expression) : base(expression)
        { 
        
        }
        #endregion

        #region as
        public new ByteCeilingFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(ByteCeilingFunctionExpression obj)
            => obj is ByteCeilingFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ByteCeilingFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

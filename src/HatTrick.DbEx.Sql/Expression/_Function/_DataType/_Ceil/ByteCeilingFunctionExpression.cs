using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ByteCeilingFunctionExpression : 
        CeilFunctionExpression<byte>,
        ByteElement,
        AnyByteElement,
        IEquatable<ByteCeilingFunctionExpression>
    {
        #region constructors
        public ByteCeilingFunctionExpression(ByteElement expression) : base(expression)
        { 
        
        }

        protected ByteCeilingFunctionExpression(IExpressionElement expression, string alias) : base(expression, alias)
        {

        }
        #endregion

        #region as
        public ByteElement As(string alias)
            => new ByteCeilingFunctionExpression(base.Expression, alias);
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

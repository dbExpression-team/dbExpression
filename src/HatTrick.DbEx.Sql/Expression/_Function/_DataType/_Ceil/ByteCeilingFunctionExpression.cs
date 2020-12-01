using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ByteCeilingFunctionExpression : 
        CeilingFunctionExpression<byte>,
        ByteElement,
        AnyByteElement,
        IEquatable<ByteCeilingFunctionExpression>
    {
        #region constructors
        public ByteCeilingFunctionExpression(ByteElement expression) : base(expression)
        { 
        
        }
        #endregion

        #region as
        public ByteElement As(string alias)
        {
            Alias = alias;
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

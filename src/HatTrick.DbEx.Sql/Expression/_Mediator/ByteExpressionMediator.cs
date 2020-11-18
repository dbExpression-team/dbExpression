using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ByteExpressionMediator :
        ExpressionMediator<byte>,
        ByteElement,
        AnyByteElement,
        IEquatable<ByteExpressionMediator>
    {
        #region constructors
        private ByteExpressionMediator()
        {
        }

        public ByteExpressionMediator(IExpressionElement expression) : base(expression)
        {
        }

        protected ByteExpressionMediator(IExpressionElement expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public ByteElement As(string alias)
            => new ByteExpressionMediator(base.Expression, alias);
        #endregion

        #region equals
        public bool Equals(ByteExpressionMediator obj)
            => obj is ByteExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ByteExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

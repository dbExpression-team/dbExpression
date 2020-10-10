using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ByteArrayExpressionMediator :
        ExpressionMediator<byte[]>,
        IEquatable<ByteArrayExpressionMediator>
    {
        #region constructors
        private ByteArrayExpressionMediator()
        {
        }

        public ByteArrayExpressionMediator(IExpression expression) : base(expression)
        {
        }

        protected ByteArrayExpressionMediator(IExpression expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public new ByteArrayExpressionMediator As(string alias)
            => new ByteArrayExpressionMediator(this.Expression, alias);
        #endregion

        #region equals
        public bool Equals(ByteArrayExpressionMediator obj)
            => obj is ByteArrayExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ByteArrayExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit operators
        public static implicit operator SelectExpression<byte[]>(ByteArrayExpressionMediator a) => new SelectExpression<byte[]>(a);
        public static implicit operator OrderByExpression(ByteArrayExpressionMediator a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(ByteArrayExpressionMediator a) => new GroupByExpression(a);
        #endregion

        #region filter operators
        #region byte[]
        public static FilterExpression<bool> operator ==(ByteArrayExpressionMediator a, byte[] b) => new FilterExpression<bool>(a, new ByteArrayExpressionMediator(new LiteralExpression<byte[]>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ByteArrayExpressionMediator a, byte[] b) => new FilterExpression<bool>(a, new ByteArrayExpressionMediator(new LiteralExpression<byte[]>(b)), FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool> operator ==(byte[] a, ByteArrayExpressionMediator b) => new FilterExpression<bool>(new ByteArrayExpressionMediator(new LiteralExpression<byte[]>(a)), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(byte[] a, ByteArrayExpressionMediator b) => new FilterExpression<bool>(new ByteArrayExpressionMediator(new LiteralExpression<byte[]>(a)), b, FilterExpressionOperator.NotEqual);
        #endregion

        #region fields
        public static FilterExpression<bool> operator ==(ByteArrayExpressionMediator a, ByteArrayFieldExpression b) => new FilterExpression<bool>(a, new ByteArrayExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ByteArrayExpressionMediator a, ByteArrayFieldExpression b) => new FilterExpression<bool>(a, new ByteArrayExpressionMediator(b), FilterExpressionOperator.NotEqual);
        #endregion

        #region mediators
        public static FilterExpression<bool> operator ==(ByteArrayExpressionMediator a, ByteArrayExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ByteArrayExpressionMediator a, ByteArrayExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        #endregion
        #endregion
    }
}

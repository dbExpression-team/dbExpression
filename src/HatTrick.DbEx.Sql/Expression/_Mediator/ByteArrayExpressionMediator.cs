using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ByteArrayExpressionMediator :
        ExpressionMediator<byte[]>,
        ByteArrayElement,
        AnyByteArrayElement,
        IEquatable<ByteArrayExpressionMediator>
    {
        #region constructors
        private ByteArrayExpressionMediator()
        {
        }

        public ByteArrayExpressionMediator(IExpressionElement expression) : base(expression)
        {
        }

        protected ByteArrayExpressionMediator(IExpressionElement expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public ByteArrayElement As(string alias)
            => new ByteArrayExpressionMediator(base.Expression, alias);
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
        public static FilterExpressionSet operator ==(ByteArrayExpressionMediator a, byte[] b) => new FilterExpressionSet(new FilterExpression(a, new LiteralExpression<byte[]>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(ByteArrayExpressionMediator a, byte[] b) => new FilterExpressionSet(new FilterExpression(a, new LiteralExpression<byte[]>(b), FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(byte[] a, ByteArrayExpressionMediator b) => new FilterExpressionSet(new FilterExpression(new LiteralExpression<byte[]>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(byte[] a, ByteArrayExpressionMediator b) => new FilterExpressionSet(new FilterExpression(new LiteralExpression<byte[]>(a), b, FilterExpressionOperator.NotEqual));
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(ByteArrayExpressionMediator a, ByteArrayFieldExpression b) => new FilterExpressionSet(new FilterExpression(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(ByteArrayExpressionMediator a, ByteArrayFieldExpression b) => new FilterExpressionSet(new FilterExpression(a, b, FilterExpressionOperator.NotEqual));
        #endregion

        #region mediators
        public static FilterExpressionSet operator ==(ByteArrayExpressionMediator a, ByteArrayExpressionMediator b) => new FilterExpressionSet(new FilterExpression(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(ByteArrayExpressionMediator a, ByteArrayExpressionMediator b) => new FilterExpressionSet(new FilterExpression(a, b, FilterExpressionOperator.NotEqual));
        #endregion
        #endregion
    }
}

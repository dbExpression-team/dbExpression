using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class ByteArrayFieldExpression : 
        FieldExpression<byte[]>,
        ByteArrayElement,
        AnyByteArrayElement,
        IEquatable<ByteArrayFieldExpression>
    {
        #region constructors
        protected ByteArrayFieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(byte[]), entity)
        {
        }

        protected ByteArrayFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(byte[]), entity, alias)
        {
        }
        #endregion

        #region as
        public abstract ByteArrayElement As(string alias);
        #endregion

        #region equals
        public bool Equals(ByteArrayFieldExpression obj)
            => obj is ByteArrayFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ByteArrayFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit operators
        public static implicit operator ByteArrayExpressionMediator(ByteArrayFieldExpression a) => new ByteArrayExpressionMediator(a);
        #endregion

        #region filter operators
        #region byte[]
        public static FilterExpression<bool> operator ==(ByteArrayFieldExpression a, byte[] b) => new FilterExpression<bool>(a, new LiteralExpression<byte[]>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ByteArrayFieldExpression a, byte[] b) => new FilterExpression<bool>(a, new LiteralExpression<byte[]>(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool> operator ==(byte[] a, ByteArrayFieldExpression b) => new FilterExpression<bool>(new LiteralExpression<byte[]>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(byte[] a, ByteArrayFieldExpression b) => new FilterExpression<bool>(new LiteralExpression<byte[]>(a), b, FilterExpressionOperator.NotEqual);
        #endregion

        #region mediators
        public static FilterExpression<bool> operator ==(ByteArrayFieldExpression a, ByteArrayExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ByteArrayFieldExpression a, ByteArrayExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        #endregion

        #region alias
        public static FilterExpressionSet operator ==(ByteArrayFieldExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(ByteArrayFieldExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        #endregion
        #endregion
    }
}

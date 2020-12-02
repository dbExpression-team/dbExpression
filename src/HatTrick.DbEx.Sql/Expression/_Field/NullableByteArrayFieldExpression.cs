using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableByteArrayFieldExpression :
        FieldExpression<byte[]>,
        NullableByteArrayElement,
        AnyByteArrayElement,
        IEquatable<NullableByteArrayFieldExpression>
    {
        #region constructors
        protected NullableByteArrayFieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(byte[]), entity)
        {

        }

        protected NullableByteArrayFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(byte[]), entity, alias)
        {

        }
        #endregion

        #region as
        public abstract NullableByteArrayElement As(string alias);
        #endregion

        #region equals
        public bool Equals(NullableByteArrayFieldExpression obj)
            => obj is NullableByteArrayFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableByteArrayFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region in value set
        public override FilterExpressionSet In(params byte[][] value) => value is object ? new FilterExpressionSet(new FilterExpression<bool>(this, new InExpression<byte[]>(value), FilterExpressionOperator.None)) : null;
        public override FilterExpressionSet In(IEnumerable<byte[]> value) => value is object ? new FilterExpressionSet(new FilterExpression<bool>(this, new InExpression<byte[]>(value), FilterExpressionOperator.None)) : null;
        #endregion

        #region implicit operators
        public static implicit operator SelectExpression<byte[]>(NullableByteArrayFieldExpression a) => new SelectExpression<byte[]>(a);
        public static implicit operator NullableByteArrayExpressionMediator(NullableByteArrayFieldExpression a) => new NullableByteArrayExpressionMediator(a);
        #endregion

        #region filter operators
        #region byte[]
        public static FilterExpression<bool?> operator ==(NullableByteArrayFieldExpression a, byte[] b) => new FilterExpression<bool?>(a, new LiteralExpression<byte[]>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableByteArrayFieldExpression a, byte[] b) => new FilterExpression<bool?>(a, new LiteralExpression<byte[]>(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator ==(byte[] a, NullableByteArrayFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte[]>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(byte[] a, NullableByteArrayFieldExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte[]>(a), b, FilterExpressionOperator.NotEqual);
        #endregion

        #region mediator
        public static FilterExpression<bool?> operator ==(NullableByteArrayFieldExpression a, ByteArrayExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableByteArrayFieldExpression a, ByteArrayExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        #endregion
        #endregion
    }
}

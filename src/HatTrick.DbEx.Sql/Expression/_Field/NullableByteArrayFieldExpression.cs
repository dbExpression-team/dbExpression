using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableByteArrayFieldExpression :
        FieldExpression<byte[]>,
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

        #region equals
        public bool Equals(NullableByteArrayFieldExpression obj)
            => obj is NullableByteArrayFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableByteArrayFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region in value set
        public override FilterExpression<bool> In(params byte[][] value) => value is object ? new FilterExpression<bool>(new ByteArrayExpressionMediator(this), new NullableByteArrayExpressionMediator(new InExpression<byte[]>(value)), FilterExpressionOperator.None) : null;
        public override FilterExpression<bool> In(IEnumerable<byte[]> value) => value is object ? new FilterExpression<bool>(new ByteArrayExpressionMediator(this), new NullableByteArrayExpressionMediator(new InExpression<byte[]>(value)), FilterExpressionOperator.None) : null;
        #endregion

        #region set
        public override AssignmentExpression Set(byte[] value) => new AssignmentExpression(this, new ByteArrayExpressionMediator(new LiteralExpression<byte[]>(value)));
        public override AssignmentExpression Set(ExpressionMediator<byte[]> value) => new AssignmentExpression(this, value);
        public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new NullableByteArrayExpressionMediator(new LiteralExpression<byte[]>(null)));
        #endregion

        #region insert
        public override InsertExpression Insert(byte[] value) => new InsertExpression(this, new ByteArrayExpressionMediator(new LiteralExpression<byte[]>(value)));
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new NullableStringExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new NullableStringExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region implicit operators
        public static implicit operator SelectExpression<byte[]>(NullableByteArrayFieldExpression a) => new SelectExpression<byte[]>(new NullableByteArrayExpressionMediator(a));
        public static implicit operator NullableByteArrayExpressionMediator(NullableByteArrayFieldExpression a) => new NullableByteArrayExpressionMediator(a);
        public static implicit operator OrderByExpression(NullableByteArrayFieldExpression a) => new OrderByExpression(new NullableByteArrayExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableByteArrayFieldExpression a) => new GroupByExpression(new NullableByteArrayExpressionMediator(a));
        #endregion

        #region filter operators
        #region byte[]
        public static FilterExpression<bool?> operator ==(NullableByteArrayFieldExpression a, byte[] b) => new FilterExpression<bool?>(new NullableByteArrayExpressionMediator(a), new ByteArrayExpressionMediator(new LiteralExpression<byte[]>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableByteArrayFieldExpression a, byte[] b) => new FilterExpression<bool?>(new NullableByteArrayExpressionMediator(a), new ByteArrayExpressionMediator(new LiteralExpression<byte[]>(b)), FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator ==(byte[] a, NullableByteArrayFieldExpression b) => new FilterExpression<bool?>(new NullableByteArrayExpressionMediator(new LiteralExpression<byte[]>(a)), new NullableByteArrayExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(byte[] a, NullableByteArrayFieldExpression b) => new FilterExpression<bool?>(new NullableByteArrayExpressionMediator(new LiteralExpression<byte[]>(a)), new NullableByteArrayExpressionMediator(b), FilterExpressionOperator.NotEqual);
        #endregion

        #region mediator
        public static FilterExpression<bool?> operator ==(NullableByteArrayFieldExpression a, ByteArrayExpressionMediator b) => new FilterExpression<bool?>(new NullableByteArrayExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableByteArrayFieldExpression a, ByteArrayExpressionMediator b) => new FilterExpression<bool?>(new NullableByteArrayExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        #endregion
        #endregion
    }
}

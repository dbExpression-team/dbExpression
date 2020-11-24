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

        #region set
        public override AssignmentExpression Set(byte[] value) => new AssignmentExpression(this, new ByteArrayExpressionMediator(new LiteralExpression<byte[]>(value)));
        public virtual AssignmentExpression Set(ByteArrayElement value) => new AssignmentExpression(this, value);
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new ByteArrayExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new ByteArrayExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region implicit operators
        public static implicit operator SelectExpression<byte[]>(ByteArrayFieldExpression a) => new SelectExpression<byte[]>(new ByteArrayExpressionMediator(a));
        public static implicit operator ByteArrayExpressionMediator(ByteArrayFieldExpression a) => new ByteArrayExpressionMediator(a);
        public static implicit operator OrderByExpression(ByteArrayFieldExpression a) => new OrderByExpression(new ByteArrayExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(ByteArrayFieldExpression a) => new GroupByExpression(new ByteArrayExpressionMediator(a));
        #endregion

        #region filter operators
        #region byte[]
        public static FilterExpression<bool> operator ==(ByteArrayFieldExpression a, byte[] b) => new FilterExpression<bool>(new ByteArrayExpressionMediator(a), new ByteArrayExpressionMediator(new LiteralExpression<byte[]>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ByteArrayFieldExpression a, byte[] b) => new FilterExpression<bool>(new ByteArrayExpressionMediator(a), new ByteArrayExpressionMediator(new LiteralExpression<byte[]>(b)), FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool> operator ==(byte[] a, ByteArrayFieldExpression b) => new FilterExpression<bool>(new ByteArrayExpressionMediator(new LiteralExpression<byte[]>(a)), new ByteArrayExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(byte[] a, ByteArrayFieldExpression b) => new FilterExpression<bool>(new ByteArrayExpressionMediator(new LiteralExpression<byte[]>(a)), new ByteArrayExpressionMediator(b), FilterExpressionOperator.NotEqual);
        #endregion

        #region mediator
        public static FilterExpression<bool> operator ==(ByteArrayFieldExpression a, ByteArrayExpressionMediator b) => new FilterExpression<bool>(new ByteArrayExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ByteArrayFieldExpression a, ByteArrayExpressionMediator b) => new FilterExpression<bool>(new ByteArrayExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        #endregion
        #endregion
    }
}

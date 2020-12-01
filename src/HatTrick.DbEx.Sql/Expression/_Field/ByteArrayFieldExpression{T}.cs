using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public class ByteArrayFieldExpression<TEntity> : ByteArrayFieldExpression,
        IEquatable<ByteArrayFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public ByteArrayFieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {
        }

        protected ByteArrayFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {
        }
        #endregion

        #region as
        public override ByteArrayElement As(string alias)
            => new ByteArrayFieldExpression<TEntity>(base.identifier, base.entity, alias);
        #endregion

        #region set
        public override AssignmentExpression Set(byte[] value) => new AssignmentExpression(this, new LiteralExpression<byte[]>(value));
        #endregion

        #region in value set
        public override FilterExpressionSet In(params byte[][] value) => value is object ? new FilterExpressionSet(new FilterExpression<bool>(this, new LiteralExpression<byte[][]>(value), FilterExpressionOperator.None)) : null;
        public override FilterExpressionSet In(IEnumerable<byte[]> value) => value is object ? new FilterExpressionSet(new FilterExpression<bool>(this, new LiteralExpression<IEnumerable<byte[]>>(value), FilterExpressionOperator.None)) : null;
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(this, OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(this, OrderExpressionDirection.DESC);
        #endregion

        #region equals
        public bool Equals(ByteArrayFieldExpression<TEntity> obj)
            => obj is ByteArrayFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ByteArrayFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}

using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public class ByteArrayFieldExpression<TEntity> : ByteArrayFieldExpression,
        IEquatable<ByteArrayFieldExpression<TEntity>>
        where TEntity : IDbEntity
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
        public ByteArrayFieldExpression<TEntity> As(string alias)
            => new ByteArrayFieldExpression<TEntity>(base.identifier, base.entity, alias);
        #endregion

        #region set
        public override AssignmentExpression Set(byte[] value) => new AssignmentExpression(this, new ByteExpressionMediator(new LiteralExpression<byte[]>(value)));
        public override AssignmentExpression Set(ExpressionMediator<byte[]> value) => new AssignmentExpression(this, value);
        #endregion

        #region insert
        public override InsertExpression Insert(byte[] value) => new InsertExpression(this, new ByteExpressionMediator(new LiteralExpression<byte[]>(value)));
        #endregion

        #region in value set
        public override FilterExpression<bool> In(params byte[][] value) => value is object ? new FilterExpression<bool>(new ByteArrayExpressionMediator(this), new ByteArrayExpressionMediator(new LiteralExpression<byte[][]>(value)), FilterExpressionOperator.None) : null;
        public override FilterExpression<bool> In(IEnumerable<byte[]> value) => value is object ? new FilterExpression<bool>(new ByteArrayExpressionMediator(this), new ByteArrayExpressionMediator(new LiteralExpression<IEnumerable<byte[]>>(value)), FilterExpressionOperator.None) : null;
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new ByteExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new ByteExpressionMediator(this), OrderExpressionDirection.DESC);
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

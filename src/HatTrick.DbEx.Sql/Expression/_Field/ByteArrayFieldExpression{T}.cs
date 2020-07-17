using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public class ByteArrayFieldExpression<TEntity> : ByteArrayFieldExpression
        where TEntity : IDbEntity,
        IEquatable<ByteArrayFieldExpression<TEntity>>
    {
        #region constructors
        public ByteArrayFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(identifier, entity, metadata)
        {
        }

        protected ByteArrayFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(identifier, entity, metadata, alias)
        {
        }
        #endregion

        #region as
        public new ByteArrayFieldExpression<TEntity> As(string alias)
            => new ByteArrayFieldExpression<TEntity>(base.Identifier, base.Entity, base.MetadataResolver, alias);
        #endregion

        #region in value set
        public override FilterExpression In(params byte[][] value) => value is object ? new FilterExpression<short>(new ByteExpressionMediator(this), new ByteExpressionMediator(new LiteralExpression<byte[][]>(value)), FilterExpressionOperator.In) : null;
        #endregion

        #region set
        public override AssignmentExpression Set(byte[] value) => new AssignmentExpression(new ByteExpressionMediator(this), new ByteExpressionMediator(new LiteralExpression<byte[]>(value)));
        public override AssignmentExpression Set(ExpressionMediator<byte[]> value) => new AssignmentExpression(new ByteExpressionMediator(this), value);
        #endregion

        #region insert
        public override InsertExpression Insert(byte[] value) => new InsertExpression(this, new ByteExpressionMediator(new LiteralExpression<byte[]>(value)));
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

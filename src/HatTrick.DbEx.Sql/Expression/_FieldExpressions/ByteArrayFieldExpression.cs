using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class ByteArrayFieldExpression : FieldExpression<byte[]>,
        ISupportedForSelectFieldExpression<byte[]>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, byte[]>,
        ISupportedForFunctionExpression<CastFunctionExpression, byte[]>
    {
        protected ByteArrayFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, byte[]>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected ByteArrayFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, byte[]>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {
        }
    }
}

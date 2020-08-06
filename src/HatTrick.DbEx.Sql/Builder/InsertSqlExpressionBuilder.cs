using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class InsertSqlExpressionBuilder<T> : SqlExpressionBuilder<T>,
        IInsertExpressionBuilder<T>,
        IInsertTerminationExpressionBuilder<T>
        where T : class, IDbEntity
    {
        private readonly IEnumerable<T> instances;
        private InsertQueryExpression insert => Expression as InsertQueryExpression;

        protected InsertSqlExpressionBuilder(DatabaseConfiguration configuration, IEnumerable<T> instances, InsertQueryExpression expression) : base(configuration, expression)
        {
            this.instances = instances;
        }

        IInsertTerminationExpressionBuilder<T> IInsertExpressionBuilder<T>.Into<U>(U entity)
        {
            var i = 0;
            insert.BaseEntity = entity;
            insert.Inserts = instances.ToDictionary(x => i++, x => new InsertExpressionSet(x, (entity as IDbExpressionEntity<T>).BuildInclusiveInsertExpression(x).Expressions));
            return this;
        }
    }
}

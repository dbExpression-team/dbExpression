using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public abstract class PipelineExecutionContext
    {
        public RuntimeSqlDatabaseConfiguration Database { get; private set; }
        public QueryExpression Expression { get; private set; }
        protected IDbEntity BaseEntity => Expression.BaseEntity as IDbEntity;
        protected ISqlEntityMetadata BaseEntityMetadata => Expression.BaseEntity as ISqlEntityMetadata;

        protected PipelineExecutionContext(RuntimeSqlDatabaseConfiguration database, QueryExpression expression)
        {
            Database = database ?? throw new ArgumentNullException($"{nameof(database)} is required to construct a pipeline execution context.");
            Expression = expression ?? throw new ArgumentNullException($"{nameof(expression)} is required to construct a pipeline execution context.");
        }
    }
}

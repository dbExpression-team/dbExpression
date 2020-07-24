using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public abstract class PipelineExecutionContext
    {
        protected QueryExpression Expression { get; private set; }
        protected IDbEntity BaseEntity => Expression.BaseEntity as IDbEntity;
        protected ISqlEntityMetadata BaseEntityMetadata => Expression.BaseEntity as ISqlEntityMetadata;

        protected PipelineExecutionContext(QueryExpression expression)
        {
            Expression = expression ?? throw new ArgumentNullException($"{nameof(expression)} is required to construct a pipeline execution context.");
        }
    }
}

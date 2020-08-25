using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class InsertedEntityPipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        public IDbEntity InsertedEntity { get; private set; }

        public InsertedEntityPipelineExecutionContext(RuntimeSqlDatabaseConfiguration database, InsertQueryExpression expression, InsertExpressionSet target)
            : base(database, expression)
        {
            InsertedEntity = target.Entity;
        }
    }
}

using HatTrick.DbEx.Sql.Executor;
using System.Data;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface ISqlStatementExecutionGroupingConfigurationBuilders : ISqlStatementConfigurationBuilderAssemblyGrouping
    {
        /// <summary>
        /// Configure the factory used for creating an <see cref="ISqlStatementExecutor"/> used to execute a sql statement against the target database.  
        /// </summary>
        ISqlStatementFactoryConfigurationBuilder Executor { get; }

        /// <summary>
        /// Configure the factory used for creating an execution pipeline used to create and execute a sql statement.  The pipeline specifies
        /// the order of events from assembly to execution.  Use with caution, there is almost certainly
        /// a better integration point to achieve something other than overriding the default factory.
        /// </summary>
        IExecutionPipelineFactoryConfigurationBuilder Pipeline { get; }

        /// <summary>
        /// Configure the factory used for creating an <see cref="IDbConnection"/> used to execute sql statements against the target database.  
        /// </summary>
        ISqlConnectionFactoryConfigurationBuilder Connection { get; }
    }
}

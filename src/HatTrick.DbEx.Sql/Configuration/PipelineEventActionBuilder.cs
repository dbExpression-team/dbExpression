using HatTrick.DbEx.Sql.Configuration.Syntax;
using HatTrick.DbEx.Sql.Pipeline;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class PipelineEventActionBuilder<TAsyncDelegate, TSyncDelegate, TPredicate> : IPipelineEventActionBuilder<TPredicate>
    {
        private readonly IRuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder caller;
        private readonly PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate> pipelineEventAction;

        public PipelineEventActionBuilder(IRuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder caller, PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate> pipelineEventAction)
        {
            this.caller = caller;
            this.pipelineEventAction = pipelineEventAction;
        }

        public IRuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder When(Predicate<TPredicate> predicate)
        {
            pipelineEventAction.Predicate = predicate;
            return caller;
        }
    }
}

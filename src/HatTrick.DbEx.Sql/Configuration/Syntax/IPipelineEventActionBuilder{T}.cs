using System;

namespace HatTrick.DbEx.Sql.Configuration.Syntax
{
    public interface IPipelineEventActionBuilder<TPredicate>
    {
        IRuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder When(Predicate<TPredicate> predicate);
    }
}

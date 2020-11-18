using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Configuration.Syntax
{
    public interface IRuntimeSqlDatabaseAssemblyConfigurationBuilder
    {
        IRuntimeSqlDatabaseAssemblyConfigurationBuilder ConfigureAttributesOfAssemblingSqlStatements(Action<SqlStatementAssemblerConfiguration> config);
        IRuntimeSqlDatabaseAssemblyConfigurationBuilder UseThisToCreateAppendersForWritingQueryExpressionPartsToTheSqlStatement(IExpressionElementAppenderFactory factory);

        IRuntimeSqlDatabaseAssemblyConfigurationBuilder UseThisToCreateAppendersForWritingSqlStatements<T>()
            where T : class, IExpressionElementAppenderFactory, new();

        IRuntimeSqlDatabaseAssemblyConfigurationBuilder UseThisToCreateAppendersForWritingSqlStatements<T>(Func<T> factory)
            where T : IExpressionElementAppenderFactory, new();

        IRuntimeSqlDatabaseAssemblyConfigurationBuilder UseThisToCreateWritersForCreatingSqlStatements(IAppenderFactory factory);

        IRuntimeSqlDatabaseAssemblyConfigurationBuilder UseThisToCreateWritersForCreatingSqlStatements<T>()
            where T : class, IAppenderFactory, new();

        IRuntimeSqlDatabaseAssemblyConfigurationBuilder UseThisAccessorToCreateAWriterForCreatingASqlStatement(Func<IAppender> appenderAccessor);

        IRuntimeSqlDatabaseAssemblyConfigurationBuilder UseThisToGetAFactoryForCreatingNewWritersForCreatingSqlStatements(Func<IAppenderFactory> factory);

        IRuntimeSqlDatabaseAssemblyConfigurationBuilder UseThisToCreateNewSqlStatementBuilders(ISqlStatementBuilderFactory factory);

        IRuntimeSqlDatabaseAssemblyConfigurationBuilder UseThisToCreateNewSqlStatementBuilders<T>()
            where T : class, ISqlStatementBuilderFactory, new();

        IRuntimeSqlDatabaseAssemblyConfigurationBuilder UseThisToGetAFactoryForCreatingNewSqlStatementBuilders(Func<ISqlStatementBuilderFactory> factory);
        IRuntimeSqlDatabaseAssemblyConfigurationBuilder UseThisToCreateSqlParameters(ISqlParameterBuilderFactory factory);

        IRuntimeSqlDatabaseAssemblyConfigurationBuilder UseThisToCreateSqlParameters<T>()
            where T : class, ISqlParameterBuilderFactory, new();

        IRuntimeSqlDatabaseAssemblyConfigurationBuilder UseThisToCreateSqlParameters(Func<ISqlParameterBuilder> factory);

        IRuntimeSqlDatabaseAssemblyConfigurationBuilder UseThisToGetAFactoryForCreatingSqlParameters(Func<ISqlParameterBuilderFactory> factory);
    }
}

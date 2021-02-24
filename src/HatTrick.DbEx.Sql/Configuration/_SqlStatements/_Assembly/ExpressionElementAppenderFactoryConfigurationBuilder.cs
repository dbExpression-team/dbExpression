using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class ExpressionElementAppenderFactoryConfigurationBuilder : IExpressionElementAppenderFactoryConfigurationBuilder
    {
        private readonly ISqlStatementAssemblyGroupingConfigurationBuilders caller;
        private readonly RuntimeSqlDatabaseConfiguration configuration;

        public ExpressionElementAppenderFactoryConfigurationBuilder(ISqlStatementAssemblyGroupingConfigurationBuilders caller, RuntimeSqlDatabaseConfiguration configuration)
        {
            this.caller = caller ?? throw new ArgumentNullException($"{nameof(caller)} is required.");
            this.configuration = configuration ?? throw new ArgumentNullException($"{nameof(configuration)} is required.");
        }

        public ISqlStatementAssemblyGroupingConfigurationBuilders Use(IExpressionElementAppenderFactory factory)
        {
            configuration.ExpressionElementAppenderFactory = factory;
            return caller;
        }

        public ISqlStatementAssemblyGroupingConfigurationBuilders Use<TExpressionElementAppenderFactory>()
            where TExpressionElementAppenderFactory : class, IExpressionElementAppenderFactory, new()
            => Use<TExpressionElementAppenderFactory>(null);

        public ISqlStatementAssemblyGroupingConfigurationBuilders Use<TExpressionElementAppenderFactory>(Action<TExpressionElementAppenderFactory> configureFactory)
            where TExpressionElementAppenderFactory : class, IExpressionElementAppenderFactory, new()
        {
            if (!(configuration.ExpressionElementAppenderFactory is TExpressionElementAppenderFactory))
                configuration.ExpressionElementAppenderFactory = new TExpressionElementAppenderFactory();
            configureFactory?.Invoke(configuration.ExpressionElementAppenderFactory as TExpressionElementAppenderFactory);
            return caller;
        }

        public ISqlStatementAssemblyGroupingConfigurationBuilders Use(Func<Type, IExpressionElementAppender> factory)
        {
            configuration.ExpressionElementAppenderFactory = new DelegateExpressionElementAppenderFactory(factory);
            return caller;
        }

        public ISqlStatementAssemblyGroupingConfigurationBuilders UseDefaultFactory()
        {
            configuration.ExpressionElementAppenderFactory = new ExpressionElementAppenderFactory();
            return caller;
        }
    }
}

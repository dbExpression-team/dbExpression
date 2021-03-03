using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class AppenderFactoryConfigurationBuilder : IAppenderFactoryConfigurationBuilder
    {
        private readonly ISqlStatementAssemblyGroupingConfigurationBuilders caller;
        private readonly RuntimeSqlDatabaseConfiguration configuration;

        public AppenderFactoryConfigurationBuilder(ISqlStatementAssemblyGroupingConfigurationBuilders caller, RuntimeSqlDatabaseConfiguration configuration)
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public ISqlStatementAssemblyGroupingConfigurationBuilders Use(IAppenderFactory factory)
        {
            configuration.AppenderFactory = factory;
            return caller;
        }

        public ISqlStatementAssemblyGroupingConfigurationBuilders Use<TAppenderFactory>()
            where TAppenderFactory : class, IAppenderFactory, new()
            => Use<TAppenderFactory>(null);

        public ISqlStatementAssemblyGroupingConfigurationBuilders Use<TAppenderFactory>(Action<TAppenderFactory> configureFactory)
            where TAppenderFactory : class, IAppenderFactory, new()
        {
            if (!(configuration.AppenderFactory is TAppenderFactory))
                configuration.AppenderFactory = new TAppenderFactory();
            configureFactory?.Invoke(configuration.AppenderFactory as TAppenderFactory);
            return caller;
        }

        public ISqlStatementAssemblyGroupingConfigurationBuilders Use(Func<IAppender> factory)
        {
            configuration.AppenderFactory = new DelegateAppenderFactory(factory);
            return caller;
        }

        public ISqlStatementAssemblyGroupingConfigurationBuilders UseDefaultFactory()
        {
            if (!(configuration.AppenderFactory is AppenderFactory))
                configuration.AppenderFactory = new AppenderFactory();
            return caller;
        }
    }
}

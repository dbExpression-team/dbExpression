using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface ISqlParameterBuilderFactoryConfigurationBuilder
    {
        /// <summary>
        /// Use a custom factory for creating a parameter builder for creating parameters used in a parameterized sql statement.
        /// </summary>
        ISqlStatementAssemblyGroupingConfigurationBuilders Use(ISqlParameterBuilderFactory factory);

        /// <summary>
        /// Use a custom factory for creating a parameter builder for creating parameters used in a parameterized sql statement.
        /// </summary>
        ISqlStatementAssemblyGroupingConfigurationBuilders Use<TSqlParameterBuilderFactory>()
            where TSqlParameterBuilderFactory : class, ISqlParameterBuilderFactory, new();

        /// <summary>
        /// Use a custom factory for creating a parameter builder for creating parameters used in a parameterized sql statement.
        /// </summary>
        /// <param name="configureFactory">Configure the <typeparamref name="TAppenderFactory"/> factory.</param>
        ISqlStatementAssemblyGroupingConfigurationBuilders Use<TSqlParameterBuilderFactory>(Action<TSqlParameterBuilderFactory> configureFactory)
            where TSqlParameterBuilderFactory : class, ISqlParameterBuilderFactory, new();

        /// <summary>
        /// Use a custom factory for creating a parameter builder for creating parameters used in a parameterized sql statement.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating an <see cref="ISqlParameterBuilder"/>.</param>
        ISqlStatementAssemblyGroupingConfigurationBuilders Use(Func<ISqlParameterBuilder> factory);
    }
}

using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface IQueryExpressionFactoryConfigurationBuilder
    {
        /// <summary>
        /// Use a custom factory to create query expressions used in fluent builders.
        /// </summary>
        void Use(IQueryExpressionFactory factory);

        /// <summary>
        /// Use a custom factory to create query expressions used in fluent builders.
        /// </summary>
        void Use<TQueryExpressionFactory>()
            where TQueryExpressionFactory : class, IQueryExpressionFactory, new();

        /// <summary>
        /// Use a custom factory to create query expressions used in fluent builders.
        /// </summary>
        /// <param name="configureFactory">Configure the query expression factory.</param>
        void Use<TQueryExpressionFactory>(Action<TQueryExpressionFactory> configureFactory)
            where TQueryExpressionFactory : class, IQueryExpressionFactory, new();

        /// <summary>
        /// Use the default factory to create query expressions used in fluent builders.
        /// </summary>
        void UseDefaultFactory();
    }
}

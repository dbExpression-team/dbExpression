using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class QueryExpressionFactoryConfigurationBuilder : IQueryExpressionFactoryConfigurationBuilder
    {
        #region internals
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        #endregion

        #region constructors
        public QueryExpressionFactoryConfigurationBuilder(RuntimeSqlDatabaseConfiguration configuration)
        {
            this.configuration = configuration;
        }
        #endregion

        #region methods
        public void Use(IQueryExpressionFactory factory)
            => configuration.QueryExpressionFactory = factory ?? throw new ArgumentNullException($"{nameof(factory)} is required.");

        public void Use<TQueryExpressionFactory>()
            where TQueryExpressionFactory : class, IQueryExpressionFactory, new()
            => Use<TQueryExpressionFactory>(null);

        public void Use<TQueryExpressionFactory>(Action<TQueryExpressionFactory> configureFactory)
            where TQueryExpressionFactory : class, IQueryExpressionFactory, new()
        {
            if (!(configuration.QueryExpressionFactory is TQueryExpressionFactory))
                configuration.QueryExpressionFactory = new TQueryExpressionFactory();
            configureFactory?.Invoke(configuration.QueryExpressionFactory as TQueryExpressionFactory);
        }

        public void UseDefaultFactory()
        {
            if (!(configuration.QueryExpressionFactory is QueryExpressionFactory))
                configuration.QueryExpressionFactory = new QueryExpressionFactory();
        }
        #endregion
    }
}

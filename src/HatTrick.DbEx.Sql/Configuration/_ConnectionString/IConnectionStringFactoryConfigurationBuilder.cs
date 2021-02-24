using HatTrick.DbEx.Sql.Connection;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface IConnectionStringFactoryConfigurationBuilder
    {
        /// <summary>
        /// Use the provided connection string to connect to the database.
        /// </summary>
        void Use(string connectionString);

        /// <summary>
        /// Use the delegate to provide a connection string to connect to the database.
        /// </summary>
        void Use(Func<string> factory);

        /// <summary>
        /// Use a custom connection string factory to provide a connection string to connect to the database.
        /// </summary>
        void Use(IConnectionStringFactory factory);

        /// <summary>
        /// Use a custom connection string factory to provide a connection string to connect to the database.
        /// </summary>
        void Use<TConnectionStringFactory>()
            where TConnectionStringFactory : class, IConnectionStringFactory, new();
    }
}

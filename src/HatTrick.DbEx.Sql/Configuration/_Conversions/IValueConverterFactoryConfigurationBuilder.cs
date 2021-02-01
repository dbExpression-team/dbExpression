using HatTrick.DbEx.Sql.Converter;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface IValueConverterFactoryConfigurationBuilder
    {
        /// <summary>
        /// Use a custom factory to create a value converter used to convert data to and from the target database.
        /// </summary>
        void Use(IValueConverterFactory factory);

        /// <summary>
        /// Use a custom factory to create a value converter used to convert data to and from the target database.
        /// </summary>
        void Use<TValueConverterFactory>()
            where TValueConverterFactory : class, IValueConverterFactory, new();

        /// <summary>
        /// Use a custom factory to create a value converter used to convert data to and from the target database.
        /// </summary>
        /// <param name="configureFactory">A delegate for configuring the <typeparamref name="TValueConverterFactory"/>.</param>
        void Use<TValueConverterFactory>(Action<TValueConverterFactory> configureFactory)
            where TValueConverterFactory : class, IValueConverterFactory, new();

        /// <summary>
        /// Use a custom factory to create a value converter used to convert data to and from the target database.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating an <see cref="IValueConverter"/> for the provided value type.</param>
        void Use(Func<Type, IValueConverter> factory);

        /// <summary>
        /// Use the default factory to create a value converter used to convert data to and from the target database.
        /// </summary>
        void UseDefaultFactory();

        /// <summary>
        /// Use the default factory to create a value converter used to convert data to and from the target database.
        /// </summary>
        /// <param name="configureFactory">Configure custom converters for specific data types.</param>
        void UseDefaultFactory(Action<IValueConverterFactoryContinuationConfigurationBuilder> configureFactory);
    }
}

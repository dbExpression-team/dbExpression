using System;

namespace HatTrick.DbEx.Sql.Converter
{
    public class DelegateValueConverterFactory : IValueConverterFactory
    {
        #region internals
        private readonly Func<Type, IValueConverter> factory;
        #endregion

        #region constructors
        public DelegateValueConverterFactory(Func<Type, IValueConverter> factory)
        {
            this.factory = factory ?? throw new ArgumentNullException($"{nameof(factory)} is required.");
        }
        #endregion

        #region methods
        public IValueConverter CreateConverter<T>()
            => factory(typeof(T)) ?? throw new DbExpressionConfigurationException($"Could not resolve a converter for type '{typeof(T)}', please ensure a converter has been registered.");

        public IValueConverter CreateConverter(Type type)
            => factory(type) ?? throw new DbExpressionConfigurationException($"Could not resolve a converter for type '{type}', please ensure a converter has been registered.");

        public void RegisterConverter<T>(IValueConverter converter)
            => throw new DbExpressionConfigurationException($"Value converters are deferred to a lambda expression, custom registration is not supported.");

        public void RegisterConverter<T, U>()
            where U : class, IValueConverter, new()
            => throw new DbExpressionConfigurationException($"Value converters are deferred to a lambda expression, custom registration is not supported.");

        public void RegisterConverter(Type type, Func<IValueConverter> converter)
            => throw new DbExpressionConfigurationException($"Value converters are deferred to a lambda expression, custom registration is not supported.");
        #endregion
    }
}

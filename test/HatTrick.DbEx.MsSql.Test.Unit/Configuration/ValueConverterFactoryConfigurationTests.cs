using DbEx.Data;
using v2019DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Expression;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Configuration
{
    public class ValueConverterFactoryConfigurationTests : TestBase
    {
        [Fact]
        public void Does_configuration_using_instance_method_with_null_instance_throw_expected_exception()
        {
            //given & when & then
            Assert.Throws<DbExpressionConfigurationException>(() => Configure<v2019MsSqlDb>(builder => builder.Conversions.Use((IValueConverterFactory)null!)));
        }

        [Fact]
        public void Does_configuration_of_a_converter_factory_using_generic_use_method_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.Conversions.Use<NoOpValueConverterFactory>());

            //when
            var matchingType = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<IValueConverterFactory>() is NoOpValueConverterFactory;

            //then
            matchingType.Should().BeTrue();
        }

        [Fact]
        public void Does_configuration_of_a_converter_factory_using_instance_use_method_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.Conversions.Use(new NoOpValueConverterFactory()));

            //when
            var matchingType = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<IValueConverterFactory>() is NoOpValueConverterFactory;

            //then
            matchingType.Should().BeTrue();
        }

        [Fact]
        public void Does_configuration_of_a_converter_factory_using_instance_factory_use_method_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.Conversions.Use(() => new NoOpValueConverterFactory()));

            //when
            var matchingType = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<IValueConverterFactory>() is NoOpValueConverterFactory;

            //then
            matchingType.Should().BeTrue();
        }

        [Fact]
        public void Does_configuration_of_a_converter_factory_using_service_provider_to_resolve_a_factory_use_method_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.Conversions.Use(sp => new NoOpValueConverterFactory()));

            //when
            var matchingType = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<IValueConverterFactory>() is NoOpValueConverterFactory;

            //then
            matchingType.Should().BeTrue();
        }

        [Fact]
        public void Does_configuration_of_a_type_converter_override_using_generic_method_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.Conversions.ForTypes(x => x.ForValueType<int>().Use<NoOpValueConverter<int>>()));

            //when
            var matchingType = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<IValueConverterFactory>() is not null;

            //then
            matchingType.Should().BeTrue();
        }

        [Fact]
        public void Does_configuration_of_type_using_generic_method_return_correct_converter_of_a_type_converter_override()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.Conversions.ForTypes(x => x.ForValueType<int>().Use<NoOpValueConverter<int>>()));
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<int>();

            //when & then
            Assert.Throws<NotImplementedException>(() => converter.ConvertFromDatabase(1));
            converter.Should().BeOfType<NoOpValueConverter<int>>();
        }

        [Fact]
        public void Does_configuration_of_a_type_converter_override_using_instance_method_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.Conversions.ForTypes(x => x.ForValueType<int>().Use(new NoOpValueConverter<int>())));

            //when
            var matchingType = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<IValueConverterFactory>() is not null;

            //then
            matchingType.Should().BeTrue();
        }

        [Fact]
        public void Does_configuration_of_a_type_using_instance_method_return_correct_converter_of_a_type_converter_override()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.Conversions.ForTypes(x => x.ForValueType<int>().Use(new NoOpValueConverter<int>())));
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<int>();

            //when & then
            Assert.Throws<NotImplementedException>(() => converter.ConvertFromDatabase(1));
            converter.Should().BeOfType<NoOpValueConverter<int>>();
        }

        [Fact]
        public void Does_configuration_of_a_enum_type_converter_override_using_generic_method_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.Conversions.ForTypes(x => x.ForEnumType<AddressType>().Use<NoOpValueConverter<AddressType>>()));

            //when
            var matchingType = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<IValueConverterFactory>() is not null;

            //then
            matchingType.Should().BeTrue();
        }

        [Fact]
        public void Does_configuration_of_enum_type_using_generic_method_return_correct_converter_of_a_type_converter_override()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.Conversions.ForTypes(x => x.ForEnumType<AddressType>().Use<NoOpValueConverter<AddressType>>()));
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<AddressType>();

            //when & then
            Assert.Throws<NotImplementedException>(() => converter.ConvertFromDatabase(1));
            converter.Should().BeOfType<NoOpValueConverter<AddressType>>();
        }

        [Fact]
        public void Does_configuration_using_instance_for_enum_type_method_return_correct_converter_of_a_type_converter_override()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.Conversions.ForTypes(x => x.ForEnumType<AddressType>().Use(new NoOpValueConverter<AddressType>())));
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<AddressType>();

            //when & then
            Assert.Throws<NotImplementedException>(() => converter.ConvertFromDatabase(1));
            converter.Should().BeOfType<NoOpValueConverter<AddressType>>();
        }

        [Fact]
        public void Does_configuration_using_delegates_for_enum_type_method_return_correct_converter_of_a_enum_type_converter_override()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.Conversions.ForTypes(x => x.ForEnumType<AddressType>().Use(a => throw new NotImplementedException(), a => AddressType.Mailing)));
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<AddressType>();

            //when
            var value = converter.ConvertFromDatabase(AddressType.Billing);

            //then
            value.Should().Be(AddressType.Mailing);
        }

        [Fact]
        public void Does_value_converter_factory_produce_singletons()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>();

            //when
            var a1 = factory.CreateConverter<int>();
            var a2 = factory.CreateConverter<int>();

            //then
            a1.Should().Be(a2);
        }

        [Fact]
        public void Does_enum_value_converter_factory_produce_singletons()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.Conversions.ForTypes(x => x.ForEnumType<AddressType>().Use(a => throw new NotImplementedException(), a => AddressType.Mailing)));
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>();

            //when
            var a1 = factory.CreateConverter<AddressType>();
            var a2 = factory.CreateConverter<AddressType>();

            //then
            a1.Should().Be(a2);
        }

        public class NoOpValueConverter<T> : IValueConverter<T>
        {
            public object? ConvertFromDatabase(object? value) => throw new NotImplementedException();
            T? IValueConverter<T>.ConvertFromDatabase(object? value) => throw new NotImplementedException();
            public (Type, object?) ConvertToDatabase(object? value) => throw new NotImplementedException();
        }

        public class NoOpValueConverterFactory : IValueConverterFactory
        {
            public IValueConverter<T> CreateConverter<T>() => throw new NotImplementedException();
            public IValueConverter CreateConverter(Type type) => throw new NotImplementedException();
            public IValueConverter CreateConverter(FieldExpression _) => throw new NotImplementedException();
        }
    }
}

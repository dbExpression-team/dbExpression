using DbEx.Data;
using v2019DbEx.DataService;
using FluentAssertions;
using DbExpression.MsSql.Configuration;
using DbExpression.Sql.Converter;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace DbExpression.MsSql.Test.Unit.Converter
{
    public class ValueConverterFactoryTests : TestBase
    {
        [Fact]
        public void Can_register_converter_for_int_generically()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(c => c.ForValueType<int>().Use<SomeValueConverter<int>>()));

            //when
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<int>();

            //then
            converter.Should().BeOfType<SomeValueConverter<int>>();
        }

        [Fact]
        public void Can_register_converter_for_nullable_int_generically()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(c => c.ForValueType<int>().Use<SomeValueConverter<int>>()));

            //when
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<int?>();

            //then
            converter.Should().BeOfType<NullableValueConverter<int?>>();
        }

        [Fact]
        public void Can_register_converter_for_enum_generically()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(c => c.ForValueType<AddressType>().Use<SomeValueConverter<AddressType>>()));

            //when
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<AddressType>();

            //then
            converter.Should().BeOfType<SomeValueConverter<AddressType>>();
        }

        [Fact]
        public void Can_register_converter_for_nullable_enum_generically()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(c => c.ForEnumType<AddressType>().Use<SomeValueConverter<AddressType>>()));

            //when
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<AddressType?>();

            //then
            converter.Should().BeOfType<DelegateValueConverter<AddressType?>>();
        }

        [Fact]
        public void Can_register_converter_for_nullable_enum_and_retrieve_default_for_different_type()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(database => database.Conversions.ForTypes(c => c.ForEnumType<AddressType>().Use<SomeValueConverter<AddressType>>()));

            //when
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<int?>();

            //then
            converter.Should().NotBeOfType<SomeValueConverter<int?>>();
        }

        private class SomeValueConverter<T> : IValueConverter<T>
        {
            public object? ConvertFromDatabase(object? value) => throw new NotImplementedException();
            T? IValueConverter<T>.ConvertFromDatabase(object? value) => throw new NotImplementedException();
            public (Type, object?) ConvertToDatabase(object? value) => throw new NotImplementedException();
        }
    }
}

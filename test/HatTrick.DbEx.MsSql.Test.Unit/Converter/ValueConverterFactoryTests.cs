using DbEx.Data;
using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql.Converter;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Converter
{
    public class ValueConverterFactoryTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_register_converter_for_int_generically(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, database => database.Conversions.ForTypes(c => c.ForValueType<int>().Use<SomeValueConverter<int>>()));

            //when
            var converter = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IValueConverterFactory<MsSqlDb>>().CreateConverter<int>();

            //then
            converter.Should().BeOfType<SomeValueConverter<int>>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_register_converter_for_nullable_int_generically(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, database => database.Conversions.ForTypes(c => c.ForValueType<int>().Use<SomeValueConverter<int>>()));

            //when
            var converter = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IValueConverterFactory<MsSqlDb>>().CreateConverter<int?>();

            //then
            converter.Should().BeOfType<NullableValueConverter<int?>>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_register_converter_for_enum_generically(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, database => database.Conversions.ForTypes(c => c.ForValueType<AddressType>().Use<SomeValueConverter<AddressType>>()));

            //when
            var converter = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IValueConverterFactory<MsSqlDb>>().CreateConverter<AddressType>();

            //then
            converter.Should().BeOfType<SomeValueConverter<AddressType>>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_register_converter_for_nullable_enum_generically(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, database => database.Conversions.ForTypes(c => c.ForEnumType<AddressType>().Use<SomeValueConverter<AddressType>>()));

            //when
            var converter = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IValueConverterFactory<MsSqlDb>>().CreateConverter<AddressType?>();

            //then
            converter.Should().BeOfType<DelegateValueConverter<AddressType?>>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_register_converter_for_nullable_enum_and_retrieve_default_for_different_type(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, database => database.Conversions.ForTypes(c => c.ForEnumType<AddressType>().Use<SomeValueConverter<AddressType>>()));

            //when
            var converter = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IValueConverterFactory<MsSqlDb>>().CreateConverter<int?>();

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

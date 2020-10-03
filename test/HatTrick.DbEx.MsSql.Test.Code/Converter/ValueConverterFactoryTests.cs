using DbEx.Data;
using FluentAssertions;
using HatTrick.DbEx.Sql.Converter;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Code.Converter
{
    public class ValueConverterFactoryTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_register_converter_for_int_generically(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            database.ValueConverterFactory.RegisterConverter<int, SomeValueConverter>();

            //when
            var converter = database.ValueConverterFactory.CreateConverter<int>();

            //then
            converter.Should().BeOfType<SomeValueConverter>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_register_converter_for_nullable_int_generically(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            database.ValueConverterFactory.RegisterConverter<int?, SomeValueConverter>();

            //when
            var converter = database.ValueConverterFactory.CreateConverter<int?>();

            //then
            converter.Should().BeOfType<SomeValueConverter>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_register_converter_for_enum_generically(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            database.ValueConverterFactory.RegisterConverter<AddressType, SomeValueConverter>();

            //when
            var converter = database.ValueConverterFactory.CreateConverter<AddressType>();

            //then
            converter.Should().BeOfType<SomeValueConverter>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_register_converter_for_nullable_enum_generically(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            database.ValueConverterFactory.RegisterConverter<AddressType?, SomeValueConverter>();

            //when
            var converter = database.ValueConverterFactory.CreateConverter<AddressType?>();

            //then
            converter.Should().BeOfType<SomeValueConverter>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_register_converter_for_nullable_enum_and_retrieve_default_for_different_type(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            database.ValueConverterFactory.RegisterConverter<AddressType?, SomeValueConverter>();

            //when
            var converter = database.ValueConverterFactory.CreateConverter<int?>();

            //then
            converter.Should().NotBeOfType<SomeValueConverter>();
        }

        private class SomeValueConverter : IValueConverter
        {
            public object ConvertFromDatabase(object value) => throw new NotImplementedException();
            public T ConvertFromDatabase<T>(object value) => throw new NotImplementedException();
            public object ConvertToDatabase(object value) => throw new NotImplementedException();
        }
    }
}

using DbEx.Data;
using FluentAssertions;
using HatTrick.DbEx.Sql.Converter;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Code.Converter
{
    public class ValueConverterTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_int_converter_return_expected_value(int version, int expected = -1)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var converter = database.ValueConverterFactory.CreateConverter<int>();

            //when
            var converted = converter.ConvertFromDatabase<int>(expected);

            //then
            converted.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_converter_for_nullable_int_returns_expected_value_when_value_is_int(int version, int? expected = -1)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var converter = database.ValueConverterFactory.CreateConverter<int?>();

            //when
            var converted = converter.ConvertFromDatabase<int?>(expected);

            //then
            converted.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_converter_for_nullable_int_returns_expected_value_when_value_is_null(int version, int? expected = null)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            database.ValueConverterFactory.RegisterConverter<int?>(new NullableValueConverter(typeof(int?)));

            var converter = database.ValueConverterFactory.CreateConverter<int?>();

            //when
            var converted = converter.ConvertFromDatabase<int?>(expected);

            //then
            converted.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_enum_converter_return_expected_value(int version, AddressType expected = AddressType.Mailing)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var converter = database.ValueConverterFactory.CreateConverter<AddressType>();

            //when
            var converted = converter.ConvertFromDatabase<AddressType>(expected);

            //then
            converted.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_converter_for_nullable_enum_returns_expected_value_when_value_is_int(int version) //, AddressType? expected = null) :: have to initialize in method, can't convert to "actual" type when method param (framework)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var converter = database.ValueConverterFactory.CreateConverter<AddressType?>();
            AddressType? expected = AddressType.Mailing; //set the expected value

            //when
            var converted = converter.ConvertFromDatabase<AddressType?>(expected);

            //then
            converted.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_converter_for_nullable_enum_returns_expected_value_when_value_is_null(int version, AddressType? expected = null)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            database.ValueConverterFactory.RegisterConverter<AddressType?>(new NullableEnumValueConverter(typeof(AddressType?)));

            var converter = database.ValueConverterFactory.CreateConverter<AddressType?>();

            //when
            var converted = converter.ConvertFromDatabase<AddressType?>(expected);

            //then
            converted.Should().Be(expected);
        }
    }
}

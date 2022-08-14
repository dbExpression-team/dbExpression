using DbEx.Data;
using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql.Converter;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Converter
{
    public class ValueConverterTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_int_converter_return_expected_value(int version, int expected = -1)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);
            var converter = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IValueConverterFactory<MsSqlDb>>().CreateConverter<int>();

            //when
            var converted = converter.ConvertFromDatabase(expected);

            //then
            converted.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_converter_for_nullable_int_return_expected_value_when_value_is_int(int version, int? expected = -1)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);
            var converter = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IValueConverterFactory<MsSqlDb>>().CreateConverter<int?>();

            //when
            var converted = converter.ConvertFromDatabase(expected);

            //then
            converted.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_converter_for_nullable_int_return_expected_value_when_value_is_null(int version, int? expected = null)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);
            var converter = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IValueConverterFactory<MsSqlDb>>().CreateConverter<int?>();

            //when
            var converted = converter.ConvertFromDatabase(expected);

            //then
            converted.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_enum_converter_return_expected_value(int version, AddressType expected = AddressType.Mailing)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);
            var converter = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IValueConverterFactory<MsSqlDb>>().CreateConverter<AddressType>();

            //when
            var converted = converter.ConvertFromDatabase(expected);

            //then
            converted.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_converter_for_nullable_enum_returns_expected_value_when_value_is_int(int version) //, AddressType? expected = null) :: have to initialize in method, can't convert to "actual" type when method param (framework)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);
            var converter = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IValueConverterFactory<MsSqlDb>>().CreateConverter<AddressType>();
            AddressType? expected = AddressType.Mailing; //set the expected value

            //when
            var converted = converter.ConvertFromDatabase(expected);

            //then
            converted.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_converter_for_nullable_enum_returns_expected_value_when_value_is_null(int version, AddressType? expected = null)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);
            var converter = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IValueConverterFactory<MsSqlDb>>().CreateConverter<AddressType?>();

            //when
            var converted = converter.ConvertFromDatabase(expected);

            //then
            converted.Should().Be(expected);
        }
    }
}

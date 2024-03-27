using DbEx.Data;
using v2019DbEx.DataService;
using FluentAssertions;
using DbExpression.MsSql.Configuration;
using DbExpression.Sql.Converter;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace DbExpression.MsSql.Test.Unit.Converter
{
    public class ValueConverterTests : TestBase
    {
        [Theory]
        [InlineData(-1)]
        public void Does_int_converter_return_expected_value(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<int>();

            //when
            var converted = converter.ConvertFromDatabase(expected);

            //then
            converted.Should().Be(expected);
        }

        [Theory]
        [InlineData(-1)]
        public void Does_converter_for_nullable_int_return_expected_value_when_value_is_int(int? expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<int?>();

            //when
            var converted = converter.ConvertFromDatabase(expected);

            //then
            converted.Should().Be(expected);
        }

        [Theory]
        [InlineData(null)]
        public void Does_converter_for_nullable_int_return_expected_value_when_value_is_null(int? expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<int?>();

            //when
            var converted = converter.ConvertFromDatabase(expected);

            //then
            converted.Should().Be(expected);
        }

        [Theory]
        [InlineData(AddressType.Mailing)]
        public void Does_enum_converter_return_expected_value(AddressType expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<AddressType>();

            //when
            var converted = converter.ConvertFromDatabase(expected);

            //then
            converted.Should().Be(expected);
        }

        [Fact]
        public void Does_converter_for_nullable_enum_returns_expected_value_when_value_is_int() //, AddressType? expected, can't convert to "actual" type when method param (framework)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<AddressType>();
            AddressType? expected = AddressType.Mailing; //set the expected value

            //when
            var converted = converter.ConvertFromDatabase(expected);

            //then
            converted.Should().Be(expected);
        }

        [Theory]
        [InlineData(null)]
        public void Does_converter_for_nullable_enum_returns_expected_value_when_value_is_null(AddressType? expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<AddressType?>();

            //when
            var converted = converter.ConvertFromDatabase(expected);

            //then
            converted.Should().Be(expected);
        }
    }
}

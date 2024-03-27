using DbEx.Data;
using v2019DbEx.DataService;
using FluentAssertions;
using DbExpression.MsSql.Configuration;
using DbExpression.Sql;
using DbExpression.Sql.Converter;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace DbExpression.MsSql.Test.Unit.Converter
{
    public class DateAndTimeValueConverterTests : TestBase
    {
        [Fact]
        public void Does_datetime_converter_convert_to_database_a_datetimeoffset_value()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTime>();
            var today = DateTimeOffset.Now.Date;

            //when
            var converted = converter.ConvertToDatabase(today);

            //then
            converted.Should().Be((typeof(DateTime), today));
        }

        [Fact]
        public void Does_datetime_converter_convert_from_database_a_datetimeoffset_value()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTime>();
            var today = DateTimeOffset.Now.Date;

            //when
            var converted = converter.ConvertFromDatabase(today);

            //then
            converted.Should().Be(today);
        }

        [Fact]
        public void Does_nullabledatetime_converter_convert_to_database_a_null_datetimeoffset_value()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTime?>();
            DateTimeOffset? value = null;

            //when
            var converted = converter.ConvertToDatabase(value);

            //then
            converted.Should().Be((typeof(DateTime?), value));
        }

        [Fact]
        public void Does_nullabledatetime_converter_convert_from_database_a_null_datetimeoffset_value()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTime?>();
            DateTimeOffset? value = null;

            //when
            var converted = converter.ConvertFromDatabase(value);

            //then
            converted.Should().Be(null);
        }

        [Fact]
        public void Does_datetime_converter_convert_to_database_a_datetime_value()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTime>();
            var today = DateTime.Now.Date;

            //when
            var converted = converter.ConvertToDatabase(today);

            //then
            converted.Should().Be((typeof(DateTime), today));
        }

        [Fact]
        public void Does_datetime_converter_convert_from_database_a_datetime_value()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTime>();
            var today = DateTime.Now.Date;

            //when
            var converted = converter.ConvertFromDatabase(today);

            //then
            converted.Should().Be(today);
        }

        [Fact]
        public void Does_nullabledatetime_converter_convert_to_database_a_null_datetime_value()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTime?>();
            DateTime? value = null;

            //when
            var converted = converter.ConvertToDatabase(value);

            //then
            converted.Should().Be((typeof(DateTime?), value));
        }

        [Fact]
        public void Does_nullabledatetime_converter_convert_from_database_a_null_datetime_value()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTime?>();
            DateTime? value = null;

            //when
            var converted = converter.ConvertFromDatabase(value);

            //then
            converted.Should().Be(null);
        }

        [Fact]
        public void Does_datetimeoffset_converter_convert_to_database_a_datetimeoffset_value()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTimeOffset>();
            var today = DateTimeOffset.Now.Date;

            //when & then
            var ex = Assert.Throws<DbExpressionConversionException>(() => converter.ConvertFromDatabase(today));
        }

        [Fact]
        public void Does_datetimeoffset_converter_convert_from_database_a_datetimeoffset_value()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTimeOffset>();
            var today = DateTimeOffset.Now.Date;

            //when & then
            var ex = Assert.Throws<DbExpressionConversionException>(() => converter.ConvertFromDatabase(today));
        }

        [Fact]
        public void Does_nullabledatetimeoffset_converter_convert_to_database_a_null_datetimeoffset_value()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTimeOffset?>();
            DateTimeOffset? value = null;

            //when
            var converted = converter.ConvertToDatabase(value);

            //then
            converted.Should().Be((typeof(DateTimeOffset?), value));
        }

        [Fact]
        public void Does_nullabledatetimeoffset_converter_convert_from_database_a_null_datetimeoffset_value()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTimeOffset?>();
            DateTimeOffset? value = null;

            //when
            var converted = converter.ConvertFromDatabase(value);

            //then
            converted.Should().Be(null);
        }

        [Fact]
        public void Does_datetimeoffset_converter_convert_to_database_a_datetime_value()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTimeOffset>();
            var today = DateTime.Now.Date;

            //when
            var converted = converter.ConvertToDatabase(today);

            //then
            converted.Should().Be((typeof(DateTimeOffset), new DateTimeOffset(today)));
        }

        [Fact]
        public void Does_datetimeoffset_converter_convert_from_database_a_datetime_value()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTimeOffset>();
            var today = DateTime.Now.Date;

            //when
            var converted = converter.ConvertFromDatabase(today);

            //then
            converted.Should().Be(today);
        }

        [Fact]
        public void Does_nullabledatetimeoffset_converter_convert_to_database_a_null_datetime_value()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTimeOffset?>();
            DateTime? value = null;

            //when
            var converted = converter.ConvertToDatabase(value);

            //then
            converted.Should().Be((typeof(DateTimeOffset?), value));
        }

        [Fact]
        public void Does_nullabledatetimeoffset_converter_convert_from_database_a_null_datetime_value()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var converter = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTimeOffset?>();
            DateTime? value = null;

            //when
            var converted = converter.ConvertFromDatabase(value);

            //then
            converted.Should().Be(null);
        }
    }
}

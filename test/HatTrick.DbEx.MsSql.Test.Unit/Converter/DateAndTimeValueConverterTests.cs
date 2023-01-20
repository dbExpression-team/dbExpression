using DbEx.Data;
using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Converter;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Converter
{
    public class DateAndTimeValueConverterTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_datetime_converter_convert_to_database_a_datetimeoffset_value(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var converter = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTime>();
            var today = DateTimeOffset.Now.Date;

            //when
            var converted = converter.ConvertToDatabase(today);

            //then
            converted.Should().Be((typeof(DateTime), today));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_datetime_converter_convert_from_database_a_datetimeoffset_value(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var converter = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTime>();
            var today = DateTimeOffset.Now.Date;

            //when
            var converted = converter.ConvertFromDatabase(today);

            //then
            converted.Should().Be(today);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_nullabledatetime_converter_convert_to_database_a_null_datetimeoffset_value(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var converter = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTime?>();
            DateTimeOffset? value = null;

            //when
            var converted = converter.ConvertToDatabase(value);

            //then
            converted.Should().Be((typeof(DateTime?), value));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_nullabledatetime_converter_convert_from_database_a_null_datetimeoffset_value(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var converter = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTime?>();
            DateTimeOffset? value = null;

            //when
            var converted = converter.ConvertFromDatabase(value);

            //then
            converted.Should().Be(null);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_datetime_converter_convert_to_database_a_datetime_value(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var converter = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTime>();
            var today = DateTime.Now.Date;

            //when
            var converted = converter.ConvertToDatabase(today);

            //then
            converted.Should().Be((typeof(DateTime), today));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_datetime_converter_convert_from_database_a_datetime_value(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var converter = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTime>();
            var today = DateTime.Now.Date;

            //when
            var converted = converter.ConvertFromDatabase(today);

            //then
            converted.Should().Be(today);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_nullabledatetime_converter_convert_to_database_a_null_datetime_value(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var converter = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTime?>();
            DateTime? value = null;

            //when
            var converted = converter.ConvertToDatabase(value);

            //then
            converted.Should().Be((typeof(DateTime?), value));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_nullabledatetime_converter_convert_from_database_a_null_datetime_value(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var converter = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTime?>();
            DateTime? value = null;

            //when
            var converted = converter.ConvertFromDatabase(value);

            //then
            converted.Should().Be(null);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_datetimeoffset_converter_convert_to_database_a_datetimeoffset_value(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var converter = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTimeOffset>();
            var today = DateTimeOffset.Now.Date;

            //when & then
            var ex = Assert.Throws<DbExpressionConversionException>(() => converter.ConvertFromDatabase(today));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_datetimeoffset_converter_convert_from_database_a_datetimeoffset_value(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var converter = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTimeOffset>();
            var today = DateTimeOffset.Now.Date;

            //when & then
            var ex = Assert.Throws<DbExpressionConversionException>(() => converter.ConvertFromDatabase(today));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_nullabledatetimeoffset_converter_convert_to_database_a_null_datetimeoffset_value(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var converter = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTimeOffset?>();
            DateTimeOffset? value = null;

            //when
            var converted = converter.ConvertToDatabase(value);

            //then
            converted.Should().Be((typeof(DateTimeOffset?), value));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_nullabledatetimeoffset_converter_convert_from_database_a_null_datetimeoffset_value(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var converter = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTimeOffset?>();
            DateTimeOffset? value = null;

            //when
            var converted = converter.ConvertFromDatabase(value);

            //then
            converted.Should().Be(null);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_datetimeoffset_converter_convert_to_database_a_datetime_value(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var converter = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTimeOffset>();
            var today = DateTime.Now.Date;

            //when
            var converted = converter.ConvertToDatabase(today);

            //then
            converted.Should().Be((typeof(DateTimeOffset), new DateTimeOffset(today)));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_datetimeoffset_converter_convert_from_database_a_datetime_value(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var converter = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTimeOffset>();
            var today = DateTime.Now.Date;

            //when
            var converted = converter.ConvertFromDatabase(today);

            //then
            converted.Should().Be(today);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_nullabledatetimeoffset_converter_convert_to_database_a_null_datetime_value(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var converter = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTimeOffset?>();
            DateTime? value = null;

            //when
            var converted = converter.ConvertToDatabase(value);

            //then
            converted.Should().Be((typeof(DateTimeOffset?), value));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_nullabledatetimeoffset_converter_convert_from_database_a_null_datetime_value(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var converter = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IValueConverterFactory>().CreateConverter<DateTimeOffset?>();
            DateTime? value = null;

            //when
            var converted = converter.ConvertFromDatabase(value);

            //then
            converted.Should().Be(null);
        }
    }
}

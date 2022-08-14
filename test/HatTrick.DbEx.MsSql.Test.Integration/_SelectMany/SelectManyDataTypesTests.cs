using DbEx.DataService;
using DbEx.unit_testDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using System;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    public class SelectManyDataTypesTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_boolean_field_expression(int version, bool expected = true)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(unit_test.ExpressionElementType.Boolean)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 1);

            //when               
            bool value = exp.Execute().FirstOrDefault();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_nullable_boolean_field_expression(int version, bool? expected = null)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(unit_test.ExpressionElementType.NullableBoolean)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 2);

            //when               
            bool? value = exp.Execute().FirstOrDefault();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_byte_field_expression(int version, byte expected = 1)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(unit_test.ExpressionElementType.Byte)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 1);

            //when               
            byte value = exp.Execute().FirstOrDefault();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_nullable_byte_field_expression(int version, byte? expected = null)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(unit_test.ExpressionElementType.NullableByte)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 2);

            //when               
            byte? value = exp.Execute().FirstOrDefault();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_bytearray_field_expression(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(unit_test.ExpressionElementType.ByteArray)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 1);

            //when               
            byte[]? value = exp.Execute().FirstOrDefault();

            //then
            value.Should().Equal(new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_nullable_bytearray_field_expression(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(unit_test.ExpressionElementType.NullableByteArray)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 2);

            //when               
            byte[]? value = exp.Execute().FirstOrDefault();

            //then
            value.Should().BeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_DateTime_field_expression(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(unit_test.ExpressionElementType.DateTime)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 1);

            //when               
            DateTime value = exp.Execute().FirstOrDefault();

            //then
            value.Should().Be(new DateTime(1900, 1, 1));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_nullable_DateTime_field_expression(int version, DateTime? expected = null)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(unit_test.ExpressionElementType.NullableDateTime)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 2);

            //when               
            DateTime? value = exp.Execute().FirstOrDefault();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_DateTimeOffset_field_expression(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(unit_test.ExpressionElementType.DateTimeOffset)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 1);

            //when               
            DateTimeOffset value = exp.Execute().FirstOrDefault();

            //then
            value.Should().Be(new DateTimeOffset(DateTime.SpecifyKind(new DateTime(1900, 1, 1), DateTimeKind.Utc)));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_nullable_DateTimeOffset_field_expression(int version, DateTimeOffset? expected = null)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(unit_test.ExpressionElementType.NullableDateTimeOffset)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 2);

            //when               
            DateTimeOffset? value = exp.Execute().FirstOrDefault();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_decimal_field_expression(int version, decimal expected = 1.2345m)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(unit_test.ExpressionElementType.Decimal)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 1);

            //when               
            decimal value = exp.Execute().FirstOrDefault();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_nullable_decimal_field_expression(int version, decimal? expected = null)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(unit_test.ExpressionElementType.NullableDecimal)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 2);

            //when               
            decimal? value = exp.Execute().FirstOrDefault();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_double_field_expression(int version, double expected = 1.23d)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(unit_test.ExpressionElementType.Double)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 1);

            //when               
            double value = exp.Execute().FirstOrDefault();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_Guid_field_expression(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(unit_test.ExpressionElementType.Guid)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 1);

            //when               
            Guid value = exp.Execute().FirstOrDefault();

            //then
            value.Should().Be(new Guid("8C4DFECE-BBDE-4B86-849B-7C7A8E8B5DB7"));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_nullable_Guid_field_expression(int version, Guid? expected = null)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(unit_test.ExpressionElementType.NullableGuid)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 2);

            //when               
            Guid? value = exp.Execute().FirstOrDefault();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_nullable_double_field_expression(int version, double? expected = null)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(unit_test.ExpressionElementType.NullableDouble)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 2);

            //when               
            double? value = exp.Execute().FirstOrDefault();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_short_field_expression(int version, short expected = short.MaxValue)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(unit_test.ExpressionElementType.Int16)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 1);

            //when               
            short value = exp.Execute().FirstOrDefault();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_nullable_short_field_expression(int version, short? expected = null)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(unit_test.ExpressionElementType.NullableInt16)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 2);

            //when               
            short? value = exp.Execute().FirstOrDefault();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_int_field_expression(int version, int expected = int.MaxValue)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(unit_test.ExpressionElementType.Int32)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 1);

            //when               
            int value = exp.Execute().FirstOrDefault();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_nullable_int_field_expression(int version, int? expected = null)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(unit_test.ExpressionElementType.NullableInt32)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 2);

            //when               
            int? value = exp.Execute().FirstOrDefault();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_long_field_expression(int version, long expected = long.MaxValue)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(unit_test.ExpressionElementType.Int64)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 1);

            //when               
            long value = exp.Execute().FirstOrDefault();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_nullable_long_field_expression(int version, long? expected = null)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(unit_test.ExpressionElementType.NullableInt64)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 2);

            //when               
            long? value = exp.Execute().FirstOrDefault();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_string_field_expression(int version, string expected = nameof(String))
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(unit_test.ExpressionElementType.String)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 1);

            //when               
            string? value = exp.Execute().FirstOrDefault();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_nullable_string_field_expression(int version, string? expected = null)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(unit_test.ExpressionElementType.NullableString)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 2);

            //when               
            string? value = exp.Execute().FirstOrDefault();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_TimeSpan_field_expression(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(unit_test.ExpressionElementType.TimeSpan)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 1);

            //when               
            TimeSpan value = exp.Execute().FirstOrDefault();

            //then
            value.Should().Be(TimeSpan.Parse("12:00:00.0000000"));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_nullable_TimeSpan_field_expression(int version, TimeSpan? expected = null)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(unit_test.ExpressionElementType.NullableTimeSpan)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 2);

            //when               
            TimeSpan? value = exp.Execute().FirstOrDefault();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_single_field_expression(int version, float expected = 3.4028235f)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(unit_test.ExpressionElementType.Single)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 1);

            //when               
            float value = exp.Execute().FirstOrDefault();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_nullable_single_field_expression(int version, float? expected = null)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(unit_test.ExpressionElementType.NullableSingle)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 2);

            //when               
            float? value = exp.Execute().FirstOrDefault();

            //then
            value.Should().Be(expected);
        }
    }
}

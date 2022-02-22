using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using FluentAssertions.Common;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    public class SelectOneDataTypes : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_boolean_field_expression(int version, bool expected = true)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.UnitTest.Boolean)
                .From(dbo.UnitTest)
                .Where(dbo.UnitTest.Id == 1);

            //when               
            bool value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_nullable_boolean_field_expression(int version, bool? expected = null)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.UnitTest.NullableBoolean)
                .From(dbo.UnitTest)
                .Where(dbo.UnitTest.Id == 2);

            //when               
            bool? value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_byte_field_expression(int version, byte expected = 1)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.UnitTest.Byte)
                .From(dbo.UnitTest)
                .Where(dbo.UnitTest.Id == 1);

            //when               
            byte value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_nullable_byte_field_expression(int version, byte? expected = null)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.UnitTest.NullableByte)
                .From(dbo.UnitTest)
                .Where(dbo.UnitTest.Id == 2);

            //when               
            byte? value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_bytearray_field_expression(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.UnitTest.ByteArray)
                .From(dbo.UnitTest)
                .Where(dbo.UnitTest.Id == 1);

            //when               
            byte[] value = exp.Execute();

            //then
            value.Should().Equal(new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_nullable_bytearray_field_expression(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.UnitTest.NullableByteArray)
                .From(dbo.UnitTest)
                .Where(dbo.UnitTest.Id == 2);

            //when               
            byte[] value = exp.Execute();

            //then
            value.Should().BeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_DateTime_field_expression(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.UnitTest.DateTime)
                .From(dbo.UnitTest)
                .Where(dbo.UnitTest.Id == 1);

            //when               
            DateTime value = exp.Execute();

            //then
            value.Should().Be(new DateTime(1900, 1, 1));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_nullable_DateTime_field_expression(int version, DateTime? expected = null)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.UnitTest.NullableDateTime)
                .From(dbo.UnitTest)
                .Where(dbo.UnitTest.Id == 2);

            //when               
            DateTime? value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_DateTimeOffset_field_expression(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.UnitTest.DateTimeOffset)
                .From(dbo.UnitTest)
                .Where(dbo.UnitTest.Id == 1);

            //when               
            DateTimeOffset value = exp.Execute();

            //then
            value.Should().Be(new DateTimeOffset(DateTime.SpecifyKind(new DateTime(1900, 1, 1), DateTimeKind.Utc)));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_nullable_DateTimeOffset_field_expression(int version, DateTimeOffset? expected = null)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.UnitTest.NullableDateTimeOffset)
                .From(dbo.UnitTest)
                .Where(dbo.UnitTest.Id == 2);

            //when               
            DateTimeOffset? value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_decimal_field_expression(int version, decimal expected = 1.2345m)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.UnitTest.Decimal)
                .From(dbo.UnitTest)
                .Where(dbo.UnitTest.Id == 1);

            //when               
            decimal value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_nullable_decimal_field_expression(int version, decimal? expected = null)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.UnitTest.NullableDecimal)
                .From(dbo.UnitTest)
                .Where(dbo.UnitTest.Id == 2);

            //when               
            decimal? value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_double_field_expression(int version, double expected = 1.23d)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.UnitTest.Double)
                .From(dbo.UnitTest)
                .Where(dbo.UnitTest.Id == 1);

            //when               
            double value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_Guid_field_expression(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.UnitTest.Guid)
                .From(dbo.UnitTest)
                .Where(dbo.UnitTest.Id == 1);

            //when               
            Guid value = exp.Execute();

            //then
            value.Should().Be(new Guid("8C4DFECE-BBDE-4B86-849B-7C7A8E8B5DB7"));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_nullable_Guid_field_expression(int version, Guid? expected = null)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.UnitTest.NullableGuid)
                .From(dbo.UnitTest)
                .Where(dbo.UnitTest.Id == 2);

            //when               
            Guid? value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_nullable_double_field_expression(int version, double? expected = null)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.UnitTest.NullableDouble)
                .From(dbo.UnitTest)
                .Where(dbo.UnitTest.Id == 2);

            //when               
            double? value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_short_field_expression(int version, short expected = short.MaxValue)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.UnitTest.Int16)
                .From(dbo.UnitTest)
                .Where(dbo.UnitTest.Id == 1);

            //when               
            short value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_nullable_short_field_expression(int version, short? expected = null)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.UnitTest.NullableInt16)
                .From(dbo.UnitTest)
                .Where(dbo.UnitTest.Id == 2);

            //when               
            short? value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_int_field_expression(int version, int expected = int.MaxValue)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.UnitTest.Int32)
                .From(dbo.UnitTest)
                .Where(dbo.UnitTest.Id == 1);

            //when               
            int value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_nullable_int_field_expression(int version, int? expected = null)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.UnitTest.NullableInt32)
                .From(dbo.UnitTest)
                .Where(dbo.UnitTest.Id == 2);

            //when               
            int? value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_long_field_expression(int version, long expected = long.MaxValue)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.UnitTest.Int64)
                .From(dbo.UnitTest)
                .Where(dbo.UnitTest.Id == 1);

            //when               
            long value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_nullable_long_field_expression(int version, long? expected = null)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.UnitTest.NullableInt64)
                .From(dbo.UnitTest)
                .Where(dbo.UnitTest.Id == 2);

            //when               
            long? value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_string_field_expression(int version, string expected = nameof(String))
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.UnitTest.String)
                .From(dbo.UnitTest)
                .Where(dbo.UnitTest.Id == 1);

            //when               
            string value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_nullable_string_field_expression(int version, string expected = null)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.UnitTest.NullableString)
                .From(dbo.UnitTest)
                .Where(dbo.UnitTest.Id == 2);

            //when               
            string value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_TimeSpan_field_expression(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.UnitTest.TimeSpan)
                .From(dbo.UnitTest)
                .Where(dbo.UnitTest.Id == 1);

            //when               
            TimeSpan value = exp.Execute();

            //then
            value.Should().Be(TimeSpan.Parse("12:00:00.0000000"));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_nullable_TimeSpan_field_expression(int version, TimeSpan? expected = null)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.UnitTest.NullableTimeSpan)
                .From(dbo.UnitTest)
                .Where(dbo.UnitTest.Id == 2);

            //when               
            TimeSpan? value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_single_field_expression(int version, float expected = 3.4028235f)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.UnitTest.Single)
                .From(dbo.UnitTest)
                .Where(dbo.UnitTest.Id == 1);

            //when               
            float value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Can_select_nullable_single_field_expression(int version, float? expected = null)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.UnitTest.NullableSingle)
                .From(dbo.UnitTest)
                .Where(dbo.UnitTest.Id == 2);

            //when               
            float? value = exp.Execute();

            //then
            value.Should().Be(expected);
        }
    }
}

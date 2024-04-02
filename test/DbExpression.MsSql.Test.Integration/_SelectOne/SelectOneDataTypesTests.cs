using v2019DbEx.DataService;
using v2019DbEx.unit_testDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using System;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    public class SelectOneDataTypesTests : ResetDatabaseNotRequired
    {
        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData(true)]
        public void Can_select_boolean_field_expression(bool expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(unit_test.ExpressionElementType.Boolean)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 1);

            //when               
            bool value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData(null)]
        public void Can_select_nullable_boolean_field_expression(bool? expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(unit_test.ExpressionElementType.NullableBoolean)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 2);

            //when               
            bool? value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData(1)]
        public void Can_select_byte_field_expression(byte expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(unit_test.ExpressionElementType.Byte)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 1);

            //when               
            byte value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData(null)]
        public void Can_select_nullable_byte_field_expression(byte? expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(unit_test.ExpressionElementType.NullableByte)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 2);

            //when               
            byte? value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Fact]
        [Trait("Statement", "SELECT")]
        public void Can_select_bytearray_field_expression()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(unit_test.ExpressionElementType.ByteArray)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 1);

            //when               
            byte[]? value = exp.Execute();

            //then
            value.Should().NotBeNull();
            value.Should().Equal(new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        }

        [Fact]
        [Trait("Statement", "SELECT")]
        public void Can_select_nullable_bytearray_field_expression()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(unit_test.ExpressionElementType.NullableByteArray)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 2);

            //when               
            byte[]? value = exp.Execute();

            //then
            value.Should().BeNull();
        }

        [Fact]
        [Trait("Statement", "SELECT")]
        public void Can_select_DateTime_field_expression()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(unit_test.ExpressionElementType.DateTime)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 1);

            //when               
            DateTime value = exp.Execute();

            //then
            value.Should().Be(new DateTime(1900, 1, 1));
        }

        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData(null)]
        public void Can_select_nullable_DateTime_field_expression(DateTime? expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(unit_test.ExpressionElementType.NullableDateTime)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 2);

            //when               
            DateTime? value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Fact]
        [Trait("Statement", "SELECT")]
        public void Can_select_DateTimeOffset_field_expression()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(unit_test.ExpressionElementType.DateTimeOffset)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 1);

            //when               
            DateTimeOffset value = exp.Execute();

            //then
            value.Should().Be(new DateTimeOffset(DateTime.SpecifyKind(new DateTime(1900, 1, 1), DateTimeKind.Utc)));
        }

        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData(null)]
        public void Can_select_nullable_DateTimeOffset_field_expression(DateTimeOffset? expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(unit_test.ExpressionElementType.NullableDateTimeOffset)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 2);

            //when               
            DateTimeOffset? value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData(1.2345)]
        public void Can_select_decimal_field_expression(decimal expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(unit_test.ExpressionElementType.Decimal)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 1);

            //when               
            decimal value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData(null)]
        public void Can_select_nullable_decimal_field_expression(decimal? expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(unit_test.ExpressionElementType.NullableDecimal)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 2);

            //when               
            decimal? value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData(1.23d)]
        public void Can_select_double_field_expression(double expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(unit_test.ExpressionElementType.Double)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 1);

            //when               
            double value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Fact]
        [Trait("Statement", "SELECT")]
        public void Can_select_Guid_field_expression()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(unit_test.ExpressionElementType.Guid)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 1);

            //when               
            Guid value = exp.Execute();

            //then
            value.Should().Be(new Guid("8C4DFECE-BBDE-4B86-849B-7C7A8E8B5DB7"));
        }

        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData(null)]
        public void Can_select_nullable_Guid_field_expression(Guid? expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(unit_test.ExpressionElementType.NullableGuid)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 2);

            //when               
            Guid? value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData(null)]
        public void Can_select_nullable_double_field_expression(double? expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(unit_test.ExpressionElementType.NullableDouble)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 2);

            //when               
            double? value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData(short.MaxValue)]
        public void Can_select_short_field_expression(short expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(unit_test.ExpressionElementType.Int16)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 1);

            //when               
            short value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData(null)]
        public void Can_select_nullable_short_field_expression(short? expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(unit_test.ExpressionElementType.NullableInt16)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 2);

            //when               
            short? value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData(int.MaxValue)]
        public void Can_select_int_field_expression(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(unit_test.ExpressionElementType.Int32)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 1);

            //when               
            int value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData(null)]
        public void Can_select_nullable_int_field_expression(int? expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(unit_test.ExpressionElementType.NullableInt32)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 2);

            //when               
            int? value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData(long.MaxValue)]
        public void Can_select_long_field_expression(long expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(unit_test.ExpressionElementType.Int64)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 1);

            //when               
            long value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData(null)]
        public void Can_select_nullable_long_field_expression(long? expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(unit_test.ExpressionElementType.NullableInt64)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 2);

            //when               
            long? value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData("String")]
        public void Can_select_string_field_expression(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(unit_test.ExpressionElementType.String)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 1);

            //when               
            string? value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData(null)]
        public void Can_select_nullable_string_field_expression(string? expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(unit_test.ExpressionElementType.NullableString)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 2);

            //when               
            string? value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Fact]
        [Trait("Statement", "SELECT")]
        public void Can_select_TimeSpan_field_expression()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(unit_test.ExpressionElementType.TimeSpan)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 1);

            //when               
            TimeSpan value = exp.Execute();

            //then
            value.Should().Be(TimeSpan.Parse("12:00:00.0000000"));
        }

        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData(null)]
        public void Can_select_nullable_TimeSpan_field_expression(TimeSpan? expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(unit_test.ExpressionElementType.NullableTimeSpan)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 2);

            //when               
            TimeSpan? value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData(3.4028235f)]
        public void Can_select_single_field_expression(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(unit_test.ExpressionElementType.Single)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 1);

            //when               
            float value = exp.Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData(null)]
        public void Can_select_nullable_single_field_expression(float? expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(unit_test.ExpressionElementType.NullableSingle)
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.Id == 2);

            //when               
            float? value = exp.Execute();

            //then
            value.Should().Be(expected);
        }
    }
}

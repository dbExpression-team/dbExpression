using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using v2019DbEx.unit_testDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    public class DateTimeAndDateTimeOffsetValueConverterTests : ResetDatabaseAfterEveryTest
    {
        [Fact]
        [Trait("Configuration", "NullableDateTimeOffsetValueConverter")]
        public void Does_where_clause_with_nullabledatetimeoffset_field_less_than_literal_value_for_datetime_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            dynamic? result = db.SelectOne(
                    unit_test.ExpressionElementType.DateTimeOffset,
                    unit_test.ExpressionElementType.DateTime
                )
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.NullableDateTimeOffset < DateTime.Now)
                .Execute();

            //then
            (result as object).Should().NotBeNull();
        }

        [Fact]
        [Trait("Configuration", "NullableDateTimeOffsetValueConverter")]
        public void Does_where_clause_with_nullabledatetimeoffset_field_less_than_literal_value_for_datetime_with_unspecified_kind_fail()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var exp = db.SelectOne(
                    unit_test.ExpressionElementType.DateTimeOffset,
                    unit_test.ExpressionElementType.DateTime
                )
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.NullableDateTimeOffset < DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified));

            //then
            var ex = Assert.Throws<DbExpressionConversionException>(() => exp.Execute());
        }

        [Fact]
        [Trait("Configuration", "DateTimeOffsetValueConverter")]
        public void Does_where_clause_with_datetimeoffset_field_less_than_literal_value_for_datetime_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            dynamic? result = db.SelectOne(
                    unit_test.ExpressionElementType.DateTimeOffset,
                    unit_test.ExpressionElementType.DateTime
                )
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.DateTimeOffset < DateTime.Now)
                .Execute();

            //then
            (result as object).Should().NotBeNull();
        }

        [Fact]
        [Trait("Configuration", "NullableDateTimeOffsetValueConverter")]
        public void Does_where_clause_with_datetimeoffset_field_less_than_literal_value_for_datetime_with_unspecified_kind_fail()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var exp = db.SelectOne(
                    unit_test.ExpressionElementType.DateTimeOffset,
                    unit_test.ExpressionElementType.DateTime
                )
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.DateTimeOffset < DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified));

            //then
            var ex = Assert.Throws<DbExpressionConversionException>(() => exp.Execute());
        }

        [Fact]
        [Trait("Configuration", "NullableDateTimeOffsetValueConverter")]
        public void Does_where_clause_with_nullabledatetimeoffset_field_equal_to_literal_null_for_datetime_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            dynamic? result = db.SelectOne(
                    unit_test.ExpressionElementType.DateTimeOffset,
                    unit_test.ExpressionElementType.DateTime
                )
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.NullableDateTimeOffset == (DateTime?)null)
                .Execute();

            //then
            (result as object).Should().NotBeNull();
        }

        [Fact]
        [Trait("Configuration", "DateTimeOffsetValueConverter")]
        public void Does_where_clause_with_datetimeoffset_field_equal_to_literal_null_for_datetime_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            dynamic? result = db.SelectOne(
                    unit_test.ExpressionElementType.DateTimeOffset,
                    unit_test.ExpressionElementType.DateTime
                )
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.DateTimeOffset == (DateTime?)null)
                .Execute();

            //then
            (result as object).Should().BeNull();
        }

        [Fact]
        [Trait("Configuration", "NullableDateTimeOffsetValueConverter")]
        public void Does_where_clause_with_nullabledatetimeoffset_field_less_than_literal_value_for_datetimeoffset_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            dynamic? result = db.SelectOne(
                    unit_test.ExpressionElementType.DateTimeOffset,
                    unit_test.ExpressionElementType.DateTime
                )
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.NullableDateTimeOffset < DateTimeOffset.Now)
                .Execute();

            //then
            (result as object).Should().NotBeNull();
        }

        [Fact]
        [Trait("Configuration", "DateTimeOffsetValueConverter")]
        public void Does_where_clause_with_datetimeoffset_field_less_than_literal_datetimeoffset_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            dynamic? result = db.SelectOne(
                    unit_test.ExpressionElementType.DateTimeOffset,
                    unit_test.ExpressionElementType.DateTime
                )
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.DateTimeOffset < DateTimeOffset.Now)
                .Execute();

            //then
            (result as object).Should().NotBeNull();
        }

        [Fact]
        [Trait("Configuration", "NullableDateTimeOffsetValueConverter")]
        public void Does_where_clause_with_nullabledatetimeoffset_field_equal_to_literal_null_for_datetimeoffset_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            dynamic? result = db.SelectOne(
                    unit_test.ExpressionElementType.DateTimeOffset,
                    unit_test.ExpressionElementType.DateTime
                )
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.NullableDateTimeOffset == (DateTimeOffset?)null)
                .Execute();

            //then
            (result as object).Should().NotBeNull();
        }

        [Fact]
        [Trait("Configuration", "DateTimeOffsetValueConverter")]
        public void Does_where_clause_with_datetimeoffset_field_equal_to_literal_null_for_datetimeoffset_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            dynamic? result = db.SelectOne(
                    unit_test.ExpressionElementType.DateTimeOffset,
                    unit_test.ExpressionElementType.DateTime
                )
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.DateTimeOffset == (DateTimeOffset?)null)
                .Execute();

            //then
            (result as object).Should().BeNull();
        }

        [Fact]
        [Trait("Configuration", "NullableDateTimeOffsetValueConverter")]
        public void Does_where_clause_with_nullabledatetime_field_less_than_literal_value_for_datetimeoffset_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            dynamic? result = db.SelectOne(
                    unit_test.ExpressionElementType.DateTimeOffset,
                    unit_test.ExpressionElementType.DateTime
                )
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.NullableDateTime < DateTimeOffset.Now)
                .Execute();

            //then
            (result as object).Should().NotBeNull();
        }

        [Fact]
        [Trait("Configuration", "DateTimeOffsetValueConverter")]
        public void Does_where_clause_with_datetime_field_less_than_literal_value_for_datetimeoffset_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            dynamic? result = db.SelectOne(
                    unit_test.ExpressionElementType.DateTimeOffset,
                    unit_test.ExpressionElementType.DateTime
                )
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.DateTime < DateTimeOffset.Now)
                .Execute();

            //then
            (result as object).Should().NotBeNull();
        }

        [Fact]
        [Trait("Configuration", "NullableDateTimeOffsetValueConverter")]
        public void Does_where_clause_with_nullabledatetime_field_equal_to_literal_null_for_datetimeoffset_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            dynamic? result = db.SelectOne(
                    unit_test.ExpressionElementType.DateTimeOffset,
                    unit_test.ExpressionElementType.DateTime
                )
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.NullableDateTime == (DateTimeOffset?)null)
                .Execute();

            //then
            (result as object).Should().NotBeNull();
        }

        [Fact]
        [Trait("Configuration", "DateTimeOffsetValueConverter")]
        public void Does_where_clause_with_datetime_field_equal_to_literal_null_for_datetimeoffset_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            dynamic? result = db.SelectOne(
                    unit_test.ExpressionElementType.DateTimeOffset,
                    unit_test.ExpressionElementType.DateTime
                )
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.DateTime == (DateTimeOffset?)null)
                .Execute();

            //then
            (result as object).Should().BeNull();
        }

        [Fact]
        [Trait("Configuration", "NullableDateTimeOffsetValueConverter")]
        public void Does_where_clause_with_nullabledatetime_field_less_than_to_literal_value_for_datetime_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            dynamic? result = db.SelectOne(
                    unit_test.ExpressionElementType.DateTimeOffset,
                    unit_test.ExpressionElementType.DateTime
                )
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.NullableDateTime < DateTime.Now)
                .Execute();

            //then
            (result as object).Should().NotBeNull();
        }

        [Fact]
        [Trait("Configuration", "DateTimeOffsetValueConverter")]
        public void Does_where_clause_with_datetime_field_less_than_to_literal_value_for_datetime_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            dynamic? result = db.SelectOne(
                    unit_test.ExpressionElementType.DateTimeOffset,
                    unit_test.ExpressionElementType.DateTime
                )
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.DateTime < DateTime.Now)
                .Execute();

            //then
            (result as object).Should().NotBeNull();
        }

        [Fact]
        [Trait("Configuration", "NullableDateTimeOffsetValueConverter")]
        public void Does_where_clause_with_nullabledatetime_field_equal_to_to_literal_null_for_datetime_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            dynamic? result = db.SelectOne(
                    unit_test.ExpressionElementType.DateTimeOffset,
                    unit_test.ExpressionElementType.DateTime
                )
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.NullableDateTime == (DateTime?)null)
                .Execute();

            //then
            (result as object).Should().NotBeNull();
        }

        [Fact]
        [Trait("Configuration", "DateTimeOffsetValueConverter")]
        public void Does_where_clause_with_datetime_field_eqaul_to_literal_null_for_datetime_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            dynamic? result = db.SelectOne(
                    unit_test.ExpressionElementType.DateTimeOffset,
                    unit_test.ExpressionElementType.DateTime
                )
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.DateTime == (DateTime?)null)
                .Execute();

            //then
            (result as object).Should().BeNull();
        }





        [Fact]
        [Trait("Configuration", "NullableDateTimeOffsetValueConverter")]
        public void Does_selecting_isnull_of_nullabledatetimeoffset_field_and_literal_datetime_value_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            DateTimeOffset result = db.SelectOne(
                    db.fx.IsNull(unit_test.ExpressionElementType.NullableDateTimeOffset, DateTime.Now)
                )
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.NullableDateTimeOffset == dbex.Null)
                .Execute();

            //then
            (result as object).Should().NotBeNull();
        }

        [Fact]
        [Trait("Configuration", "NullableDateTimeOffsetValueConverter")]
        public void Does_selecting_isnull_of_nullabledatetimeoffset_field_and_literal_datetimeoffset_value_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            DateTimeOffset result = db.SelectOne(
                    db.fx.IsNull(unit_test.ExpressionElementType.NullableDateTimeOffset, DateTimeOffset.Now)
                )
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.NullableDateTimeOffset == dbex.Null)
                .Execute();

            //then
            (result as object).Should().NotBeNull();
        }

        [Fact]
        [Trait("Configuration", "NullableDateTimeOffsetValueConverter")]
        public void Does_selecting_isnull_of_nullabledatetimeoffset_field_and_literal_null_for_datetime_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            DateTimeOffset? result = db.SelectOne(
                    db.fx.IsNull(unit_test.ExpressionElementType.NullableDateTimeOffset, (DateTime?)null)
                )
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.NullableDateTimeOffset == dbex.Null)
                .Execute();

            //then
            (result as object).Should().BeNull();
        }

        [Fact]
        [Trait("Configuration", "NullableDateTimeOffsetValueConverter")]
        public void Does_selecting_isnull_of_nullabledatetimeoffset_field_and_literal_null_for_datetimeoffset_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            DateTimeOffset? result = db.SelectOne(
                    db.fx.IsNull(unit_test.ExpressionElementType.NullableDateTimeOffset, (DateTimeOffset?)null)
                )
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.NullableDateTimeOffset == dbex.Null)
                .Execute();

            //then
            (result as object).Should().BeNull();
        }

        [Fact]
        [Trait("Configuration", "NullableDateTimeOffsetValueConverter")]
        public void Does_selecting_isnull_of_nullabledatetime_field_and_literal_datetime_value_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            DateTimeOffset result = db.SelectOne(
                    db.fx.IsNull(unit_test.ExpressionElementType.NullableDateTime, DateTime.Now)
                )
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.NullableDateTimeOffset == dbex.Null)
                .Execute();

            //then
            (result as object).Should().NotBeNull();
        }

        [Fact]
        [Trait("Configuration", "NullableDateTimeOffsetValueConverter")]
        public void Does_selecting_isnull_of_nullabledatetime_field_and_literal_null_for_datetime_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            DateTimeOffset? result = db.SelectOne(
                    db.fx.IsNull(unit_test.ExpressionElementType.NullableDateTime, (DateTime?)null)
                )
                .From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.NullableDateTimeOffset == dbex.Null)
                .Execute();

            //then
            (result as object).Should().BeNull();
        }
    }
}

using DbEx.Data;
using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Expression;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System.Collections.Generic;
using System.Linq;
using System.Dynamic;
using Xunit;
using System;
using DbExpression.Sql.Builder.Alias;

namespace DbExpression.MsSql.Test.Integration
{
    public class AliasTupleGroupByTests : ResetDatabaseNotRequired
    {        
        [Theory]
        [Trait("Operation", "ORDER BY")]
        [Trait("Operation", "GROUP BY")]
        [InlineData(50)]
        public void Does_select_many_entity_with_order_by_and_multiple_aliased_group_by_result_in_correct_output(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            IEnumerable<AccessAuditLog> results = db.SelectMany<AccessAuditLog>(
                ).From(dbo.AccessAuditLog)
                .OrderBy(dbo.AccessAuditLog.DateCreated)
                .GroupBy(
                    ("AccessAuditLog", "Id"),
                    ("AccessAuditLog", "PersonId"),
                    ("AccessAuditLog", "AccessResult"),
                    ("AccessAuditLog", "DateCreated")
                )
                .Execute();

            //then
            results.Should().HaveCount(expectedCount);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [Trait("Operation", "GROUP BY")]
        [InlineData(50)]
        public void Does_select_many_entity_with_order_by_and_aliased_and_field_expression_group_by_result_in_correct_output(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            IEnumerable<AccessAuditLog> results = db.SelectMany<AccessAuditLog>(
                ).From(dbo.AccessAuditLog)
                .OrderBy(dbo.AccessAuditLog.DateCreated)
                .GroupBy(
                    ("AccessAuditLog", "Id"),
                    ("AccessAuditLog", "PersonId"),
                    dbo.AccessAuditLog.AccessResult,
                    ("AccessAuditLog", "DateCreated")
                )
                .Execute();

            //then
            results.Should().HaveCount(expectedCount);
        }

        [Fact]
        [Trait("Operation", "GROUP BY")]
        public void Does_select_one_entity_with_multiple_aliased_group_by_result_in_correct_output()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            AccessAuditLog? result = db.SelectOne<AccessAuditLog>(
                ).From(dbo.AccessAuditLog)
                .OrderBy(dbo.AccessAuditLog.DateCreated)
                .GroupBy(
                    ("AccessAuditLog", "Id"),
                    ("AccessAuditLog", "PersonId"),
                    ("AccessAuditLog", "AccessResult"),
                    ("AccessAuditLog", "DateCreated")
                )
                .Execute();

            //then
            (result as object).Should().NotBeNull();
        }

        [Fact]
        [Trait("Operation", "GROUP BY")]
        public void Does_select_one_entity_with_aliased_and_field_expression_group_by_result_in_correct_output()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            AccessAuditLog? result = db.SelectOne<AccessAuditLog>(
               ).From(dbo.AccessAuditLog)
               .GroupBy(
                   ("AccessAuditLog", "Id"),
                   ("AccessAuditLog", "PersonId"),
                    dbo.AccessAuditLog.AccessResult,
                   ("AccessAuditLog", "DateCreated")
               )
               .Execute();

            //then
            (result as object).Should().NotBeNull();
        }

        [Fact]
        [Trait("Operation", "ORDER BY")]
        [Trait("Operation", "GROUP BY")]
        public void Does_select_one_entity_with_order_by_and_multiple_aliased_group_by_result_in_correct_output()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            AccessAuditLog? result = db.SelectOne<AccessAuditLog>(
              ).From(dbo.AccessAuditLog)
              .OrderBy(dbo.AccessAuditLog.DateCreated)
              .GroupBy(
                  ("AccessAuditLog", "Id"),
                  ("AccessAuditLog", "PersonId"),
                  ("AccessAuditLog", "AccessResult"),
                  ("AccessAuditLog", "DateCreated")
              )
              .Execute();

            //then
            (result as object).Should().NotBeNull();
        }

        [Fact]
        [Trait("Operation", "ORDER BY")]
        [Trait("Operation", "GROUP BY")]
        public void Does_select_one_entity_with_order_by_and_aliased_and_field_expression_group_by_result_in_correct_output()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            AccessAuditLog? result = db.SelectOne<AccessAuditLog>(
              ).From(dbo.AccessAuditLog)
              .OrderBy(dbo.AccessAuditLog.DateCreated)
              .GroupBy(
                  ("AccessAuditLog", "Id"),
                  ("AccessAuditLog", "PersonId"),
                  dbo.AccessAuditLog.AccessResult,
                  ("AccessAuditLog", "DateCreated")
              )
              .Execute();

            //then
            (result as object).Should().NotBeNull();
        }

        [Theory]
        [Trait("Operation", "GROUP BY")]
        [InlineData(41)]
        public void Does_select_many_dynamic_with_aliased_group_by_result_in_correct_output(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            IEnumerable<dynamic> results = db.SelectMany(
                    dbo.Person.LastName,
                    db.fx.Count().As("person_count")
                ).From(dbo.Person)
                .GroupBy(("Person", "LastName"))
                .Execute();

            //then
            results.Should().HaveCount(expectedCount);
        }

        [Theory]
        [Trait("Operation", "GROUP BY")]
        [InlineData(44)]
        public void Does_select_many_dynamic_with_multiple_aliased_group_by_result_in_correct_output(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            IEnumerable<dynamic> results = db.SelectMany(
                    dbo.Person.GenderType,
                    dbo.Person.LastName,
                    db.fx.Count().As("person_count")
                ).From(dbo.Person)
                .GroupBy(
                    ("Person", "GenderType"),
                    ("Person", "LastName")
                )
                .Execute();

            //then
            results.Should().HaveCount(expectedCount);
        }

        [Theory]
        [Trait("Operation", "GROUP BY")]
        [InlineData(44)]
        public void Does_select_many_dynamic_with_aliased_and_field_expression_group_by_result_in_correct_output(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            IEnumerable<dynamic> results = db.SelectMany(
                    dbo.Person.GenderType,
                    dbo.Person.LastName,
                    db.fx.Count().As("person_count")
                ).From(dbo.Person)
                .GroupBy(
                    ("Person", "GenderType"),
                    dbo.Person.LastName
                )
                .Execute();

            //then
            results.Should().HaveCount(expectedCount);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [Trait("Operation", "GROUP BY")]
        [InlineData(41)]
        public void Does_select_many_dynamic_with_order_by_and_aliased_group_by_result_in_correct_output(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            IEnumerable<dynamic> results = db.SelectMany(
                    dbo.Person.LastName,
                    db.fx.Count().As("person_count")
                ).From(dbo.Person)
                .OrderBy(dbo.Person.LastName)
                .GroupBy(("Person", "LastName"))
                .Execute();

            //then
            results.Should().HaveCount(expectedCount);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [Trait("Operation", "GROUP BY")]
        [InlineData(44)]
        public void Does_select_many_dynamic_with_order_by_and_multiple_aliased_group_by_result_in_correct_output(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            IEnumerable<dynamic> results = db.SelectMany(
                    dbo.Person.GenderType,
                    dbo.Person.LastName,
                    db.fx.Count().As("person_count")
                ).From(dbo.Person)
                .OrderBy(dbo.Person.LastName)
                .GroupBy(
                    ("Person", "GenderType"),
                    ("Person", "LastName")
                )
                .Execute();

            //then
            results.Should().HaveCount(expectedCount);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [Trait("Operation", "GROUP BY")]
        [InlineData(44)]
        public void Does_select_many_dynamic_with_order_by_and_aliased_and_field_expression_group_by_result_in_correct_output(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            IEnumerable<dynamic> results = db.SelectMany(
                    dbo.Person.GenderType,
                    dbo.Person.LastName,
                    db.fx.Count().As("person_count")
                ).From(dbo.Person)
                .OrderBy(dbo.Person.LastName)
                .GroupBy(
                    ("Person", "GenderType"),
                    dbo.Person.LastName
                )
                .Execute();

            //then
            results.Should().HaveCount(expectedCount);
        }

        [Fact]
        [Trait("Operation", "GROUP BY")]
        public void Does_select_one_dynamic_with_aliased_group_by_result_in_correct_output()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            dynamic? result = db.SelectOne(
                    dbo.Person.LastName,
                    db.fx.Count().As("person_count")
                ).From(dbo.Person)
                .GroupBy(("Person", "LastName"))
                .Execute();

            //then
            (result as object).Should().NotBeNull();
        }

        [Fact]
        [Trait("Operation", "GROUP BY")]
        public void Does_select_one_dynamic_with_multiple_aliased_group_by_result_in_correct_output()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            dynamic? result = db.SelectOne(
                    dbo.Person.GenderType,
                    dbo.Person.LastName,
                    db.fx.Count().As("person_count")
                ).From(dbo.Person)
                .GroupBy(
                    ("Person", "GenderType"),
                    ("Person", "LastName")
                )
                .Execute();

            //then
            (result as object).Should().NotBeNull();
        }

        [Fact]
        [Trait("Operation", "GROUP BY")]
        public void Does_select_one_dynamic_with_aliased_and_field_expression_group_by_result_in_correct_output()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            dynamic? result = db.SelectOne(
                    dbo.Person.GenderType,
                    dbo.Person.LastName,
                    db.fx.Count().As("person_count")
                ).From(dbo.Person)
                .GroupBy(
                    ("Person", "GenderType"),
                    dbo.Person.LastName
                )
                .Execute();

            //then
            (result as object).Should().NotBeNull();
        }

        [Fact]
        [Trait("Operation", "ORDER BY")]
        [Trait("Operation", "GROUP BY")]
        public void Does_select_one_dynamic_with_order_by_and_aliased_group_by_result_in_correct_output()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            dynamic? result = db.SelectOne(
                    dbo.Person.LastName,
                    db.fx.Count().As("person_count")
                ).From(dbo.Person)
                .OrderBy(dbo.Person.LastName)
                .GroupBy(("Person", "LastName"))
                .Execute();

            //then
            (result as object).Should().NotBeNull();
        }

        [Fact]
        [Trait("Operation", "ORDER BY")]
        [Trait("Operation", "GROUP BY")]
        public void Does_select_one_dynamic_with_order_by_and_multiple_aliased_group_by_result_in_correct_output()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            dynamic? result = db.SelectOne(
                    dbo.Person.GenderType,
                    dbo.Person.LastName,
                    db.fx.Count().As("person_count")
                ).From(dbo.Person)
                .OrderBy(dbo.Person.LastName)
                .GroupBy(
                    ("Person", "GenderType"),
                    ("Person", "LastName")
                )
                .Execute();

            //then
            (result as object).Should().NotBeNull();
        }

        [Fact]
        [Trait("Operation", "ORDER BY")]
        [Trait("Operation", "GROUP BY")]
        public void Does_select_one_dynamic_with_order_by_and_aliased_and_field_expression_group_by_result_in_correct_output()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            dynamic? result = db.SelectOne(
                    dbo.Person.GenderType,
                    dbo.Person.LastName,
                    db.fx.Count().As("person_count")
                ).From(dbo.Person)
                .OrderBy(dbo.Person.LastName)
                .GroupBy(
                    ("Person", "GenderType"),
                    dbo.Person.LastName
                )
                .Execute();

            //then
            (result as object).Should().NotBeNull();
        }

        [Theory]
        [Trait("Operation", "GROUP BY")]
        [InlineData(41)]
        public void Does_select_many_values_with_aliased_group_by_result_in_correct_output(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            IEnumerable<string> results = db.SelectMany(
                    dbo.Person.LastName
                ).From(dbo.Person)
                .GroupBy(("Person", "LastName"))
                .Execute();

            //then
            results.Should().HaveCount(expectedCount);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [Trait("Operation", "GROUP BY")]
        [InlineData(41)]
        public void Does_select_many_values_with_order_by_and_aliased_group_by_result_in_correct_output(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            IEnumerable<string> results = db.SelectMany(
                    dbo.Person.LastName
                ).From(dbo.Person)
                .OrderBy(dbo.Person.LastName)
                .GroupBy(("Person", "LastName"))
                .Execute();

            //then
            results.Should().HaveCount(expectedCount);
        }

        [Fact]
        [Trait("Operation", "GROUP BY")]
        public void Does_select_one_value_with_aliased_group_by_result_in_correct_output()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            string? result = db.SelectOne(
                    dbo.Person.LastName
                ).From(dbo.Person)
                .GroupBy(("Person", "LastName"))
                .Execute();

            //then
            (result as object).Should().NotBeNull();
        }

        [Fact]
        [Trait("Operation", "ORDER BY")]
        [Trait("Operation", "GROUP BY")]
        public void Does_select_one_value_with_order_by_and_aliased_group_by_result_in_correct_output()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            string? result = db.SelectOne(
                    dbo.Person.LastName
                ).From(dbo.Person)
                .OrderBy(dbo.Person.LastName)
                .GroupBy(("Person", "LastName"))
                .Execute();

            //then
            (result as object).Should().NotBeNull();
        }
    }
}

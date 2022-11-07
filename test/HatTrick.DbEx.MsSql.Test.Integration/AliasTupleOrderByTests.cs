using DbEx.Data;
using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System.Collections.Generic;
using System.Linq;
using System.Dynamic;
using Xunit;
using System;
using HatTrick.DbEx.Sql.Builder.Alias;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    public class AliasTupleOrderByTests : ResetDatabaseNotRequired
    {        
        [Theory]
        [Trait("Operation", "ORDER BY")]
        [MsSqlVersions.AllVersions]
        public void Does_select_many_entity_with_multiple_aliased_order_by_result_in_correct_output(int version, int expectedCount = 50)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            IList<AccessAuditLog> results = db.SelectMany<AccessAuditLog>(
                ).From(dbo.AccessAuditLog)
                .OrderBy(
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
        [MsSqlVersions.AllVersions]
        public void Does_select_many_entity_with_aliased_and_field_expression_order_by_result_in_correct_output(int version, int expectedCount = 50)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            IList<AccessAuditLog> results = db.SelectMany<AccessAuditLog>(
                ).From(dbo.AccessAuditLog)
                .OrderBy(
                    ("AccessAuditLog", "Id"),
                    ("AccessAuditLog", "PersonId"),
                    dbo.AccessAuditLog.AccessResult,
                    ("AccessAuditLog", "DateCreated")
                )
                .Execute();

            //then
            results.Should().HaveCount(expectedCount);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [MsSqlVersions.AllVersions]
        public void Does_select_one_entity_with_multiple_aliased_order_by_result_in_correct_output(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            AccessAuditLog? result = db.SelectOne<AccessAuditLog>(
                ).From(dbo.AccessAuditLog)
                .OrderBy(
                    ("AccessAuditLog", "Id"),
                    ("AccessAuditLog", "PersonId"),
                    ("AccessAuditLog", "AccessResult"),
                    ("AccessAuditLog", "DateCreated")
                )
                .Execute();

            //then
            (result as object).Should().NotBeNull();
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [MsSqlVersions.AllVersions]
        public void Does_select_one_entity_with_aliased_and_field_expression_order_by_result_in_correct_output(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            AccessAuditLog? result = db.SelectOne<AccessAuditLog>(
               ).From(dbo.AccessAuditLog)
               .OrderBy(
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
        [Trait("Operation", "ORDER BY")]
        [MsSqlVersions.AllVersions]
        public void Does_select_many_dynamic_with_aliased_order_by_result_in_correct_output(int version, int expectedCount = 50)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            IList<dynamic> results = db.SelectMany(
                    dbo.Person.LastName,
                    dbo.Person.FirstName
                ).From(dbo.Person)
                .OrderBy(("Person", "LastName"))
                .Execute();

            //then
            results.Should().HaveCount(expectedCount);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [MsSqlVersions.AllVersions]
        public void Does_select_many_dynamic_with_multiple_aliased_order_by_result_in_correct_output(int version, int expectedCount = 50)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            IList<dynamic> results = db.SelectMany(
                    dbo.Person.GenderType,
                    dbo.Person.LastName
                ).From(dbo.Person)
                .OrderBy(
                    ("Person", "GenderType"),
                    ("Person", "LastName")
                )
                .Execute();

            //then
            results.Should().HaveCount(expectedCount);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [MsSqlVersions.AllVersions]
        public void Does_select_many_dynamic_with_aliased_and_field_expression_order_by_result_in_correct_output(int version, int expectedCount = 50)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            IList<dynamic> results = db.SelectMany(
                    dbo.Person.GenderType,
                    dbo.Person.LastName
                ).From(dbo.Person)
                .OrderBy(
                    ("Person", "GenderType"),
                    dbo.Person.LastName
                )
                .Execute();

            //then
            results.Should().HaveCount(expectedCount);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [MsSqlVersions.AllVersions]
        public void Does_select_one_dynamic_with_aliased_order_by_result_in_correct_output(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            dynamic? result = db.SelectOne(
                    dbo.Person.LastName,
                    dbo.Person.FirstName
                ).From(dbo.Person)
                .OrderBy(("Person", "LastName"))
                .Execute();

            //then
            (result as object).Should().NotBeNull();
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [MsSqlVersions.AllVersions]
        public void Does_select_one_dynamic_with_multiple_aliased_order_by_result_in_correct_output(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            dynamic? result = db.SelectOne(
                    dbo.Person.GenderType,
                    dbo.Person.LastName
                ).From(dbo.Person)
                .OrderBy(
                    ("Person", "GenderType"),
                    ("Person", "LastName")
                )
                .Execute();

            //then
            (result as object).Should().NotBeNull();
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [MsSqlVersions.AllVersions]
        public void Does_select_one_dynamic_with_aliased_and_field_expression_order_by_result_in_correct_output(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            dynamic? result = db.SelectOne(
                    dbo.Person.GenderType,
                    dbo.Person.LastName
                ).From(dbo.Person)
                .OrderBy(
                    ("Person", "GenderType"),
                    dbo.Person.LastName
                )
                .Execute();

            //then
            (result as object).Should().NotBeNull();
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [MsSqlVersions.AllVersions]
        public void Does_select_many_values_with_aliased_order_by_result_in_correct_output(int version, int expectedCount = 50)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            IList<string> results = db.SelectMany(
                    dbo.Person.LastName
                ).From(dbo.Person)
                .OrderBy(("Person", "LastName"))
                .Execute();

            //then
            results.Should().HaveCount(expectedCount);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [MsSqlVersions.AllVersions]
        public void Does_select_one_value_with_aliased_order_by_result_in_correct_output(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            string? result = db.SelectOne(
                    dbo.Person.LastName
                ).From(dbo.Person)
                .OrderBy(("Person", "LastName"))
                .Execute();

            //then
            (result as object).Should().NotBeNull();
        }
    }
}

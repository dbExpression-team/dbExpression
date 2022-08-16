using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Builder.Alias;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Collections.Generic;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "PATINDEX")]
    public partial class PatIndexTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_patindex_of_person_first_name_with_static_value_pattern_succeed(int version, string pattern = "K%", string firstName = "Kenny", long expected = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.PatIndex(pattern, dbo.Person.FirstName)
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            long result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_patindex_of_address_line2_with_static_value_pattern_succeed(int version, string pattern = "A%", string line2 = "Apt. 42", long expected = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.PatIndex(pattern, dbo.Address.Line2)
                ).From(dbo.Address)
                .Where(dbo.Address.Line2 == line2);

            //when               
            long? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_patindex_of_null_address_line2_with_static_value_pattern_and_no_match_succeed(int version, string pattern = "Z%")
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.PatIndex(pattern, dbo.Address.Line2)
                ).From(dbo.Address)
                .Where(dbo.Address.Line2 == dbex.Null);

            //when               
            long? result = exp.Execute();

            //then
            result.Should().BeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_patindex_of_person_first_name_with_null_value_pattern_throw_exception(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when & then      
            Assert.Throws<ArgumentException>(() => 
                db.SelectOne(
                    db.fx.PatIndex((string)null!, dbo.Person.FirstName)
                ).From(dbo.Person)
            );
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_where_clause_with_patindex_of_person_first_name_with_static_value_pattern_succeed(int version, string pattern = "K%", int expected = 3)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectMany<Person>()
                .From(dbo.Person)
                .Where(db.fx.PatIndex(pattern, dbo.Person.FirstName) == 1);

            //when               
            var persons = exp.Execute();

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "SUBQUERY")]
        public void Does_patindex_of_aliased_field_succeed(int version, int expected = 0)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.PatIndex("P", ("_address", "Line1")).As("address_line1")
                ).From(dbo.Address)
                .InnerJoin(
                    db.SelectOne<Address>()
                    .From(dbo.Address)
                    .Where(dbo.Address.Id == 1)
                ).As("_address").On(dbo.Address.Id == ("_address", "Id"));

            //when               
            long? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }
    }
}

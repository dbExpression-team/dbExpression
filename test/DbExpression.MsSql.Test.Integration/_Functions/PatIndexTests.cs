using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Builder.Alias;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System;
using System.Collections.Generic;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "PATINDEX")]
    public partial class PatIndexTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData("K%", "Kenny", 1)]
        public void Does_patindex_of_person_first_name_with_static_value_pattern_succeed(string pattern, string firstName, long expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
        [InlineData("A%", "Apt. 42", 1)]
        public void Does_patindex_of_address_line2_with_static_value_pattern_succeed(string pattern, string line2, long expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
        [InlineData("Z%")]
        public void Does_patindex_of_null_address_line2_with_static_value_pattern_and_no_match_succeed(string pattern)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.PatIndex(pattern, dbo.Address.Line2)
                ).From(dbo.Address)
                .Where(dbo.Address.Line2 == dbex.Null);

            //when               
            long? result = exp.Execute();

            //then
            result.Should().BeNull();
        }

        [Fact]
        public void Does_patindex_of_person_first_name_with_null_value_pattern_throw_exception()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when & then      
            Assert.Throws<ArgumentException>(() => 
                db.SelectOne(
                    db.fx.PatIndex((string)null!, dbo.Person.FirstName)
                ).From(dbo.Person)
            );
        }

        [Theory]
        [InlineData("K%", 3)]
        public void Does_where_clause_with_patindex_of_person_first_name_with_static_value_pattern_succeed(string pattern, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person)
                .Where(db.fx.PatIndex(pattern, dbo.Person.FirstName) == 1);

            //when               
            var persons = exp.Execute();

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [InlineData(0)]
        public void Does_patindex_of_aliased_field_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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

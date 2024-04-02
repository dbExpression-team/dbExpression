
using DbEx.Data;
using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System.Linq;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Operation", "ORDER BY")]
    public partial class OrderByTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(50, 1)]
        public void Does_selecting_value_list_with_order_by_asc_succeed(int expectedCount, int expectedId)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person)
                .OrderBy(dbo.Person.Id.Asc());

            //when               
            var persons = exp.Execute();

            //then
            persons.Should().HaveCount(expectedCount);
            persons.First().Should().Be(expectedId);
        }

        [Theory]
        [InlineData(50, 1)]
        public void Does_selecting_value_list_with_order_by_desc_succeed(int expectedCount, int expectedId)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person)
                .OrderBy(dbo.Person.Id.Desc());

            //when               
            var persons = exp.Execute();

            //then
            persons.Should().HaveCount(expectedCount);
            persons.First().Should().NotBe(expectedId);
        }

        [Theory]
        [InlineData(1)]
        public void Does_selecting_value_with_order_by_asc_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(dbo.Person.Id)
                .From(dbo.Person)
                .OrderBy(dbo.Person.Id.Asc());

            //when               
            var persons = exp.Execute();

            //then
            persons.Should().Be(expected);
        }

        [Theory]
        [InlineData(1)]
        public void Does_selecting_value_with_order_by_desc_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(dbo.Person.Id)
                .From(dbo.Person)
                .OrderBy(dbo.Person.Id.Desc());

            //when               
            var persons = exp.Execute();

            //then
            persons.Should().NotBe(expected);
        }

        [Theory]
        [InlineData(50, 1)]
        public void Does_selecting_dynamic_value_list_with_order_by_asc_succeed(int expectedCount, int expectedId)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person)
                .OrderBy(dbo.Person.Id.Asc());

            //when               
            var persons = exp.Execute();

            //then
            persons.Should().HaveCount(expectedCount);
            ((int)persons.First().Id).Should().Be(expectedId);
        }

        [Theory]
        [InlineData(50, 1)]
        public void Does_selecting_dynamic_value_list_with_order_by_desc_succeed(int expectedCount, int expectedId)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person)
                .OrderBy(dbo.Person.Id.Desc());

            //when               
            var persons = exp.Execute();

            //then
            persons.Should().HaveCount(expectedCount);
            ((int)persons.First().Id).Should().NotBe(expectedId);
        }

        [Theory]
        [InlineData(1)]
        public void Does_selecting_dynamic_value_with_order_by_asc_succeed(int expectedId)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person)
                .OrderBy(dbo.Person.Id.Asc());

            //when               
            var person = exp.Execute();

            //then
            ((int)person!.Id).Should().Be(expectedId);
        }

        [Theory]
        [InlineData(1)]
        public void Does_selecting_dynamic_value_with_order_by_desc_succeed(int expectedId)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person)
                .OrderBy(dbo.Person.Id.Desc());

            //when               
            var person = exp.Execute();

            //then
            ((int)person!.Id).Should().NotBe(expectedId);
        }

        [Theory]
        [InlineData(50, 1)]
        public void Does_selecting_entity_list_with_order_by_asc_succeed(int expectedCount, int expectedId)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person)
                .OrderBy(dbo.Person.Id.Asc());

            //when               
            var persons = exp.Execute();

            //then
            persons.Should().HaveCount(expectedCount);
            persons.First().Id.Should().Be(expectedId);
        }

        [Theory]
        [InlineData(50, 1)]
        public void Does_selecting_entity_list_with_order_by_desc_succeed(int expectedCount, int expectedId)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person)
                .OrderBy(dbo.Person.Id.Desc());

            //when               
            var persons = exp.Execute();

            //then
            persons.Should().HaveCount(expectedCount);
            persons.First().Should().NotBe(expectedId);
        }

        [Theory]
        [InlineData(1)]
        public void Does_selecting_entity_with_order_by_asc_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne<Person>()
                .From(dbo.Person)
                .OrderBy(dbo.Person.Id.Asc());

            //when               
            var person = exp.Execute();

            //then
            person!.Id.Should().Be(expected);
        }

        [Theory]
        [InlineData(1)]
        public void Does_selecting_entity_with_order_by_desc_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne<Person>()
                .From(dbo.Person)
                .OrderBy(dbo.Person.Id.Desc());

            //when               
            var person = exp.Execute();

            //then
            person!.Id.Should().NotBe(expected);
        }

        [Fact]
        [Trait("Operation", "SUBQUERY")]
        public void Does_order_by_in_subquery_fail_with_expected_exception()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    dbex.Alias<double>("lines", "PurchasePrice").As("alias")
                ).From(dbo.Purchase)
                .LeftJoin(
                    db.SelectMany<PurchaseLine>()
                    .From(dbo.PurchaseLine)
                    .OrderBy(dbo.PurchaseLine.PurchasePrice.Desc())
                ).As("lines").On(dbo.Purchase.Id == ("lines", "PurchaseId"))
                .Where(dbo.Purchase.Id == 1);

            //when & then
            Assert.Throws<Microsoft.Data.SqlClient.SqlException>(() => exp.Execute());
        }
    }
}

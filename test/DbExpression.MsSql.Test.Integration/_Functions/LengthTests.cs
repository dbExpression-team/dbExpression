using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Builder.Alias;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "LENGTH")]
    public partial class LengthTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData("Kenny", 5)]
        public void Does_length_of_person_first_name_succeed(string firstName, long expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Len(dbo.Person.FirstName)
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            long length = exp.Execute();

            //then
            length.Should().Be(expected);
        }

        [Theory]
        [InlineData(null)]
        public void Does_length_of_address_line2_succeed(string? line2)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Len(dbo.Address.Line2)
                ).From(dbo.Address)
                .Where(dbo.Address.Line2 == line2);

            //when               
            long? length = exp.Execute();

            //then
            length.Should().BeNull();
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [InlineData(10)]
        public void Can_datepart_of_aliased_field_succeed(long expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Len(("other", "Line1")).As("alias")
                ).From(dbo.Address)
                .InnerJoin(
                    db.SelectOne(
                            dbo.Address.Id,
                            dbo.Address.Line1
                        )
                        .From(dbo.Address)
                        .Where(dbo.Address.Line1 == "100 1st St")
                ).As("other").On(dbo.Address.Id == ("other", "Id"));

            //when               
            long? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }
    }
}

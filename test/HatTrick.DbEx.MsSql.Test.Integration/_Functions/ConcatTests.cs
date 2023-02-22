using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System.Collections.Generic;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "CONCAT")]
    public partial class ConcatTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(50)]
        public void Does_concat_of_person_first_and_last_name_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Concat(dbo.Person.FirstName, dbo.Person.LastName)
                ).From(dbo.Person);

            //when               
            IEnumerable<string> names = exp.Execute();

            //then
            names.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public void Does_concat_of_person_first_and_last_name_with_literal_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Concat(dbo.Person.FirstName, " ", dbo.Person.LastName)
                ).From(dbo.Person);

            //when               
            IEnumerable<string> names = exp.Execute();

            //then
            names.Should().HaveCount(expected);
        }
    }
}

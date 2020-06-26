using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Builder;
using System;
using System.Collections.Generic;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    public class StringFieldExpression : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_like_firstname_succeed(int version, int expected = 3)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    dbo.Person.FirstName
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName.Like("Bill%"));

            //when               
            IList<string> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_like_firstname_concatenated_with_lastname_succeed(int version, int expected = 1)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    dbo.Person.FirstName
                ).From(dbo.Person)
                .Where((dbo.Person.FirstName + " " + dbo.Person.LastName).Like("David W%"));

            //when               
            IList<string> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }
    }
}

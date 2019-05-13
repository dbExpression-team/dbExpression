using DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Extensions.Builder;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    public partial class SelectMany
    {
        [Trait("Operation", "INNER JOIN")]
        public partial class InnerJoin
        {
            public partial class CrossSchema : ExecutorTestBase
            {
                [Theory]
                [MsSqlVersions.AllVersions]
                public void Does_joining_across_schemas_succeed(int version, int expectedCount = 0)
                {
                    //given
                    ConfigureForMsSqlVersion(version);

                    var exp = db.SelectMany(
                            sec.Person.Id
                        ).From(dbo.Person.As("dboPerson"))
                        .InnerJoin(sec.Person).On(dbo.Person.As("dboPerson").Id == sec.Person.Id);

                    //when               
                    var purchases = exp.Execute();

                    //then
                    purchases.Should().HaveCount(expectedCount);
                }

                [Theory]
                [MsSqlVersions.AllVersions]
                public void Does_joining_across_schemas_with_explicit_alias_succeed(int version, int expectedCount = 0)
                {
                    //given
                    ConfigureForMsSqlVersion(version);

                    var foo = sec.Person.As("foo");

                    var exp = db.SelectMany(
                            foo.Id
                        ).From(dbo.Person)
                        .InnerJoin(foo).As("foo").On(dbo.Person.Id == foo.Id);

                    //when               
                    var purchases = exp.Execute();

                    //then
                    purchases.Should().HaveCount(expectedCount);
                }
            }
        }
    }
}

using DbEx.DataService;
using DbEx.dboDataService;
using DbEx.secDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System.Collections.Generic;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Statement", "SELECT")]
    public partial class SelectMany
    {
        public class MultiSchema : ExecutorTestBase
        {
            [Theory]
            [MsSqlVersions.AllVersions]
            [Trait("Operation", "INNER JOIN")]
            public void Are_there_50_records_for_persons_when_inner_joining_to_sec_schema(int version, int expected = 50)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectMany(
                        dbo.Person.As("dboPerson").Id.As("dboId"), 
                        sec.Person.Id.As("secId")
                    )
                    .From(dbo.Person.As("dboPerson"))
                    .InnerJoin(sec.Person).On(dbo.Person.As("dboPerson").Id == sec.Person.Id);

                //when               
                IList<dynamic> persons = exp.Execute();

                //then
                persons.Should().HaveCount(expected);
            }

            [Theory]
            [MsSqlVersions.AllVersions]
            [Trait("Operation", "INNER JOIN")]
            public void Are_there_50_records_for_persons_when_inner_joining_to_sec_schema_when_reversing_join_condition(int version, int expected = 50)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectMany(
                        dbo.Person.As("dboPerson").Id.As("dboId"), 
                        sec.Person.Id.As("secId")
                    )
                    .From(dbo.Person.As("dboPerson"))
                    .InnerJoin(sec.Person).On(sec.Person.Id == dbo.Person.As("dboPerson").Id);

                //when               
                IList<dynamic> persons = exp.Execute();

                //then
                persons.Should().HaveCount(expected);
            }
        }
    }
}

using Data;
using Data.dbo;
using DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Extensions.Builder;
using System;
using System.Linq;
using Xunit;
using db = HatTrick.DbEx.MsSql.Builder.MsSqlExpressionBuilder;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    public partial class SelectAll
    {
        public class MultiSchema : ExecutorTestBase
        {
            [Theory]
            [InlineData(2012, 0)]
            [InlineData(2014, 0)]
            public void Are_there_no_records_for_persons_when_inner_joining_to_sec_schema(int version, int expectedCount)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(dbo.Person.As("dboPerson").Id, sec.Person.Id)
                    .From(dbo.Person.As("dboPerson"))
                    .InnerJoin(sec.Person).On(dbo.Person.As("dboPerson").Id == sec.Person.Id);

                //when               
                var persons = exp.Execute();

                //then
                persons.Should().HaveCount(expectedCount);
            }

            [Theory]
            [InlineData(2012, 0)]
            [InlineData(2014, 0)]
            public void Are_there_no_records_for_persons_when_inner_joining_to_sec_schema_when_reversing_join_condition(int version, int expectedCount)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(dbo.Person.As("dboPerson").Id, sec.Person.Id)
                    .From(dbo.Person.As("dboPerson"))
                    .InnerJoin(sec.Person).On(sec.Person.Id == dbo.Person.As("dboPerson").Id);

                //when               
                var persons = exp.Execute();

                //then
                persons.Should().HaveCount(expectedCount);
            }
        }
    }
}

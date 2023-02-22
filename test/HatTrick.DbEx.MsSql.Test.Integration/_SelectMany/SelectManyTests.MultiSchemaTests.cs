using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using v2019DbEx.secDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System.Collections.Generic;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    public partial class SelectManyTests
    {
        public class MultiSchemaTests : ResetDatabaseNotRequired
        {
            [Theory]
            [Trait("Operation", "INNER JOIN")]
            [InlineData(true, 50)]
            [InlineData(false, 50)]
            public void Are_there_50_records_for_persons_when_inner_joining_to_sec_schema(bool useSyntheticAliases, int expected)
            {
                //given
                var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

                var exp = db.SelectMany(
                        dbo.Person.As("dboPerson").Id.As("dboId"),
                        sec.Person.Id.As("secId")
                    )
                    .From(dbo.Person.As("dboPerson"))
                    .InnerJoin(sec.Person).On(dbo.Person.As("dboPerson").Id == sec.Person.Id);

                //when               
                IEnumerable<dynamic> persons = exp.Execute();

                //then
                persons.Should().HaveCount(expected);
            }

            [Theory]
            [Trait("Operation", "INNER JOIN")]
            [InlineData(true, 50)]
            [InlineData(false, 50)]
            public void Are_there_50_records_for_persons_when_inner_joining_to_sec_schema_when_reversing_join_condition(bool useSyntheticAliases, int expected)
            {
                //given
                var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

                var exp = db.SelectMany(
                        dbo.Person.As("dboPerson").Id.As("dboId"),
                        sec.Person.Id.As("secId")
                    )
                    .From(dbo.Person.As("dboPerson"))
                    .InnerJoin(sec.Person).On(sec.Person.Id == dbo.Person.As("dboPerson").Id);

                //when               
                IEnumerable<dynamic> persons = exp.Execute();

                //then
                persons.Should().HaveCount(expected);
            }
        }
    }
}

using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System.Collections.Generic;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    public partial class SelectManyTests
    {
        public partial class InnerJoinTests : ExecutorTestBase
        {
            [Theory]
            [MsSqlVersions.AllVersions]
            [Trait("Operation", "INNER JOIN")]
            public void Does_persons_with_addresses_have_52_records(int version)
            {
                //given
                var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

                var exp = db.SelectMany(dbo.Person.Id)
                    .From(dbo.Person)
                    .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId);

                //when               
                IList<int> persons = exp.Execute();

                //then
                persons.Should().HaveCount(52);
            }

            [Theory]
            [MsSqlVersions.AllVersions]
            [Trait("Operation", "INNER JOIN")]
            public void Can_select_values_from_one_table_while_using_a_different_table_in_the_from_clause(int version)
            {
                //given
                var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

                var exp = db.SelectMany(dbo.Person.Id)
                    .From(dbo.PersonAddress)
                    .InnerJoin(dbo.Person).On(dbo.PersonAddress.PersonId == dbo.Person.Id);

                //when               
                IList<int> persons = exp.Execute();

                //then
                persons.Should().HaveCount(52);
            }

            [Theory]
            [MsSqlVersions.AllVersions]
            [Trait("Operation", "INNER JOIN")]
            public void Can_select_entities_from_one_table_while_using_a_different_table_in_the_from_clause(int version)
            {
                //given
                var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

                var exp = db.SelectMany<Person>()
                    .From(dbo.PersonAddress)
                    .InnerJoin(dbo.Person).On(dbo.PersonAddress.PersonId == dbo.Person.Id);

                //when               
                IList<Person> persons = exp.Execute();

                //then
                persons.Should().HaveCount(52);
            }
        }
    }
}

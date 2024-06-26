using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System.Collections.Generic;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    public partial class SelectManyTests
    {
        public partial class InnerJoinTests : ResetDatabaseNotRequired
        {
            [Theory]
            [InlineData(false)]
            [InlineData(true)]
            [Trait("Operation", "INNER JOIN")]
            public void Does_persons_with_addresses_have_52_records(bool useSyntheticAliases)
            {
                //given
                var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

                var exp = db.SelectMany(dbo.Person.Id)
                    .From(dbo.Person)
                    .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId);

                //when               
                IEnumerable<int> persons = exp.Execute();

                //then
                persons.Should().HaveCount(52);
            }

            [Theory]
            [InlineData(false)]
            [InlineData(true)]
            [Trait("Operation", "INNER JOIN")]
            public void Can_select_values_from_one_table_while_using_a_different_table_in_the_from_clause(bool useSyntheticAliases)
            {
                //given
                var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

                var exp = db.SelectMany(dbo.Person.Id)
                    .From(dbo.PersonAddress)
                    .InnerJoin(dbo.Person).On(dbo.PersonAddress.PersonId == dbo.Person.Id);

                //when               
                IEnumerable<int> persons = exp.Execute();

                //then
                persons.Should().HaveCount(52);
            }

            [Theory]
            [InlineData(false)]
            [InlineData(true)]
            [Trait("Operation", "INNER JOIN")]
            public void Can_select_entities_from_one_table_while_using_a_different_table_in_the_from_clause(bool useSyntheticAliases)
            {
                //given
                var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

                var exp = db.SelectMany<Person>()
                    .From(dbo.PersonAddress)
                    .InnerJoin(dbo.Person).On(dbo.PersonAddress.PersonId == dbo.Person.Id);

                //when               
                IEnumerable<Person> persons = exp.Execute();

                //then
                persons.Should().HaveCount(52);
            }
        }
    }
}

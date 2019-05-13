using Data;
using DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Extensions.Builder;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    public partial class SelectMany
    {
        public partial class InnerJoin : ExecutorTestBase
        {
            [Theory]
            [InlineData(2012)]
            [InlineData(2014)]
            public void Does_persons_with_addresses_have_52_records(int version)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectMany<int>(dbo.Person.Id)
                    .From(dbo.Person)
                    .InnerJoin(dbo.Person_Address).On(dbo.Person.Id == dbo.Person_Address.PersonId);

                //when               
                var persons = exp.Execute();

                //then
                persons.Should().HaveCount(52);
            }
        }
    }
}

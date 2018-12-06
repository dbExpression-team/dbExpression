using DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Extensions.Builder;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    public partial class SelectAll
    {
        public partial class InnerJoin
        {
            public partial class GroupBy : ExecutorTestBase
            {
                [Theory]
                [Trait("Function", "COUNT")]
                [InlineData(2014)]
                public void Does_address_count_by_person_have_correct_record_counts(int version)
                {
                    //given
                    ConfigureForMsSqlVersion(version);

                    var exp = db.SelectAll(
                            dbo.Person.Id,
                            db.Count(dbo.Address.Id).As("AddressCount")
                        )
                        .From(dbo.Person)
                        .InnerJoin(dbo.Person_Address).On(dbo.Person.Id == dbo.Person_Address.PersonId)
                        .InnerJoin(dbo.Address).On(dbo.Person_Address.AddressId == dbo.Address.Id)
                        .GroupBy(dbo.Person.Id);

                    //when               
                    var persons = exp.Execute();

                    //then
                    persons.Should().HaveCount(35);
                    persons.Count(a => a.AddressCount == 1).Should().Be(18);
                    persons.Count(a => a.AddressCount == 2).Should().Be(17);
                }

                [Theory]
                [Trait("Function", "COUNT")]
                [InlineData(2014)]
                public void Does_address_count_by_person_having_count_greater_than_1_have_18_records(int version)
                {
                    //given
                    ConfigureForMsSqlVersion(version);

                    var exp = db.SelectAll(
                            dbo.Person.Id,
                            db.Count(dbo.Address.Id).As("AddressCount")
                        )
                        .From(dbo.Person)
                        .InnerJoin(dbo.Person_Address).On(dbo.Person.Id == dbo.Person_Address.PersonId)
                        .InnerJoin(dbo.Address).On(dbo.Person_Address.AddressId == dbo.Address.Id)
                        .GroupBy(dbo.Person.Id)
                        .Having(db.Count(dbo.Address.Id) > 1);

                    //when               
                    var persons = exp.Execute();

                    //then
                    persons.Should().HaveCount(17);
                }

                [Theory]
                [Trait("Function", "COUNT")]
                [InlineData(2014)]
                public void Does_address_count_by_person_having_count_greater_than_1_and_less_than_3_have_18_records(int version)
                {
                    //given
                    ConfigureForMsSqlVersion(version);

                    var exp = db.SelectAll(
                            dbo.Person.Id,
                            db.Count(dbo.Address.Id).As("AddressCount")
                        )
                        .From(dbo.Person)
                        .InnerJoin(dbo.Person_Address).On(dbo.Person.Id == dbo.Person_Address.PersonId)
                        .InnerJoin(dbo.Address).On(dbo.Person_Address.AddressId == dbo.Address.Id)
                        .GroupBy(dbo.Person.Id)
                        //basically equal to 2, testing composite having statement
                        .Having(db.Count(dbo.Address.Id) > 1 & db.Count(dbo.Address.Id) < 3);

                    //when               
                    var persons = exp.Execute();

                    //then
                    persons.Should().HaveCount(17);
                }

                [Theory]
                [Trait("Function", "COUNT")]
                [InlineData(2014)]
                public void Does_address_count_by_person_having_count_equal_to_1_2_or_3_have_35_records(int version)
                {
                    //given
                    ConfigureForMsSqlVersion(version);

                    var exp = db.SelectAll(
                            dbo.Person.Id,
                            db.Count(dbo.Address.Id).As("AddressCount")
                        )
                        .From(dbo.Person)
                        .InnerJoin(dbo.Person_Address).On(dbo.Person.Id == dbo.Person_Address.PersonId)
                        .InnerJoin(dbo.Address).On(dbo.Person_Address.AddressId == dbo.Address.Id)
                        .GroupBy(dbo.Person.Id)
                        //testing composite having statement with 3 parts
                        .Having(db.Count(dbo.Address.Id) == 1 | db.Count(dbo.Address.Id) == 2 | db.Count(dbo.Address.Id) == 3);

                    //when               
                    var persons = exp.Execute();

                    //then
                    persons.Should().HaveCount(35);
                }
            }
        }
    }
}

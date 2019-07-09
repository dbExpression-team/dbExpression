using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Builder;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    public partial class SelectMany
    {
        public partial class InnerJoin
        {
            public partial class GroupBy : ExecutorTestBase
            {
                [Theory]
                [Trait("Function", "COUNT")]
                [Trait("Operation", "GROUP BY")]
                [MsSqlVersions.AllVersions]
                public void Does_address_count_by_person_have_correct_record_counts(int version, int expectedCount = 35)
                {
                    //given
                    ConfigureForMsSqlVersion(version);

                    var exp = db.SelectMany(
                            dbo.Person.Id,
                            db.fx.Count(dbo.Address.Id).As("AddressCount")
                        )
                        .From(dbo.Person)
                        .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
                        .InnerJoin(dbo.Address).On(dbo.PersonAddress.AddressId == dbo.Address.Id)
                        .GroupBy(dbo.Person.Id);

                    //when               
                    var persons = exp.Execute();

                    //then
                    persons.Should().HaveCount(expectedCount);
                    persons.Count(a => a.AddressCount == 1).Should().Be(18);
                    persons.Count(a => a.AddressCount == 2).Should().Be(17);
                }

                [Theory]
                [Trait("Function", "COUNT")]
                [Trait("Operation", "GROUP BY")]
                [Trait("Operation", "HAVING")]
                [MsSqlVersions.AllVersions]
                public void Does_address_count_by_person_having_count_greater_than_1_have_18_records(int version, int expectedCount = 17)
                {
                    //given
                    ConfigureForMsSqlVersion(version);

                    var exp = db.SelectMany(
                            dbo.Person.Id,
                            db.fx.Count(dbo.Address.Id).As("AddressCount")
                        )
                        .From(dbo.Person)
                        .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
                        .InnerJoin(dbo.Address).On(dbo.PersonAddress.AddressId == dbo.Address.Id)
                        .GroupBy(dbo.Person.Id)
                        .Having(db.fx.Count(dbo.Address.Id) > 1);

                    //when               
                    var persons = exp.Execute();

                    //then
                    persons.Should().HaveCount(expectedCount);
                }

                [Theory]
                [Trait("Function", "COUNT")]
                [Trait("Operation", "GROUP BY")]
                [Trait("Operation", "HAVING")]
                [MsSqlVersions.AllVersions]
                public void Does_address_count_by_person_having_count_greater_than_1_and_less_than_3_have_18_records(int version, int expectedCount = 17)
                {
                    //given
                    ConfigureForMsSqlVersion(version);

                    var exp = db.SelectMany(
                            dbo.Person.Id,
                            db.fx.Count(dbo.Address.Id).As("AddressCount")
                        )
                        .From(dbo.Person)
                        .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
                        .InnerJoin(dbo.Address).On(dbo.PersonAddress.AddressId == dbo.Address.Id)
                        .GroupBy(dbo.Person.Id)
                        //basically equal to 2, testing composite having statement
                        .Having(db.fx.Count(dbo.Address.Id) > 1 & db.fx.Count(dbo.Address.Id) < 3);

                    //when               
                    var persons = exp.Execute();

                    //then
                    persons.Should().HaveCount(expectedCount);
                }

                [Theory]
                [Trait("Function", "COUNT")]
                [Trait("Operation", "GROUP BY")]
                [Trait("Operation", "HAVING")]
                [MsSqlVersions.AllVersions]
                public void Does_address_count_by_person_having_count_equal_to_1_2_or_3_have_35_records(int version, int expectedCount = 35)
                {
                    //given
                    ConfigureForMsSqlVersion(version);

                    var exp = db.SelectMany(
                            dbo.Person.Id,
                            db.fx.Count(dbo.Address.Id).As("AddressCount")
                        )
                        .From(dbo.Person)
                        .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
                        .InnerJoin(dbo.Address).On(dbo.PersonAddress.AddressId == dbo.Address.Id)
                        .GroupBy(dbo.Person.Id)
                        //testing composite having statement with 3 parts
                        .Having(db.fx.Count(dbo.Address.Id) == 1 | db.fx.Count(dbo.Address.Id) == 2 | db.fx.Count(dbo.Address.Id) == 3);

                    //when               
                    var persons = exp.Execute();

                    //then
                    persons.Should().HaveCount(expectedCount);
                }

                [Theory]
                [Trait("Function", "COUNT")]
                [Trait("Operation", "GROUP BY")]
                [Trait("Operation", "HAVING")]
                [Trait("Function", "DATEPART")]
                [MsSqlVersions.AllVersions]
                public void Does_purchasedate_count_by_person_having_count_of_shipdate_equal_to_3_and_year_equal_to_2017_have_correct_count(int version, int expectedCount = 3)
                {
                    //given
                    ConfigureForMsSqlVersion(version);

                    var exp = db.SelectMany(
                            dbo.Person.Id,
                            db.fx.Count(dbo.Purchase.ShipDate).As("ShippedCount"),
                            db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate).As("ShippedDay")
                        )
                        .From(dbo.Purchase)
                        .InnerJoin(dbo.Person).On(dbo.Purchase.PersonId == dbo.Person.Id)
                        .Where(dbo.Purchase.ShipDate != null)
                        .GroupBy(
                            dbo.Person.Id,
                            db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate)
                        )
                        .Having(
                            db.fx.Count(dbo.Purchase.ShipDate) == 3 
                            & db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate) == 2017
                        );

                    //when               
                    var persons = exp.Execute();

                    //then
                    persons.Should().HaveCount(expectedCount);
                }
            }
        }
    }
}

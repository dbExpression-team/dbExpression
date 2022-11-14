using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    public partial class SelectManyTests
    {
        public partial class InnerJoinTests
        {
            public partial class GroupByTests : ResetDatabaseNotRequired
            {
                [Theory]
                [Trait("Function", "COUNT")]
                [Trait("Operation", "INNER JOIN")]
                [Trait("Operation", "GROUP BY")]
                [MsSqlVersions.AllVersions]
                public void Does_address_count_by_person_have_correct_record_counts(int version, int expected = 35, int oneAddressCount = 18, int twoAddressCount = 17)
                {
                    //given
                    var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

                    var exp = db.SelectMany(
                            dbo.Person.Id,
                            db.fx.Count(dbo.Address.Id).As("address_count")
                        )
                        .From(dbo.Person)
                        .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
                        .InnerJoin(dbo.Address).On(dbo.PersonAddress.AddressId == dbo.Address.Id)
                        .GroupBy(dbo.Person.Id);

                    //when               
                    IEnumerable<dynamic> persons = exp.Execute();

                    //then
                    persons.Should().HaveCount(expected);
                    persons.Count(a => a.address_count == 1).Should().Be(oneAddressCount);
                    persons.Count(a => a.address_count == 2).Should().Be(twoAddressCount);
                }

                [Theory]
                [Trait("Function", "COUNT")]
                [Trait("Operation", "INNER JOIN")]
                [Trait("Operation", "GROUP BY")]
                [Trait("Operation", "HAVING")]
                [MsSqlVersions.AllVersions]
                public void Does_address_count_by_person_having_count_greater_than_1_have_18_records(int version, int expected = 17)
                {
                    //given
                    var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

                    var exp = db.SelectMany(
                            dbo.Person.Id,
                            db.fx.Count(dbo.Address.Id).As("address_count")
                        )
                        .From(dbo.Person)
                        .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
                        .InnerJoin(dbo.Address).On(dbo.PersonAddress.AddressId == dbo.Address.Id)
                        .GroupBy(dbo.Person.Id)
                        .Having(db.fx.Count(dbo.Address.Id) > 1);

                    //when               
                    IEnumerable<dynamic> persons = exp.Execute();

                    //then
                    persons.Should().HaveCount(expected);
                    persons.Count(p => p.address_count == 2).Should().Be(expected);
                }

                [Theory]
                [Trait("Function", "COUNT")]
                [Trait("Operation", "INNER JOIN")]
                [Trait("Operation", "GROUP BY")]
                [Trait("Operation", "HAVING")]
                [MsSqlVersions.AllVersions]
                public void Does_address_count_by_person_having_count_greater_than_1_and_less_than_3_have_18_records(int version, int expected = 17)
                {
                    //given
                    var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

                    var exp = db.SelectMany(
                            dbo.Person.Id,
                            db.fx.Count(dbo.Address.Id).As("address_count")
                        )
                        .From(dbo.Person)
                        .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
                        .InnerJoin(dbo.Address).On(dbo.PersonAddress.AddressId == dbo.Address.Id)
                        .GroupBy(dbo.Person.Id)
                        //basically equal to 2, testing composite having statement
                        .Having(db.fx.Count(dbo.Address.Id) > 1 & db.fx.Count(dbo.Address.Id) < 3);

                    //when               
                    IEnumerable<dynamic> persons = exp.Execute();

                    //then
                    persons.Should().HaveCount(expected);
                    persons.Count(p => p.address_count == 2).Should().Be(expected);
                }

                [Theory]
                [Trait("Function", "COUNT")]
                [Trait("Operation", "INNER JOIN")]
                [Trait("Operation", "GROUP BY")]
                [Trait("Operation", "HAVING")]
                [MsSqlVersions.AllVersions]
                public void Does_address_count_by_person_having_count_equal_to_1_2_or_3_have_35_records(int version, int expected = 35, int oneAddressCount = 18, int twoAddressCount = 17, int threeAddressCount = 0)
                {
                    //given
                    var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

                    var exp = db.SelectMany(
                            dbo.Person.Id,
                            db.fx.Count(dbo.Address.Id).As("address_count")
                        )
                        .From(dbo.Person)
                        .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
                        .InnerJoin(dbo.Address).On(dbo.PersonAddress.AddressId == dbo.Address.Id)
                        .GroupBy(dbo.Person.Id)
                        //testing composite having statement with 3 parts
                        .Having(db.fx.Count(dbo.Address.Id) == 1 | db.fx.Count(dbo.Address.Id) == 2 | db.fx.Count(dbo.Address.Id) == 3);

                    //when               
                    IEnumerable<dynamic> persons = exp.Execute();

                    //then
                    persons.Should().HaveCount(expected);
                    persons.Count(a => a.address_count == 1).Should().Be(oneAddressCount);
                    persons.Count(a => a.address_count == 2).Should().Be(twoAddressCount);
                    persons.Count(a => a.address_count == 3).Should().Be(threeAddressCount);
                }

                [Theory]
                [Trait("Function", "COUNT")]
                [Trait("Function", "DATEPART")]
                [Trait("Operation", "INNER JOIN")]
                [Trait("Operation", "WHERE")]
                [Trait("Operation", "GROUP BY")]
                [Trait("Operation", "HAVING")]
                [MsSqlVersions.AllVersions]
                public void Does_purchasedate_count_by_person_having_count_of_shipdate_equal_to_3_and_year_equal_to_2017_have_correct_count(int version, int expected = 3, int shippedCount = 3, int year = 2019)
                {
                    //given
                    var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

                    var exp = db.SelectMany(
                            dbo.Person.Id,
                            db.fx.Count(dbo.Purchase.ShipDate).As("shipped_count"),
                            db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate).As("shipped_year")
                        )
                        .From(dbo.Purchase)
                        .InnerJoin(dbo.Person).On(dbo.Purchase.PersonId == dbo.Person.Id)
                        .Where(dbo.Purchase.ShipDate != dbex.Null)
                        .GroupBy(
                            dbo.Person.Id,
                            db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate)
                        )
                        .Having(
                            db.fx.Count(dbo.Purchase.ShipDate) == shippedCount 
                            & db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate) == year
                        );

                    //when               
                    IEnumerable<dynamic> persons = exp.Execute();

                    //then
                    persons.Should().HaveCount(expected);
                    persons.All(p => p.shipped_count == shippedCount).Should().BeTrue();
                    persons.All(p => p.shipped_year == year).Should().BeTrue();
                }
            }
        }
    }
}

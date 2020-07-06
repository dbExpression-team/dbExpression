using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Statement", "SELECT")]
    public partial class SelectMany
    {
        [Trait("Operation", "INNER JOIN")]
        public partial class InnerJoin
        {
            [Trait("Operation", "Subquery")]
            public class Subquery : ExecutorTestBase
            {
                [Theory]
                [MsSqlVersions.AllVersions]
                public void Does_persons_with_addresses_have_52_records(int version, int expected = 52)
                {
                    //given
                    ConfigureForMsSqlVersion(version);

                    var exp = db.SelectMany(
                            dbo.Person.Id,
                            dbo.PersonAddress.As("t1").PersonId,
                            dbo.PersonAddress.As("t1").AddressId
                        )
                        .From(dbo.Person)
                        .InnerJoin(
                            db.SelectMany(
                                dbo.PersonAddress.PersonId,
                                dbo.PersonAddress.AddressId
                            )
                            .From(dbo.PersonAddress)
                        ).As("t1").On(dbo.Person.Id == dbo.PersonAddress.As("t1").PersonId);

                    //when               
                    var persons = exp.Execute();

                    //then
                    persons.Should().HaveCount(expected);
                    persons.All(p => p.Id == p.PersonId).Should().BeTrue();
                }

                [Theory]
                [MsSqlVersions.AllVersions]
                public void Does_persons_with_addresses_with_aliases_set_using_variable_have_52_records(int version, int expected = 52)
                {
                    //given
                    ConfigureForMsSqlVersion(version);

                    var t1 = dbo.PersonAddress.As("t1");

                    var exp = db.SelectMany(
                            dbo.Person.Id,
                            t1.PersonId,
                            t1.AddressId
                        )
                        .From(dbo.Person)
                        .InnerJoin(
                            db.SelectMany(
                                dbo.PersonAddress.PersonId,
                                dbo.PersonAddress.AddressId
                            )
                            .From(dbo.PersonAddress)
                        ).As("t1").On(dbo.Person.Id == t1.PersonId);

                    //when               
                    var persons = exp.Execute();

                    //then
                    persons.Should().HaveCount(expected);
                    persons.All(p => p.Id == p.PersonId).Should().BeTrue();
                }

                [Theory]
                [MsSqlVersions.AllVersions]
                [Trait("Operation", "WHERE")]
                public void Does_persons_with_purchase_line_equal_to_30_have_1_records(int version, int expected = 1)
                {
                    //given
                    ConfigureForMsSqlVersion(version);

                    var exp = db.SelectMany(
                            dbo.Person.Id,
                            dbo.Purchase.As("t2").PersonId,
                            dbo.Purchase.As("t2").TotalPurchaseAmount,
                            dbo.PurchaseLine.As("t2").PurchasePrice
                        )
                        .From(dbo.Person)
                        .InnerJoin(
                            db.SelectMany(
                                dbo.Purchase.Id,
                                dbo.Purchase.PersonId,
                                dbo.Purchase.TotalPurchaseAmount,
                                dbo.PurchaseLine.As("t1").PurchasePrice
                            )
                            .From(dbo.Purchase)
                            .InnerJoin(
                                db.SelectMany(
                                    dbo.PurchaseLine.PurchaseId,
                                    dbo.PurchaseLine.PurchasePrice)
                                .From(dbo.PurchaseLine)
                                .Where(dbo.PurchaseLine.PurchasePrice == 30)
                            ).As("t1").On(dbo.Purchase.Id == dbo.PurchaseLine.As("t1").PurchaseId)
                        ).As("t2").On(dbo.Person.Id == dbo.Purchase.As("t2").PersonId);

                    //when               
                    var persons = exp.Execute();

                    //then
                    persons.Should().HaveCount(expected);
                    persons.Where(p => p.Id == 6).Should().ContainSingle();
                }

                [Theory]
                [MsSqlVersions.AllVersions]
                [Trait("Operation", "WHERE")]
                public void Does_persons_with_purchase_line_with_aliases_set_using_variables_have_1_records(int version, int expected = 1)
                {
                    //given
                    ConfigureForMsSqlVersion(version);

                    var purchase = dbo.Purchase.As("t0");
                    var purchaseLine = dbo.PurchaseLine.As("t1");
                    var purchaseLine_t2 = dbo.PurchaseLine.As("t2");
                    var purchase_t2 = dbo.Purchase.As("t2");

                    var exp = db.SelectMany(
                            dbo.Person.Id,
                            purchase_t2.PersonId,
                            purchase_t2.TotalPurchaseAmount,
                            purchaseLine_t2.PurchasePrice
                        )
                        .From(dbo.Person)
                        .InnerJoin(
                            db.SelectMany(
                                purchase.Id,
                                purchase.PersonId,
                                purchase.TotalPurchaseAmount,
                                purchaseLine.PurchasePrice
                            )
                            .From(purchase)
                            .InnerJoin(
                                db.SelectMany(
                                    purchaseLine.PurchaseId,
                                    purchaseLine.PurchasePrice)
                                .From(purchaseLine)
                                .Where(purchaseLine.PurchasePrice == 30)
                            ).As("t1").On(purchase.Id == purchaseLine.PurchaseId)
                        ).As("t2").On(dbo.Person.Id == purchase_t2.PersonId);

                    //when               
                    var persons = exp.Execute();

                    //then
                    persons.Should().HaveCount(expected);
                    persons.Where(p => p.Id == 6).Should().ContainSingle();
                }

                [Theory]
                [MsSqlVersions.AllVersions]
                [Trait("Operation", "WHERE")]
                public void Does_persons_with_purchase_line_using_variables_with_redundant_and_aliased_inner_join_have_1_record(int version, int expected = 1)
                {
                    //given
                    ConfigureForMsSqlVersion(version);

                    var foo = dbo.PurchaseLine.As("foo");

                    var exp = db.SelectMany(
                            dbo.Person.Id,
                            dbo.Purchase.As("t3").PersonId,
                            dbo.Purchase.As("t3").TotalPurchaseAmount,
                            dbo.PurchaseLine.As("t3").PurchasePrice
                        )
                        .From(dbo.Person)
                        .InnerJoin(
                            db.SelectMany(
                                dbo.Purchase.Id,
                                dbo.Purchase.PersonId,
                                dbo.Purchase.TotalPurchaseAmount,
                                dbo.PurchaseLine.As("t1").PurchasePrice
                            )
                            .From(dbo.Purchase)
                            .InnerJoin(
                                db.SelectMany(
                                    dbo.PurchaseLine.PurchaseId,
                                    dbo.PurchaseLine.PurchasePrice)
                                .From(dbo.PurchaseLine)
                                .Where(dbo.PurchaseLine.PurchasePrice == 30)
                            ).As("t1").On(dbo.Purchase.Id == dbo.PurchaseLine.As("t1").PurchaseId)
                            .InnerJoin(
                                db.SelectMany(
                                    foo.PurchaseId,
                                    foo.PurchasePrice)
                                .From(foo)
                                .Where(foo.PurchasePrice == 30)
                            ).As("t2").On(dbo.Purchase.Id == foo.As("t2").PurchaseId)
                        ).As("t3").On(dbo.Person.Id == dbo.Purchase.As("t3").PersonId);

                    //when               
                    var persons = exp.Execute();

                    //then
                    persons.Should().HaveCount(expected);
                    persons.Where(p => p.Id == 6).Should().ContainSingle();
               }


                [Theory]
                [MsSqlVersions.AllVersions]
                [Trait("Operation", "WHERE")]
                public void Does_persons_with_purchases_using_aliased_inner_join_with_like_where_clause_have_3_records(int version, int expected = 3)
                {
                    //given
                    ConfigureForMsSqlVersion(version);

                    var exp = db.SelectMany(
                            dbo.Purchase.Id.As("PurchaseId"),
                            dbo.Person.As("foo").Id.As("PersonId"),
                            (dbo.Person.As("foo").FirstName + " " + dbo.Person.As("foo").LastName).As("Name")
                        )
                        .From(dbo.Purchase)
                        .InnerJoin(
                            db.SelectMany(
                                dbo.Person.Id,
                                dbo.Person.FirstName,
                                dbo.Person.LastName
                            )
                            .From(dbo.Person)
                            .Where((dbo.Person.FirstName + " " + dbo.Person.LastName).Like("Butters S%"))
                        ).As("foo").On(dbo.Purchase.PersonId == dbo.Person.As("foo").Id);

                    //when               
                    var purchases = exp.Execute();

                    //then
                    purchases.Should().HaveCount(expected);
                }
            }
        }
    }
}

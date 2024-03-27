using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Operation", "INNER JOIN")]
    public partial class SelectManyTests
    {
        [Trait("Operation", "Subquery")]
        public class SubqueryTests : ResetDatabaseNotRequired
        {
            [Theory]
            [InlineData(true, 52)]
            [InlineData(false, 52)]
            public void Does_persons_with_addresses_have_52_records(bool useSyntheticAliases, int expected)
            {
                //given
                var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

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
                IEnumerable<dynamic> persons = exp.Execute();

                //then
                persons.Should().HaveCount(expected);
                persons.All(p => p.Id == p.PersonId).Should().BeTrue();
            }

            [Theory]
            [InlineData(true, 52)]
            [InlineData(false, 52)]
            public void Does_persons_with_addresses_with_aliases_set_using_variable_have_52_records(bool useSyntheticAliases, int expected)
            {
                //given
                var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

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
                IEnumerable<dynamic> persons = exp.Execute();

                //then
                persons.Should().HaveCount(expected);
                persons.All(p => p.Id == p.PersonId).Should().BeTrue();
            }

            [Theory]
            [Trait("Operation", "WHERE")]
            [InlineData(true, 1)]
            [InlineData(false, 1)]
            public void Does_persons_with_purchase_line_equal_to_30_have_1_records(bool useSyntheticAliases, int expected)
            {
                //given
                var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

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
                IEnumerable<dynamic> persons = exp.Execute();

                //then
                persons.Should().HaveCount(expected);
                persons.Where(p => p.Id == 6).Should().ContainSingle();
            }

            [Theory]
            [Trait("Operation", "WHERE")]
            [InlineData(true, 1)]
            [InlineData(false, 1)]
            public void Does_persons_with_purchase_line_with_aliases_set_using_variables_have_1_records(bool useSyntheticAliases, int expected)
            {
                //given
                var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

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
                IEnumerable<dynamic> persons = exp.Execute();

                //then
                persons.Should().HaveCount(expected);
                persons.Where(p => p.Id == 6).Should().ContainSingle();
            }

            [Theory]
            [Trait("Operation", "WHERE")]
            [InlineData(true, 1)]
            [InlineData(false, 1)]
            public void Does_persons_with_purchase_line_using_variables_with_redundant_and_aliased_inner_join_have_1_record(bool useSyntheticAliases, int expected)
            {
                //given
                var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

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
                                foo.PurchasePrice
                            )
                            .From(foo)
                            .Where(foo.PurchasePrice == 30)
                        ).As("t2").On(dbo.Purchase.Id == foo.As("t2").PurchaseId)
                    ).As("t3").On(dbo.Person.Id == dbo.Purchase.As("t3").PersonId);

                //when               
                IEnumerable<dynamic> persons = exp.Execute();

                //then
                persons.Should().HaveCount(expected);
                persons.Where(p => p.Id == 6).Should().ContainSingle();
            }


            [Theory]
            [Trait("Operation", "WHERE")]
            [InlineData(true, 3)]
            [InlineData(false, 3)]
            public void Does_persons_with_purchases_using_aliased_inner_join_with_like_where_clause_have_3_records(bool useSyntheticAliases, int expected)
            {
                //given
                var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

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
                IEnumerable<dynamic> purchases = exp.Execute();

                //then
                purchases.Should().HaveCount(expected);
            }
        }
    }
}

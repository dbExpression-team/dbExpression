using DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Extensions.Builder;
using System.Data.SqlClient;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Statement", "SELECT")]
    public partial class SelectAll
    {
        [Trait("Operation", "INNER JOIN")]
        public partial class InnerJoin
        {
            [Trait("Operation", "Subquery")]
            public class Subquery : ExecutorTestBase
            {
                [Theory]
                [InlineData(2014)]
                public void Does_persons_with_addresses_with_auto_discover_aliases_have_52_records(int version)
                {
                    //given
                    ConfigureForMsSqlVersion(version);

                    var exp = db.SelectAll(
                            dbo.Person.Id,
                            dbo.Person_Address.PersonId,
                            dbo.Person_Address.AddressId
                        )
                        .From(dbo.Person)
                        .InnerJoin(
                            db.SelectAll(
                                dbo.Person_Address.PersonId,
                                dbo.Person_Address.AddressId
                            )
                            .From(dbo.Person_Address)
                        ).On(dbo.Person.Id == dbo.Person_Address.PersonId);

                    //when               
                    var persons = exp.Execute();

                    //then
                    persons.Should().HaveCount(52);
                }

                [Theory]
                [InlineData(2014)]
                public void Does_persons_with_addresses_with_aliases_set_using_As_have_52_records(int version)
                {
                    //given
                    ConfigureForMsSqlVersion(version);

                    var exp = db.SelectAll(
                            dbo.Person.Id,
                            dbo.Person_Address.As("foo").PersonId,
                            dbo.Person_Address.As("foo").AddressId
                        )
                        .From(dbo.Person)
                        .InnerJoin(
                            db.SelectAll(
                                dbo.Person_Address.As("foo").PersonId,
                                dbo.Person_Address.As("foo").AddressId
                            )
                            .From(dbo.Person_Address.As("foo"))
                        ).On(dbo.Person.Id == dbo.Person_Address.As("foo").PersonId);

                    //when               
                    var persons = exp.Execute();

                    //then
                    persons.Should().HaveCount(52);
                }

                [Theory]
                [InlineData(2014)]
                public void Does_persons_with_addresses_with_aliases_set_using_variable_have_52_records(int version)
                {
                    //given
                    ConfigureForMsSqlVersion(version);

                    var foo = dbo.Person_Address.As("foo");

                    var exp = db.SelectAll(
                            dbo.Person.Id,
                            foo.PersonId,
                            foo.AddressId
                        )
                        .From(dbo.Person)
                        .InnerJoin(
                            db.SelectAll(
                                foo.PersonId,
                                foo.AddressId
                            )
                            .From(foo)
                        ).On(dbo.Person.Id == foo.PersonId);

                    //when               
                    var persons = exp.Execute();

                    //then
                    persons.Should().HaveCount(52);
                }

                [Theory]
                [InlineData(2014)]
                public void Does_persons_with_purchase_line_equal_to_30_with_auto_discover_aliases_have_1_records(int version)
                {
                    //given
                    ConfigureForMsSqlVersion(version);

                    var exp = db.SelectAll(
                            dbo.Person.Id,
                            dbo.Purchase.PersonId,
                            dbo.Purchase.TotalPurchaseAmount,
                            dbo.PurchaseLine.PurchasePrice
                        )
                        .From(dbo.Person)
                        .InnerJoin(
                            db.SelectAll(
                                dbo.Purchase.Id,
                                dbo.Purchase.PersonId,
                                dbo.Purchase.TotalPurchaseAmount,
                                dbo.PurchaseLine.PurchasePrice
                            )
                            .From(dbo.Purchase)
                            .InnerJoin(
                                db.SelectAll(
                                    dbo.PurchaseLine.PurchaseId,
                                    dbo.PurchaseLine.PurchasePrice)
                                .From(dbo.PurchaseLine)
                                .Where(dbo.PurchaseLine.PurchasePrice == 30)
                            ).On(dbo.Purchase.Id == dbo.PurchaseLine.PurchaseId)
                        ).On(dbo.Person.Id == dbo.Purchase.PersonId);

                    //when               
                    var persons = exp.Execute();

                    //then
                    persons.Should().HaveCount(1);
                }

                [Theory]
                [InlineData(2014)]
                public void Does_persons_with_purchase_line_equal_to_30_with_aliases_set_have_1_records(int version)
                {
                    //given
                    ConfigureForMsSqlVersion(version);

                    var exp = db.SelectAll(
                            dbo.Person.Id,
                            dbo.Purchase.As("bar").PersonId,
                            dbo.Purchase.As("bar").TotalPurchaseAmount,
                            dbo.PurchaseLine.As("foo").PurchasePrice
                        )
                        .From(dbo.Person)
                        .InnerJoin(
                            db.SelectAll(
                                dbo.Purchase.As("bar").Id,
                                dbo.Purchase.As("bar").PersonId,
                                dbo.Purchase.As("bar").TotalPurchaseAmount,
                                dbo.PurchaseLine.As("foo").PurchasePrice
                            )
                            .From(dbo.Purchase.As("bar"))
                            .InnerJoin(
                                db.SelectAll(
                                    dbo.PurchaseLine.As("foo").PurchaseId,
                                    dbo.PurchaseLine.As("foo").PurchasePrice)
                                .From(dbo.PurchaseLine.As("foo"))
                                .Where(dbo.PurchaseLine.As("foo").PurchasePrice == 30)
                            ).On(dbo.Purchase.As("bar").Id == dbo.PurchaseLine.As("foo").PurchaseId)
                        ).On(dbo.Person.Id == dbo.Purchase.As("bar").PersonId);

                    //when               
                    var persons = exp.Execute();

                    //then
                    persons.Should().HaveCount(1);
                }

                [Theory]
                [InlineData(2014)]
                public void Does_persons_with_purchase_line_with_aliases_set_using_variables_have_1_records(int version)
                {
                    //given
                    ConfigureForMsSqlVersion(version);

                    var foo = dbo.PurchaseLine.As("foo");
                    var bar = dbo.Purchase.As("bar");

                    var exp = db.SelectAll(
                            dbo.Person.Id,
                            bar.PersonId,
                            bar.TotalPurchaseAmount,
                            foo.PurchasePrice
                        )
                        .From(dbo.Person)
                        .InnerJoin(
                            db.SelectAll(
                                bar.Id,
                                bar.PersonId,
                                bar.TotalPurchaseAmount,
                                foo.PurchasePrice
                            )
                            .From(bar)
                            .InnerJoin(
                                db.SelectAll(
                                    foo.PurchaseId,
                                    foo.PurchasePrice)
                                .From(foo)
                                .Where(foo.PurchasePrice == 30)
                            ).On(bar.Id == foo.PurchaseId)
                        ).On(dbo.Person.Id == bar.PersonId);

                    //when               
                    var persons = exp.Execute();

                    //then
                    persons.Should().HaveCount(1);
                }

                [Theory]
                [InlineData(2014)]
                public void Does_persons_with_purchase_line_using_variables_with_redundant_and_aliased_inner_join_have_1_record(int version)
                {
                    //given
                    ConfigureForMsSqlVersion(version);

                    var foo = dbo.PurchaseLine.As("foo");

                    var exp = db.SelectAll(
                            dbo.Person.Id,
                            dbo.Purchase.PersonId,
                            dbo.Purchase.TotalPurchaseAmount,
                            foo.PurchasePrice
                        )
                        .From(dbo.Person)
                        .InnerJoin(
                            db.SelectAll(
                                dbo.Purchase.Id,
                                dbo.Purchase.PersonId,
                                dbo.Purchase.TotalPurchaseAmount,
                                foo.PurchasePrice
                            )
                            .From(dbo.Purchase)
                            .InnerJoin(
                                db.SelectAll(
                                    dbo.PurchaseLine.PurchaseId,
                                    dbo.PurchaseLine.PurchasePrice)
                                .From(dbo.PurchaseLine)
                                .Where(dbo.PurchaseLine.PurchasePrice == 30)
                            ).On(dbo.Purchase.Id == dbo.PurchaseLine.PurchaseId)
                            .InnerJoin(
                                db.SelectAll(
                                    foo.PurchaseId,
                                    foo.PurchasePrice)
                                .From(foo)
                                .Where(foo.PurchasePrice == 30)
                            ).On(dbo.Purchase.Id == foo.PurchaseId)
                        ).On(dbo.Person.Id == dbo.Purchase.PersonId);

                    //when               
                    var persons = exp.Execute();

                    //then
                    persons.Should().HaveCount(1);
                }

                [Theory]
                [InlineData(2014)]
                public void Does_persons_with_purchase_line_using_variables_with_redundant_inner_join_fail(int version)
                {
                    //given
                    ConfigureForMsSqlVersion(version);

                    var exp = db.SelectAll(
                            dbo.Person.Id,
                            dbo.Purchase.PersonId,
                            dbo.Purchase.TotalPurchaseAmount,
                            dbo.PurchaseLine.PurchasePrice
                        )
                        .From(dbo.Person)
                        .InnerJoin(
                            db.SelectAll(
                                dbo.Purchase.Id,
                                dbo.Purchase.PersonId,
                                dbo.Purchase.TotalPurchaseAmount,
                                dbo.PurchaseLine.PurchasePrice
                            )
                            .From(dbo.Purchase)
                            .InnerJoin(
                                db.SelectAll(
                                    dbo.PurchaseLine.PurchaseId,
                                    dbo.PurchaseLine.PurchasePrice)
                                .From(dbo.PurchaseLine)
                                .Where(dbo.PurchaseLine.PurchasePrice == 30)
                            ).On(dbo.Purchase.Id == dbo.PurchaseLine.PurchaseId)
                            .InnerJoin(
                                db.SelectAll(
                                    dbo.PurchaseLine.PurchaseId,
                                    dbo.PurchaseLine.PurchasePrice)
                                .From(dbo.PurchaseLine)
                                .Where(dbo.PurchaseLine.PurchasePrice == 30)
                            ).On(dbo.Purchase.Id == dbo.PurchaseLine.PurchaseId)
                        ).On(dbo.Person.Id == dbo.Purchase.PersonId);

                    //when
                    var ex = Assert.Throws<SqlException>(() => exp.Execute());

                    //then
                    ex.Message.Should().Be("The correlation name 't2' is specified multiple times in a FROM clause.");
                }

                [Theory]
                [InlineData(2014)]
                public void Does_persons_with_purchase_line_using_variables_with_redundant_inner_join_using_alias_fail(int version)
                {
                    //given
                    ConfigureForMsSqlVersion(version);

                    var foo = dbo.PurchaseLine.As("foo");
                    var bar = dbo.Purchase.As("bar");

                    var exp = db.SelectAll(
                            dbo.Person.Id,
                            bar.PersonId,
                            bar.TotalPurchaseAmount,
                            foo.PurchasePrice
                        )
                        .From(dbo.Person)
                        .InnerJoin(
                            db.SelectAll(
                                bar.Id,
                                bar.PersonId,
                                bar.TotalPurchaseAmount,
                                foo.PurchasePrice
                            )
                            .From(bar)
                            .InnerJoin(
                                db.SelectAll(
                                    foo.PurchaseId,
                                    foo.PurchasePrice)
                                .From(foo)
                                .Where(foo.PurchasePrice == 30)
                            ).On(bar.Id == foo.PurchaseId)
                            .InnerJoin(
                                db.SelectAll(
                                    dbo.PurchaseLine.As("foo").PurchaseId,
                                    dbo.PurchaseLine.As("foo").PurchasePrice)
                                .From(dbo.PurchaseLine.As("foo"))
                                .Where(dbo.PurchaseLine.As("foo").PurchasePrice == 30)
                            ).On(bar.Id == foo.PurchaseId)
                        ).On(dbo.Person.Id == bar.PersonId);

                    //when
					var ex = Assert.Throws<SqlException>(() => exp.Execute());

                    //then
                    ex.Message.Should().Be("The correlation name 'foo' is specified multiple times in a FROM clause.");
                }
            }
        }
    }
}

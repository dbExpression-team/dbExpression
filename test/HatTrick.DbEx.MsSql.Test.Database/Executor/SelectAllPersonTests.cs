using Data;
using DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Extensions.Builder;
using System;
using System.Linq;
using Xunit;
using db = HatTrick.DbEx.MsSql.Builder.MsSqlExpressionBuilder;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    public class SelectAllPersonTests : ExecutorTestBase
    {
        [Theory]
        [InlineData(2014)]
        public void Are_there_50_person_records(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectAll(dbo.Person.Id)
               .From(dbo.Person);

            //when               
            var persons = exp.Execute();

            //then
            persons.Should().HaveCount(50);
        }

        public class Where : ExecutorTestBase
        {
            [Theory]
            [InlineData(2014)]
            public void Does_IlastName_of_Broflovski_or_lastName_of_MarshI_and_gender_maleI_have_6_records(int version)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(dbo.Person.Id)
                   .From(dbo.Person)
                   .Where((dbo.Person.LastName == "Broflovski" | dbo.Person.LastName == "Marsh") & dbo.Person.GenderType == GenderType.Male);

                //when               
                var persons = exp.Execute();

                //then
                persons.Should().HaveCount(6);
            }

            [Theory]
            [InlineData(2014)]
            public void Does_lastName_of_Broflovski_or_I_lastName_of_Marsh_and_gender_maleI_have_7_records(int version)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(dbo.Person.Id)
                   .From(dbo.Person)
                   .Where(dbo.Person.LastName == "Broflovski" | (dbo.Person.LastName == "Marsh" & dbo.Person.GenderType == GenderType.Male));

                //when               
                var persons = exp.Execute();

                //then
                persons.Should().HaveCount(7);
            }

            [Theory]
            [InlineData(2014)]
            public void Does_IlastName_of_Broflovski_or_lastName_of_MarshI_and_Igender_male_or_birthDate_greater_than_1_1_1996I_have_6_records(int version)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(dbo.Person.Id)
                   .From(dbo.Person)
                   .Where((dbo.Person.LastName == "Broflovski" | dbo.Person.LastName == "Marsh") & (dbo.Person.GenderType == GenderType.Male | dbo.Person.BirthDate > new DateTime(1996, 1, 1)));

                //when               
                var persons = exp.Execute();

                //then
                persons.Should().HaveCount(6);
            }
        }

        public class InnerJoin : ExecutorTestBase
        {
            [Theory]
            [InlineData(2014)]
            public void Does_persons_with_addresses_have_52_records(int version)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(dbo.Person.Id)
                    .From(dbo.Person)
                    .InnerJoin(dbo.Person_Address).On(dbo.Person.Id == dbo.Person_Address.PersonId);

                //when               
                var persons = exp.Execute();

                //then
                persons.Should().HaveCount(52);
            }

            [Theory]
            [InlineData(2014)]
            public void Does_filtering_by_billing_addresstype_equal_to_billing_have_35_records(int version)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(dbo.Person.Id)
                    .From(dbo.Person)
                    .InnerJoin(dbo.Person_Address).On(dbo.Person.Id == dbo.Person_Address.PersonId)
                    .InnerJoin(dbo.Address).On(dbo.Person_Address.AddressId == dbo.Address.Id)
                    .Where(dbo.Address.AddressType == AddressType.Billing);

                //when               
                var persons = exp.Execute();

                //then
                persons.Should().HaveCount(35);
            }

            [Theory]
            [InlineData(2014)]
            public void Does_filtering_by_address_id_equal_to_1_have_14_records(int version)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(dbo.Person.Id)
                    .From(dbo.Person)
                    .InnerJoin(dbo.Person_Address).On(dbo.Person.Id == dbo.Person_Address.PersonId)
                    .InnerJoin(dbo.Address).On(dbo.Person_Address.AddressId == dbo.Address.Id)
                    .Where(dbo.Address.Id == 1);

                //when               
                var persons = exp.Execute();

                //then
                persons.Should().HaveCount(14);
            }

            [Theory]
            [InlineData(2014)]
            public void Does_filtering_by_addresstype_equal_to_billing_and_address_id_not_equal_to_1_have_35_records(int version)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(dbo.Person.Id)
                    .From(dbo.Person)
                    .InnerJoin(dbo.Person_Address).On(dbo.Person.Id == dbo.Person_Address.PersonId)
                    .InnerJoin(dbo.Address).On(dbo.Person_Address.AddressId == dbo.Address.Id)
                    .Where(dbo.Address.AddressType == AddressType.Billing & dbo.Address.Id != 1);

                //when               
                var persons = exp.Execute();

                //then
                persons.Should().HaveCount(35);
            }

            [Theory]
            [InlineData(2014)]
            public void Does_address_count_by_person_have_correct_record_counts(int version)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(
                        dbo.Person.Id, 
                        dbo.Address.Id.Count().As("AddressCount")
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
            [InlineData(2014)]
            public void Does_address_count_by_person_having_count_greater_than_1_have_18_records(int version)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(
                        dbo.Person.Id,
                        dbo.Address.Id.Count().As("AddressCount")
                    )
                    .From(dbo.Person)
                    .InnerJoin(dbo.Person_Address).On(dbo.Person.Id == dbo.Person_Address.PersonId)
                    .InnerJoin(dbo.Address).On(dbo.Person_Address.AddressId == dbo.Address.Id)
                    .GroupBy(dbo.Person.Id)
                    .Having(dbo.Address.Id.Count() > 1);

                //when               
                var persons = exp.Execute();

                //then
                persons.Should().HaveCount(17);
            }

            [Theory]
            [InlineData(2014)]
            public void Does_address_count_by_person_having_count_greater_than_1_and_less_than_3_have_18_records(int version)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(
                        dbo.Person.Id,
                        dbo.Address.Id.Count().As("AddressCount")
                    )
                    .From(dbo.Person)
                    .InnerJoin(dbo.Person_Address).On(dbo.Person.Id == dbo.Person_Address.PersonId)
                    .InnerJoin(dbo.Address).On(dbo.Person_Address.AddressId == dbo.Address.Id)
                    .GroupBy(dbo.Person.Id)
                    //basically equal to 2, testing composite having statement
                    .Having(dbo.Address.Id.Count() > 1 & dbo.Address.Id.Count() < 3);

                //when               
                var persons = exp.Execute();

                //then
                persons.Should().HaveCount(17);
            }

            [Theory]
            [InlineData(2014)]
            public void Does_address_count_by_person_having_count_equal_to_1_2_or_3_have_35_records(int version)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(
                        dbo.Person.Id,
                        dbo.Address.Id.Count().As("AddressCount")
                    )
                    .From(dbo.Person)
                    .InnerJoin(dbo.Person_Address).On(dbo.Person.Id == dbo.Person_Address.PersonId)
                    .InnerJoin(dbo.Address).On(dbo.Person_Address.AddressId == dbo.Address.Id)
                    .GroupBy(dbo.Person.Id)
                    //testing composite having statement with 3 parts
                    .Having(dbo.Address.Id.Count() == 1 | dbo.Address.Id.Count() == 2 | dbo.Address.Id.Count() == 3);

                //when               
                var persons = exp.Execute();

                //then
                persons.Should().HaveCount(35);
            }
        }

        public class InnerJoin_CorrelatedSubquery : ExecutorTestBase
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
        }

        public class InnerJoin_CorrelatedSubqueries : ExecutorTestBase
        {
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

        //    [Theory]
        //    [InlineData(2014)]
        //    public void Does_persons_with_addresses_with_aliases_set_using_As_have_52_records(int version)
        //    {
        //        //given
        //        ConfigureForMsSqlVersion(version);

        //        var exp = db.SelectAll(
        //                dbo.Person.Id,
        //                dbo.Person_Address.As("foo").PersonId,
        //                dbo.Person_Address.As("foo").AddressId
        //            )
        //            .From(dbo.Person)
        //            .InnerJoin(
        //                db.SelectAll(
        //                    dbo.Person_Address.As("foo").PersonId,
        //                    dbo.Person_Address.As("foo").AddressId
        //                )
        //                .From(dbo.Person_Address.As("foo"))
        //            ).On(dbo.Person.Id == dbo.Person_Address.As("foo").PersonId)
        //            .InnerJoin(
        //                db.SelectAll(
        //                    dbo.Person_Address.As("bar").PersonId,
        //                    dbo.Person_Address.As("bar").AddressId
        //                )
        //                .From(dbo.Person_Address.As("bar"))
        //            ).On(dbo.Person.Id == dbo.Person_Address.As("bar").PersonId);

        //        //when               
        //        var persons = exp.Execute();

        //        //then
        //        persons.Should().HaveCount(52);
        //    }

        //    [Theory]
        //    [InlineData(2014)]
        //    public void Does_persons_with_addresses_with_aliases_set_using_variable_have_52_records(int version)
        //    {
        //        //given
        //        ConfigureForMsSqlVersion(version);

        //        var foo = dbo.Person_Address.As("foo");

        //        var exp = db.SelectAll(
        //                dbo.Person.Id,
        //                foo.PersonId,
        //                foo.AddressId
        //            )
        //            .From(dbo.Person)
        //            .InnerJoin(
        //                db.SelectAll(
        //                    foo.PersonId,
        //                    foo.AddressId
        //                )
        //                .From(foo)
        //            ).On(dbo.Person.Id == foo.PersonId);

        //        //when               
        //        var persons = exp.Execute();

        //        //then
        //        persons.Should().HaveCount(52);
        //    }
    }
        }
}

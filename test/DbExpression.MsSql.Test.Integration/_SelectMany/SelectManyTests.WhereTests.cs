using DbEx.Data;
using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Clause", "WHERE")]
    public partial class SelectManyTests
    {
        [Theory]
        [InlineData(6)]
        public void Does_IlastName_of_Broflovski_or_lastName_of_MarshI_and_gender_maleI_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person)
                .Where((dbo.Person.LastName == "Broflovski" | dbo.Person.LastName == "Marsh") & dbo.Person.GenderType == GenderType.Male);

            //when               
            IEnumerable<int> persons = exp.Execute();

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(7)]
        public void Does_lastName_of_Broflovski_or_I_lastName_of_Marsh_and_gender_maleI_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person)
                .Where(dbo.Person.LastName == "Broflovski" | (dbo.Person.LastName == "Marsh" & dbo.Person.GenderType == GenderType.Male));

            //when               
            IEnumerable<int> persons = exp.Execute();

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(6)]
        public void Does_IlastName_of_Broflovski_or_lastName_of_MarshI_and_Igender_male_or_birthDate_greater_than_1_1_1996I_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person)
                .Where((dbo.Person.LastName == "Broflovski" | dbo.Person.LastName == "Marsh") & (dbo.Person.GenderType == GenderType.Male | dbo.Person.BirthDate > new DateTime(1996, 1, 1)));

            //when               
            IEnumerable<int> persons = exp.Execute();

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(7)]
        public void Does_IlastName_of_Broflovski_or_lastName_of_Marsh_or_lastName_of_StotchI_and_Igender_male_or_birthDate_greater_than_1_1_1996I_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person)
                .Where((dbo.Person.LastName == "Broflovski" | dbo.Person.LastName == "Marsh" | dbo.Person.LastName == "Stotch") & (dbo.Person.GenderType == GenderType.Male | dbo.Person.BirthDate > new DateTime(1996, 1, 1)));

            //when               
            IEnumerable<int> persons = exp.Execute();

            //then
            persons.Should().HaveCount(expected);
        }

        #region where predicate with null
        [Theory]
        [InlineData(3)]
        public void Does_ship_date_equal_to_null_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Purchase.Id)
                .From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate == dbex.Null);

            //when               
            IEnumerable<int> purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(12)]
        public void Does_ship_date_not_equal_to_null_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Purchase.Id)
                .From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            IEnumerable<int> purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(12)]
        public void Does_negated_ship_date_equal_to_null_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Purchase.Id)
                .From(dbo.Purchase)
                .Where(!(dbo.Purchase.ShipDate == dbex.Null));

            //when               
            IEnumerable<int> purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(3)]
        public void Does_negated_ship_date_not_equal_to_null_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Purchase.Id)
                .From(dbo.Purchase)
                .Where(!(dbo.Purchase.ShipDate != dbex.Null));

            //when               
            IEnumerable<int> purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(4)]
        public void Does_ship_date_equal_to_null_or_total_purchase_amount_greater_than_50_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Purchase.Id)
                .From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate == dbex.Null | dbo.Purchase.TotalPurchaseAmount > 55);

            //when               
            IEnumerable<int> purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(1)]
        public void Does_ship_date_not_equal_to_null_and_total_purchase_amount_greater_than_50_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Purchase.Id)
                .From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != dbex.Null & dbo.Purchase.TotalPurchaseAmount > 55);

            //when               
            IEnumerable<int> purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(1)]
        public void Does_negated_ship_date_equal_to_null_and_total_purchase_amount_greater_than_50_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Purchase.Id)
                .From(dbo.Purchase)
                .Where(!(dbo.Purchase.ShipDate == dbex.Null) & dbo.Purchase.TotalPurchaseAmount > 55);

            //when               
            IEnumerable<int> purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(5)]
        public void Does_Inegated_ship_date_equal_to_nullI_and_Itotal_purchase_amount_greater_than_50_or_less_than_10I_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Purchase.Id)
                .From(dbo.Purchase)
                .Where(!(dbo.Purchase.ShipDate == dbex.Null) & (dbo.Purchase.TotalPurchaseAmount > 55 | dbo.Purchase.TotalPurchaseAmount < 10));

            //when               
            IEnumerable<int> purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(7)]
        public void Does_ship_date_not_equal_to_null_and_Inegated_total_purchase_amount_greater_than_55_or_less_than_10I_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Purchase.Id)
                .From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != dbex.Null & !(dbo.Purchase.TotalPurchaseAmount > 55 | dbo.Purchase.TotalPurchaseAmount < 10));

            //when               
            IEnumerable<int> purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(7)]
        public void Does_Inegated_ship_date_equal_to_nullI_and_Inegated_total_purchase_amount_greater_than_55_or_less_than_10I_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Purchase.Id)
                .From(dbo.Purchase)
                .Where(!(dbo.Purchase.ShipDate == dbex.Null) & !(dbo.Purchase.TotalPurchaseAmount > 55 | dbo.Purchase.TotalPurchaseAmount < 10));

            //when               
            IEnumerable<int> purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(7)]
        public void Does_Inegated_ship_date_equal_to_nowI_and_Inegated_total_purchase_amount_greater_than_55_or_less_than_10I_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Purchase.Id)
                .From(dbo.Purchase)
                .Where(!(dbo.Purchase.ShipDate == DateTime.Now) & !(dbo.Purchase.TotalPurchaseAmount > 55 | dbo.Purchase.TotalPurchaseAmount < 10));

            //when               
            IEnumerable<int> purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(27)]
        public void Can_select_many_addresses_where_line2_is_null_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Address.Id)
                .From(dbo.Address)
                .Where(dbo.Address.Line2 == dbex.Null);

            //when               
            IEnumerable<int> purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(15)]
        public void Can_select_many_person_ids_where_that_have_no_address_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            IEnumerable<int> personsWithNoAddresses = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person)
                .LeftJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
                .Where(dbo.PersonAddress.AddressId == dbex.Null)
                .Execute();

            //then
            personsWithNoAddresses.Should().HaveCount(expected);
        }


        [Theory]
        [InlineData(5)]
        public void Does_complex_where_clause_1_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Purchase.Id)
                .From(dbo.Purchase)
                .Where(
                    !(dbo.Purchase.ShipDate == dbex.Null) 
                    & 
                    (
                        dbo.Purchase.TotalPurchaseAmount > 55 
                        |
                        (
                            dbo.Purchase.TotalPurchaseAmount < 10
                            &
                            dbo.Purchase.TotalPurchaseAmount > 0
                        )
                    )
                );

            //when               
            IEnumerable<int> purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(5)]
        public void Does_complex_where_clause_2_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Purchase.Id)
                .From(dbo.Purchase)
                .Where(
                    !(
                        dbo.Purchase.ShipDate == dbex.Null
                        |
                        dbo.Purchase.DateCreated >= DateTime.Now
                    )
                    &
                    (
                        dbo.Purchase.TotalPurchaseAmount > 55
                        |
                        (
                            dbo.Purchase.TotalPurchaseAmount < 10
                            &
                            dbo.Purchase.TotalPurchaseAmount > 0
                        )
                    )
                );

            //when               
            IEnumerable<int> purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(1, 14)]
        public void Does_complex_where_clause_3_succeed(int expectedCount, int expectedId)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Purchase.Id)
                .From(dbo.Purchase)
                .Where(
                    (
                        (
                            dbo.Purchase.ShipDate == dbex.Null
                            |
                            dbo.Purchase.DateCreated >= DateTime.Now  
                        )
                        &
                        (
                            dbo.Purchase.TotalPurchaseAmount > 55
                            |
                            (
                                dbo.Purchase.TotalPurchaseAmount < 10
                                &
                                dbo.Purchase.TotalPurchaseAmount > 0
                            )
                        )
                    )
                    & dbo.Purchase.Id > 1
                );

            //when               
            IEnumerable<int> purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
            ((int)purchases.First()).Should().Be(expectedId);
        }

        [Theory]
        [InlineData(1, 14)]
        public void Does_complex_where_clause_4_succeed(int expectedCount, int expectedId)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Purchase.Id)
                .From(dbo.Purchase)
                .Where(
                    (
                        dbo.Purchase.ShipDate == dbex.Null
                        |
                        dbo.Purchase.DateCreated >= DateTime.Now
                    )
                    &
                    (
                        dbo.Purchase.TotalPurchaseAmount > 55
                        |
                        (
                            dbo.Purchase.TotalPurchaseAmount < 10
                            &
                            dbo.Purchase.TotalPurchaseAmount > 0
                        )
                    )
                    & 
                    (
                        dbo.Purchase.Id > 1
                        |
                        dbo.Purchase.Id < 1000
                    )
                );

            //when               
            IEnumerable<int> purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
            ((int)purchases.First()).Should().Be(expectedId);
        }

        [Theory]
        [InlineData(1, 14)]
        public void Does_complex_where_clause_5_succeed(int expectedCount, int expectedId)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Purchase.Id)
                .From(dbo.Purchase)
                .Where(
                    (
                        dbo.Purchase.ShipDate == dbex.Null
                        |
                        dbo.Purchase.DateCreated >= DateTime.Now
                    )
                    &
                    (
                        dbo.Purchase.TotalPurchaseAmount > 55
                        |
                        (
                            dbo.Purchase.TotalPurchaseAmount < 10
                            &
                            dbo.Purchase.TotalPurchaseAmount > 0
                        )
                    )
                    &
                    (
                        dbo.Purchase.Id > 1
                        |
                        dbo.Purchase.Id < 1000
                    )
                    & dbo.Purchase.Id < 2000
                );

            //when               
            IEnumerable<int> purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
            ((int)purchases.First()).Should().Be(expectedId);
        }

        [Fact]
        public void Does_non_null_field_cause_exception_when_using_left_join_pattern_which_returns_null_value_from_database_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            Action execute = () => db.SelectMany(dbo.PersonAddress.Id)
                .From(dbo.Person)
                .LeftJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
                .Where(dbo.PersonAddress.AddressId == dbex.Null)
                .Execute();

                //when & then
                execute.Should().Throw<DbExpressionConversionException>();
            }

        [Fact]
        public void Can_select_product_where_image_is_not_null()
        {
            //given
            AppendImagesToProductsInDatabase();
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            IEnumerable<int> productId = db.SelectMany(dbo.Product.Id)
                .From(dbo.Product)
                .Where(dbo.Product.Image != dbex.Null)
                .Execute();

            //then
            productId.First().Should().BeGreaterThan(0);
        }
        #endregion

        [Theory]
        [InlineData(9)]
        public async Task Can_an_overriden_property_type_return_the_correct_data_type_when_selecting_values_succeed(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            IEnumerable<ProductDescription?> values = await db.SelectMany(
                    dbo.Product.Description
                )
                .From(dbo.Product)
                .Where(dbo.Product.Description != dbex.Null)
                .ExecuteAsync();

            //then
            values.Should().HaveCount(expectedCount);
        }

        [Theory]
        [InlineData(9)]
        public async Task Can_an_overriden_property_type_and_aliased_return_the_correct_data_type_when_selecting_values_succeed(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            IEnumerable<ProductDescription?> values = await db.SelectMany(
                    dbo.Product.Description.As("foo")
                )
                .From(dbo.Product)
                .Where(dbo.Product.Description != dbex.Null)
                .ExecuteAsync();

            //then
            values.Should().HaveCount(expectedCount);
        }

        [Theory]
        [InlineData(9)]
        public async Task Can_select_dynamic_list_of_an_overriden_property_type_return_the_correct_data_type_when_selecting_values_succeed(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            IEnumerable<dynamic> values = await db.SelectMany(
                    dbo.Product.Id,
                    dbo.Product.Description
                )
                .From(dbo.Product)
                .Where(dbo.Product.Description != dbex.Null)
                .ExecuteAsync();

            //then
            values.Should().HaveCount(expectedCount);
        }

        [Theory]
        [InlineData(9)]
        public async Task Can_select_dynamic_list_of_an_overriden_property_type_and_aliased_return_the_correct_data_type_when_selecting_values_succeed(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            IEnumerable<dynamic> values = await db.SelectMany(
                    dbo.Product.Id,
                    dbo.Product.Description.As("foo")
                )
                .From(dbo.Product)
                .Where(dbo.Product.Description != dbex.Null)
                .ExecuteAsync();

            //then
            values.Should().HaveCount(expectedCount);
        }
    }
}

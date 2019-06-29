using DbEx.Data;
using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Extensions.Builder;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Statement", "SELECT")]
    public partial class SelectMany
    {
        [Trait("Clause", "WHERE")]
        public class Where : ExecutorTestBase
        {
            [Theory]
            [MsSqlVersions.AllVersions]
            public void Does_IlastName_of_Broflovski_or_lastName_of_MarshI_and_gender_maleI_have_6_records(int version, int expectedCount = 6)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectMany<int>(dbo.Person.Id)
                   .From(dbo.Person)
                   .Where((dbo.Person.LastName == "Broflovski" | dbo.Person.LastName == "Marsh") & dbo.Person.GenderType == GenderType.Male);

                //when               
                var persons = exp.Execute();

                //then
                persons.Should().HaveCount(expectedCount);
            }

            [Theory]
            [MsSqlVersions.AllVersions]
            public void Does_lastName_of_Broflovski_or_I_lastName_of_Marsh_and_gender_maleI_have_7_records(int version, int expectedCount = 7)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectMany<int>(dbo.Person.Id)
                   .From(dbo.Person)
                   .Where(dbo.Person.LastName == "Broflovski" | (dbo.Person.LastName == "Marsh" & dbo.Person.GenderType == GenderType.Male));

                //when               
                var persons = exp.Execute();

                //then
                persons.Should().HaveCount(expectedCount);
            }

            [Theory]
            [MsSqlVersions.AllVersions]
            public void Does_IlastName_of_Broflovski_or_lastName_of_MarshI_and_Igender_male_or_birthDate_greater_than_1_1_1996I_have_6_records(int version, int expectedCount = 6)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectMany<int>(dbo.Person.Id)
                   .From(dbo.Person)
                   .Where((dbo.Person.LastName == "Broflovski" | dbo.Person.LastName == "Marsh") & (dbo.Person.GenderType == GenderType.Male | dbo.Person.BirthDate > new DateTime(1996, 1, 1)));

                //when               
                var persons = exp.Execute();

                //then
                persons.Should().HaveCount(expectedCount);
            }

            #region where predicate with null
            [Theory]
            [MsSqlVersions.AllVersions]
            public void Does_ship_date_equal_to_null_have_3_records(int version, int expectedCount = 3)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectMany<int>(dbo.Purchase.Id)
                   .From(dbo.Purchase)
                   .Where(dbo.Purchase.ShipDate == null);

                //when               
                var purchases = exp.Execute();

                //then
                purchases.Should().HaveCount(expectedCount);
            }

            [Theory]
            [MsSqlVersions.AllVersions]
            public void Does_ship_date_not_equal_to_null_have_12_records(int version, int expectedCount = 12)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectMany<int>(dbo.Purchase.Id)
                   .From(dbo.Purchase)
                   .Where(dbo.Purchase.ShipDate != null);

                //when               
                var purchases = exp.Execute();

                //then
                purchases.Should().HaveCount(expectedCount);
            }

            [Theory]
            [MsSqlVersions.AllVersions]
            public void Does_negated_ship_date_equal_to_null_have_12_records(int version, int expectedCount = 12)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectMany<int>(dbo.Purchase.Id)
                   .From(dbo.Purchase)
                   .Where(!(dbo.Purchase.ShipDate == null));

                //when               
                var purchases = exp.Execute();

                //then
                purchases.Should().HaveCount(expectedCount);
            }

            [Theory]
            [MsSqlVersions.AllVersions]
            public void Does_negated_ship_date_not_equal_to_null_have_3_records(int version, int expectedCount = 3)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectMany<int>(dbo.Purchase.Id)
                   .From(dbo.Purchase)
                   .Where(!(dbo.Purchase.ShipDate != null));

                //when               
                var purchases = exp.Execute();

                //then
                purchases.Should().HaveCount(expectedCount);
            }

            [Theory]
            [MsSqlVersions.AllVersions]
            public void Does_ship_date_equal_to_null_or_total_purchase_amount_greater_than_50_have_4_records(int version, int expectedCount = 4)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectMany<int>(dbo.Purchase.Id)
                   .From(dbo.Purchase)
                   .Where(dbo.Purchase.ShipDate == null | dbo.Purchase.TotalPurchaseAmount > 55);

                //when               
                var purchases = exp.Execute();

                //then
                purchases.Should().HaveCount(expectedCount);
            }

            [Theory]
            [MsSqlVersions.AllVersions]
            public void Does_ship_date_not_equal_to_null_and_total_purchase_amount_greater_than_50_have_1_records(int version, int expectedCount = 1)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectMany<int>(dbo.Purchase.Id)
                   .From(dbo.Purchase)
                   .Where(dbo.Purchase.ShipDate != null & dbo.Purchase.TotalPurchaseAmount > 55);

                //when               
                var purchases = exp.Execute();

                //then
                purchases.Should().HaveCount(expectedCount);
            }

            [Theory]
            [MsSqlVersions.AllVersions]
            public void Does_negated_ship_date_equal_to_null_and_total_purchase_amount_greater_than_50_have_1_records(int version, int expectedCount = 1)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectMany<int>(dbo.Purchase.Id)
                   .From(dbo.Purchase)
                   .Where(!(dbo.Purchase.ShipDate == null) & dbo.Purchase.TotalPurchaseAmount > 55);

                //when               
                var purchases = exp.Execute();

                //then
                purchases.Should().HaveCount(expectedCount);
            }

            [Theory]
            [MsSqlVersions.AllVersions]
            public void Does_Inegated_ship_date_equal_to_nullI_and_Itotal_purchase_amount_greater_than_50_or_less_than_10I_have_5_records(int version, int expectedCount = 5)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectMany<int>(dbo.Purchase.Id)
                   .From(dbo.Purchase)
                   .Where(!(dbo.Purchase.ShipDate == null) & (dbo.Purchase.TotalPurchaseAmount > 55 | dbo.Purchase.TotalPurchaseAmount < 10));

                //when               
                var purchases = exp.Execute();

                //then
                purchases.Should().HaveCount(expectedCount);
            }

            [Theory]
            [MsSqlVersions.AllVersions]
            public void Does_ship_date_not_equal_to_null_and_Inegated_total_purchase_amount_greater_than_55_or_less_than_10I_have_7_records(int version, int expectedCount = 7)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectMany<int>(dbo.Purchase.Id)
                   .From(dbo.Purchase)
                   .Where(dbo.Purchase.ShipDate != null & !(dbo.Purchase.TotalPurchaseAmount > 55 | dbo.Purchase.TotalPurchaseAmount < 10));

                //when               
                var purchases = exp.Execute();

                //then
                purchases.Should().HaveCount(expectedCount);
            }

            [Theory]
            [MsSqlVersions.AllVersions]
            public void Does_Integrated_ship_date_equal_to_nullI_and_Inegated_total_purchase_amount_greater_than_55_or_less_than_10I_have_7_records(int version, int expectedCount = 7)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectMany<int>(dbo.Purchase.Id)
                   .From(dbo.Purchase)
                   .Where(!(dbo.Purchase.ShipDate == null) & !(dbo.Purchase.TotalPurchaseAmount > 55 | dbo.Purchase.TotalPurchaseAmount < 10));

                //when               
                var purchases = exp.Execute();

                //then
                purchases.Should().HaveCount(expectedCount);
            }

            [Theory]
            [MsSqlVersions.AllVersions]
            public void Does_Integrated_ship_date_equal_to_nowI_and_Inegated_total_purchase_amount_greater_than_55_or_less_than_10I_have_7_records(int version, int expectedCount = 7)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectMany<int>(dbo.Purchase.Id)
                   .From(dbo.Purchase)
                   .Where(!(dbo.Purchase.ShipDate == DateTime.Now) & !(dbo.Purchase.TotalPurchaseAmount > 55 | dbo.Purchase.TotalPurchaseAmount < 10));

                //when               
                var purchases = exp.Execute();

                //then
                purchases.Should().HaveCount(expectedCount);
            }
            #endregion
        }
    }
}

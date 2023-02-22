using DbEx.Data;
using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "UPDATE")]
    public partial class UpdateTests : ResetDatabaseAfterEveryTest
    {
        [Theory]
        [Trait("Operation", "WHERE")]
        [InlineData(1, "Foo")]
        public void Can_update_persons_firstname(int id, string expectedFirstName)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.Update(dbo.Person.FirstName.Set(expectedFirstName))
               .From(dbo.Person)
               .Where(dbo.Person.Id == id);

            //when               
            exp.Execute();

            //then
            var firstName = db.SelectOne(dbo.Person.FirstName).From(dbo.Person).Where(dbo.Person.Id == id).Execute();
            firstName.Should().Be(expectedFirstName);
        }

        [Theory]
        [Trait("Operation", "WHERE")]
        [InlineData(1, "Foo", 1)]
        public void Can_update_persons_firstname_and_result_in_correct_records_affected(int id, string expectedFirstName, int expectedRecordsAffected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.Update(dbo.Person.FirstName.Set(expectedFirstName))
               .From(dbo.Person)
               .Where(dbo.Person.Id == id);

            //when               
            var recordsAffected = exp.Execute();

            //then
            recordsAffected.Should().Be(expectedRecordsAffected);
        }

        [Theory]
        [Trait("Operation", "WHERE")]
        [InlineData(1, "Foo", "Bar")]
        public void Can_update_persons_firstname_and_lastname(int id, string expectedFirstName, string expectedLastName)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.Update(
                    dbo.Person.FirstName.Set(expectedFirstName), 
                    dbo.Person.LastName.Set(expectedLastName)
                )
               .From(dbo.Person)
               .Where(dbo.Person.Id == id);

            //when               
            exp.Execute();

            //then
            var person = db.SelectOne<Person>().From(dbo.Person).Where(dbo.Person.Id == id).Execute()!;
            person.FirstName.Should().Be(expectedFirstName);
            person.LastName.Should().Be(expectedLastName);
        }

        [Theory]
        [Trait("Operation", "WHERE")]
        [InlineData("Broflovski", "]")]
        public void Can_update_persons_firstname_where_lastname(string lastName, string appendToFirstName)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.Update(
                    dbo.Person.FirstName.Set(dbo.Person.FirstName + appendToFirstName)
                )
               .From(dbo.Person)
               .Where(dbo.Person.LastName == lastName);

            //when               
            exp.Execute();

            //then
            var persons = db.SelectMany<Person>().From(dbo.Person).Where(dbo.Person.LastName == lastName).Execute();
            persons.Should().Match(x => x.All(y => y.FirstName.EndsWith(appendToFirstName)));
        }

        [Theory]
        [Trait("Operation", "WHERE")]
        [InlineData("Broflovski", "]", 4)]
        public void Can_update_persons_firstname_where_lastname_result_in_correct_records_affected(string lastName, string appendToFirstName, int expectedRecordsAffected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.Update(
                    dbo.Person.FirstName.Set(dbo.Person.FirstName + appendToFirstName)
                )
               .From(dbo.Person)
               .Where(dbo.Person.LastName == lastName);

            //when               
            var recordsAffected = exp.Execute();

            //then
            recordsAffected.Should().Be(expectedRecordsAffected);
        }

        [Theory]
        [Trait("Operation", "WHERE")]
        [InlineData("]", 2)]
        public void Can_update_persons_firstname_where_lastname_and_top_result_in_correct_records_affected(string appendToFirstName, int expectedRecordsAffected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.Update(
                    dbo.Person.FirstName.Set(dbo.Person.FirstName + appendToFirstName)
                )
                .Top(expectedRecordsAffected)
                .From(dbo.Person);

            //when               
            var recordsAffected = exp.Execute();

            //then
            recordsAffected.Should().Be(expectedRecordsAffected);
        }

        [Fact]
        [Trait("Operation", "WHERE")]
        public void Can_update_product_image_to_the_same_as_another_product()
        {
            //given
            AppendImagesToProductsInDatabase();
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            Product product1 = db.SelectOne<Product>().From(dbo.Product).Where(dbo.Product.Id == 1).Execute()!;

            //when
            db.Update(dbo.Product.Image.Set(product1.Image))
               .From(dbo.Product)
               .Where(dbo.Product.Id == 2)
               .Execute();

            //then
            byte[] product2Image = db.SelectOne(dbo.Product.Image).From(dbo.Product).Where(dbo.Product.Id == 2).Execute()!;
            product2Image.Should().BeEquivalentTo(product1.Image);
        }

        [Fact]
        [Trait("Operation", "WHERE")]
        public void Can_update_address_line2_to_null()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var address = db.SelectOne<Address>().From(dbo.Address).Where(dbo.Address.Line2 != dbex.Null).Execute()!;

            //when
            db.Update(dbo.Address.Line2.Set(dbex.Null))
               .From(dbo.Address)
               .Where(dbo.Address.Id == address.Id)
               .Execute();

            //then
            var updatedAddress = db.SelectOne<Address>().From(dbo.Address).Where(dbo.Address.Id == address.Id).Execute()!;
            updatedAddress.Line2.Should().BeNull();
        }

        [Fact]
        [Trait("Operation", "WHERE")]
        public void Can_update_product_image_to_null()
        {
            //given
            AppendImagesToProductsInDatabase();
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            db.Update(dbo.Product.Image.Set(dbex.Null))
               .From(dbo.Product)
               .Where(dbo.Product.Id == 1)
               .Execute();

            //then
            var updatedProduct = db.SelectOne<Product>().From(dbo.Product).Where(dbo.Product.Id == 1).Execute()!;
            updatedProduct.Image.Should().BeNull();
        }

        [Theory]
        [Trait("Operation", "WHERE")]
        [InlineData("Biggle", 1)]
        public void Can_update_persons_lastname_and_firstname_using_entities_to_build_assignment_expression_result_in_correct_records_affected(string lastName, int expectedRecordsAffected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var unchanged = db.SelectOne<Person>().From(dbo.Person).Where(dbo.Person.LastName == lastName).Execute()!;
            var updated = db.SelectOne<Person>().From(dbo.Person).Where(dbo.Person.LastName == lastName).Execute()!;

            updated.LastName = "x";
            updated.FirstName = "x";

            var comparison = dbex.BuildAssignmentsFor(dbo.Person).From(unchanged).To(updated);
            var exp = db.Update(comparison)
                .From(dbo.Person)
                .Where(dbo.Person.Id == unchanged.Id);

            //when               
            var recordsAffected = exp.Execute();
            var verification = db.SelectOne<Person>().From(dbo.Person).Where(dbo.Person.LastName == "x").Execute()!;

            //then
            recordsAffected.Should().Be(expectedRecordsAffected);
            verification.LastName.Should().Be("x");
            verification.FirstName.Should().Be("x");
        }

        [Theory]
        [Trait("Operation", "WHERE")]
        [InlineData("Biggle")]
        public void Does_an_empty_update_expression_set_cause_sql_exception(string lastName)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var source = db.SelectOne<Person>().From(dbo.Person).Where(dbo.Person.LastName == lastName).Execute()!;
            var target = db.SelectOne<Person>().From(dbo.Person).Where(dbo.Person.LastName == lastName).Execute()!;

            var comparison = dbex.BuildAssignmentsFor(dbo.Person).From(source).To(target);
            Func<Task> execute = async () => await db.Update(comparison)
                .From(dbo.Person)
                .Where(dbo.Person.Id == source.Id)
                .ExecuteAsync();

            //when & then
            execute.Should().ThrowAsync<SqlException>().Result.And.Message.Should().StartWith("Incorrect syntax near");

        }

        [Theory]
        [Trait("Operation", "WHERE")]
        [InlineData(1, "Foo")]
        public async Task Can_update_persons_firstname_async(int id, string expectedFirstName)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.Update(dbo.Person.FirstName.Set(expectedFirstName))
               .From(dbo.Person)
               .Where(dbo.Person.Id == id);

            //when               
            await exp.ExecuteAsync();

            //then
            var firstName = db.SelectOne(dbo.Person.FirstName).From(dbo.Person).Where(dbo.Person.Id == id).Execute();
            firstName.Should().Be(expectedFirstName);
        }

        [Theory]
        [Trait("Operation", "WHERE")]
        [InlineData(GenderType.Female)]
        public async Task Can_update_persons_gendertype_async(GenderType expectedGenderType)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.Update(dbo.Person.GenderType.Set(expectedGenderType))
               .From(dbo.Person)
               .Where(dbo.Person.GenderType == GenderType.Male);

            //when               
            await exp.ExecuteAsync();

            //then
            var genderType = await db.SelectOne(dbo.Person.GenderType).From(dbo.Person).ExecuteAsync();
            genderType.Should().Be(expectedGenderType);
        }

        [Fact]
        public async Task Does_truncate_with_update_statement_throw_exception_as_expected()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var ex = await Assert.ThrowsAsync<SqlException>(async () => await db.Update(dbo.Person.FirstName.Set(new string(Enumerable.Repeat('a', 1000).ToArray())))
                .From(dbo.Person)
                .ExecuteAsync());

            ex.Should().NotBeNull();
            ex.Message.Should().Contain("truncated");
        }

        [Theory]
        [InlineData("XXX")]
        public async Task Can_try_to_set_field_value_before_update_assembly_event(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeUpdateStart(context => context.TrySetFieldValue(nameof(dbo.Person.FirstName), expected)));

            //when
            await db.Update(dbo.Person.LastName.Set("YYY")).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();

            //then
            var name = await db.SelectOne(dbo.Person.FirstName).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();

            name.Should().Be(expected);
        }

        [Theory]
        [InlineData("XXX")]
        public async Task Can_set_field_value_before_update_assembly_event(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeUpdateStart(context => context.SetFieldValue(nameof(dbo.Person.FirstName), expected)));

            //when
            await db.Update(dbo.Person.LastName.Set("YYY")).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();

            //then
            var name = await db.SelectOne(dbo.Person.FirstName).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();

            name.Should().Be(expected);
        }

        [Theory]
        [InlineData(10, 11)]
        public async Task Can_update_credit_limit_using_arithmetic_expression_with_literal(int percent, int anticipatedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            int affectedCount = await db.Update(
                    dbo.Person.CreditLimit.Set(
                            dbo.Person.CreditLimit + db.fx.Cast(
                                 dbo.Person.CreditLimit * ((decimal)(percent + 0.0) / 100)
                                ).AsInt()
                        )
                    )
                .From(dbo.Person)
                .Where(dbo.Person.CreditLimit == 10000)
                .ExecuteAsync();

            //then
            affectedCount.Should().Be(anticipatedCount);
        }

        [Fact]
        ///issue #283
        public async Task Can_update_records_using_a_select_subquery()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var subquery = db.SelectMany(
                            dbo.Purchase.PersonId,
                            db.fx.Max(dbo.Purchase.TotalPurchaseAmount).As("MaxPurchaseAmount")
                        )
                        .From(dbo.Purchase)
                        .Where(dbo.Purchase.TotalPurchaseAmount > 20)
                        .GroupBy(dbo.Purchase.PersonId);

            var anticipatedCount = await db.SelectOne(db.fx.Count())
                .From(dbo.Person)
                .InnerJoin(subquery).As("newCreditLimit").On(dbo.Person.Id == ("newCreditLimit", nameof(dbo.Purchase.PersonId)))
                .ExecuteAsync();

            //when
            var affectedCount = await db.Update(dbo.Person.CreditLimit.Set(1000))
                .From(dbo.Person)
                .InnerJoin(subquery).As("newCreditLimit").On(dbo.Person.Id == ("newCreditLimit", nameof(dbo.Purchase.PersonId)))
                .ExecuteAsync();

            //then
            affectedCount.Should().Be(anticipatedCount);
        }

        [Theory]
        [InlineData(9)]
        public async Task Can_update_records_using_arithmetic(int anticipatedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            int affectedCount = await db.Update(
                        dbo.Product.Quantity.Set(dbo.Product.Quantity - 1)
                    )
                .From(dbo.Product)
                .ExecuteAsync();

            //then
            affectedCount.Should().Be(anticipatedCount);

        }

        [Theory]
        [InlineData(6)]
        public async Task Can_update_records_using_arithmetic_via_aliased_subquery(int anticipatedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            int affectedCount = await db.Update(dbo.Person.CreditLimit.Set(("newCreditLimit", "creditLimit")))
                .From(dbo.Person)
                .InnerJoin(
                    db.SelectMany(
                            dbo.Purchase.PersonId,
                            db.fx.Max(dbo.Purchase.TotalPurchaseAmount).As("creditLimit")
                        )
                        .From(dbo.Purchase)
                        .GroupBy(dbo.Purchase.PersonId)
                ).As("newCreditLimit").On(dbo.Person.Id == ("newCreditLimit", "PersonId"))
                .ExecuteAsync();

            //then
            affectedCount.Should().Be(anticipatedCount);

        }
    }
}

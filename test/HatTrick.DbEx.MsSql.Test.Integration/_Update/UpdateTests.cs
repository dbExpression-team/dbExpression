using DbEx.Data;
using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "UPDATE")]
    public partial class UpdateTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public void Can_update_persons_firstname(int version, int id = 1, string expectedFirstName = "Foo")
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

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
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public void Can_update_persons_firstname_and_result_in_correct_records_affected(int version, int id = 1, string expectedFirstName = "Foo", int expectedRecordsAffected = 1)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.Update(dbo.Person.FirstName.Set(expectedFirstName))
               .From(dbo.Person)
               .Where(dbo.Person.Id == id);

            //when               
            var recordsAffected = exp.Execute();

            //then
            recordsAffected.Should().Be(expectedRecordsAffected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public void Can_update_persons_firstname_and_lastname(int version, int id = 1, string expectedFirstName = "Foo", string expectedLastName = "Bar")
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

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
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public void Can_update_persons_firstname_where_lastname(int version, string lastName = "Broflovski", string appendToFirstName = "]")
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

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
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public void Can_update_persons_firstname_where_lastname_result_in_correct_records_affected(int version, string lastName = "Broflovski", string appendToFirstName = "]", int expectedRecordsAffected = 4)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

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
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public void Can_update_persons_firstname_where_lastname_and_top_result_in_correct_records_affected(int version, string appendToFirstName = "]", int expectedRecordsAffected = 2)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

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

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public void Can_update_product_image_to_the_same_as_another_product(int version)
        {
            //given
            AppendImagesToProductsInDatabase();
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);
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

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public void Can_update_address_line2_to_null(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);
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

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public void Can_update_product_image_to_null(int version)
        {
            //given
            AppendImagesToProductsInDatabase();
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

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
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public void Can_update_persons_lastname_and_firstname_using_entities_to_build_assignment_expression_result_in_correct_records_affected(int version, string lastName = "Biggle", int expectedRecordsAffected = 1)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

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
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public void Does_an_empty_update_expression_set_cause_sql_exception(int version, string lastName = "Biggle")
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

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
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public async Task Can_update_persons_firstname_async(int version, int id = 1, string expectedFirstName = "Foo")
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

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
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public async Task Can_update_persons_gendertype_async(int version,GenderType expectedGenderType = GenderType.Female)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.Update(dbo.Person.GenderType.Set(expectedGenderType))
               .From(dbo.Person)
               .Where(dbo.Person.GenderType == GenderType.Male);

            //when               
            await exp.ExecuteAsync();

            //then
            var genderType = await db.SelectOne(dbo.Person.GenderType).From(dbo.Person).ExecuteAsync();
            genderType.Should().Be(expectedGenderType);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_truncate_with_update_statement_throw_exception_as_expected(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var ex = await Assert.ThrowsAsync<SqlException>(async () => await db.Update(dbo.Person.FirstName.Set(new string(Enumerable.Repeat('a', 1000).ToArray())))
                .From(dbo.Person)
                .ExecuteAsync());

            ex.Should().NotBeNull();
            ex.Message.Should().Contain("truncated");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_try_to_set_field_value_before_update_assembly_event(int version, string expected = "XXX")
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, configure => configure.Events.OnBeforeUpdateSqlStatementAssembly(context => context.TrySetFieldValue(nameof(dbo.Person.FirstName), expected)));

            //when
            await db.Update(dbo.Person.LastName.Set("YYY")).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();

            //then
            var name = await db.SelectOne(dbo.Person.FirstName).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();

            name.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_set_field_value_before_update_assembly_event(int version, string expected = "XXX")
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, configure => configure.Events.OnBeforeUpdateSqlStatementAssembly(context => context.SetFieldValue(nameof(dbo.Person.FirstName), expected)));

            //when
            await db.Update(dbo.Person.LastName.Set("YYY")).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();

            //then
            var name = await db.SelectOne(dbo.Person.FirstName).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();

            name.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_update_credit_limit_using_arithmetic_expression_with_literal(int version, int percent = 10, int anticipatedCount = 11)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

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

        [Theory]
        [MsSqlVersions.AllVersions]
        ///issue #283
        public async Task Can_update_records_using_a_select_subquery(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

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
        [MsSqlVersions.AllVersions]
        public async Task Can_update_records_using_arithmetic(int version, int anticipatedCount = 9)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

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
        [MsSqlVersions.AllVersions]
        public async Task Can_update_records_using_arithmetic_via_aliased_subquery(int version, int anticipatedCount = 6)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

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

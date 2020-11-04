using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Statement", "UPDATE")]
    public partial class Update : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public void Can_update_persons_firstname(int version, int id = 1, string expectedFirstName = "Foo")
        {
            //given
            ConfigureForMsSqlVersion(version);

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
            ConfigureForMsSqlVersion(version);

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
            ConfigureForMsSqlVersion(version);

            var exp = db.Update(
                    dbo.Person.FirstName.Set(expectedFirstName), 
                    dbo.Person.LastName.Set(expectedLastName)
                )
               .From(dbo.Person)
               .Where(dbo.Person.Id == id);

            //when               
            exp.Execute();

            //then
            var person = db.SelectOne<Person>().From(dbo.Person).Where(dbo.Person.Id == id).Execute();
            person.FirstName.Should().Be(expectedFirstName);
            person.LastName.Should().Be(expectedLastName);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public void Can_update_persons_firstname_where_lastname(int version, string lastName = "Broflovski", string appendToFirstName = "]")
        {
            //given
            ConfigureForMsSqlVersion(version);

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
            ConfigureForMsSqlVersion(version);

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
        public void Can_update_product_image_to_the_same_as_another_product(int version)
        {
            //given
            AppendImagesToProductsInDatabase();
            ConfigureForMsSqlVersion(version);
            var product1 = db.SelectOne<Product>().From(dbo.Product).Where(dbo.Product.Id == 1).Execute();

            //when
            db.Update(dbo.Product.Image.Set(product1.Image))
               .From(dbo.Product)
               .Where(dbo.Product.Id == 2)
               .Execute();

            //then
            var product2Image = db.SelectOne(dbo.Product.Image).From(dbo.Product).Where(dbo.Product.Id == 2).Execute();
            product2Image.Should().BeEquivalentTo(product1.Image);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public void Can_update_address_line2_to_null(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);
            var address = db.SelectOne<Address>().From(dbo.Address).Where(dbo.Address.Line2 != DBNull.Value).Execute();

            //when
            db.Update(dbo.Address.Line2.Set(DBNull.Value))
               .From(dbo.Address)
               .Where(dbo.Address.Id == address.Id)
               .Execute();

            //then
            var updatedAddress = db.SelectOne<Address>().From(dbo.Address).Where(dbo.Address.Id == address.Id).Execute();
            updatedAddress.Line2.Should().BeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public void Can_update_product_image_to_null(int version)
        {
            //given
            AppendImagesToProductsInDatabase();
            ConfigureForMsSqlVersion(version);

            //when
            db.Update(dbo.Product.Image.Set(DBNull.Value))
               .From(dbo.Product)
               .Where(dbo.Product.Id == 1)
               .Execute();

            //then
            var updatedProduct = db.SelectOne<Product>().From(dbo.Product).Where(dbo.Product.Id == 1).Execute();
            updatedProduct.Image.Should().BeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public void Can_update_persons_lastname_and_firstname_using_entities_to_build_assignment_expression_result_in_correct_records_affected(int version, string lastName = "Biggle", int expectedRecordsAffected = 1)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var source = db.SelectOne<Person>().From(dbo.Person).Where(dbo.Person.LastName == lastName).Execute();
            var target = db.SelectOne<Person>().From(dbo.Person).Where(dbo.Person.LastName == lastName).Execute();

            target.LastName = $"x{source.LastName}";
            target.FirstName = $"x{target.FirstName}";

            var exp = db.Update<Person>(
                   target,
                   source
                )
               .From(dbo.Person)
               .Where(dbo.Person.Id == source.Id);

            //when               
            var recordsAffected = exp.Execute();
            var updated = db.SelectOne<Person>().From(dbo.Person).Where(dbo.Person.LastName == $"x{source.LastName}").Execute();

            //then
            recordsAffected.Should().Be(expectedRecordsAffected);
            updated.LastName.Should().Be($"x{source.LastName}");
            updated.FirstName.Should().Be($"x{source.FirstName}");
        }
    }
}

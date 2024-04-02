using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Operation", "IN")]
    public class InTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(0)]
        public void Does_selecting_persons_using_empty_enumerable_result_in_no_output(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var personIds = Enumerable.Empty<int>();

            //when
            var persons = db.SelectMany<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id.In(personIds))
                .Execute();

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [InlineData(2)]
        public void Does_selecting_addresses_using_a_null_value_as_first_element_in_the_enumerable_result_in_no_output(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var lines = new List<string> { null!, "Box 13", "Apt. 42" };

            //when
            var addresses = db.SelectMany<Address>()
                .From(dbo.Address)
                .Where(dbo.Address.Line2.In(lines))
                .Execute();

            //then
            addresses.Should().HaveCount(expectedCount);
        }

        [Theory]
        [InlineData(2)]
        public void Does_selecting_addresses_using_a_null_value_in_the_enumerable_result_in_correct_output(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var lines = new List<string> { "Box 13", null!, "Apt. 42" };

            //when
            var addresses = db.SelectMany<Address>()
                .From(dbo.Address)
                .Where(dbo.Address.Line2.In(lines))
                .Execute();

            //then
            addresses.Should().HaveCount(expectedCount);
        }

        [Theory]
        [InlineData(0)]
        public void Does_selecting_addresses_using_a_null_values_for_every_element_of_the_enumerable_result_in_no_output(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var lines = new List<string> { null!, null!, null!, null! };

            //when
            var addresses = db.SelectMany<Address>()
                .From(dbo.Address)
                .Where(dbo.Address.Line2.In(lines))
                .Execute();

            //then
            addresses.Should().HaveCount(expectedCount);
        }

        [Theory]
        [InlineData(15)]
        public void Does_selecting_persons_using_enumerable_of_ids_result_in_correct_output(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var personIds = Enumerable.Range(1, 15);

            //when
            var persons = db.SelectMany<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id.In(personIds))
                .Execute();

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [InlineData(15)]
        public void Does_selecting_persons_using_params_of_ids_result_in_correct_output(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var persons = db.SelectMany<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id.In(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15))
                .Execute();

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [InlineData(35)]
        public void Does_selecting_persons_using_enumerable_of_ids_exclusive_result_in_correct_output(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var personIds = Enumerable.Range(1, 15);

            //when
            var persons = db.SelectMany<Person>()
                .From(dbo.Person)
                .Where(!dbo.Person.Id.In(personIds))
                .Execute();

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [InlineData(35)]
        public void Does_selecting_persons_using_params_of_ids_exclusive_result_in_correct_output(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var persons = db.SelectMany<Person>()
                .From(dbo.Person)
                .Where(!dbo.Person.Id.In(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15))
                .Execute();

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [InlineData(50)]
        public void Does_selecting_persons_using_enumerable_of_ids_appended_to_before_execution_result_in_correct_output(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var personIds = Enumerable.Range(1, 15).ToList();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id.In(personIds));

            //when
            personIds.AddRange(Enumerable.Range(16, 35));
            var persons = exp.Execute();

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [Trait("Function", "Cast")]
        [InlineData(15)]
        public void Does_selecting_persons_using_enumerable_of_ids_cast_as_strings_result_in_correct_output(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var personIds = Enumerable.Range(1, 15).Select(x => x.ToString());

            var exp = db.SelectMany<Person>()
                .From(dbo.Person)
                .Where(db.fx.Cast(dbo.Person.Id).AsVarChar(20).In(personIds));

            //when
            var persons = exp.Execute();

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [Trait("Operation", "Having")]
        [Trait("Operation", "GroupBy")]
        [Trait("Function", "Avg")]
        [InlineData(4)]
        public void Does_selecting_average_of_product_quantity_in_list_result_in_correct_output(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var quantities = new List<int>() { 100, 5500, 7400, 11100 };

            var exp = db.SelectMany(
                    dbo.Product.ProductCategoryType,
                    db.fx.Avg(dbo.Product.Quantity).As("Quantity")
                )
                .From(dbo.Product)
                .GroupBy(dbo.Product.ProductCategoryType)
                .Having(db.fx.Avg(dbo.Product.Quantity).In(quantities));

            //when
            var products = exp.Execute();

            //then
            products.Should().HaveCount(expectedCount);
        }
    }
}

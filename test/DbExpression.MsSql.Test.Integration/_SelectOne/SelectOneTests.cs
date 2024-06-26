using DbEx.Data;
using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using v2019DbEx.secDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
//using DbExpression.MsSql.Expression;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    public partial class SelectOneTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        [Trait("Operation", "WHERE")]
        public void Can_a_person_record_select_successfully(bool useSyntheticAliases)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

            var exp = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1);

            //when               
            Person? person = exp.Execute();

            //then
            person.Should().NotBeNull();
            person!.FirstName.Should().Be("Kenny");
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        [Trait("Operation", "WHERE")]
        public void Does_a_non_existent_person_record_select_and_return_null_successfully(bool useSyntheticAliases)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

            var exp = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id == -1);

            //when               
            Person? person = exp.Execute();

            //then
            person.Should().BeNull();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        [Trait("Operation", "WHERE")]
        public async Task Can_a_person_record_select_async_successfully(bool useSyntheticAliases)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

            var exp = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1);

            //when               
            Person? person = await exp.ExecuteAsync();

            //then
            person.Should().NotBeNull();
            person!.FirstName.Should().Be("Kenny");
        }

        [Theory]
        [InlineData(true, 1)]
        [InlineData(false, 1)]
        [Trait("Operation", "GROUP BY")]
        public async Task Can_a_group_by_select_async_when_table_name_is_aliased_runsuccessfully(bool useSyntheticAliases, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

            var table = dbo.Person.As("dboPerson");  
                        
            var count = await db.SelectOne(db.fx.Count(table.FirstName))
                .From(table)
                .GroupBy(table.FirstName)
                .ExecuteAsync();

            //then
            count.Should().Be(expected);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Can_select_two_person_fields_as_a_dynamic(bool useSyntheticAliases)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

            dynamic? person = await db.SelectOne(
                    sec.Person.Id, 
                    sec.Person.SocialSecurityNumber
                )
                .From(sec.Person).ExecuteAsync();

            //then
            ((object?)person).Should().NotBeNull();
            ((string)person!.SocialSecurityNumber).Should().NotBeNull();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Can_an_overriden_property_name_aliased_return_the_correct_data_type_when_selecting_value(bool useSyntheticAliases)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

            var person = await db.SelectOne(
                    sec.Person.SocialSecurityNumber.As("foo")
                )
                .From(sec.Person).ExecuteAsync();

            //then
            person.Should().NotBeNull();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Can_select_dynamic_by_providing_list_of_any_element(bool useSyntheticAliases)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

            dynamic? person = await db.SelectOne(
                    new List<AnyElement>() {
                        dbo.Person.Id,
                        dbo.Person.FirstName,
                        dbo.Person.LastName,
                        dbo.Person.CreditLimit
                    }
                )
                .From(dbo.Person).ExecuteAsync();

            //then
            ((object?)person).Should().NotBeNull();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Can_select_dynamic_by_providing_list_of_any_element_and_additional_fields_as_params(bool useSyntheticAliases)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

            dynamic? person = await db.SelectOne(
                    new List<AnyElement>() {
                        dbo.Person.Id,
                        dbo.Person.FirstName,
                        dbo.Person.LastName,
                        dbo.Person.CreditLimit
                    },
                    dbo.Person.BirthDate,
                    dbo.Person.DateCreated,
                    dbo.Person.DateUpdated
                )
                .From(dbo.Person).ExecuteAsync();

            //then
            ((object?)person).Should().NotBeNull();
            ((int?)person!.Id).Should().NotBeNull();
            ((DateTime?)person.DateCreated).Should().NotBeNull();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Can_an_overriden_property_type_return_the_correct_data_type_when_selecting_value(bool useSyntheticAliases)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

            //when
            ProductDescription? value = await db.SelectOne(
                    dbo.Product.Description
                )
                .From(dbo.Product)
                .Where(dbo.Product.Description != dbex.Null)
                .ExecuteAsync();

            //then
            value.Should().NotBeNull();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Can_an_overriden_property_type_and_aliased_return_the_correct_data_type_when_selecting_value(bool useSyntheticAliases)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

            //when
            ProductDescription? value = await db.SelectOne(
                    dbo.Product.Description.As("foo")
                )
                .From(dbo.Product)
                .Where(dbo.Product.Description != dbex.Null)
                .ExecuteAsync();

            //then
            value.Should().NotBeNull();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Can_select_dynamic_with_an_overriden_property_type_return_the_correct_data_type_when_selecting_value(bool useSyntheticAliases)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

            //when
            dynamic? value = await db.SelectOne(
                    dbo.Product.Id,
                    dbo.Product.Description
                )
                .From(dbo.Product)
                .Where(dbo.Product.Description != dbex.Null)
                .ExecuteAsync();

            //then
            (value?.Description as ProductDescription).Should().NotBeNull();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Can_select_dynamic_with_an_overriden_property_type_and_aliased_return_the_correct_data_type_when_selecting_value(bool useSyntheticAliases)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

            //when
            dynamic? value = await db.SelectOne(
                    dbo.Product.Id,
                    dbo.Product.Description.As("foo")
                )
                .From(dbo.Product)
                .Where(dbo.Product.Description != dbex.Null)
                .ExecuteAsync();

            //then
            (value?.foo as ProductDescription).Should().NotBeNull();
        }

        [Theory]
        [InlineData(true, 9)]
        [InlineData(false, 9)]
        public async Task Can_select_count_of_bytearray_when_equal_to_dbnull(bool useSyntheticAliases, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));
            AppendImagesToProductsInDatabase();

            //when
            int value = await db.SelectOne(db.fx.Count())
                .From(dbo.Product)
                .Where(dbo.Product.Image != dbex.Null)
                .ExecuteAsync();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Can_select_aliased_bytearray_when_equal_to_dbnull(bool useSyntheticAliases)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));
            AppendImagesToProductsInDatabase();

            //when
            dynamic? value = await db.SelectOne(
                    dbo.Product.Id,
                    dbo.Product.Image.As("foo")
                )
                .From(dbo.Product)
                .Where(dbo.Product.Image != dbex.Null)
                .ExecuteAsync();

            //then
            (value!.foo as byte[]).Should().NotBeEmpty();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Can_select_sys_date_time(bool useSyntheticAliases)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

            //when
            DateTime value = await db.SelectOne(
                    db.fx.SysDateTime()
                )
                .From(dbo.Person)
                .ExecuteAsync();

            //then
            (value - DateTime.Now).Should().BeLessThan(TimeSpan.FromSeconds(5));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Can_select_sys_date_time_offset(bool useSyntheticAliases)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

            //when
            DateTimeOffset value = await db.SelectOne(
                    db.fx.SysDateTimeOffset()
                )
                .From(dbo.Person)
                .ExecuteAsync();

            //then
            (value - DateTimeOffset.Now).Should().BeLessThan(TimeSpan.FromSeconds(5));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Can_select_sys_utc_date_time(bool useSyntheticAliases)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

            //when
            DateTime value = await db.SelectOne(
                    db.fx.SysUtcDateTime()
                )
                .From(dbo.Person)
                .ExecuteAsync();

            //then
            (value - DateTime.UtcNow).Should().BeLessThan(TimeSpan.FromSeconds(5));
        }
    }
}

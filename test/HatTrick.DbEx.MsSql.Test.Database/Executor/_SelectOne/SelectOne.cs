using DbEx.Data;
using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using DbEx.secDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
//using HatTrick.DbEx.MsSql.Expression;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Statement", "SELECT")]
    public partial class SelectOne : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public void Can_a_person_record_select_successfully(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public async Task Can_a_person_record_select_async_successfully(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public async Task Can_a_group_by_select_async_when_table_name_is_aliased_runsuccessfully(int version, int expected = 1)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var table = dbo.Person.As("dboPerson");  
                        
            var count = await db.SelectOne(db.fx.Count(table.FirstName))
                .From(table)
                .GroupBy(table.FirstName)
                .ExecuteAsync();

            //then
            count.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_select_two_person_fields_as_a_dynamic(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        public async Task Can_an_overriden_property_name_aliased_return_the_correct_data_type_when_selecting_value(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var person = await db.SelectOne(
                    sec.Person.SocialSecurityNumber.As("foo")
                )
                .From(sec.Person).ExecuteAsync();

            //then
            person.Should().NotBeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_select_dynamic_by_providing_list_of_any_element(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        public async Task Can_select_dynamic_by_providing_list_of_any_element_and_additional_fields_as_params(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        public async Task Can_an_overriden_property_type_return_the_correct_data_type_when_selecting_value(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when
            ProductDescription? value = await db.SelectOne(
                    dbo.Product.Description
                )
                .From(dbo.Product)
                .Where(dbo.Product.Description != DBNull.Value)
                .ExecuteAsync();

            //then
            value.Should().NotBeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_an_overriden_property_type_and_aliased_return_the_correct_data_type_when_selecting_value(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when
            ProductDescription? value = await db.SelectOne(
                    dbo.Product.Description.As("foo")
                )
                .From(dbo.Product)
                .Where(dbo.Product.Description != DBNull.Value)
                .ExecuteAsync();

            //then
            value.Should().NotBeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_select_dynamic_with_an_overriden_property_type_return_the_correct_data_type_when_selecting_value(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when
            dynamic? value = await db.SelectOne(
                    dbo.Product.Id,
                    dbo.Product.Description
                )
                .From(dbo.Product)
                .Where(dbo.Product.Description != DBNull.Value)
                .ExecuteAsync();

            //then
            (value?.Description as ProductDescription).Should().NotBeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_select_dynamic_with_an_overriden_property_type_and_aliased_return_the_correct_data_type_when_selecting_value(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when
            dynamic? value = await db.SelectOne(
                    dbo.Product.Id,
                    dbo.Product.Description.As("foo")
                )
                .From(dbo.Product)
                .Where(dbo.Product.Description != DBNull.Value)
                .ExecuteAsync();

            //then
            (value?.foo as ProductDescription).Should().NotBeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_select_count_of_bytearray_when_equal_to_dbnull(int version, int expected = 9)
        {
            //given
            ConfigureForMsSqlVersion(version);
            AppendImagesToProductsInDatabase();

            //when
            int value = await db.SelectOne(db.fx.Count())
                .From(dbo.Product)
                .Where(dbo.Product.Image != DBNull.Value)
                .ExecuteAsync();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_select_aliased_bytearray_when_equal_to_dbnull(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);
            AppendImagesToProductsInDatabase();

            //when
            dynamic? value = await db.SelectOne(
                    dbo.Product.Id,
                    dbo.Product.Image.As("foo")
                )
                .From(dbo.Product)
                .Where(dbo.Product.Image != DBNull.Value)
                .ExecuteAsync();

            //then
            (value!.foo as byte[]).Should().NotBeEmpty();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_select_sys_date_time(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        public async Task Can_select_sys_date_time_offset(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        public async Task Can_select_sys_utc_date_time(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

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

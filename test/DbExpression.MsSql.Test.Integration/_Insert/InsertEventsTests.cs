using DbEx.Data;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;
using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Statement", "INSERT")]
    public partial class InsertEventsTests : ResetDatabaseAfterEveryTest
    {
        [Theory]
        [InlineData("XXX")]
        public async Task Can_set_field_value_by_name_before_insert_assembly_event(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(context => context.SetFieldValue(nameof(dbo.Person.FirstName), expected)));
            var person = new Person { FirstName = "xxx", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow };

            //when
            await db.Insert(person).Into(dbo.Person).ExecuteAsync();

            //then
            var name = await db.SelectOne(dbo.Person.FirstName).From(dbo.Person).Where(dbo.Person.Id == person.Id).ExecuteAsync();
            name.Should().Be(expected);
        }

        [Theory]
        [InlineData("XXX")]
        public async Task Can_set_field_value_before_insert_assembly_event(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(context => context.SetFieldValue(dbo.Person.FirstName, expected)));
            var person = new Person { FirstName = "...", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow };

            //when
            await db.Insert(person).Into(dbo.Person).ExecuteAsync();

            //then
            var name = await db.SelectOne(dbo.Person.FirstName).From(dbo.Person).Where(dbo.Person.Id == person.Id).ExecuteAsync();
            name.Should().Be(expected);
        }

        [Theory]
        [InlineData("XXX")]
        public async Task Can_omit_setting_field_value_before_insert_assembly_event_when_inserting_an_entity_not_containing_the_field(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(context => context.SetFieldValue(dbo.Product.Name, "ZZZ")));
            var person = new Person { FirstName = expected, LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow };

            //when
            await db.Insert(person).Into(dbo.Person).ExecuteAsync();

            //then
            var name = await db.SelectOne(dbo.Person.FirstName).From(dbo.Person).Where(dbo.Person.Id == person.Id).ExecuteAsync();
            name.Should().Be(expected);
        }

        [Fact]
        public async Task Can_set_field_value_by_name_to_dbnull_before_insert_assembly_event()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(context => context.SetFieldValue(nameof(dbo.Person.BirthDate), dbex.Null)));
            var person = new Person { FirstName = "...", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow, BirthDate = DateTime.UtcNow };

            //when
            await db.Insert(person).Into(dbo.Person).ExecuteAsync();

            //then
            var birthDate = await db.SelectOne(dbo.Person.BirthDate).From(dbo.Person).Where(dbo.Person.Id == person.Id).ExecuteAsync();
            birthDate.Should().Be(null);
        }

        [Theory]
        [InlineData(GenderType.Male)]
        public async Task Can_set_enum_field_value_to_an_enum_before_insert_assembly_event(GenderType expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(context => context.SetFieldValue(dbo.Person.GenderType, expected)));
            var person = new Person { FirstName = "...", LastName = "FIND_ME", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow, BirthDate = DateTime.UtcNow };

            //when
            await db.Insert(person).Into(dbo.Person).ExecuteAsync();

            //then
            var gender = await db.SelectOne(dbo.Person.GenderType).From(dbo.Person).Where(dbo.Person.Id == person.Id).ExecuteAsync();
            gender.Should().Be(expected);
        }

        [Fact]
        public async Task Can_set_nullable_enum_field_value_to_an_enum_before_insert_assembly_event() //this causes exception prior to test run: ", AddressType? expected)
        {
            AddressType? expected = AddressType.Mailing;

            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(context => context.SetFieldValue(dbo.Address.AddressType, expected)));
            var address = new Address { Line1 = "...", City = "YYY", State = "TX", Zip = "55555" };

            //when
            await db.Insert(address).Into(dbo.Address).ExecuteAsync();

            //then
            var addressType = await db.SelectOne(dbo.Address.AddressType).From(dbo.Address).Where(dbo.Address.Id == address.Id).ExecuteAsync();
            addressType.Should().Be(expected);
        }

        [Theory]
        [InlineData(null)]
        public async Task Can_set_nullable_enum_field_value_to_a_null_before_insert_assembly_event(AddressType? expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(context => context.SetFieldValue(dbo.Address.AddressType, expected)));
            var address = new Address { AddressType = AddressType.Mailing, Line1 = "...", City = "YYY", State = "TX", Zip = "55555" };

            //when
            await db.Insert(address).Into(dbo.Address).ExecuteAsync();

            //then
            var addressType = await db.SelectOne(dbo.Address.AddressType).From(dbo.Address).Where(dbo.Address.Id == address.Id).ExecuteAsync();
            addressType.Should().Be(expected);
        }

        [Fact]
        public async Task Can_set_nullable_enum_field_value_to_dbnull_before_insert_assembly_event()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(context => context.SetFieldValue(dbo.Address.AddressType, dbex.Null)));
            var address = new Address { AddressType = AddressType.Mailing, Line1 = "...", City = "YYY", State = "TX", Zip = "55555" };

            //when
            await db.Insert(address).Into(dbo.Address).ExecuteAsync();

            //then
            var addressType = await db.SelectOne(dbo.Address.AddressType).From(dbo.Address).Where(dbo.Address.Id == address.Id).ExecuteAsync();
            addressType.Should().BeNull();
        }

        [Theory]
        [InlineData("uh-oh")]
        public async Task Does_setting_field_value_by_name_to_a_different_data_type_before_insert_assembly_event_fail_as_expected(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(context => context.SetFieldValue(nameof(dbo.Person.GenderType), expected)));
            var person = new Person { FirstName = "...", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow, BirthDate = DateTime.UtcNow };

            //when & then
            await Assert.ThrowsAsync<SqlException>(async() => await db.Insert(person).Into(dbo.Person).ExecuteAsync());
        }

        [Fact]
        public async Task Can_set_field_value_by_name_for_a_field_that_is_design_time_configured_to_not_allow_insert()
        {
            //given
            DateTime expected = DateTime.UtcNow.AddYears(-1);
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(context => context.SetFieldValue(nameof(dbo.Person.DateCreated), expected)));
            var person = new Person { FirstName = "...", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow, BirthDate = DateTime.UtcNow };

            //when
            await db.Insert(person).Into(dbo.Person).ExecuteAsync();

            //then
            var dateCreated = await db.SelectOne(dbo.Person.DateCreated).From(dbo.Person).Where(dbo.Person.Id == person.Id).ExecuteAsync();
            dateCreated.Year.Should().Be(expected.Year);
        }

        [Theory]
        [InlineData("XXX")]
        public async Task Can_set_field_values_by_name_before_insert_assembly_event_when_inserting_many(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(context => context.SetFieldValue(nameof(dbo.Person.FirstName), expected)));
            var person1 = new Person { FirstName = "...", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow };
            var person2 = new Person { FirstName = "...", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow };
            var person3 = new Person { FirstName = "..", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow };

            //when
            await db.InsertMany(person1, person2, person3).Into(dbo.Person).ExecuteAsync();

            //then
            var names = await db.SelectMany(dbo.Person.FirstName).From(dbo.Person).Where(dbo.Person.Id.In(person1.Id, person2.Id, person3.Id)).ExecuteAsync();
            names.Should().OnlyContain(name => name == expected);
        }

        [Theory]
        [InlineData("XXX")]
        public async Task Can_set_field_values_before_insert_assembly_event_when_inserting_many(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(context => context.SetFieldValue(dbo.Person.FirstName, expected)));
            var person1 = new Person { FirstName = "...", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow };
            var person2 = new Person { FirstName = "...", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow };
            var person3 = new Person { FirstName = "..", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow };

            //when
            await db.InsertMany(person1, person2, person3).Into(dbo.Person).ExecuteAsync();

            //then
            var names = await db.SelectMany(dbo.Person.FirstName).From(dbo.Person).Where(dbo.Person.Id.In(person1.Id, person2.Id, person3.Id)).ExecuteAsync();
            names.Should().OnlyContain(name => name == expected);
        }

        [Theory]
        [InlineData("XXX")]
        public async Task Can_omit_setting_field_values_before_insert_assembly_event_when_inserting_an_entity_not_containing_the_field_when_inserting_many(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(context => context.SetFieldValue(dbo.Product.Name, expected)));
            var person1 = new Person { FirstName = expected, LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow };
            var person2 = new Person { FirstName = expected, LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow };
            var person3 = new Person { FirstName = expected, LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow };

            //when
            await db.InsertMany(person1, person2, person3).Into(dbo.Person).ExecuteAsync();

            //then
            var names = await db.SelectMany(dbo.Person.FirstName).From(dbo.Person).Where(dbo.Person.Id.In(person1.Id, person2.Id, person3.Id)).ExecuteAsync();
            names.Should().OnlyContain(name => name == expected);
        }

        [Fact]
        public async Task Can_set_field_values_by_name_to_dbnull_before_insert_assembly_event_when_inserting_many()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(context => context.SetFieldValue(nameof(dbo.Person.BirthDate), dbex.Null)));
            var person1 = new Person { FirstName = "...", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow, BirthDate = DateTime.UtcNow };
            var person2 = new Person { FirstName = "...", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow, BirthDate = DateTime.UtcNow };
            var person3 = new Person { FirstName = "..", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow, BirthDate = DateTime.UtcNow };

            //when
            await db.InsertMany(person1, person2, person3).Into(dbo.Person).ExecuteAsync();

            //then
            var birthDates = await db.SelectMany(dbo.Person.BirthDate).From(dbo.Person).Where(dbo.Person.Id.In(person1.Id, person2.Id, person3.Id)).ExecuteAsync();
            birthDates.Should().OnlyContain(name => name == null);
        }

        [Theory]
        [InlineData(GenderType.Male)]
        public async Task Can_set_enum_field_values_to_an_enum_before_insert_assembly_event_when_inserting_many(GenderType expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(context => context.SetFieldValue(dbo.Person.GenderType, expected)));
            var person1 = new Person { FirstName = "...", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow, BirthDate = DateTime.UtcNow };
            var person2 = new Person { FirstName = "...", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow, BirthDate = DateTime.UtcNow };
            var person3 = new Person { FirstName = "..", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow, BirthDate = DateTime.UtcNow };

            //when
            await db.InsertMany(person1, person2, person3).Into(dbo.Person).ExecuteAsync();

            //then
            var genders = await db.SelectMany(dbo.Person.GenderType).From(dbo.Person).Where(dbo.Person.Id.In(person1.Id, person2.Id, person3.Id)).ExecuteAsync();
            genders.Should().OnlyContain(gender => gender == GenderType.Male);
        }

        [Fact]
        public async Task Can_set_nullable_enum_field_values_to_an_enum_before_insert_assembly_event_when_inserting_many() //this causes exception prior to test run: ", AddressType? expected)
        {
            AddressType? expected = AddressType.Mailing;

            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(context => context.SetFieldValue(dbo.Address.AddressType, expected)));
            var address1 = new Address { Line1 = "...", City = "YYY", State = "TX", Zip = "55555" };
            var address2 = new Address { Line1 = "...", City = "YYY", State = "TX", Zip = "55555" };
            var address3 = new Address { Line1 = "...", City = "YYY", State = "TX", Zip = "55555" };

            //when
            await db.InsertMany(address1, address2, address3).Into(dbo.Address).ExecuteAsync();

            //then
            var addressTypes = await db.SelectMany(dbo.Address.AddressType).From(dbo.Address).Where(dbo.Address.Id.In(address1.Id, address2.Id, address3.Id)).ExecuteAsync();
            addressTypes.Should().OnlyContain(t => t == expected);
        }

        [Theory]
        [InlineData(null)]
        public async Task Can_set_nullable_enum_field_values_to_a_null_before_insert_assembly_event_when_inserting_many(AddressType? expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(context => context.SetFieldValue(dbo.Address.AddressType, expected)));
            var address1 = new Address { AddressType = AddressType.Mailing, Line1 = "...", City = "YYY", State = "TX", Zip = "55555" };
            var address2 = new Address { AddressType = AddressType.Mailing, Line1 = "...", City = "YYY", State = "TX", Zip = "55555" };
            var address3 = new Address { AddressType = AddressType.Mailing, Line1 = "...", City = "YYY", State = "TX", Zip = "55555" };

            //when
            await db.InsertMany(address1, address2, address2).Into(dbo.Address).ExecuteAsync();

            //then
            var addressTypes = await db.SelectMany(dbo.Address.AddressType).From(dbo.Address).Where(dbo.Address.Id.In(address1.Id, address2.Id, address3.Id)).ExecuteAsync();
            addressTypes.Should().OnlyContain(t => t == expected);
        }

        [Fact]
        public async Task Can_set_nullable_enum_field_values_to_dbnull_before_insert_assembly_event_when_inserting_many()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(context => context.SetFieldValue(dbo.Address.AddressType, dbex.Null)));
            var address1 = new Address { AddressType = AddressType.Mailing, Line1 = "...", City = "YYY", State = "TX", Zip = "55555" };
            var address2 = new Address { AddressType = AddressType.Mailing, Line1 = "...", City = "YYY", State = "TX", Zip = "55555" };
            var address3 = new Address { AddressType = AddressType.Mailing, Line1 = "...", City = "YYY", State = "TX", Zip = "55555" };

            //when
            await db.InsertMany(address1, address2, address2).Into(dbo.Address).ExecuteAsync();

            //then
            var addressTypes = await db.SelectMany(dbo.Address.AddressType).From(dbo.Address).Where(dbo.Address.Id.In(address1.Id, address2.Id, address3.Id)).ExecuteAsync();
            addressTypes.Should().OnlyContain(t => t == null);
        }

        [Theory]
        [InlineData("uh-oh")]
        public async Task Does_setting_field_values_by_name_to_a_different_data_type_before_insert_assembly_event_fail_as_expected_when_inserting_many(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(context => context.SetFieldValue(nameof(dbo.Person.GenderType), expected)));
            var person1 = new Person { FirstName = "...", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow, BirthDate = DateTime.UtcNow };
            var person2 = new Person { FirstName = "...", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow, BirthDate = DateTime.UtcNow };
            var person3 = new Person { FirstName = "...", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow, BirthDate = DateTime.UtcNow };

            //when & then
            await Assert.ThrowsAsync<SqlException>(async () => await db.InsertMany(person1, person2, person3).Into(dbo.Person).ExecuteAsync());
        }

        [Fact]
        public async Task Can_set_field_values_by_name_for_a_field_that_is_design_time_configured_to_not_allow_insert_when_inserting_many()
        {
            //given
            DateTime expected = DateTime.UtcNow.AddYears(-1);
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(context => context.SetFieldValue(nameof(dbo.Person.DateCreated), expected)));
            var person1 = new Person { FirstName = "...", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow, BirthDate = DateTime.UtcNow };
            var person2 = new Person { FirstName = "...", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow, BirthDate = DateTime.UtcNow };
            var person3 = new Person { FirstName = "...", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow, BirthDate = DateTime.UtcNow };

            //when
            await db.InsertMany(person1, person2, person3).Into(dbo.Person).ExecuteAsync();

            //then
            var dateCreated = await db.SelectMany(dbo.Person.DateCreated).From(dbo.Person).Where(dbo.Person.Id.In(person1.Id, person2.Id, person3.Id)).ExecuteAsync();
            dateCreated.Should().OnlyContain(d => d.Year == expected.Year);
        }
    }
}

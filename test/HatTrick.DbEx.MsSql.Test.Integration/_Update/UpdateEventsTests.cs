using DbEx.Data;
using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Threading.Tasks;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "UPDATE")]
    public partial class UpdateEventsTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_set_field_value_by_name_before_update_assembly_event(int version, string expected = "XXX")
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateSqlStatementAssembly(context => context.SetFieldValue(nameof(dbo.Person.FirstName), expected)));

            //when
            await db.Update(dbo.Person.LastName.Set(expected)).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();

            //then
            var name = await db.SelectOne(dbo.Person.FirstName).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();
            name.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_set_field_value_before_update_assembly_event(int version, string expected = "XXX")
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateSqlStatementAssembly(context => context.SetFieldValue(dbo.Person.FirstName, expected)));

            //when
            await db.Update(dbo.Person.LastName.Set(expected)).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();

            //then
            var name = await db.SelectOne(dbo.Person.FirstName).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();
            name.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_omit_setting_field_value_before_update_assembly_event_when_updating_an_entity_not_containing_the_field(int version, string expected = "XXX")
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateSqlStatementAssembly(context => context.SetFieldValue(dbo.Product.Name, expected)));

            //when
            await db.Update(dbo.Person.FirstName.Set(expected)).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();

            //then
            var name = await db.SelectOne(dbo.Person.FirstName).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();
            name.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_set_field_value_by_name_to_dbnull_before_update_assembly_event_when_override_is_true(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateSqlStatementAssembly(context => context.SetFieldValue(nameof(dbo.Person.BirthDate), dbex.Null, true)));

            //when
            await db.Update(dbo.Person.BirthDate.Set(DateTime.Now)).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();

            //then
            var birthDate = await db.SelectOne(dbo.Person.BirthDate).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();
            birthDate.Should().BeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_set_field_value_by_name_to_dbnull_before_update_assembly_event_when_override_is_false_have_no_affect(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateSqlStatementAssembly(context => context.SetFieldValue(nameof(dbo.Person.BirthDate), dbex.Null)));

            //when
            await db.Update(dbo.Person.BirthDate.Set(DateTime.Now)).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();

            //then
            var birthDate = await db.SelectOne(dbo.Person.BirthDate).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();
            birthDate.Should().NotBeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_set_enum_field_value_to_an_enum_before_update_assembly_event_when_override_is_true(int version, GenderType expected = GenderType.Male)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateSqlStatementAssembly(context => context.SetFieldValue(dbo.Person.GenderType, expected, true)));

            //when
            await db.Update(dbo.Person.GenderType.Set(GenderType.Female)).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();

            //then
            var gender = await db.SelectOne(dbo.Person.GenderType).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();
            gender.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_setting_enum_field_value_to_an_enum_before_update_assembly_event_when_override_is_false_have_no_affect(int version, GenderType expected = GenderType.Female)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateSqlStatementAssembly(context => context.SetFieldValue(dbo.Person.GenderType, GenderType.Male)));

            //when
            await db.Update(dbo.Person.GenderType.Set(expected)).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();

            //then
            var gender = await db.SelectOne(dbo.Person.GenderType).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();
            gender.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_set_nullable_enum_field_value_to_an_enum_before_update_assembly_event_when_override_is_true(int version) //this causes exception prior to test run: ", AddressType? expected = AddressType.Mailing)"
        {
            AddressType? expected = AddressType.Mailing;

            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateSqlStatementAssembly(context => context.SetFieldValue(dbo.Address.AddressType, expected, true)));

            //when
            await db.Update(dbo.Address.AddressType.Set(AddressType.Billing)).From(dbo.Address).Where(dbo.Address.Id == 1).ExecuteAsync();

            //then
            var addressType = await db.SelectOne(dbo.Address.AddressType).From(dbo.Address).Where(dbo.Address.Id == 1).ExecuteAsync();
            addressType.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_set_nullable_enum_field_value_to_an_enum_before_update_assembly_event_when_override_is_false_have_no_affect(int version) //this causes exception prior to test run: ", AddressType? expected = AddressType.Mailing)"
        {
            AddressType? expected = AddressType.Mailing;

            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateSqlStatementAssembly(context => context.SetFieldValue(dbo.Address.AddressType, AddressType.Billing)));

            //when
            await db.Update(dbo.Address.AddressType.Set(expected)).From(dbo.Address).Where(dbo.Address.Id == 1).ExecuteAsync();

            //then
            var addressType = await db.SelectOne(dbo.Address.AddressType).From(dbo.Address).Where(dbo.Address.Id == 1).ExecuteAsync();
            addressType.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_set_nullable_enum_field_value_to_a_null_before_update_assembly_event_when_override_is_true(int version, AddressType? expected = null)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateSqlStatementAssembly(context => context.SetFieldValue(dbo.Address.AddressType, expected, true)));

            //when
            await db.Update(dbo.Address.AddressType.Set(AddressType.Billing)).From(dbo.Address).Where(dbo.Address.Id == 1).ExecuteAsync();

            //then
            var addressType = await db.SelectOne(dbo.Address.AddressType).From(dbo.Address).Where(dbo.Address.Id == 1).ExecuteAsync();
            addressType.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_set_nullable_enum_field_value_to_a_null_before_update_assembly_event_when_override_is_false_have_no_affect(int version, AddressType? expected = null)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateSqlStatementAssembly(context => context.SetFieldValue(dbo.Address.AddressType, AddressType.Billing)));

            //when
            await db.Update(dbo.Address.AddressType.Set(expected)).From(dbo.Address).Where(dbo.Address.Id == 1).ExecuteAsync();

            //then
            var addressType = await db.SelectOne(dbo.Address.AddressType).From(dbo.Address).Where(dbo.Address.Id == 1).ExecuteAsync();
            addressType.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_set_nullable_enum_field_value_to_dbnull_before_update_assembly_event_when_override_is_true(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateSqlStatementAssembly(context => context.SetFieldValue(dbo.Address.AddressType, dbex.Null, true)));

            //when
            await db.Update(dbo.Address.AddressType.Set(AddressType.Billing)).From(dbo.Address).Where(dbo.Address.Id == 1).ExecuteAsync();

            //then
            var addressType = await db.SelectOne(dbo.Address.AddressType).From(dbo.Address).Where(dbo.Address.Id == 1).ExecuteAsync();
            addressType.Should().BeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_set_nullable_enum_field_value_to_dbnull_before_update_assembly_event_when_override_is_false_have_no_affect(int version, AddressType expected = AddressType.Billing)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateSqlStatementAssembly(context => context.SetFieldValue(dbo.Address.AddressType, dbex.Null)));

            //when
            await db.Update(dbo.Address.AddressType.Set(expected)).From(dbo.Address).Where(dbo.Address.Id == 1).ExecuteAsync();

            //then
            var addressType = await db.SelectOne(dbo.Address.AddressType).From(dbo.Address).Where(dbo.Address.Id == 1).ExecuteAsync();
            addressType.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_set_field_value_by_name_for_a_field_that_is_design_time_configured_to_not_allow_update(int version)
        {
            //given
            DateTime expected = DateTime.UtcNow.AddYears(-1);
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateSqlStatementAssembly(context => context.SetFieldValue(nameof(dbo.Person.DateCreated), expected)));

            //when
            await db.Update(dbo.Person.FirstName.Set("...")).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();

            //then
            var dateCreated = await db.SelectOne(dbo.Person.DateCreated).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();
            dateCreated.Year.Should().Be(expected.Year);
        }
    }
}

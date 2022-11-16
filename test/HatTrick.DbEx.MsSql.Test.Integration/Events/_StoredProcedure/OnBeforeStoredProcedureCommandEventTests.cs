using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration.Events
{
    public class OnBeforeStoredProcedureCommandEventTests : ResetDatabaseNotRequired
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_before_stored_procedure_command_event_fire_when_sync_action_configured_with_sync_execute_while_selecting_scalar_value(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeStoredProcedureCommand(_ => actionExecuted = true));

            //when
            int value = db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).GetValue<int>().Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_before_stored_procedure_command_event_fire_when_sync_action_configured_with_sync_execute_while_selecting_list_of_scalar_values(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeStoredProcedureCommand(_ => actionExecuted = true));

            //when
            IEnumerable<int> values = db.sp.dbo.SelectPersonId_As_ScalarValueList_With_Input(1).GetValues<int>().Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_before_stored_procedure_command_event_fire_when_sync_action_configured_with_sync_execute_while_selecting_dynamic_value(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeStoredProcedureCommand(_ => actionExecuted = true));

            //when
            dynamic? value = db.sp.dbo.SelectPerson_As_Dynamic_With_Input(1).GetValue().Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_before_stored_procedure_command_event_fire_when_sync_action_configured_with_sync_execute_while_selecting_list_of_dynamic_values(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeStoredProcedureCommand(_ => actionExecuted = true));

            //when
            IEnumerable<dynamic> values = db.sp.dbo.SelectPerson_As_DynamicList_With_Input(1).GetValues().Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_before_stored_procedure_command_event_fire_when_sync_action_configured_with_sync_execute_while_mapping_rowsets(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeStoredProcedureCommand(_ => actionExecuted = true));

            //when
            db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).MapValues(row => { }).Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_before_stored_procedure_command_event_fire_when_sync_action_configured_with_async_execute_while_selecting_scalar_value(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeStoredProcedureCommand(_ => actionExecuted = true));

            //when
            int value = await db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).GetValue<int>().ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_before_stored_procedure_command_event_fire_when_sync_action_configured_with_async_execute_while_selecting_list_of_scalar_values(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeStoredProcedureCommand(_ => actionExecuted = true));

            //when
            IEnumerable<int> values = await db.sp.dbo.SelectPersonId_As_ScalarValueList_With_Input(1).GetValues<int>().ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_before_stored_procedure_command_event_fire_when_sync_action_configured_with_async_execute_while_selecting_dynamic_value(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeStoredProcedureCommand(_ => actionExecuted = true));

            //when
            dynamic? value = await db.sp.dbo.SelectPerson_As_Dynamic_With_Input(1).GetValue().ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_before_stored_procedure_command_event_fire_when_sync_action_configured_with_async_execute_while_selecting_list_of_dynamic_values(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeStoredProcedureCommand(_ => actionExecuted = true));

            //when
            IEnumerable<dynamic> values = await db.sp.dbo.SelectPerson_As_DynamicList_With_Input(1).GetValues().ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_before_stored_procedure_command_event_fired_with_cancellation_of_token_source_with_async_execute_cancel_successfully(int version)
        {
            //given
            var source = new CancellationTokenSource();
            var token = source.Token;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeStoredProcedureCommand(_ => source.Cancel()));
            var task = db.sp.dbo.SelectPerson_As_DynamicList_With_Input(1).GetValues().ExecuteAsync(token);

            //when
            await Assert.ThrowsAsync<OperationCanceledException>(async () => await task);

            //then
            task.Status.Should().Be(TaskStatus.Canceled);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_before_stored_procedure_command_event_fire_when_sync_action_configured_with_async_execute_while_mapping_rowsets(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeStoredProcedureCommand(_ => actionExecuted = true));

            //when
            await db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).MapValues(row => { }).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }
    }
}

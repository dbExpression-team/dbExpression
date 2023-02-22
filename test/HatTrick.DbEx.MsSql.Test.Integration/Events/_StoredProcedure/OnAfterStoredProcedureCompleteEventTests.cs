using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration.Events
{
    public class OnAfterStoredProcedureCompleteEventTests : ResetDatabaseNotRequired
    {
        [Fact]
        public void Does_after_stored_procedure_complete_event_fire_when_sync_action_configured_with_sync_execute_while_stored_procedureing_entity()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterStoredProcedureComplete(_ => actionExecuted = true));

            //when
            db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).GetValue<int>().Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public void Does_after_stored_procedure_complete_event_fire_when_sync_action_configured_with_sync_execute_while_stored_procedureing_list_of_entities()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterStoredProcedureComplete(_ => actionExecuted = true));

            //when
            db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).GetValue<int>().Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [InlineData(5)]
        public void Does_after_stored_procedure_complete_event_fire_expected_number_of_times_when_sync_action_configured_with_sync_execute_while_stored_procedureing_entity(int expected)
        {
            //given
            var actionExecutedCount = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterStoredProcedureComplete(_ => actionExecutedCount++));

            //when
            for (var i = 0; i < expected; i++)
                db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).GetValue<int>().Execute();

            //then
            actionExecutedCount.Should().Be(expected);
        }

        [Fact]
        public void Does_after_stored_procedure_complete_event_fire_when_sync_action_and_passing_predicate_configured_with_sync_execute_while_stored_procedureing_entity()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterStoredProcedureComplete(_ => actionExecuted = true, p => true));

            //when
            db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).GetValue<int>().Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public void Does_after_stored_procedure_complete_event_not_fire_when_sync_action_and_failing_predicate_configured_with_sync_execute_while_stored_procedureing_entity()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterStoredProcedureComplete(_ => actionExecuted = true, p => false));

            //when
            db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).GetValue<int>().Execute();

            //then
            actionExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Does_after_stored_procedure_complete_event_fire_when_sync_action_configured_with_async_execute_while_stored_procedureing_entity()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterStoredProcedureComplete(_ => actionExecuted = true));

            //when
            await db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).GetValue<int>().ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Does_after_stored_procedure_complete_event_fire_when_sync_action_configured_with_async_execute_while_stored_procedureing_list_of_entities()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterStoredProcedureComplete(_ => actionExecuted = true));

            //when
            await db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).GetValue<int>().ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [InlineData(5)]
        public async Task Does_after_stored_procedure_complete_event_fire_expected_number_of_times_when_sync_action_configured_with_async_execute_while_stored_procedureing_entity(int expected)
        {
            //given
            var actionExecutedCount = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterStoredProcedureComplete(_ => actionExecutedCount++));

            //when
            for (var i = 0; i < expected; i++)
                await db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).GetValue<int>().ExecuteAsync();

            //then
            actionExecutedCount.Should().Be(expected);
        }

        [Fact]
        public async Task Does_after_stored_procedure_complete_event_fire_when_sync_action_and_passing_predicate_configured_with_async_execute_while_stored_procedureing_entity()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterStoredProcedureComplete(_ => actionExecuted = true, p => true));

            //when
            await db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).GetValue<int>().ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Does_after_stored_procedure_complete_event_not_fire_when_sync_action_configured_and_failing_predicate_configured_with_async_execute_while_stored_procedureing_entity()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterStoredProcedureComplete(_ => actionExecuted = true, p => false));

            //when
            await db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).GetValue<int>().ExecuteAsync();

            //then
            actionExecuted.Should().BeFalse();
        }

        [Fact]
        public Task Does_after_stored_procedure_complete_event_fire_when_async_action_configured_with_sync_execute_while_stored_procedureing_entity()
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterStoredProcedureComplete(async _ => { actionExecuted = true; await Task.Delay(1); }));

            //when
            db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).GetValue<int>().Execute();

            //then
            actionExecuted.Should().BeTrue();

            return Task.CompletedTask;
        }

        [Fact]
        public Task Does_after_stored_procedure_complete_event_fire_when_async_action_and_passing_predicate_configured_with_sync_execute_while_stored_procedureing_entity()
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterStoredProcedureComplete(async _ => { actionExecuted = true; await Task.Delay(1); }, p => true));

            //when
            db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).GetValue<int>().Execute();

            //then
            actionExecuted.Should().BeTrue();

            return Task.CompletedTask;
        }

        [Fact]
        public Task Does_after_stored_procedure_complete_event_not_fire_when_async_action_and_failing_predicate_configured_with_sync_execute_while_stored_procedureing_entity()
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterStoredProcedureComplete(async _ => { actionExecuted = true; await Task.Delay(1); }, p => false));

            //when
            db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).GetValue<int>().Execute();

            //then
            actionExecuted.Should().BeFalse();

            return Task.CompletedTask;
        }

        [Fact]
        public async Task Does_after_stored_procedure_complete_event_fire_when_async_action_configured_with_async_execute_while_stored_procedureing_entity()
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterStoredProcedureComplete(async _ => { actionExecuted = true; await Task.Delay(1); }));

            //when
            await db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).GetValue<int>().ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Does_after_stored_procedure_complete_event_fire_when_async_action_and_passing_predicate_configured_with_async_execute_while_stored_procedureing_entity()
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterStoredProcedureComplete(async _ => { actionExecuted = true; await Task.Delay(1); }, p => true));

            //when
            await db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).GetValue<int>().ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public void Does_after_stored_procedure_complete_event_throw_exception_when_fired_with_sync_action_configured_with_sync_execute_while_stored_procedureing_entity()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterStoredProcedureComplete(_ => throw new NotImplementedException()));

            //when & then
            Assert.Throws<DbExpressionEventException>(() => db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).GetValue<int>().Execute());
        }

        [Fact]
        public void Does_after_stored_procedure_complete_event_throw_exception_when_fired_with_sync_action_and_predicate_throwing_exception_configured_with_sync_execute_while_stored_procedureing_entity()
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterStoredProcedureComplete(_ => actionExecuted = true, _ => throw new NotImplementedException()));

            //when & then
            Assert.Throws<DbExpressionEventException>(() => db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).GetValue<int>().Execute());
            actionExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Can_after_stored_procedure_complete_event_fired_with_cancellation_of_token_source_with_async_execute_cancel_successfully()
        {
            //given
            var source = new CancellationTokenSource();
            var token = source.Token;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterStoredProcedureComplete(_ => source.Cancel()));
            var task = db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).GetValue<int>().ExecuteAsync(token);

            //when
            await Assert.ThrowsAsync<OperationCanceledException>(async () => await task);

            //then
            task.Status.Should().Be(TaskStatus.Canceled);
        }
    }
}

using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor.Events
{
    public class OnAfterInsertQueryExecutionEvent : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_after_insert_query_execution_event_fire_when_sync_action_configured_with_sync_execute_while_selecting_entity(int version)
        {
            //given
            var actionExecuted = false;
            ConfigureForMsSqlVersion(version, configure => configure.Events.OnAfterInsertQueryExecution(_ => actionExecuted = true));

            //when
            db.Insert(new Address { Line1 = "123 Main St", City = "Nowhere", State = "XX", Zip = "00000" }).Into(dbo.Address).Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_after_insert_query_execution_event_fire_when_sync_action_configured_with_sync_execute_while_selecting_list_of_entities(int version)
        {
            //given
            var actionExecuted = false;
            ConfigureForMsSqlVersion(version, configure => configure.Events.OnAfterInsertQueryExecution(_ => actionExecuted = true));

            //when
            db.Insert(new Address { Line1 = "123 Main St", City = "Nowhere", State = "XX", Zip = "00000" }).Into(dbo.Address).Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_after_insert_query_execution_event_fire_expected_number_of_times_when_sync_action_configured_with_sync_execute_while_selecting_entity(int version, int expected = 5)
        {
            //given
            var actionExecutedCount = 0;
            ConfigureForMsSqlVersion(version, configure => configure.Events.OnAfterInsertQueryExecution(_ => actionExecutedCount++));

            //when
            for (var i = 0; i < expected; i++)
                db.Insert(new Address { Line1 = "123 Main St", City = "Nowhere", State = "XX", Zip = "00000" }).Into(dbo.Address).Execute();

            //then
            actionExecutedCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_after_insert_query_execution_event_fire_when_sync_action_and_passing_predicate_configured_with_sync_execute_while_selecting_entity(int version)
        {
            //given
            var actionExecuted = false;
            ConfigureForMsSqlVersion(version, configure => configure.Events.OnAfterInsertQueryExecution(_ => actionExecuted = true, p => true));

            //when
            db.Insert(new Address { Line1 = "123 Main St", City = "Nowhere", State = "XX", Zip = "00000" }).Into(dbo.Address).Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_after_insert_query_execution_event_not_fire_when_sync_action_and_failing_predicate_configured_with_sync_execute_while_selecting_entity(int version)
        {
            //given
            var actionExecuted = false;
            ConfigureForMsSqlVersion(version, configure => configure.Events.OnAfterInsertQueryExecution(_ => actionExecuted = true, p => false));

            //when
            db.Insert(new Address { Line1 = "123 Main St", City = "Nowhere", State = "XX", Zip = "00000" }).Into(dbo.Address).Execute();

            //then
            actionExecuted.Should().BeFalse();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_after_insert_query_execution_event_fire_when_sync_action_configured_with_async_execute_while_selecting_entity(int version)
        {
            //given
            var actionExecuted = false;
            ConfigureForMsSqlVersion(version, configure => configure.Events.OnAfterInsertQueryExecution(_ => actionExecuted = true));

            //when
            await db.Insert(new Address { Line1 = "123 Main St", City = "Nowhere", State = "XX", Zip = "00000" }).Into(dbo.Address).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_after_insert_query_execution_event_fire_when_sync_action_configured_with_async_execute_while_selecting_list_of_entities(int version)
        {
            //given
            var actionExecuted = false;
            ConfigureForMsSqlVersion(version, configure => configure.Events.OnAfterInsertQueryExecution(_ => actionExecuted = true));

            //when
            await db.Insert(new Address { Line1 = "123 Main St", City = "Nowhere", State = "XX", Zip = "00000" }).Into(dbo.Address).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_after_insert_query_execution_event_fire_expected_number_of_times_when_sync_action_configured_with_async_execute_while_selecting_entity(int version, int expected = 5)
        {
            //given
            var actionExecutedCount = 0;
            ConfigureForMsSqlVersion(version, configure => configure.Events.OnAfterInsertQueryExecution(_ => actionExecutedCount++));

            //when
            for (var i = 0; i < expected; i++)
                await db.Insert(new Address { Line1 = "123 Main St", City = "Nowhere", State = "XX", Zip = "00000" }).Into(dbo.Address).ExecuteAsync();

            //then
            actionExecutedCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_after_insert_query_execution_event_fire_when_sync_action_and_passing_predicate_configured_with_async_execute_while_selecting_entity(int version)
        {
            //given
            var actionExecuted = false;
            ConfigureForMsSqlVersion(version, configure => configure.Events.OnAfterInsertQueryExecution(_ => actionExecuted = true, p => true));

            //when
            await db.Insert(new Address { Line1 = "123 Main St", City = "Nowhere", State = "XX", Zip = "00000" }).Into(dbo.Address).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_after_insert_query_execution_event_not_fire_when_sync_action_configured_and_failing_predicate_configured_with_async_execute_while_selecting_entity(int version)
        {
            //given
            var actionExecuted = false;
            ConfigureForMsSqlVersion(version, configure => configure.Events.OnAfterInsertQueryExecution(_ => actionExecuted = true, p => false));

            //when
            await db.Insert(new Address { Line1 = "123 Main St", City = "Nowhere", State = "XX", Zip = "00000" }).Into(dbo.Address).ExecuteAsync();

            //then
            actionExecuted.Should().BeFalse();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public Task Does_after_insert_query_execution_event_fire_when_async_action_configured_with_sync_execute_while_selecting_entity(int version)
        {
            //given
            bool actionExecuted = false;
            ConfigureForMsSqlVersion(version, configure => configure.Events.OnAfterInsertQueryExecution(async _ => await Task.Run(() => actionExecuted = true)));

            //when
            db.Insert(new Address { Line1 = "123 Main St", City = "Nowhere", State = "XX", Zip = "00000" }).Into(dbo.Address).Execute();

            //then
            actionExecuted.Should().BeTrue();

            return Task.CompletedTask;
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public Task Does_after_insert_query_execution_event_fire_when_async_action_and_passing_predicate_configured_with_sync_execute_while_selecting_entity(int version)
        {
            //given
            bool actionExecuted = false;
            ConfigureForMsSqlVersion(version, configure => configure.Events.OnAfterInsertQueryExecution(async _ => await Task.Run(() => actionExecuted = true), p => true));

            //when
            db.Insert(new Address { Line1 = "123 Main St", City = "Nowhere", State = "XX", Zip = "00000" }).Into(dbo.Address).Execute();

            //then
            actionExecuted.Should().BeTrue();

            return Task.CompletedTask;
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public Task Does_after_insert_query_execution_event_not_fire_when_async_action_and_failing_predicate_configured_with_sync_execute_while_selecting_entity(int version)
        {
            //given
            bool actionExecuted = false;
            ConfigureForMsSqlVersion(version, configure => configure.Events.OnAfterInsertQueryExecution(async _ => await Task.Run(() => actionExecuted = true), p => false));

            //when
            db.Insert(new Address { Line1 = "123 Main St", City = "Nowhere", State = "XX", Zip = "00000" }).Into(dbo.Address).Execute();

            //then
            actionExecuted.Should().BeFalse();

            return Task.CompletedTask;
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_after_insert_query_execution_event_fire_when_async_action_configured_with_async_execute_while_selecting_entity(int version)
        {
            //given
            bool actionExecuted = false;
            ConfigureForMsSqlVersion(version, configure => configure.Events.OnAfterInsertQueryExecution(async _ => await Task.Run(() => actionExecuted = true)));

            //when
            await db.Insert(new Address { Line1 = "123 Main St", City = "Nowhere", State = "XX", Zip = "00000" }).Into(dbo.Address).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_after_insert_query_execution_event_fire_when_async_action_and_passing_predicate_configured_with_async_execute_while_selecting_entity(int version)
        {
            //given
            bool actionExecuted = false;
            ConfigureForMsSqlVersion(version, configure => configure.Events.OnAfterInsertQueryExecution(async _ => await Task.Run(() => actionExecuted = true), p => true));

            //when
            await db.Insert(new Address { Line1 = "123 Main St", City = "Nowhere", State = "XX", Zip = "00000" }).Into(dbo.Address).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_after_insert_query_execution_event_throw_exception_when_fired_with_sync_action_configured_with_sync_execute_while_selecting_entity(int version)
        {
            //given
            ConfigureForMsSqlVersion(version, configure => configure.Events.OnAfterInsertQueryExecution(_ => throw new NotImplementedException()));

            //when & then
            Assert.Throws<NotImplementedException>(() => db.Insert(new Address { Line1 = "123 Main St", City = "Nowhere", State = "XX", Zip = "00000" }).Into(dbo.Address).Execute());
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_after_insert_query_execution_event_throw_exception_when_fired_with_sync_action_and_predicate_throwing_exception_configured_with_sync_execute_while_selecting_entity(int version)
        {
            //given
            bool actionExecuted = false;
            ConfigureForMsSqlVersion(version, configure => configure.Events.OnAfterInsertQueryExecution(_ => actionExecuted = true, _ => throw new NotImplementedException()));

            //when & then
            Assert.Throws<NotImplementedException>(() => db.Insert(new Address { Line1 = "123 Main St", City = "Nowhere", State = "XX", Zip = "00000" }).Into(dbo.Address).Execute());
            actionExecuted.Should().BeFalse();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_after_insert_query_execution_event_fired_with_cancellation_of_token_source_with_async_execute_cancel_successfully(int version)
        {
            //given
            var source = new CancellationTokenSource();
            var token = source.Token;
            ConfigureForMsSqlVersion(version, configure => configure.Events.OnAfterInsertQueryExecution(_ => source.Cancel()));
            var address = new Address { Line1 = "123 Main St", City = "Nowhere", State = "XX", Zip = "00000" };
            var task = db.Insert(address).Into(dbo.Address).ExecuteAsync(token);

            //when
            await Assert.ThrowsAsync<OperationCanceledException>(async () => await task);

            //then
            task.Status.Should().Be(TaskStatus.Canceled);
        }
    }
}

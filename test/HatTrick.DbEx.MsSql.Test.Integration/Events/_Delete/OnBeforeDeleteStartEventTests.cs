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
    public class OnBeforeDeleteStartEventTests : ResetDatabaseNotRequired
    {
        [Fact]
        public void Does_before_delete_start_event_fire_when_sync_action_configured_with_sync_execute_while_selecting_entity()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeDeleteStart(_ => actionExecuted = true));

            //when
            db.Delete().From(dbo.PersonAddress).Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public void Does_before_delete_start_event_fire_when_sync_action_configured_with_sync_execute_while_selecting_list_of_entities()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeDeleteStart(_ => actionExecuted = true));

            //when
            db.Delete().From(dbo.PersonAddress).Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [InlineData(5)]
        public void Does_before_delete_start_event_fire_expected_number_of_times_when_sync_action_configured_with_sync_execute_while_selecting_entity(int expected)
        {
            //given
            var actionExecutedCount = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeDeleteStart(_ => actionExecutedCount++));

            //when
            for (var i = 0; i < expected; i++)
                db.Delete().From(dbo.PersonAddress).Execute();

            //then
            actionExecutedCount.Should().Be(expected);
        }

        [Fact]
        public void Does_before_delete_start_event_fire_when_sync_action_and_passing_predicate_configured_with_sync_execute_while_selecting_entity()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeDeleteStart(_ => actionExecuted = true, p => true));

            //when
            db.Delete().From(dbo.PersonAddress).Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public void Does_before_delete_start_event_not_fire_when_sync_action_and_failing_predicate_configured_with_sync_execute_while_selecting_entity()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeDeleteStart(_ => actionExecuted = true, p => false));

            //when
            db.Delete().From(dbo.PersonAddress).Execute();

            //then
            actionExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Does_before_delete_start_event_fire_when_sync_action_configured_with_async_execute_while_selecting_entity()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeDeleteStart(_ => actionExecuted = true));

            //when
            await db.Delete().From(dbo.PersonAddress).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Does_before_delete_start_event_fire_when_sync_action_configured_with_async_execute_while_selecting_list_of_entities()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeDeleteStart(_ => actionExecuted = true));

            //when
            await db.Delete().From(dbo.PersonAddress).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [InlineData(5)]
        public async Task Does_before_delete_start_event_fire_expected_number_of_times_when_sync_action_configured_with_async_execute_while_selecting_entity(int expected)
        {
            //given
            var actionExecutedCount = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeDeleteStart(_ => actionExecutedCount++));

            //when
            for (var i = 0; i < expected; i++)
                await db.Delete().From(dbo.PersonAddress).ExecuteAsync();

            //then
            actionExecutedCount.Should().Be(expected);
        }

        [Fact]
        public async Task Does_before_delete_start_event_fire_when_sync_action_and_passing_predicate_configured_with_async_execute_while_selecting_entity()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeDeleteStart(_ => actionExecuted = true, p => true));

            //when
            await db.Delete().From(dbo.PersonAddress).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Does_before_delete_start_event_not_fire_when_sync_action_configured_and_failing_predicate_configured_with_async_execute_while_selecting_entity()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeDeleteStart(_ => actionExecuted = true, p => false));

            //when
            await db.Delete().From(dbo.PersonAddress).ExecuteAsync();

            //then
            actionExecuted.Should().BeFalse();
        }

        [Fact]
        public Task Does_before_delete_start_event_fire_when_async_action_configured_with_sync_execute_while_selecting_entity()
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeDeleteStart(async _ => { actionExecuted = true; await Task.Delay(1); }));

            //when
            db.Delete().From(dbo.PersonAddress).Execute();

            //then
            actionExecuted.Should().BeTrue();

            return Task.CompletedTask;
        }

        [Fact]
        public Task Does_before_delete_start_event_fire_when_async_action_and_passing_predicate_configured_with_sync_execute_while_selecting_entity()
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeDeleteStart(async _ => { actionExecuted = true; await Task.Delay(1); }, p => true));

            //when
            db.Delete().From(dbo.PersonAddress).Execute();

            //then
            actionExecuted.Should().BeTrue();

            return Task.CompletedTask;
        }

        [Fact]
        public Task Does_before_delete_start_event_not_fire_when_async_action_and_failing_predicate_configured_with_sync_execute_while_selecting_entity()
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeDeleteStart(async _ => { actionExecuted = true; await Task.Delay(1); }, p => false));

            //when
            db.Delete().From(dbo.PersonAddress).Execute();

            //then
            actionExecuted.Should().BeFalse();

            return Task.CompletedTask;
        }

        [Fact]
        public async Task Does_before_delete_start_event_fire_when_async_action_configured_with_async_execute_while_selecting_entity()
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeDeleteStart(async _ => { actionExecuted = true; await Task.Delay(1); }));

            //when
            await db.Delete().From(dbo.PersonAddress).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Does_before_delete_start_event_fire_when_async_action_and_passing_predicate_configured_with_async_execute_while_selecting_entity()
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeDeleteStart(async _ => { actionExecuted = true; await Task.Delay(1); }, p => true));

            //when
            await db.Delete().From(dbo.PersonAddress).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public void Does_before_delete_start_event_throw_exception_when_fired_with_sync_action_configured_with_sync_execute_while_selecting_entity()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeDeleteStart(_ => throw new NotImplementedException()));

            //when & then
            Assert.Throws<DbExpressionEventException>(() => db.Delete().From(dbo.PersonAddress).Execute());
        }

        [Fact]
        public void Does_before_delete_start_event_throw_exception_when_fired_with_sync_action_and_predicate_throwing_exception_configured_with_sync_execute_while_selecting_entity()
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeDeleteStart(_ => actionExecuted = true, _ => throw new NotImplementedException()));

            //when & then
            Assert.Throws<DbExpressionEventException>(() => db.Delete().From(dbo.PersonAddress).Execute());
            actionExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Can_before_delete_start_event_fired_with_cancellation_of_token_source_with_async_execute_cancel_successfully()
        {
            //given
            var source = new CancellationTokenSource();
            var token = source.Token;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeDeleteStart(_ => source.Cancel()));
            var task = db.Delete().From(dbo.PersonAddress).ExecuteAsync(token);

            //when
            await Assert.ThrowsAsync<OperationCanceledException>(async () => await task);

            //then
            task.AsTask().Status.Should().Be(TaskStatus.Canceled);
        }

        [Fact]
        public async Task Can_before_delete_start_event_fired_with_cancellation_of_token_source_with_async_execute_cancel_successfully_and_not_progress_in_pipeline()
        {
            //given
            var source = new CancellationTokenSource();
            var token = source.Token;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure =>
                configure.Events
                    .OnBeforeStart(_ => source.Cancel())
                    .OnBeforeDeleteStart(_ => throw new NotImplementedException())
            );
            var task = db.Delete().From(dbo.PersonAddress).ExecuteAsync(token);

            //when
            await Assert.ThrowsAsync<OperationCanceledException>(async () => await task);

            //then
            task.AsTask().Status.Should().Be(TaskStatus.Canceled);
        }
    }
}

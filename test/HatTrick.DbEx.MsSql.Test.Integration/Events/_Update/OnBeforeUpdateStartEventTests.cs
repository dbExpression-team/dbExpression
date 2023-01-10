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

namespace HatTrick.DbEx.MsSql.Test.Integration.Events
{
    public class OnBeforeUpdateStartEventTests : ResetDatabaseNotRequired
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_before_update_assembly_query_execution_event_fire_when_sync_action_configured_with_sync_execute_while_selecting_entity(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateStart(_ => actionExecuted = true));

            //when
            db.Update(dbo.Person.FirstName.Set("foo")).From(dbo.Person).Where(dbo.Person.Id == 0).Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_before_update_assembly_query_execution_event_fire_when_sync_action_configured_with_sync_execute_while_selecting_list_of_entities(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateStart(_ => actionExecuted = true));

            //when
            db.Update(dbo.Person.FirstName.Set("foo")).From(dbo.Person).Where(dbo.Person.Id == 0).Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_before_update_assembly_query_execution_event_fire_expected_number_of_times_when_sync_action_configured_with_sync_execute_while_selecting_entity(int version, int expected = 5)
        {
            //given
            var actionExecutedCount = 0;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateStart(_ => actionExecutedCount++));

            //when
            for (var i = 0; i < expected; i++)
                db.Update(dbo.Person.FirstName.Set("foo")).From(dbo.Person).Where(dbo.Person.Id == 0).Execute();

            //then
            actionExecutedCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_before_update_assembly_query_execution_event_fire_when_sync_action_and_passing_predicate_configured_with_sync_execute_while_selecting_entity(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateStart(_ => actionExecuted = true, p => true));

            //when
            db.Update(dbo.Person.FirstName.Set("foo")).From(dbo.Person).Where(dbo.Person.Id == 0).Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_before_update_assembly_query_execution_event_not_fire_when_sync_action_and_failing_predicate_configured_with_sync_execute_while_selecting_entity(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateStart(_ => actionExecuted = true, p => false));

            //when
            db.Update(dbo.Person.FirstName.Set("foo")).From(dbo.Person).Where(dbo.Person.Id == 0).Execute();

            //then
            actionExecuted.Should().BeFalse();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_before_update_assembly_query_execution_event_fire_when_sync_action_configured_with_async_execute_while_selecting_entity(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateStart(_ => actionExecuted = true));

            //when
            await db.Update(dbo.Person.FirstName.Set("foo")).From(dbo.Person).Where(dbo.Person.Id == 0).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_before_update_assembly_query_execution_event_fire_when_sync_action_configured_with_async_execute_while_selecting_list_of_entities(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateStart(_ => actionExecuted = true));

            //when
            await db.Update(dbo.Person.FirstName.Set("foo")).From(dbo.Person).Where(dbo.Person.Id == 0).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_before_update_assembly_query_execution_event_fire_expected_number_of_times_when_sync_action_configured_with_async_execute_while_selecting_entity(int version, int expected = 5)
        {
            //given
            var actionExecutedCount = 0;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateStart(_ => actionExecutedCount++));

            //when
            for (var i = 0; i < expected; i++)
                await db.Update(dbo.Person.FirstName.Set("foo")).From(dbo.Person).Where(dbo.Person.Id == 0).ExecuteAsync();

            //then
            actionExecutedCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_before_update_assembly_query_execution_event_fire_when_sync_action_and_passing_predicate_configured_with_async_execute_while_selecting_entity(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateStart(_ => actionExecuted = true, p => true));

            //when
            await db.Update(dbo.Person.FirstName.Set("foo")).From(dbo.Person).Where(dbo.Person.Id == 0).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_before_update_assembly_query_execution_event_not_fire_when_sync_action_configured_and_failing_predicate_configured_with_async_execute_while_selecting_entity(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateStart(_ => actionExecuted = true, p => false));

            //when
            await db.Update(dbo.Person.FirstName.Set("foo")).From(dbo.Person).Where(dbo.Person.Id == 0).ExecuteAsync();

            //then
            actionExecuted.Should().BeFalse();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public Task Does_before_update_assembly_query_execution_event_fire_when_async_action_configured_with_sync_execute_while_selecting_entity(int version)
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateStart(async _ => { actionExecuted = true; await Task.Delay(1); }));

            //when
            db.Update(dbo.Person.FirstName.Set("foo")).From(dbo.Person).Where(dbo.Person.Id == 0).Execute();

            //then
            actionExecuted.Should().BeTrue();

            return Task.CompletedTask;
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public Task Does_before_update_assembly_query_execution_event_fire_when_async_action_and_passing_predicate_configured_with_sync_execute_while_selecting_entity(int version)
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateStart(async _ => { actionExecuted = true; await Task.Delay(1); }, p => true));

            //when
            db.Update(dbo.Person.FirstName.Set("foo")).From(dbo.Person).Where(dbo.Person.Id == 0).Execute();

            //then
            actionExecuted.Should().BeTrue();

            return Task.CompletedTask;
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public Task Does_before_update_assembly_query_execution_event_not_fire_when_async_action_and_failing_predicate_configured_with_sync_execute_while_selecting_entity(int version)
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateStart(async _ => { actionExecuted = true; await Task.Delay(1); }, p => false));

            //when
            db.Update(dbo.Person.FirstName.Set("foo")).From(dbo.Person).Where(dbo.Person.Id == 0).Execute();

            //then
            actionExecuted.Should().BeFalse();

            return Task.CompletedTask;
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_before_update_assembly_query_execution_event_fire_when_async_action_configured_with_async_execute_while_selecting_entity(int version)
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateStart(async _ => { actionExecuted = true; await Task.Delay(1); }));

            //when
            await db.Update(dbo.Person.FirstName.Set("foo")).From(dbo.Person).Where(dbo.Person.Id == 0).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_before_update_assembly_query_execution_event_fire_when_async_action_and_passing_predicate_configured_with_async_execute_while_selecting_entity(int version)
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateStart(async _ => { actionExecuted = true; await Task.Delay(1); }, p => true));

            //when
            await db.Update(dbo.Person.FirstName.Set("foo")).From(dbo.Person).Where(dbo.Person.Id == 0).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_before_update_assembly_query_execution_event_throw_exception_when_fired_with_sync_action_configured_with_sync_execute_while_selecting_entity(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateStart(_ => throw new NotImplementedException()));

            //when & then
            Assert.Throws<NotImplementedException>(() => db.Update(dbo.Person.FirstName.Set("foo")).From(dbo.Person).Where(dbo.Person.Id == 0).Execute());
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_before_update_assembly_query_execution_event_throw_exception_when_fired_with_sync_action_and_predicate_throwing_exception_configured_with_sync_execute_while_selecting_entity(int version)
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateStart(_ => actionExecuted = true, _ => throw new NotImplementedException()));

            //when & then
            Assert.Throws<NotImplementedException>(() => db.Update(dbo.Person.FirstName.Set("foo")).From(dbo.Person).Where(dbo.Person.Id == 0).Execute());
            actionExecuted.Should().BeFalse();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_before_update_assembly_query_execution_event_fired_with_cancellation_of_token_source_with_async_execute_cancel_successfully(int version)
        {
            //given
            var source = new CancellationTokenSource();
            var token = source.Token;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeUpdateStart(_ => source.Cancel()));
            var task = db.Update(dbo.Person.FirstName.Set("foo")).From(dbo.Person).Where(dbo.Person.Id == 0).ExecuteAsync(token);

            //when
            await Assert.ThrowsAsync<OperationCanceledException>(async () => await task);

            //then
            task.AsTask().Status.Should().Be(TaskStatus.Canceled);
        }
    }
}

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
    public class OnBeforeSqlStatementExecutionEventTests : ResetDatabaseNotRequired
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_before_sql_statement_execution_event_fire_when_sync_action_configured_with_sync_execute_while_selecting_entity(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeSqlStatementExecution(_ => actionExecuted = true));

            //when
            db.SelectOne<Person>().From(dbo.Person).Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_before_sql_statement_execution_event_fire_when_sync_action_configured_with_sync_execute_while_selecting_list_of_entities(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeSqlStatementExecution(_ => actionExecuted = true));

            //when
            db.SelectMany<Person>().From(dbo.Person).Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_before_sql_statement_execution_event_fire_when_sync_action_configured_with_sync_execute_while_selecting_scalar_value(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeSqlStatementExecution(_ => actionExecuted = true));

            //when
            db.SelectOne(dbo.Person.Id).From(dbo.Person).Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_before_sql_statement_execution_event_fire_when_sync_action_configured_with_sync_execute_while_selecting_list_of_scalar_values(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeSqlStatementExecution(_ => actionExecuted = true));

            //when
            db.SelectMany(dbo.Person.Id).From(dbo.Person).Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_before_sql_statement_execution_event_fire_when_sync_action_configured_with_sync_execute_while_selecting_dynamic_value(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeSqlStatementExecution(_ => actionExecuted = true));

            //when
            db.SelectOne(dbo.Person.Id, dbo.Person.FirstName).From(dbo.Person).Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_before_sql_statement_execution_event_fire_when_sync_action_configured_with_sync_execute_while_selecting_list_of_dynamic_values(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeSqlStatementExecution(_ => actionExecuted = true));

            //when
            db.SelectMany(dbo.Person.Id, dbo.Person.FirstName).From(dbo.Person).Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_before_sql_statement_execution_event_fire_expected_number_of_times_when_sync_action_configured_with_sync_execute_while_selecting_entity(int version, int expected = 5)
        {
            //given
            var actionExecutedCount = 0;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeSqlStatementExecution(_ => actionExecutedCount++));

            //when
            for (var i = 0; i < expected; i++)
                db.SelectOne<Person>().From(dbo.Person).Execute();

            //then
            actionExecutedCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_before_sql_statement_execution_event_fire_when_sync_action_and_passing_predicate_configured_with_sync_execute_while_selecting_entity(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeSqlStatementExecution(_ => actionExecuted = true, p => true));

            //when
            db.SelectOne<Person>().From(dbo.Person).Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_before_sql_statement_execution_event_not_fire_when_sync_action_and_failing_predicate_configured_with_sync_execute_while_selecting_entity(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeSqlStatementExecution(_ => actionExecuted = true, p => false));

            //when
            db.SelectOne<Person>().From(dbo.Person).Execute();

            //then
            actionExecuted.Should().BeFalse();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_before_sql_statement_execution_event_fire_when_sync_action_configured_with_async_execute_while_selecting_entity(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeSqlStatementExecution(_ => actionExecuted = true));

            //when
            await db.SelectOne<Person>().From(dbo.Person).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_before_sql_statement_execution_event_fire_when_sync_action_configured_with_async_execute_while_selecting_list_of_entities(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeSqlStatementExecution(_ => actionExecuted = true));

            //when
            await db.SelectMany<Person>().From(dbo.Person).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_before_sql_statement_execution_event_fire_when_sync_action_configured_with_async_execute_while_selecting_scalar_value(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeSqlStatementExecution(_ => actionExecuted = true));

            //when
            await db.SelectOne(dbo.Person.Id).From(dbo.Person).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_before_sql_statement_execution_event_fire_when_sync_action_configured_with_async_execute_while_selecting_list_of_scalar_values(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeSqlStatementExecution(_ => actionExecuted = true));

            //when
            await db.SelectMany(dbo.Person.Id).From(dbo.Person).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_before_sql_statement_execution_event_fire_when_sync_action_configured_with_async_execute_while_selecting_dynamic_value(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeSqlStatementExecution(_ => actionExecuted = true));

            //when
            await db.SelectOne(dbo.Person.Id, dbo.Person.FirstName).From(dbo.Person).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_before_sql_statement_execution_event_fire_when_sync_action_configured_with_async_execute_while_selecting_list_of_dynamic_values(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeSqlStatementExecution(_ => actionExecuted = true));

            //when
            await db.SelectMany(dbo.Person.Id, dbo.Person.FirstName).From(dbo.Person).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_before_sql_statement_execution_event_fire_expected_number_of_times_when_sync_action_configured_with_async_execute_while_selecting_entity(int version, int expected = 5)
        {
            //given
            var actionExecutedCount = 0;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeSqlStatementExecution(_ => actionExecutedCount++));

            //when
            for (var i = 0; i < expected; i++)
                await db.SelectOne<Person>().From(dbo.Person).ExecuteAsync();

            //then
            actionExecutedCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_before_sql_statement_execution_event_fire_when_sync_action_and_passing_predicate_configured_with_async_execute_while_selecting_entity(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeSqlStatementExecution(_ => actionExecuted = true, p => true));

            //when
            await db.SelectOne<Person>().From(dbo.Person).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_before_sql_statement_execution_event_not_fire_when_sync_action_configured_and_failing_predicate_configured_with_async_execute_while_selecting_entity(int version)
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeSqlStatementExecution(_ => actionExecuted = true, p => false));

            //when
            await db.SelectOne<Person>().From(dbo.Person).ExecuteAsync();

            //then
            actionExecuted.Should().BeFalse();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public Task Does_before_sql_statement_execution_event_fire_when_async_action_configured_with_sync_execute_while_selecting_entity(int version)
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeSqlStatementExecution(async _ => await Task.Run(() => actionExecuted = true)));

            //when
            db.SelectOne<Person>().From(dbo.Person).Execute();

            //then
            actionExecuted.Should().BeTrue();

            return Task.CompletedTask;
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public Task Does_before_sql_statement_execution_event_fire_when_async_action_and_passing_predicate_configured_with_sync_execute_while_selecting_entity(int version)
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeSqlStatementExecution(async _ => await Task.Run(() => actionExecuted = true), p => true));

            //when
            db.SelectOne<Person>().From(dbo.Person).Execute();

            //then
            actionExecuted.Should().BeTrue();

            return Task.CompletedTask;
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public Task Does_before_sql_statement_execution_event_not_fire_when_async_action_and_failing_predicate_configured_with_sync_execute_while_selecting_entity(int version)
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeSqlStatementExecution(async _ => await Task.Run(() => actionExecuted = true), p => false));

            //when
            db.SelectOne<Person>().From(dbo.Person).Execute();

            //then
            actionExecuted.Should().BeFalse();

            return Task.CompletedTask;
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_before_sql_statement_execution_event_fire_when_async_action_configured_with_async_execute_while_selecting_entity(int version)
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeSqlStatementExecution(async _ => await Task.Run(() => actionExecuted = true)));

            //when
            await db.SelectOne<Person>().From(dbo.Person).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_before_sql_statement_execution_event_fire_when_async_action_and_passing_predicate_configured_with_async_execute_while_selecting_entity(int version)
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeSqlStatementExecution(async _ => await Task.Run(() => actionExecuted = true), p => true));

            //when
            await db.SelectOne<Person>().From(dbo.Person).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_before_sql_statement_execution_event_throw_exception_when_fired_with_sync_action_configured_with_sync_execute_while_selecting_entity(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeSqlStatementExecution(_ => throw new NotImplementedException()));

            //when & then
            Assert.Throws<NotImplementedException>(() => db.SelectOne<Person>().From(dbo.Person).Execute());
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_before_sql_statement_execution_event_throw_exception_when_fired_with_sync_action_and_predicate_throwing_exception_configured_with_sync_execute_while_selecting_entity(int version)
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeSqlStatementExecution(_ => actionExecuted = true, _ => throw new NotImplementedException()));

            //when & then
            Assert.Throws<NotImplementedException>(() => db.SelectOne<Person>().From(dbo.Person).Execute());
            actionExecuted.Should().BeFalse();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_before_sql_statement_execution_event_fired_with_cancellation_of_token_source_with_async_execute_cancel_successfully(int version)
        {
            //given
            var source = new CancellationTokenSource();
            var token = source.Token;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => configure.Events.OnBeforeSqlStatementExecution(_ => source.Cancel()));
            var task = db.SelectOne<Person>().From(dbo.Person).ExecuteAsync(token);

            //when
            await Assert.ThrowsAsync<OperationCanceledException>(async () => await task);

            //then
            task.Status.Should().Be(TaskStatus.Canceled);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_before_sql_statement_execution_event_fired_with_cancellation_of_token_source_with_async_execute_cancel_successfully_and_not_progress_in_pipeline(int version)
        {
            //given
            var source = new CancellationTokenSource();
            var token = source.Token;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure => 
                configure.Events
                    .OnBeforeSqlStatementExecution(_ => source.Cancel())
                    .OnAfterSqlStatementExecution(_ => throw new NotImplementedException())
            );
            var task = db.SelectOne<Person>().From(dbo.Person).ExecuteAsync(token);

            //when
            await Assert.ThrowsAsync<OperationCanceledException>(async () => await task);

            //then
            task.Status.Should().Be(TaskStatus.Canceled);
        }
    }
}

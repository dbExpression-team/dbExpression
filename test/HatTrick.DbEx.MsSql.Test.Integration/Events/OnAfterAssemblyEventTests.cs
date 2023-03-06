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
    public class OnAfterAssemblyEventTests : ResetDatabaseNotRequired
    {
        [Fact]
        public void Does_after_assembly_event_fire_when_sync_action_configured_with_sync_execute_while_selecting_entity()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterAssembly(_ => actionExecuted = true));

            //when
            db.SelectOne<Person>().From(dbo.Person).Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public void Does_after_assembly_event_fire_when_sync_action_configured_with_sync_execute_while_selecting_list_of_entities()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterAssembly(_ => actionExecuted = true));

            //when
            db.SelectMany<Person>().From(dbo.Person).Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public void Does_after_assembly_event_fire_when_sync_action_configured_with_sync_execute_while_selecting_scalar_value()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterAssembly(_ => actionExecuted = true));

            //when
            db.SelectOne(dbo.Person.Id).From(dbo.Person).Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public void Does_after_assembly_event_fire_when_sync_action_configured_with_sync_execute_while_selecting_list_of_scalar_values()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterAssembly(_ => actionExecuted = true));

            //when
            db.SelectMany(dbo.Person.Id).From(dbo.Person).Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public void Does_after_assembly_event_fire_when_sync_action_configured_with_sync_execute_while_selecting_dynamic_value()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterAssembly(_ => actionExecuted = true));

            //when
            db.SelectOne(dbo.Person.Id, dbo.Person.FirstName).From(dbo.Person).Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public void Does_after_assembly_event_fire_when_sync_action_configured_with_sync_execute_while_selecting_list_of_dynamic_values()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterAssembly(_ => actionExecuted = true));

            //when
            db.SelectMany(dbo.Person.Id, dbo.Person.FirstName).From(dbo.Person).Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [InlineData(5)]
        public void Does_after_assembly_event_fire_expected_number_of_times_when_sync_action_configured_with_sync_execute_while_selecting_entity(int expected)
        {
            //given
            var actionExecutedCount = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterAssembly(_ => actionExecutedCount++));

            //when
            for (var i = 0; i < expected; i++)
                db.SelectOne<Person>().From(dbo.Person).Execute();

            //then
            actionExecutedCount.Should().Be(expected);
        }

        [Fact]
        public void Does_after_assembly_event_fire_when_sync_action_and_passing_predicate_configured_with_sync_execute_while_selecting_entity()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterAssembly(_ => actionExecuted = true, p => true));

            //when
            db.SelectOne<Person>().From(dbo.Person).Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public void Does_after_assembly_event_not_fire_when_sync_action_and_failing_predicate_configured_with_sync_execute_while_selecting_entity()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterAssembly(_ => actionExecuted = true, p => false));

            //when
            db.SelectOne<Person>().From(dbo.Person).Execute();

            //then
            actionExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Does_after_assembly_event_fire_when_sync_action_configured_with_async_execute_while_selecting_entity()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterAssembly(_ => actionExecuted = true));

            //when
            await db.SelectOne<Person>().From(dbo.Person).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Does_after_assembly_event_fire_when_sync_action_configured_with_async_execute_while_selecting_list_of_entities()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterAssembly(_ => actionExecuted = true));

            //when
            await db.SelectMany<Person>().From(dbo.Person).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Does_after_assembly_event_fire_when_sync_action_configured_with_async_execute_while_selecting_scalar_value()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterAssembly(_ => actionExecuted = true));

            //when
            await db.SelectOne(dbo.Person.Id).From(dbo.Person).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Does_after_assembly_event_fire_when_sync_action_configured_with_async_execute_while_selecting_list_of_scalar_values()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterAssembly(_ => actionExecuted = true));

            //when
            await db.SelectMany(dbo.Person.Id).From(dbo.Person).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Does_after_assembly_event_fire_when_sync_action_configured_with_async_execute_while_selecting_dynamic_value()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterAssembly(_ => actionExecuted = true));

            //when
            await db.SelectOne(dbo.Person.Id, dbo.Person.FirstName).From(dbo.Person).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Does_after_assembly_event_fire_when_sync_action_configured_with_async_execute_while_selecting_list_of_dynamic_values()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterAssembly(_ => actionExecuted = true));

            //when
            await db.SelectMany(dbo.Person.Id, dbo.Person.FirstName).From(dbo.Person).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [InlineData(5)]
        public async Task Does_after_assembly_event_fire_expected_number_of_times_when_sync_action_configured_with_async_execute_while_selecting_entity(int expected)
        {
            //given
            var actionExecutedCount = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterAssembly(_ => actionExecutedCount++));

            //when
            for (var i = 0; i < expected; i++)
                await db.SelectOne<Person>().From(dbo.Person).ExecuteAsync();

            //then
            actionExecutedCount.Should().Be(expected);
        }

        [Fact]
        public async Task Does_after_assembly_event_fire_when_sync_action_and_passing_predicate_configured_with_async_execute_while_selecting_entity()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterAssembly(_ => actionExecuted = true, p => true));

            //when
            await db.SelectOne<Person>().From(dbo.Person).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Does_after_assembly_event_not_fire_when_sync_action_configured_and_failing_predicate_configured_with_async_execute_while_selecting_entity()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterAssembly(_ => actionExecuted = true, p => false));

            //when
            await db.SelectOne<Person>().From(dbo.Person).ExecuteAsync();

            //then
            actionExecuted.Should().BeFalse();
        }

        [Fact]
        public Task Does_after_assembly_event_fire_when_async_action_configured_with_sync_execute_while_selecting_entity()
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterAssembly(async _ => { actionExecuted = true; await Task.Delay(1); }));

            //when
            db.SelectOne<Person>().From(dbo.Person).Execute();

            //then
            actionExecuted.Should().BeTrue();

            return Task.CompletedTask;
        }

        [Fact]
        public Task Does_after_assembly_event_fire_when_async_action_and_passing_predicate_configured_with_sync_execute_while_selecting_entity()
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterAssembly(async _ => { actionExecuted = true; await Task.Delay(1); }, p => true));

            //when
            db.SelectOne<Person>().From(dbo.Person).Execute();

            //then
            actionExecuted.Should().BeTrue();

            return Task.CompletedTask;
        }

        [Fact]
        public Task Does_after_assembly_event_not_fire_when_async_action_and_failing_predicate_configured_with_sync_execute_while_selecting_entity()
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterAssembly(async _ => { actionExecuted = true; await Task.Delay(1); }, p => false));

            //when
            db.SelectOne<Person>().From(dbo.Person).Execute();

            //then
            actionExecuted.Should().BeFalse();

            return Task.CompletedTask;
        }

        [Fact]
        public async Task Does_after_assembly_event_fire_when_async_action_configured_with_async_execute_while_selecting_entity()
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterAssembly(async _ => { actionExecuted = true; await Task.Delay(1); }));

            //when
            await db.SelectOne<Person>().From(dbo.Person).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Does_after_assembly_event_fire_when_async_action_and_passing_predicate_configured_with_async_execute_while_selecting_entity()
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterAssembly(async _ => { actionExecuted = true; await Task.Delay(1); }, p => true));

            //when
            await db.SelectOne<Person>().From(dbo.Person).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public void Does_after_assembly_event_throw_exception_when_fired_with_sync_action_configured_with_sync_execute_while_selecting_entity()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterAssembly(_ => throw new NotImplementedException()));

            //when & then
            Assert.Throws<DbExpressionPipelineEventException>(() => db.SelectOne<Person>().From(dbo.Person).Execute());
        }

        [Fact]
        public void Does_after_assembly_event_throw_exception_when_fired_with_sync_action_and_predicate_throwing_exception_configured_with_sync_execute_while_selecting_entity()
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterAssembly(_ => actionExecuted = true, _ => throw new NotImplementedException()));

            //when & then
            Assert.Throws<DbExpressionPipelineEventException>(() => db.SelectOne<Person>().From(dbo.Person).Execute());
            actionExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Can_after_sql_statement_assembly_event_fired_with_cancellation_of_token_source_with_async_execute_cancel_successfully()
        {
            //given
            var source = new CancellationTokenSource();
            var token = source.Token;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnAfterAssembly(_ => source.Cancel()));
            var task = db.SelectOne<Person>().From(dbo.Person).ExecuteAsync(token);

            //when
            await Assert.ThrowsAsync<OperationCanceledException>(async () => await task);

            //then
            task.Status.Should().Be(TaskStatus.Canceled);
        }

        [Fact]
        public async Task Can_after_sql_statement_assembly_event_fired_with_cancellation_of_token_source_with_async_execute_cancel_successfully_and_not_progress_in_pipeline()
        {
            //given
            var source = new CancellationTokenSource();
            var token = source.Token;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure =>
                configure.Events
                    .OnAfterAssembly(_ => source.Cancel())
                    .OnBeforeCommand(async _ => { await Task.Delay(1); throw new NotImplementedException(); })
            );
            var task = db.SelectOne<Person>().From(dbo.Person).ExecuteAsync(token);

            //when
            await Assert.ThrowsAsync<OperationCanceledException>(async () => await task);

            //then
            task.Status.Should().Be(TaskStatus.Canceled);
        }
    }
}

using DbEx.Data;
using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DbExpression.MsSql.Test.Integration.Events
{
    public class OnBeforeInsertStartEventTests : ResetDatabaseAfterEveryTest
    {
        [Fact]
        public void Does_before_insert_start_event_fire_when_sync_action_configured_with_sync_execute_while_selecting_entity()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(_ => actionExecuted = true));
            var person = new Person { FirstName = "xxx", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow };

            //when
            db.Insert(person).Into(dbo.Person).Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public void Does_before_insert_start_event_fire_when_sync_action_configured_with_sync_execute_while_selecting_list_of_entities()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(_ => actionExecuted = true));
            var person = new Person { FirstName = "xxx", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow };

            //when
            db.Insert(person).Into(dbo.Person).Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [InlineData(5)]
        public void Does_before_insert_start_event_fire_expected_number_of_times_when_sync_action_configured_with_sync_execute_while_selecting_entity(int expected)
        {
            //given
            var actionExecutedCount = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(_ => actionExecutedCount++));

            //when
            for (var i = 0; i < expected; i++)
                db.Insert(new Person { FirstName = "xxx", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow }).Into(dbo.Person).Execute();

            //then
            actionExecutedCount.Should().Be(expected);
        }

        [Fact]
        public void Does_before_insert_start_event_fire_when_sync_action_and_passing_predicate_configured_with_sync_execute_while_selecting_entity()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(_ => actionExecuted = true, p => true));
            var person = new Person { FirstName = "xxx", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow };

            //when
            db.Insert(person).Into(dbo.Person).Execute();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public void Does_before_insert_start_event_not_fire_when_sync_action_and_failing_predicate_configured_with_sync_execute_while_selecting_entity()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(_ => actionExecuted = true, p => false));
            var person = new Person { FirstName = "xxx", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow };

            //when
            db.Insert(person).Into(dbo.Person).Execute();

            //then
            actionExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Does_before_insert_start_event_fire_when_sync_action_configured_with_async_execute_while_selecting_entity()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(_ => actionExecuted = true));
            var person = new Person { FirstName = "xxx", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow };

            //when
            await db.Insert(person).Into(dbo.Person).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Does_before_insert_start_event_fire_when_sync_action_configured_with_async_execute_while_selecting_list_of_entities()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(_ => actionExecuted = true));
            var person = new Person { FirstName = "xxx", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow };

            //when
            await db.Insert(person).Into(dbo.Person).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Theory]
        [InlineData(5)]
        public async Task Does_before_insert_start_event_fire_expected_number_of_times_when_sync_action_configured_with_async_execute_while_selecting_entity(int expected)
        {
            //given
            var actionExecutedCount = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(_ => actionExecutedCount++));

            //when
            for (var i = 0; i < expected; i++)
                await db.Insert(new Person { FirstName = "xxx", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow }).Into(dbo.Person).ExecuteAsync();

            //then
            actionExecutedCount.Should().Be(expected);
        }

        [Fact]
        public async Task Does_before_insert_start_event_fire_when_sync_action_and_passing_predicate_configured_with_async_execute_while_selecting_entity()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(_ => actionExecuted = true, p => true));
            var person = new Person { FirstName = "xxx", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow };

            //when
            await db.Insert(person).Into(dbo.Person).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Does_before_insert_start_event_not_fire_when_sync_action_configured_and_failing_predicate_configured_with_async_execute_while_selecting_entity()
        {
            //given
            var actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(_ => actionExecuted = true, p => false));
            var person = new Person { FirstName = "xxx", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow };

            //when
            await db.Insert(person).Into(dbo.Person).ExecuteAsync();

            //then
            actionExecuted.Should().BeFalse();
        }

        [Fact]
        public Task Does_before_insert_start_event_fire_when_async_action_configured_with_sync_execute_while_selecting_entity()
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(async _ => { actionExecuted = true; await Task.CompletedTask; }));
            var person = new Person { FirstName = "xxx", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow };

            //when
            db.Insert(person).Into(dbo.Person).Execute();

            //then
            actionExecuted.Should().BeTrue();

            return Task.CompletedTask;
        }

        [Fact]
        public Task Does_before_insert_start_event_fire_when_async_action_and_passing_predicate_configured_with_sync_execute_while_selecting_entity()
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(async _ => { actionExecuted = true; await Task.CompletedTask; }, p => true));
            var person = new Person { FirstName = "xxx", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow };

            //when
            db.Insert(person).Into(dbo.Person).Execute();

            //then
            actionExecuted.Should().BeTrue();

            return Task.CompletedTask;
        }

        [Fact]
        public Task Does_before_insert_start_event_not_fire_when_async_action_and_failing_predicate_configured_with_sync_execute_while_selecting_entity()
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(async _ => { actionExecuted = true; await Task.CompletedTask; }, p => false));
            var person = new Person { FirstName = "xxx", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow };

            //when
            db.Insert(person).Into(dbo.Person).Execute();

            //then
            actionExecuted.Should().BeFalse();

            return Task.CompletedTask;
        }

        [Fact]
        public async Task Does_before_insert_start_event_fire_when_async_action_configured_with_async_execute_while_selecting_entity()
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(async _ => { actionExecuted = true; await Task.CompletedTask; }));
            var person = new Person { FirstName = "xxx", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow };

            //when
            await db.Insert(person).Into(dbo.Person).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Does_before_insert_start_event_fire_when_async_action_and_passing_predicate_configured_with_async_execute_while_selecting_entity()
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(async _ => { actionExecuted = true; await Task.CompletedTask; }, p => true));
            var person = new Person { FirstName = "xxx", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow };

            //when
            await db.Insert(person).Into(dbo.Person).ExecuteAsync();

            //then
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public void Does_before_insert_start_event_throw_exception_when_fired_with_sync_action_configured_with_sync_execute_while_selecting_entity()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(_ => throw new NotImplementedException()));
            var person = new Person { FirstName = "xxx", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow };

            //when & then
            Assert.Throws<DbExpressionPipelineEventException>(() => db.Insert(person).Into(dbo.Person).Execute());
        }

        [Fact]
        public void Does_before_insert_start_event_throw_exception_when_fired_with_sync_action_and_predicate_throwing_exception_configured_with_sync_execute_while_selecting_entity()
        {
            //given
            bool actionExecuted = false;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure => configure.Events.OnBeforeInsertStart(_ => actionExecuted = true, _ => throw new NotImplementedException()));
            var person = new Person { FirstName = "xxx", LastName = "YYY", GenderType = GenderType.Female, RegistrationDate = DateTimeOffset.UtcNow };

            //when & then
            Assert.Throws<DbExpressionPipelineEventException>(() => db.Insert(person).Into(dbo.Person).Execute());
            actionExecuted.Should().BeFalse();
        }
    }
}

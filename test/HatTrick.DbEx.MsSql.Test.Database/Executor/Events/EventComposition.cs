using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.Sql;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor.Events
{
    public class EventComposition : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Do_all_pipeline_events_fire_when_selecting(int version, int expected = 6)
        {
            //given
            var executionCount = 0;
            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeSqlStatementAssembly(_ => executionCount++)
                        .OnAfterSqlStatementAssembly(_ => executionCount++)
                        .OnBeforeSelectQueryExecution(_ => executionCount++)
                        .OnBeforeSqlStatementExecution(_ => executionCount++)
                        .OnAfterSqlStatementExecution(_ => executionCount++)
                        .OnAfterSelectQueryExecution(_ => executionCount++)
                    );

            //when
            db.SelectOne(dbo.Person.Id).From(dbo.Person).Where(dbo.Person.Id == 1).Execute();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Do_all_pipeline_events_fire_when_selecting_and_event_confiugurations_are_repeated(int version, int expected = 12)
        {
            //given
            var executionCount = 0;
            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeSqlStatementAssembly(_ => executionCount++)
                        .OnBeforeSqlStatementAssembly(_ => executionCount++)

                        .OnAfterSqlStatementAssembly(_ => executionCount++)
                        .OnAfterSqlStatementAssembly(_ => executionCount++)

                        .OnBeforeSelectQueryExecution(_ => executionCount++)
                        .OnBeforeSelectQueryExecution(_ => executionCount++)

                        .OnBeforeSqlStatementExecution(_ => executionCount++)
                        .OnBeforeSqlStatementExecution(_ => executionCount++)

                        .OnAfterSqlStatementExecution(_ => executionCount++)
                        .OnAfterSqlStatementExecution(_ => executionCount++)

                        .OnAfterSelectQueryExecution(_ => executionCount++)
                        .OnAfterSelectQueryExecution(_ => executionCount++)
                    );

            //when
            db.SelectOne(dbo.Person.Id).From(dbo.Person).Where(dbo.Person.Id == 1).Execute();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Do_all_pipeline_events_fire_in_order_when_selecting(int version, string expected = "543210")
        {
            //given
            var execution = "";
            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeSqlStatementAssembly(_ => execution += "5")
                        .OnAfterSqlStatementAssembly(_ => execution += "4")
                        .OnBeforeSelectQueryExecution(_ => execution += "3")
                        .OnBeforeSqlStatementExecution(_ => execution += "2")
                        .OnAfterSqlStatementExecution(_ => execution += "1")
                        .OnAfterSelectQueryExecution(_ => execution += "0")
                    );

            //when
            db.SelectOne(dbo.Person.Id).From(dbo.Person).Where(dbo.Person.Id == 1).Execute();

            //then
            execution.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Do_all_pipeline_events_fire_when_selecting_async(int version, int expected = 6)
        {
            //given
            var executionCount = 0;
            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeSqlStatementAssembly(_ => executionCount++)
                        .OnAfterSqlStatementAssembly(_ => executionCount++)
                        .OnBeforeSelectQueryExecution(_ => executionCount++)
                        .OnBeforeSqlStatementExecution(_ => executionCount++)
                        .OnAfterSqlStatementExecution(_ => executionCount++)
                        .OnAfterSelectQueryExecution(_ => executionCount++)
                    );

            //when
            await db.SelectOne(dbo.Person.Id).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Do_all_pipeline_events_fire_when_selecting_async_and_event_configurations_are_repeated(int version, int expected = 12)
        {
            //given
            var executionCount = 0;
            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeSqlStatementAssembly(_ => executionCount++)
                        .OnBeforeSqlStatementAssembly(_ => executionCount++)

                        .OnAfterSqlStatementAssembly(_ => executionCount++)
                        .OnAfterSqlStatementAssembly(_ => executionCount++)

                        .OnBeforeSelectQueryExecution(_ => executionCount++)
                        .OnBeforeSelectQueryExecution(_ => executionCount++)

                        .OnBeforeSqlStatementExecution(_ => executionCount++)
                        .OnBeforeSqlStatementExecution(_ => executionCount++)

                        .OnAfterSqlStatementExecution(_ => executionCount++)
                        .OnAfterSqlStatementExecution(_ => executionCount++)

                        .OnAfterSelectQueryExecution(_ => executionCount++)
                        .OnAfterSelectQueryExecution(_ => executionCount++)
                    );

            //when
            await db.SelectOne(dbo.Person.Id).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Do_all_pipeline_events_fire_in_order_when_selecting_async(int version, string expected = "543210")
        {
            //given
            var execution = "";
            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeSqlStatementAssembly(_ => execution += "5")
                        .OnAfterSqlStatementAssembly(_ => execution += "4")
                        .OnBeforeSelectQueryExecution(_ => execution += "3")
                        .OnBeforeSqlStatementExecution(_ => execution += "2")
                        .OnAfterSqlStatementExecution(_ => execution += "1")
                        .OnAfterSelectQueryExecution(_ => execution += "0")
                    );

            //when
            await db.SelectOne(dbo.Person.Id).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();

            //then
            execution.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Do_all_pipeline_events_fire_when_inserting(int version, int expected = 7)
        {
            //given
            var executionCount = 0;
            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeSqlStatementAssembly(_ => executionCount++)
                        .OnBeforeInsertSqlStatementAssembly(_ => executionCount++)
                        .OnAfterSqlStatementAssembly(_ => executionCount++)
                        .OnBeforeInsertQueryExecution(_ => executionCount++)
                        .OnBeforeSqlStatementExecution(_ => executionCount++)
                        .OnAfterSqlStatementExecution(_ => executionCount++)
                        .OnAfterInsertQueryExecution(_ => executionCount++)
                    );

            //when
            db.Insert(new Address { Line1 = "123 Main St", City = "Nowhere", State = "XX", Zip = "00000" }).Into(dbo.Address).Execute();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Do_all_pipeline_events_fire_when_inserting_and_event_configurations_are_repeated(int version, int expected = 14)
        {
            //given
            var executionCount = 0;
            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeSqlStatementAssembly(_ => executionCount++)
                        .OnBeforeSqlStatementAssembly(_ => executionCount++)

                        .OnBeforeInsertSqlStatementAssembly(_ => executionCount++)
                        .OnBeforeInsertSqlStatementAssembly(_ => executionCount++)

                        .OnAfterSqlStatementAssembly(_ => executionCount++)
                        .OnAfterSqlStatementAssembly(_ => executionCount++)

                        .OnBeforeInsertQueryExecution(_ => executionCount++)
                        .OnBeforeInsertQueryExecution(_ => executionCount++)

                        .OnBeforeSqlStatementExecution(_ => executionCount++)
                        .OnBeforeSqlStatementExecution(_ => executionCount++)

                        .OnAfterSqlStatementExecution(_ => executionCount++)
                        .OnAfterSqlStatementExecution(_ => executionCount++)

                        .OnAfterInsertQueryExecution(_ => executionCount++)
                        .OnAfterInsertQueryExecution(_ => executionCount++)
                    );

            //when
            db.Insert(new Address { Line1 = "123 Main St", City = "Nowhere", State = "XX", Zip = "00000" }).Into(dbo.Address).Execute();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Do_all_pipeline_events_fire_in_order_when_inserting(int version, string expected = "6543210")
        {
            //given
            var execution = "";
            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeSqlStatementAssembly(_ => execution += "6")
                        .OnBeforeInsertSqlStatementAssembly(_ => execution += "5")
                        .OnAfterSqlStatementAssembly(_ => execution += "4")
                        .OnBeforeInsertQueryExecution(_ => execution += "3")
                        .OnBeforeSqlStatementExecution(_ => execution += "2")
                        .OnAfterSqlStatementExecution(_ => execution += "1")
                        .OnAfterInsertQueryExecution(_ => execution += "0")
                    );

            //when
            db.Insert(new Address { Line1 = "123 Main St", City = "Nowhere", State = "XX", Zip = "00000" }).Into(dbo.Address).Execute();

            //then
            execution.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Do_all_pipeline_events_fire_when_inserting_async(int version, int expected = 7)
        {
            //given
            var executionCount = 0;
            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeSqlStatementAssembly(_ => executionCount++)
                        .OnBeforeInsertSqlStatementAssembly(_ => executionCount++)
                        .OnAfterSqlStatementAssembly(_ => executionCount++)
                        .OnBeforeInsertQueryExecution(_ => executionCount++)
                        .OnBeforeSqlStatementExecution(_ => executionCount++)
                        .OnAfterSqlStatementExecution(_ => executionCount++)
                        .OnAfterInsertQueryExecution(_ => executionCount++)
                    );

            //when
            await db.Insert(new Address { Line1 = "123 Main St", City = "Nowhere", State = "XX", Zip = "00000" }).Into(dbo.Address).ExecuteAsync();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Do_all_pipeline_events_fire_when_inserting_and_event_configurations_are_repeated_async(int version, int expected = 14)
        {
            //given
            var executionCount = 0;
            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeSqlStatementAssembly(_ => executionCount++)
                        .OnBeforeSqlStatementAssembly(_ => executionCount++)

                        .OnBeforeInsertSqlStatementAssembly(_ => executionCount++)
                        .OnBeforeInsertSqlStatementAssembly(_ => executionCount++)

                        .OnAfterSqlStatementAssembly(_ => executionCount++)
                        .OnAfterSqlStatementAssembly(_ => executionCount++)

                        .OnBeforeInsertQueryExecution(_ => executionCount++)
                        .OnBeforeInsertQueryExecution(_ => executionCount++)

                        .OnBeforeSqlStatementExecution(_ => executionCount++)
                        .OnBeforeSqlStatementExecution(_ => executionCount++)

                        .OnAfterSqlStatementExecution(_ => executionCount++)
                        .OnAfterSqlStatementExecution(_ => executionCount++)

                        .OnAfterInsertQueryExecution(_ => executionCount++)
                        .OnAfterInsertQueryExecution(_ => executionCount++)
                    );

            //when
            await db.Insert(new Address { Line1 = "123 Main St", City = "Nowhere", State = "XX", Zip = "00000" }).Into(dbo.Address).ExecuteAsync();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Do_all_pipeline_events_fire_in_order_when_inserting_async(int version, string expected = "6543210")
        {
            //given
            var execution = "";
            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeSqlStatementAssembly(_ => execution += "6")
                        .OnBeforeInsertSqlStatementAssembly(_ => execution += "5")
                        .OnAfterSqlStatementAssembly(_ => execution += "4")
                        .OnBeforeInsertQueryExecution(_ => execution += "3")
                        .OnBeforeSqlStatementExecution(_ => execution += "2")
                        .OnAfterSqlStatementExecution(_ => execution += "1")
                        .OnAfterInsertQueryExecution(_ => execution += "0")
                    );

            //when
            await db.Insert(new Address { Line1 = "123 Main St", City = "Nowhere", State = "XX", Zip = "00000" }).Into(dbo.Address).ExecuteAsync();

            //then
            execution.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Do_all_pipeline_events_fire_when_updating(int version, int expected = 7)
        {
            //given
            var executionCount = 0;
            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeSqlStatementAssembly(_ => executionCount++)
                        .OnBeforeUpdateSqlStatementAssembly(_ => executionCount++)
                        .OnAfterSqlStatementAssembly(_ => executionCount++)
                        .OnBeforeUpdateQueryExecution(_ => executionCount++)
                        .OnBeforeSqlStatementExecution(_ => executionCount++)
                        .OnAfterSqlStatementExecution(_ => executionCount++)
                        .OnAfterUpdateQueryExecution(_ => executionCount++)
                    );

            //when
            db.Update(dbo.Person.FirstName.Set("foo")).Top(1).From(dbo.Person).Execute();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Do_all_pipeline_events_fire_when_updating_and_event_configurations_are_repeated(int version, int expected = 14)
        {
            //given
            var executionCount = 0;
            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeSqlStatementAssembly(_ => executionCount++)
                        .OnBeforeSqlStatementAssembly(_ => executionCount++)

                        .OnBeforeUpdateSqlStatementAssembly(_ => executionCount++)
                        .OnBeforeUpdateSqlStatementAssembly(_ => executionCount++)

                        .OnAfterSqlStatementAssembly(_ => executionCount++)
                        .OnAfterSqlStatementAssembly(_ => executionCount++)

                        .OnBeforeUpdateQueryExecution(_ => executionCount++)
                        .OnBeforeUpdateQueryExecution(_ => executionCount++)

                        .OnBeforeSqlStatementExecution(_ => executionCount++)
                        .OnBeforeSqlStatementExecution(_ => executionCount++)

                        .OnAfterSqlStatementExecution(_ => executionCount++)
                        .OnAfterSqlStatementExecution(_ => executionCount++)

                        .OnAfterUpdateQueryExecution(_ => executionCount++)
                        .OnAfterUpdateQueryExecution(_ => executionCount++)
                    );

            //when
            db.Update(dbo.Person.FirstName.Set("foo")).Top(1).From(dbo.Person).Execute();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Do_all_pipeline_events_fire_in_order_when_updating(int version, string expected = "6543210")
        {
            //given
            var execution = "";
            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeSqlStatementAssembly(_ => execution += "6")
                        .OnBeforeUpdateSqlStatementAssembly(_ => execution += "5")
                        .OnAfterSqlStatementAssembly(_ => execution += "4")
                        .OnBeforeUpdateQueryExecution(_ => execution += "3")
                        .OnBeforeSqlStatementExecution(_ => execution += "2")
                        .OnAfterSqlStatementExecution(_ => execution += "1")
                        .OnAfterUpdateQueryExecution(_ => execution += "0")
                    );

            //when
            db.Update(dbo.Person.FirstName.Set("foo")).Top(1).From(dbo.Person).Execute();

            //then
            execution.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Do_all_pipeline_events_fire_when_updating_async(int version, int expected = 7)
        {
            //given
            var executionCount = 0;
            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeSqlStatementAssembly(_ => executionCount++)
                        .OnBeforeUpdateSqlStatementAssembly(_ => executionCount++)
                        .OnAfterSqlStatementAssembly(_ => executionCount++)
                        .OnBeforeUpdateQueryExecution(_ => executionCount++)
                        .OnBeforeSqlStatementExecution(_ => executionCount++)
                        .OnAfterSqlStatementExecution(_ => executionCount++)
                        .OnAfterUpdateQueryExecution(_ => executionCount++)
                    );

            //when
            await db.Update(dbo.Person.FirstName.Set("foo")).Top(1).From(dbo.Person).ExecuteAsync();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Do_all_pipeline_events_fire_when_updating_and_event_configurations_are_repeated_async(int version, int expected = 14)
        {
            //given
            var executionCount = 0;
            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeSqlStatementAssembly(_ => executionCount++)
                        .OnBeforeSqlStatementAssembly(_ => executionCount++)

                        .OnBeforeUpdateSqlStatementAssembly(_ => executionCount++)
                        .OnBeforeUpdateSqlStatementAssembly(_ => executionCount++)

                        .OnAfterSqlStatementAssembly(_ => executionCount++)
                        .OnAfterSqlStatementAssembly(_ => executionCount++)

                        .OnBeforeUpdateQueryExecution(_ => executionCount++)
                        .OnBeforeUpdateQueryExecution(_ => executionCount++)

                        .OnBeforeSqlStatementExecution(_ => executionCount++)
                        .OnBeforeSqlStatementExecution(_ => executionCount++)

                        .OnAfterSqlStatementExecution(_ => executionCount++)
                        .OnAfterSqlStatementExecution(_ => executionCount++)

                        .OnAfterUpdateQueryExecution(_ => executionCount++)
                        .OnAfterUpdateQueryExecution(_ => executionCount++)
                    );

            //when
            await db.Update(dbo.Person.FirstName.Set("foo")).Top(1).From(dbo.Person).ExecuteAsync();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Do_all_pipeline_events_fire_in_order_when_updating_async(int version, string expected = "6543210")
        {
            //given
            var execution = "";
            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeSqlStatementAssembly(_ => execution += "6")
                        .OnBeforeUpdateSqlStatementAssembly(_ => execution += "5")
                        .OnAfterSqlStatementAssembly(_ => execution += "4")
                        .OnBeforeUpdateQueryExecution(_ => execution += "3")
                        .OnBeforeSqlStatementExecution(_ => execution += "2")
                        .OnAfterSqlStatementExecution(_ => execution += "1")
                        .OnAfterUpdateQueryExecution(_ => execution += "0")
                    );

            //when
            await db.Update(dbo.Person.FirstName.Set("foo")).Top(1).From(dbo.Person).ExecuteAsync();

            //then
            execution.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Do_all_pipeline_events_fire_when_deleting(int version, int expected = 6)
        {
            //given
            var executionCount = 0;
            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeSqlStatementAssembly(_ => executionCount++)
                        .OnAfterSqlStatementAssembly(_ => executionCount++)
                        .OnBeforeDeleteQueryExecution(_ => executionCount++)
                        .OnBeforeSqlStatementExecution(_ => executionCount++)
                        .OnAfterSqlStatementExecution(_ => executionCount++)
                        .OnAfterDeleteQueryExecution(_ => executionCount++)
                    );

            //when
            db.Delete().Top(1).From(dbo.PersonAddress).Execute();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Do_all_pipeline_events_fire_when_deleting_and_event_configurations_are_repeated(int version, int expected = 12)
        {
            //given
            var executionCount = 0;
            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeSqlStatementAssembly(_ => executionCount++)
                        .OnBeforeSqlStatementAssembly(_ => executionCount++)

                        .OnAfterSqlStatementAssembly(_ => executionCount++)
                        .OnAfterSqlStatementAssembly(_ => executionCount++)

                        .OnBeforeDeleteQueryExecution(_ => executionCount++)
                        .OnBeforeDeleteQueryExecution(_ => executionCount++)

                        .OnBeforeSqlStatementExecution(_ => executionCount++)
                        .OnBeforeSqlStatementExecution(_ => executionCount++)

                        .OnAfterSqlStatementExecution(_ => executionCount++)
                        .OnAfterSqlStatementExecution(_ => executionCount++)

                        .OnAfterDeleteQueryExecution(_ => executionCount++)
                        .OnAfterDeleteQueryExecution(_ => executionCount++)
                    );

            //when
            db.Delete().Top(1).From(dbo.PersonAddress).Execute();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Do_all_pipeline_events_fire_in_order_when_deleting(int version, string expected = "543210")
        {
            //given
            var execution = "";
            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeSqlStatementAssembly(_ => execution += "5")
                        .OnAfterSqlStatementAssembly(_ => execution += "4")
                        .OnBeforeDeleteQueryExecution(_ => execution += "3")
                        .OnBeforeSqlStatementExecution(_ => execution += "2")
                        .OnAfterSqlStatementExecution(_ => execution += "1")
                        .OnAfterDeleteQueryExecution(_ => execution += "0")
                    );

            //when
            db.Delete().Top(1).From(dbo.PersonAddress).Execute();

            //then
            execution.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Do_all_pipeline_events_fire_when_deleting_async(int version, int expected = 6)
        {
            //given
            var executionCount = 0;
            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeSqlStatementAssembly(_ => executionCount++)
                        .OnAfterSqlStatementAssembly(_ => executionCount++)
                        .OnBeforeDeleteQueryExecution(_ => executionCount++)
                        .OnBeforeSqlStatementExecution(_ => executionCount++)
                        .OnAfterSqlStatementExecution(_ => executionCount++)
                        .OnAfterDeleteQueryExecution(_ => executionCount++)
                    );

            //when
            await db.Delete().Top(1).From(dbo.PersonAddress).ExecuteAsync();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Do_all_pipeline_events_fire_when_deleting_and_event_configurations_are_repeated_async(int version, int expected = 12)
        {
            //given
            var executionCount = 0;
            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeSqlStatementAssembly(_ => executionCount++)
                        .OnBeforeSqlStatementAssembly(_ => executionCount++)

                        .OnAfterSqlStatementAssembly(_ => executionCount++)
                        .OnAfterSqlStatementAssembly(_ => executionCount++)

                        .OnBeforeDeleteQueryExecution(_ => executionCount++)
                        .OnBeforeDeleteQueryExecution(_ => executionCount++)

                        .OnBeforeSqlStatementExecution(_ => executionCount++)
                        .OnBeforeSqlStatementExecution(_ => executionCount++)

                        .OnAfterSqlStatementExecution(_ => executionCount++)
                        .OnAfterSqlStatementExecution(_ => executionCount++)

                        .OnAfterDeleteQueryExecution(_ => executionCount++)
                        .OnAfterDeleteQueryExecution(_ => executionCount++)
                    );

            //when
            await db.Delete().Top(1).From(dbo.PersonAddress).ExecuteAsync();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Do_all_pipeline_events_fire_in_order_when_deleting_async(int version, string expected = "543210")
        {
            //given
            var execution = "";
            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeSqlStatementAssembly(_ => execution += "5")
                        .OnAfterSqlStatementAssembly(_ => execution += "4")
                        .OnBeforeDeleteQueryExecution(_ => execution += "3")
                        .OnBeforeSqlStatementExecution(_ => execution += "2")
                        .OnAfterSqlStatementExecution(_ => execution += "1")
                        .OnAfterDeleteQueryExecution(_ => execution += "0")
                    );

            //when
            await db.Delete().Top(1).From(dbo.PersonAddress).ExecuteAsync();

            //then
            execution.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Do_expected_number_of_iterations_of_before_and_after_execution_events_fire(int version, int iterations = 10)
        {
            //given
            var before = 0;
            var after = 0;
            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events.OnBeforeSqlStatementExecution(_ => before++)
                        .OnAfterSqlStatementExecution(_ => after++));

            //when
            for (var i = 0; i < iterations; i++)
                db.SelectOne(dbo.Person.Id).From(dbo.Person).Where(dbo.Person.Id == 1).Execute();

            //then
            before.Should().Be(after);
            before.Should().Be(iterations);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Do_expected_number_of_iterations_of_before_and_after_execution_events_fire_and_cancel_when_execute_async(int version, int iterations = 10, int cancelOnIteration = 9)
        {
            //given
            var before = 0;
            var after = 0;
            var source = new CancellationTokenSource();
            var token = source.Token;

            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events.OnBeforeSqlStatementExecution(_ =>
                            {
                                if (before == cancelOnIteration)
                                    source.Cancel();
                                before++;
                            })
                        .OnAfterSqlStatementExecution(_ => after++));

            //when
            for (var i = 0; i < iterations; i++)
            {
                if (i == cancelOnIteration)
                    await Assert.ThrowsAsync<OperationCanceledException>(async () => await db.SelectOne(dbo.Person.Id).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync(token));
                else
                    await db.SelectOne(dbo.Person.Id).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync(token);
            }

            //then
            before.Should().Be(after + 1);
            after.Should().Be(cancelOnIteration);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Do_all_pipeline_events_fire_when_executing_stored_procedure(int version, int expected = 6)
        {
            //given
            var executionCount = 0;
            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeSqlStatementAssembly(_ => executionCount++)
                        .OnAfterSqlStatementAssembly(_ => executionCount++)
                        .OnBeforeStoredProcedureExecution(_ => executionCount++)
                        .OnBeforeSqlStatementExecution(_ => executionCount++)
                        .OnAfterSqlStatementExecution(_ => executionCount++)
                        .OnAfterStoredProcedureExecution(_ => executionCount++)
                    );

            //when
            db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).Execute();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Do_all_pipeline_events_fire_when_executing_stored_procedure_and_event_confiugurations_are_repeated(int version, int expected = 12)
        {
            //given
            var executionCount = 0;
            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeSqlStatementAssembly(_ => executionCount++)
                        .OnBeforeSqlStatementAssembly(_ => executionCount++)

                        .OnAfterSqlStatementAssembly(_ => executionCount++)
                        .OnAfterSqlStatementAssembly(_ => executionCount++)

                        .OnBeforeStoredProcedureExecution(_ => executionCount++)
                        .OnBeforeStoredProcedureExecution(_ => executionCount++)

                        .OnBeforeSqlStatementExecution(_ => executionCount++)
                        .OnBeforeSqlStatementExecution(_ => executionCount++)

                        .OnAfterSqlStatementExecution(_ => executionCount++)
                        .OnAfterSqlStatementExecution(_ => executionCount++)

                        .OnAfterStoredProcedureExecution(_ => executionCount++)
                        .OnAfterStoredProcedureExecution(_ => executionCount++)
                    );

            //when
            db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).Execute();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Do_all_pipeline_events_fire_in_order_when_executing_stored_procedure(int version, string expected = "543210")
        {
            //given
            var execution = "";
            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeSqlStatementAssembly(_ => execution += "5")
                        .OnAfterSqlStatementAssembly(_ => execution += "4")
                        .OnBeforeStoredProcedureExecution(_ => execution += "3")
                        .OnBeforeSqlStatementExecution(_ => execution += "2")
                        .OnAfterSqlStatementExecution(_ => execution += "1")
                        .OnAfterStoredProcedureExecution(_ => execution += "0")
                    );

            //when
            db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).Execute();

            //then
            execution.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Do_all_pipeline_events_fire_when_executing_stored_procedure_async(int version, int expected = 6)
        {
            //given
            var executionCount = 0;
            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeSqlStatementAssembly(_ => executionCount++)
                        .OnAfterSqlStatementAssembly(_ => executionCount++)
                        .OnBeforeStoredProcedureExecution(_ => executionCount++)
                        .OnBeforeSqlStatementExecution(_ => executionCount++)
                        .OnAfterSqlStatementExecution(_ => executionCount++)
                        .OnAfterStoredProcedureExecution(_ => executionCount++)
                    );

            //when
            await db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).ExecuteAsync();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Do_all_pipeline_events_fire_when_executing_stored_procedure_async_and_event_configurations_are_repeated(int version, int expected = 12)
        {
            //given
            var executionCount = 0;
            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeSqlStatementAssembly(_ => executionCount++)
                        .OnBeforeSqlStatementAssembly(_ => executionCount++)

                        .OnAfterSqlStatementAssembly(_ => executionCount++)
                        .OnAfterSqlStatementAssembly(_ => executionCount++)

                        .OnBeforeStoredProcedureExecution(_ => executionCount++)
                        .OnBeforeStoredProcedureExecution(_ => executionCount++)

                        .OnBeforeSqlStatementExecution(_ => executionCount++)
                        .OnBeforeSqlStatementExecution(_ => executionCount++)

                        .OnAfterSqlStatementExecution(_ => executionCount++)
                        .OnAfterSqlStatementExecution(_ => executionCount++)

                        .OnAfterStoredProcedureExecution(_ => executionCount++)
                        .OnAfterStoredProcedureExecution(_ => executionCount++)
                    );

            //when
            await db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).ExecuteAsync();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Do_all_pipeline_events_fire_in_order_when_executing_stored_procedure_async(int version, string expected = "543210")
        {
            //given
            var execution = "";
            var config = ConfigureForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeSqlStatementAssembly(_ => execution += "5")
                        .OnAfterSqlStatementAssembly(_ => execution += "4")
                        .OnBeforeStoredProcedureExecution(_ => execution += "3")
                        .OnBeforeSqlStatementExecution(_ => execution += "2")
                        .OnAfterSqlStatementExecution(_ => execution += "1")
                        .OnAfterStoredProcedureExecution(_ => execution += "0")
                    );

            //when
            await db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).ExecuteAsync();

            //then
            execution.Should().Be(expected);
        }
    }
}

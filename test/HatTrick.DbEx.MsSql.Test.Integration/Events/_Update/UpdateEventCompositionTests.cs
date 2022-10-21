using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration.Events
{
    public class UpdateEventCompositionTests : ResetDatabaseNotRequired
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Do_all_pipeline_events_fire_when_updating(int version, int expected = 10)
        {
            //given
            var executionCount = 0;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeStart(_ => executionCount++)
                        .OnBeforeUpdateStart(_ => executionCount++)
                        .OnAfterUpdateAssembly(_ => executionCount++)
                        .OnAfterAssembly(_ => executionCount++)
                        .OnBeforeCommand(_ => executionCount++)
                        .OnBeforeUpdateCommand(_ => executionCount++)
                        .OnAfterUpdateCommand(_ => executionCount++)
                        .OnAfterCommand(_ => executionCount++)
                        .OnAfterUpdateComplete(_ => executionCount++)
                        .OnAfterComplete(_ => executionCount++)
                    );

            //when
            db.Update(dbo.Person.FirstName.Set("foo")).From(dbo.Person).Where(dbo.Person.Id == 0).Execute();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Do_all_pipeline_events_fire_when_updating_and_event_confiugurations_are_repeated(int version, int expected = 20)
        {
            //given
            var executionCount = 0;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeStart(_ => executionCount++)
                        .OnBeforeStart(_ => executionCount++)

                        .OnBeforeUpdateStart(_ => executionCount++)
                        .OnBeforeUpdateStart(_ => executionCount++)

                        .OnAfterUpdateAssembly(_ => executionCount++)
                        .OnAfterUpdateAssembly(_ => executionCount++)

                        .OnAfterAssembly(_ => executionCount++)
                        .OnAfterAssembly(_ => executionCount++)

                        .OnBeforeCommand(_ => executionCount++)
                        .OnBeforeCommand(_ => executionCount++)

                        .OnBeforeUpdateCommand(_ => executionCount++)
                        .OnBeforeUpdateCommand(_ => executionCount++)

                        .OnAfterUpdateCommand(_ => executionCount++)
                        .OnAfterUpdateCommand(_ => executionCount++)

                        .OnAfterCommand(_ => executionCount++)
                        .OnAfterCommand(_ => executionCount++)

                        .OnAfterUpdateComplete(_ => executionCount++)
                        .OnAfterUpdateComplete(_ => executionCount++)

                        .OnAfterComplete(_ => executionCount++)
                        .OnAfterComplete(_ => executionCount++)
                    );

            //when
            db.Update(dbo.Person.FirstName.Set("foo")).From(dbo.Person).Where(dbo.Person.Id == 0).Execute();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Do_all_pipeline_events_fire_in_order_when_updating(int version, string expected = "9876543210")
        {
            //given
            var execution = "";
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeStart(_ => execution += "9")
                        .OnBeforeUpdateStart(_ => execution += "8")
                        .OnAfterUpdateAssembly(_ => execution += "7")
                        .OnAfterAssembly(_ => execution += "6")
                        .OnBeforeCommand(_ => execution += "5")
                        .OnBeforeUpdateCommand(_ => execution += "4")
                        .OnAfterUpdateCommand(_ => execution += "3")
                        .OnAfterCommand(_ => execution += "2")
                        .OnAfterUpdateComplete(_ => execution += "1")
                        .OnAfterComplete(_ => execution += "0")
                    );

            //when
            db.Update(dbo.Person.FirstName.Set("foo")).From(dbo.Person).Where(dbo.Person.Id == 0).Execute();

            //then
            execution.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Do_all_pipeline_events_fire_when_updating_and_predicate_is_met(int version, int expected = 10)
        {
            //given
            var executionCount = 0;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeStart(_ => executionCount++, c => c.Expression.IsUpdateQueryExpression())
                        .OnBeforeUpdateStart(_ => executionCount++, c => c.Expression.IsUpdateQueryExpression())
                        .OnAfterUpdateAssembly(_ => executionCount++, c => c.Expression.IsUpdateQueryExpression())
                        .OnAfterAssembly(_ => executionCount++, c => c.Expression.IsUpdateQueryExpression())
                        .OnBeforeCommand(_ => executionCount++, c => c.Expression.IsUpdateQueryExpression())
                        .OnBeforeUpdateCommand(_ => executionCount++, c => c.Expression.IsUpdateQueryExpression())
                        .OnAfterUpdateCommand(_ => executionCount++, c => c.Expression.IsUpdateQueryExpression())
                        .OnAfterCommand(_ => executionCount++, c => c.Expression.IsUpdateQueryExpression())
                        .OnAfterUpdateComplete(_ => executionCount++, c => c.Expression.IsUpdateQueryExpression())
                        .OnAfterComplete(_ => executionCount++, c => c.Expression.IsUpdateQueryExpression())
                    );

            //when
            db.Update(dbo.Person.FirstName.Set("foo")).From(dbo.Person).Where(dbo.Person.Id == 0).Execute();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Do_all_pipeline_events_fire_when_updating_async(int version, int expected = 10)
        {
            //given
            var executionCount = 0;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeStart(_ => executionCount++)
                        .OnBeforeUpdateStart(_ => executionCount++)
                        .OnAfterUpdateAssembly(_ => executionCount++)
                        .OnAfterAssembly(_ => executionCount++)
                        .OnBeforeCommand(_ => executionCount++)
                        .OnBeforeUpdateCommand(_ => executionCount++)
                        .OnAfterUpdateCommand(_ => executionCount++)
                        .OnAfterCommand(_ => executionCount++)
                        .OnAfterUpdateComplete(_ => executionCount++)
                        .OnAfterComplete(_ => executionCount++)
                    );

            //when
            await db.Update(dbo.Person.FirstName.Set("foo")).From(dbo.Person).Where(dbo.Person.Id == 0).ExecuteAsync();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Do_all_pipeline_events_fire_when_updating_async_and_event_configurations_are_repeated(int version, int expected = 20)
        {
            //given
            var executionCount = 0;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeStart(_ => executionCount++)
                        .OnBeforeStart(_ => executionCount++)

                        .OnBeforeUpdateStart(_ => executionCount++)
                        .OnBeforeUpdateStart(_ => executionCount++)

                        .OnAfterUpdateAssembly(_ => executionCount++)
                        .OnAfterUpdateAssembly(_ => executionCount++)

                        .OnAfterAssembly(_ => executionCount++)
                        .OnAfterAssembly(_ => executionCount++)

                        .OnBeforeCommand(_ => executionCount++)
                        .OnBeforeCommand(_ => executionCount++)

                        .OnBeforeUpdateCommand(_ => executionCount++)
                        .OnBeforeUpdateCommand(_ => executionCount++)

                        .OnAfterUpdateCommand(_ => executionCount++)
                        .OnAfterUpdateCommand(_ => executionCount++)

                        .OnAfterCommand(_ => executionCount++)
                        .OnAfterCommand(_ => executionCount++)

                        .OnAfterUpdateComplete(_ => executionCount++)
                        .OnAfterUpdateComplete(_ => executionCount++)

                        .OnAfterComplete(_ => executionCount++)
                        .OnAfterComplete(_ => executionCount++)
                    );

            //when
            await db.Update(dbo.Person.FirstName.Set("foo")).From(dbo.Person).Where(dbo.Person.Id == 0).ExecuteAsync();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Do_all_pipeline_events_fire_in_order_when_updating_async(int version, string expected = "9876543210")
        {
            //given
            var execution = "";
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeStart(_ => execution += "9")
                        .OnBeforeUpdateStart(_ => execution += "8")
                        .OnAfterUpdateAssembly(_ => execution += "7")
                        .OnAfterAssembly(_ => execution += "6")
                        .OnBeforeCommand(_ => execution += "5")
                        .OnBeforeUpdateCommand(_ => execution += "4")
                        .OnAfterUpdateCommand(_ => execution += "3")
                        .OnAfterCommand(_ => execution += "2")
                        .OnAfterUpdateComplete(_ => execution += "1")
                        .OnAfterComplete(_ => execution += "0")
                    );

            //when
            await db.Update(dbo.Person.FirstName.Set("foo")).From(dbo.Person).Where(dbo.Person.Id == 0).ExecuteAsync();

            //then
            execution.Should().Be(expected);
        }
    }
}

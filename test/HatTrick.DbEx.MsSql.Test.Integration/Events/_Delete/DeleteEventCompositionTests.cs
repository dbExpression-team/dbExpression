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
    public class DeleteEventCompositionTests : ResetDatabaseNotRequired
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Do_all_pipeline_events_fire_when_deleting(int version, int expected = 10)
        {
            //given
            var executionCount = 0;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeStart(_ => executionCount++)
                        .OnBeforeDeleteStart(_ => executionCount++)
                        .OnAfterDeleteAssembly(_ => executionCount++)
                        .OnAfterAssembly(_ => executionCount++)
                        .OnBeforeCommand(_ => executionCount++)
                        .OnBeforeDeleteCommand(_ => executionCount++)
                        .OnAfterDeleteCommand(_ => executionCount++)
                        .OnAfterCommand(_ => executionCount++)
                        .OnAfterDeleteComplete(_ => executionCount++)
                        .OnAfterComplete(_ => executionCount++)
                    );

            //when
            db.Delete().Top(1).From(dbo.PersonAddress).Where(dbo.PersonAddress.Id == 0).Execute();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Do_all_pipeline_events_fire_when_deleting_and_event_confiugurations_are_repeated(int version, int expected = 20)
        {
            //given
            var executionCount = 0;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeStart(_ => executionCount++)
                        .OnBeforeStart(_ => executionCount++)

                        .OnBeforeDeleteStart(_ => executionCount++)
                        .OnBeforeDeleteStart(_ => executionCount++)

                        .OnAfterDeleteAssembly(_ => executionCount++)
                        .OnAfterDeleteAssembly(_ => executionCount++)

                        .OnAfterAssembly(_ => executionCount++)
                        .OnAfterAssembly(_ => executionCount++)

                        .OnBeforeCommand(_ => executionCount++)
                        .OnBeforeCommand(_ => executionCount++)

                        .OnBeforeDeleteCommand(_ => executionCount++)
                        .OnBeforeDeleteCommand(_ => executionCount++)

                        .OnAfterDeleteCommand(_ => executionCount++)
                        .OnAfterDeleteCommand(_ => executionCount++)

                        .OnAfterCommand(_ => executionCount++)
                        .OnAfterCommand(_ => executionCount++)

                        .OnAfterDeleteComplete(_ => executionCount++)
                        .OnAfterDeleteComplete(_ => executionCount++)

                        .OnAfterComplete(_ => executionCount++)
                        .OnAfterComplete(_ => executionCount++)
                    );

            //when
            db.Delete().Top(1).From(dbo.PersonAddress).Where(dbo.PersonAddress.Id == 0).Execute();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Do_all_pipeline_events_fire_in_order_when_deleting(int version, string expected = "9876543210")
        {
            //given
            var execution = "";
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeStart(_ => execution += "9")
                        .OnBeforeDeleteStart(_ => execution += "8")
                        .OnAfterDeleteAssembly(_ => execution += "7")
                        .OnAfterAssembly(_ => execution += "6")
                        .OnBeforeCommand(_ => execution += "5")
                        .OnBeforeDeleteCommand(_ => execution += "4")
                        .OnAfterDeleteCommand(_ => execution += "3")
                        .OnAfterCommand(_ => execution += "2")
                        .OnAfterDeleteComplete(_ => execution += "1")
                        .OnAfterComplete(_ => execution += "0")
                    );

            //when
            db.Delete().Top(1).From(dbo.PersonAddress).Where(dbo.PersonAddress.Id == 0).Execute();

            //then
            execution.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Do_all_pipeline_events_fire_when_deleting_and_predicate_is_met(int version, int expected = 10)
        {
            //given
            var executionCount = 0;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeStart(_ => executionCount++, c => c.Expression.IsDeleteQueryExpression())
                        .OnBeforeDeleteStart(_ => executionCount++, c => c.Expression.IsDeleteQueryExpression())
                        .OnAfterDeleteAssembly(_ => executionCount++, c => c.Expression.IsDeleteQueryExpression())
                        .OnAfterAssembly(_ => executionCount++, c => c.Expression.IsDeleteQueryExpression())
                        .OnBeforeCommand(_ => executionCount++, c => c.Expression.IsDeleteQueryExpression())
                        .OnBeforeDeleteCommand(_ => executionCount++, c => c.Expression.IsDeleteQueryExpression())
                        .OnAfterDeleteCommand(_ => executionCount++, c => c.Expression.IsDeleteQueryExpression())
                        .OnAfterCommand(_ => executionCount++, c => c.Expression.IsDeleteQueryExpression())
                        .OnAfterDeleteComplete(_ => executionCount++, c => c.Expression.IsDeleteQueryExpression())
                        .OnAfterComplete(_ => executionCount++, c => c.Expression.IsDeleteQueryExpression())
                    );

            //when
            db.Delete().Top(1).From(dbo.PersonAddress).Where(dbo.PersonAddress.Id == 0).Execute();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Do_all_pipeline_events_fire_when_deleting_async(int version, int expected = 10)
        {
            //given
            var executionCount = 0;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeStart(_ => executionCount++)
                        .OnBeforeDeleteStart(_ => executionCount++)
                        .OnAfterDeleteAssembly(_ => executionCount++)
                        .OnAfterAssembly(_ => executionCount++)
                        .OnBeforeCommand(_ => executionCount++)
                        .OnBeforeDeleteCommand(_ => executionCount++)
                        .OnAfterDeleteCommand(_ => executionCount++)
                        .OnAfterCommand(_ => executionCount++)
                        .OnAfterDeleteComplete(_ => executionCount++)
                        .OnAfterComplete(_ => executionCount++)
                    );

            //when
            await db.Delete().Top(1).From(dbo.PersonAddress).Where(dbo.PersonAddress.Id == 0).ExecuteAsync();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Do_all_pipeline_events_fire_when_deleting_async_and_event_configurations_are_repeated(int version, int expected = 20)
        {
            //given
            var executionCount = 0;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeStart(_ => executionCount++)
                        .OnBeforeStart(_ => executionCount++)

                        .OnBeforeDeleteStart(_ => executionCount++)
                        .OnBeforeDeleteStart(_ => executionCount++)

                        .OnAfterDeleteAssembly(_ => executionCount++)
                        .OnAfterDeleteAssembly(_ => executionCount++)

                        .OnAfterAssembly(_ => executionCount++)
                        .OnAfterAssembly(_ => executionCount++)

                        .OnBeforeCommand(_ => executionCount++)
                        .OnBeforeCommand(_ => executionCount++)

                        .OnBeforeDeleteCommand(_ => executionCount++)
                        .OnBeforeDeleteCommand(_ => executionCount++)

                        .OnAfterDeleteCommand(_ => executionCount++)
                        .OnAfterDeleteCommand(_ => executionCount++)

                        .OnAfterCommand(_ => executionCount++)
                        .OnAfterCommand(_ => executionCount++)

                        .OnAfterDeleteComplete(_ => executionCount++)
                        .OnAfterDeleteComplete(_ => executionCount++)

                        .OnAfterComplete(_ => executionCount++)
                        .OnAfterComplete(_ => executionCount++)
                    );

            //when
            await db.Delete().Top(1).From(dbo.PersonAddress).Where(dbo.PersonAddress.Id == 0).ExecuteAsync();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Do_all_pipeline_events_fire_in_order_when_deleting_async(int version, string expected = "9876543210")
        {
            //given
            var execution = "";
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                    c => c.Events
                        .OnBeforeStart(_ => execution += "9")
                        .OnBeforeDeleteStart(_ => execution += "8")
                        .OnAfterDeleteAssembly(_ => execution += "7")
                        .OnAfterAssembly(_ => execution += "6")
                        .OnBeforeCommand(_ => execution += "5")
                        .OnBeforeDeleteCommand(_ => execution += "4")
                        .OnAfterDeleteCommand(_ => execution += "3")
                        .OnAfterCommand(_ => execution += "2")
                        .OnAfterDeleteComplete(_ => execution += "1")
                        .OnAfterComplete(_ => execution += "0")
                    );

            //when
            await db.Delete().Top(1).From(dbo.PersonAddress).Where(dbo.PersonAddress.Id == 0).ExecuteAsync();

            //then
            execution.Should().Be(expected);
        }
    }
}

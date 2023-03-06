using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
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
        [InlineData(10)]
        public void Do_all_pipeline_events_fire_when_updating(int expected)
        {
            //given
            var executionCount = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
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
        [InlineData(20)]
        public void Do_all_pipeline_events_fire_when_updating_and_event_confiugurations_are_repeated(int expected)
        {
            //given
            var executionCount = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
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
        [InlineData("9876543210")]
        public void Do_all_pipeline_events_fire_in_order_when_updating(string expected)
        {
            //given
            var execution = "";
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
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
        [InlineData(10)]
        public void Do_all_pipeline_events_fire_when_updating_and_predicate_is_met(int expected)
        {
            //given
            var executionCount = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
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
        [InlineData(10)]
        public async Task Do_all_pipeline_events_fire_when_updating_async(int expected)
        {
            //given
            var executionCount = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
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
        [InlineData(20)]
        public async Task Do_all_pipeline_events_fire_when_updating_async_and_event_configurations_are_repeated(int expected)
        {
            //given
            var executionCount = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
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
        [InlineData("9876543210")]
        public async Task Do_all_pipeline_events_fire_in_order_when_updating_async(string expected)
        {
            //given
            var execution = "";
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
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

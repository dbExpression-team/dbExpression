using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql.Expression;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DbExpression.MsSql.Test.Integration.Events
{
    public class SelectEventCompositionTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(10)]
        public void Do_all_pipeline_events_fire_when_selecting(int expected)
        {
            //given
            var executionCount = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                    c => c.Events
                        .OnBeforeStart(_ => executionCount++)
                        .OnBeforeSelectStart(_ => executionCount++)
                        .OnAfterSelectAssembly(_ => executionCount++)
                        .OnAfterAssembly(_ => executionCount++)
                        .OnBeforeCommand(_ => executionCount++)
                        .OnBeforeSelectCommand(_ => executionCount++)
                        .OnAfterSelectCommand(_ => executionCount++)
                        .OnAfterCommand(_ => executionCount++)
                        .OnAfterSelectComplete(_ => executionCount++)
                        .OnAfterComplete(_ => executionCount++)
                    );

            //when
            db.SelectOne(dbo.Person.Id).From(dbo.Person).Where(dbo.Person.Id == 1).Execute();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [InlineData(20)]
        public void Do_all_pipeline_events_fire_when_selecting_and_event_confiugurations_are_repeated(int expected)
        {
            //given
            var executionCount = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                    c => c.Events
                        .OnBeforeStart(_ => executionCount++)
                        .OnBeforeStart(_ => executionCount++)

                        .OnBeforeSelectStart(_ => executionCount++)
                        .OnBeforeSelectStart(_ => executionCount++)

                        .OnAfterSelectAssembly(_ => executionCount++)
                        .OnAfterSelectAssembly(_ => executionCount++)

                        .OnAfterAssembly(_ => executionCount++)
                        .OnAfterAssembly(_ => executionCount++)

                        .OnBeforeCommand(_ => executionCount++)
                        .OnBeforeCommand(_ => executionCount++)

                        .OnBeforeSelectCommand(_ => executionCount++)
                        .OnBeforeSelectCommand(_ => executionCount++)

                        .OnAfterSelectCommand(_ => executionCount++)
                        .OnAfterSelectCommand(_ => executionCount++)

                        .OnAfterCommand(_ => executionCount++)
                        .OnAfterCommand(_ => executionCount++)

                        .OnAfterSelectComplete(_ => executionCount++)
                        .OnAfterSelectComplete(_ => executionCount++)

                        .OnAfterComplete(_ => executionCount++)
                        .OnAfterComplete(_ => executionCount++)
                    );

            //when
            db.SelectOne(dbo.Person.Id).From(dbo.Person).Where(dbo.Person.Id == 1).Execute();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [InlineData("9876543210")]
        public void Do_all_pipeline_events_fire_in_order_when_selecting(string expected)
        {
            //given
            var execution = "";
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                    c => c.Events
                        .OnBeforeStart(_ => execution += "9")
                        .OnBeforeSelectStart(_ => execution += "8")
                        .OnAfterSelectAssembly(_ => execution += "7")
                        .OnAfterAssembly(_ => execution += "6")
                        .OnBeforeCommand(_ => execution += "5")
                        .OnBeforeSelectCommand(_ => execution += "4")
                        .OnAfterSelectCommand(_ => execution += "3")
                        .OnAfterCommand(_ => execution += "2")
                        .OnAfterSelectComplete(_ => execution += "1")
                        .OnAfterComplete(_ => execution += "0")
                    );

            //when
            db.SelectOne(dbo.Person.Id).From(dbo.Person).Where(dbo.Person.Id == 1).Execute();

            //then
            execution.Should().Be(expected);
        }

        [Theory]
        [InlineData(10)]
        public void Do_all_pipeline_events_fire_when_selecting_and_predicate_is_met(int expected)
        {
            //given
            var executionCount = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                    c => c.Events
                        .OnBeforeStart(_ => executionCount++, c => c.Expression.IsSelectQueryExpression())
                        .OnBeforeSelectStart(_ => executionCount++, c => c.Expression.IsSelectQueryExpression())
                        .OnAfterSelectAssembly(_ => executionCount++, c => c.Expression.IsSelectQueryExpression())
                        .OnAfterAssembly(_ => executionCount++, c => c.Expression.IsSelectQueryExpression())
                        .OnBeforeCommand(_ => executionCount++, c => c.Expression.IsSelectQueryExpression())
                        .OnBeforeSelectCommand(_ => executionCount++, c => c.Expression.IsSelectQueryExpression())
                        .OnAfterSelectCommand(_ => executionCount++, c => c.Expression.IsSelectQueryExpression())
                        .OnAfterCommand(_ => executionCount++, c => c.Expression.IsSelectQueryExpression())
                        .OnAfterSelectComplete(_ => executionCount++, c => c.Expression.IsSelectQueryExpression())
                        .OnAfterComplete(_ => executionCount++, c => c.Expression.IsSelectQueryExpression())
                    );

            //when
            db.SelectOne(dbo.Person.Id).From(dbo.Person).Where(dbo.Person.Id == 1).Execute();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [InlineData(10)]
        public async Task Do_all_pipeline_events_fire_when_selecting_async(int expected)
        {
            //given
            var executionCount = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                    c => c.Events
                        .OnBeforeStart(_ => executionCount++)
                        .OnBeforeSelectStart(_ => executionCount++)
                        .OnAfterSelectAssembly(_ => executionCount++)
                        .OnAfterAssembly(_ => executionCount++)
                        .OnBeforeCommand(_ => executionCount++)
                        .OnBeforeSelectCommand(_ => executionCount++)
                        .OnAfterSelectCommand(_ => executionCount++)
                        .OnAfterCommand(_ => executionCount++)
                        .OnAfterSelectComplete(_ => executionCount++)
                        .OnAfterComplete(_ => executionCount++)
                    );

            //when
            await db.SelectOne(dbo.Person.Id).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [InlineData(20)]
        public async Task Do_all_pipeline_events_fire_when_selecting_async_and_event_configurations_are_repeated(int expected)
        {
            //given
            var executionCount = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                    c => c.Events
                        .OnBeforeStart(_ => executionCount++)
                        .OnBeforeStart(_ => executionCount++)

                        .OnBeforeSelectStart(_ => executionCount++)
                        .OnBeforeSelectStart(_ => executionCount++)

                        .OnAfterSelectAssembly(_ => executionCount++)
                        .OnAfterSelectAssembly(_ => executionCount++)

                        .OnAfterAssembly(_ => executionCount++)
                        .OnAfterAssembly(_ => executionCount++)

                        .OnBeforeCommand(_ => executionCount++)
                        .OnBeforeCommand(_ => executionCount++)

                        .OnBeforeSelectCommand(_ => executionCount++)
                        .OnBeforeSelectCommand(_ => executionCount++)

                        .OnAfterSelectCommand(_ => executionCount++)
                        .OnAfterSelectCommand(_ => executionCount++)

                        .OnAfterCommand(_ => executionCount++)
                        .OnAfterCommand(_ => executionCount++)

                        .OnAfterSelectComplete(_ => executionCount++)
                        .OnAfterSelectComplete(_ => executionCount++)

                        .OnAfterComplete(_ => executionCount++)
                        .OnAfterComplete(_ => executionCount++)
                    );

            //when
            await db.SelectOne(dbo.Person.Id).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [InlineData("9876543210")]
        public async Task Do_all_pipeline_events_fire_in_order_when_selecting_async(string expected)
        {
            //given
            var execution = "";
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                    c => c.Events
                        .OnBeforeStart(_ => execution += "9")
                        .OnBeforeSelectStart(_ => execution += "8")
                        .OnAfterSelectAssembly(_ => execution += "7")
                        .OnAfterAssembly(_ => execution += "6")
                        .OnBeforeCommand(_ => execution += "5")
                        .OnBeforeSelectCommand(_ => execution += "4")
                        .OnAfterSelectCommand(_ => execution += "3")
                        .OnAfterCommand(_ => execution += "2")
                        .OnAfterSelectComplete(_ => execution += "1")
                        .OnAfterComplete(_ => execution += "0")
                    );

            //when
            await db.SelectOne(dbo.Person.Id).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();

            //then
            execution.Should().Be(expected);
        }
    }
}

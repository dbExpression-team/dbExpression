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
    public class InsertEventCompositionTests : ResetDatabaseAfterEveryTest
    {
        [Theory]
        [InlineData(10)]
        public void Do_all_pipeline_events_fire_when_inserting(int expected)
        {
            //given
            var executionCount = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                    c => c.Events
                        .OnBeforeStart(_ => executionCount++)
                        .OnBeforeInsertStart(_ => executionCount++)
                        .OnAfterInsertAssembly(_ => executionCount++)
                        .OnAfterAssembly(_ => executionCount++)
                        .OnBeforeCommand(_ => executionCount++)
                        .OnBeforeInsertCommand(_ => executionCount++)
                        .OnAfterInsertCommand(_ => executionCount++)
                        .OnAfterCommand(_ => executionCount++)
                        .OnAfterInsertComplete(_ => executionCount++)
                        .OnAfterComplete(_ => executionCount++)
                    );

            //when
            db.Insert(new Address { Line1 = "123 Main St", City = "Nowhere", State = "XX", Zip = "00000" }).Into(dbo.Address).Execute();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [InlineData(20)]
        public void Do_all_pipeline_events_fire_when_inserting_and_event_confiugurations_are_repeated(int expected)
        {
            //given
            var executionCount = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                    c => c.Events
                        .OnBeforeStart(_ => executionCount++)
                        .OnBeforeStart(_ => executionCount++)

                        .OnBeforeInsertStart(_ => executionCount++)
                        .OnBeforeInsertStart(_ => executionCount++)

                        .OnAfterInsertAssembly(_ => executionCount++)
                        .OnAfterInsertAssembly(_ => executionCount++)

                        .OnAfterAssembly(_ => executionCount++)
                        .OnAfterAssembly(_ => executionCount++)

                        .OnBeforeCommand(_ => executionCount++)
                        .OnBeforeCommand(_ => executionCount++)

                        .OnBeforeInsertCommand(_ => executionCount++)
                        .OnBeforeInsertCommand(_ => executionCount++)

                        .OnAfterInsertCommand(_ => executionCount++)
                        .OnAfterInsertCommand(_ => executionCount++)

                        .OnAfterCommand(_ => executionCount++)
                        .OnAfterCommand(_ => executionCount++)

                        .OnAfterInsertComplete(_ => executionCount++)
                        .OnAfterInsertComplete(_ => executionCount++)

                        .OnAfterComplete(_ => executionCount++)
                        .OnAfterComplete(_ => executionCount++)
                    );

            //when
            db.Insert(new Address { Line1 = "123 Main St", City = "Nowhere", State = "XX", Zip = "00000" }).Into(dbo.Address).Execute();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [InlineData("9876543210")]
        public void Do_all_pipeline_events_fire_in_order_when_inserting(string expected)
        {
            //given
            var execution = "";
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                    c => c.Events
                        .OnBeforeStart(_ => execution += "9")
                        .OnBeforeInsertStart(_ => execution += "8")
                        .OnAfterInsertAssembly(_ => execution += "7")
                        .OnAfterAssembly(_ => execution += "6")
                        .OnBeforeCommand(_ => execution += "5")
                        .OnBeforeInsertCommand(_ => execution += "4")
                        .OnAfterInsertCommand(_ => execution += "3")
                        .OnAfterCommand(_ => execution += "2")
                        .OnAfterInsertComplete(_ => execution += "1")
                        .OnAfterComplete(_ => execution += "0")
                    );

            //when
            db.Insert(new Address { Line1 = "123 Main St", City = "Nowhere", State = "XX", Zip = "00000" }).Into(dbo.Address).Execute();

            //then
            execution.Should().Be(expected);
        }

        [Theory]
        [InlineData(10)]
        public void Do_all_pipeline_events_fire_when_inserting_and_predicate_is_met(int expected)
        {
            //given
            var executionCount = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                    c => c.Events
                        .OnBeforeStart(_ => executionCount++, c => c.Expression.IsInsertQueryExpression())
                        .OnBeforeInsertStart(_ => executionCount++, c => c.Expression.IsInsertQueryExpression())
                        .OnAfterInsertAssembly(_ => executionCount++, c => c.Expression.IsInsertQueryExpression())
                        .OnAfterAssembly(_ => executionCount++, c => c.Expression.IsInsertQueryExpression())
                        .OnBeforeCommand(_ => executionCount++, c => c.Expression.IsInsertQueryExpression())
                        .OnBeforeInsertCommand(_ => executionCount++, c => c.Expression.IsInsertQueryExpression())
                        .OnAfterInsertCommand(_ => executionCount++, c => c.Expression.IsInsertQueryExpression())
                        .OnAfterCommand(_ => executionCount++, c => c.Expression.IsInsertQueryExpression())
                        .OnAfterInsertComplete(_ => executionCount++, c => c.Expression.IsInsertQueryExpression())
                        .OnAfterComplete(_ => executionCount++, c => c.Expression.IsInsertQueryExpression())
                    );

            //when
            db.Insert(new Address { Line1 = "123 Main St", City = "Nowhere", State = "XX", Zip = "00000" }).Into(dbo.Address).Execute();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [InlineData(10)]
        public async Task Do_all_pipeline_events_fire_when_inserting_async(int expected)
        {
            //given
            var executionCount = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                    c => c.Events
                        .OnBeforeStart(_ => executionCount++)
                        .OnBeforeInsertStart(_ => executionCount++)
                        .OnAfterInsertAssembly(_ => executionCount++)
                        .OnAfterAssembly(_ => executionCount++)
                        .OnBeforeCommand(_ => executionCount++)
                        .OnBeforeInsertCommand(_ => executionCount++)
                        .OnAfterInsertCommand(_ => executionCount++)
                        .OnAfterCommand(_ => executionCount++)
                        .OnAfterInsertComplete(_ => executionCount++)
                        .OnAfterComplete(_ => executionCount++)
                    );

            //when
            await db.Insert(new Address { Line1 = "123 Main St", City = "Nowhere", State = "XX", Zip = "00000" }).Into(dbo.Address).ExecuteAsync();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [InlineData(20)]
        public async Task Do_all_pipeline_events_fire_when_inserting_async_and_event_configurations_are_repeated(int expected)
        {
            //given
            var executionCount = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                    c => c.Events
                        .OnBeforeStart(_ => executionCount++)
                        .OnBeforeStart(_ => executionCount++)

                        .OnBeforeInsertStart(_ => executionCount++)
                        .OnBeforeInsertStart(_ => executionCount++)

                        .OnAfterInsertAssembly(_ => executionCount++)
                        .OnAfterInsertAssembly(_ => executionCount++)

                        .OnAfterAssembly(_ => executionCount++)
                        .OnAfterAssembly(_ => executionCount++)

                        .OnBeforeCommand(_ => executionCount++)
                        .OnBeforeCommand(_ => executionCount++)

                        .OnBeforeInsertCommand(_ => executionCount++)
                        .OnBeforeInsertCommand(_ => executionCount++)

                        .OnAfterInsertCommand(_ => executionCount++)
                        .OnAfterInsertCommand(_ => executionCount++)

                        .OnAfterCommand(_ => executionCount++)
                        .OnAfterCommand(_ => executionCount++)

                        .OnAfterInsertComplete(_ => executionCount++)
                        .OnAfterInsertComplete(_ => executionCount++)

                        .OnAfterComplete(_ => executionCount++)
                        .OnAfterComplete(_ => executionCount++)
                    );

            //when
            await db.Insert(new Address { Line1 = "123 Main St", City = "Nowhere", State = "XX", Zip = "00000" }).Into(dbo.Address).ExecuteAsync();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory]
        [InlineData("9876543210")]
        public async Task Do_all_pipeline_events_fire_in_order_when_inserting_async(string expected)
        {
            //given
            var execution = "";
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                    c => c.Events
                        .OnBeforeStart(_ => execution += "9")
                        .OnBeforeInsertStart(_ => execution += "8")
                        .OnAfterInsertAssembly(_ => execution += "7")
                        .OnAfterAssembly(_ => execution += "6")
                        .OnBeforeCommand(_ => execution += "5")
                        .OnBeforeInsertCommand(_ => execution += "4")
                        .OnAfterInsertCommand(_ => execution += "3")
                        .OnAfterCommand(_ => execution += "2")
                        .OnAfterInsertComplete(_ => execution += "1")
                        .OnAfterComplete(_ => execution += "0")
                    );

            //when
            await db.Insert(new Address { Line1 = "123 Main St", City = "Nowhere", State = "XX", Zip = "00000" }).Into(dbo.Address).ExecuteAsync();

            //then
            execution.Should().Be(expected);
        }
    }
}

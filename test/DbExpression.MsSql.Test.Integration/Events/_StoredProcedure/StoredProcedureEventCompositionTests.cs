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
    public class StoredProcedureEventCompositionTests : ResetDatabaseNotRequired
    {
        [Theory(Skip = "Async ends up double wrapped")]
        [InlineData(10)]
        public void Do_all_pipeline_events_fire_when_executing_a_stored_procedure(int expected)
        {
            //given
            var executionCount = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                    c => c.Events
                        .OnBeforeStart(_ => executionCount++)
                        .OnBeforeStoredProcedureStart(_ => executionCount++)
                        .OnAfterStoredProcedureAssembly(_ => executionCount++)
                        .OnAfterAssembly(_ => executionCount++)
                        .OnBeforeCommand(_ => executionCount++)
                        .OnBeforeStoredProcedureCommand(_ => executionCount++)
                        .OnAfterStoredProcedureCommand(_ => executionCount++)
                        .OnAfterCommand(_ => executionCount++)
                        .OnAfterStoredProcedureComplete(_ => executionCount++)
                        .OnAfterComplete(_ => executionCount++)
                    );

            //when
            db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).Execute();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory(Skip = "Async ends up double wrapped")]
        [InlineData(20)]
        public void Do_all_pipeline_events_fire_when_executing_a_stored_procedure_and_event_confiugurations_are_repeated(int expected)
        {
            //given
            var executionCount = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                    c => c.Events
                        .OnBeforeStart(_ => executionCount++)
                        .OnBeforeStart(_ => executionCount++)

                        .OnBeforeStoredProcedureStart(_ => executionCount++)
                        .OnBeforeStoredProcedureStart(_ => executionCount++)

                        .OnAfterStoredProcedureAssembly(_ => executionCount++)
                        .OnAfterStoredProcedureAssembly(_ => executionCount++)

                        .OnAfterAssembly(_ => executionCount++)
                        .OnAfterAssembly(_ => executionCount++)

                        .OnBeforeCommand(_ => executionCount++)
                        .OnBeforeCommand(_ => executionCount++)

                        .OnBeforeStoredProcedureCommand(_ => executionCount++)
                        .OnBeforeStoredProcedureCommand(_ => executionCount++)

                        .OnAfterStoredProcedureCommand(_ => executionCount++)
                        .OnAfterStoredProcedureCommand(_ => executionCount++)

                        .OnAfterCommand(_ => executionCount++)
                        .OnAfterCommand(_ => executionCount++)

                        .OnAfterStoredProcedureComplete(_ => executionCount++)
                        .OnAfterStoredProcedureComplete(_ => executionCount++)

                        .OnAfterComplete(_ => executionCount++)
                        .OnAfterComplete(_ => executionCount++)
                    );

            //when
            db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).Execute();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory(Skip = "Async ends up double wrapped")]
        [InlineData("9876543210")]
        public void Do_all_pipeline_events_fire_in_order_when_executing_a_stored_procedure(string expected)
        {
            //given
            var execution = "";
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                    c => c.Events
                        .OnBeforeStart(_ => execution += "9")
                        .OnBeforeStoredProcedureStart(_ => execution += "8")
                        .OnAfterStoredProcedureAssembly(_ => execution += "7")
                        .OnAfterAssembly(_ => execution += "6")
                        .OnBeforeCommand(_ => execution += "5")
                        .OnBeforeStoredProcedureCommand(_ => execution += "4")
                        .OnAfterStoredProcedureCommand(_ => execution += "3")
                        .OnAfterCommand(_ => execution += "2")
                        .OnAfterStoredProcedureComplete(_ => execution += "1")
                        .OnAfterComplete(_ => execution += "0")
                    );

            //when
            db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).Execute();

            //then
            execution.Should().Be(expected);
        }

        [Theory(Skip = "Async ends up double wrapped")]
        [InlineData(10)]
        public void Do_all_pipeline_events_fire_when_executing_a_stored_procedure_and_predicate_is_met(int expected)
        {
            //given
            var executionCount = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                    c => c.Events
                        .OnBeforeStart(_ => executionCount++, c => c.Expression.IsStoredProcedureQueryExpression())
                        .OnBeforeStoredProcedureStart(_ => executionCount++, c => c.Expression.IsStoredProcedureQueryExpression())
                        .OnAfterStoredProcedureAssembly(_ => executionCount++, c => c.Expression.IsStoredProcedureQueryExpression())
                        .OnAfterAssembly(_ => executionCount++, c => c.Expression.IsStoredProcedureQueryExpression())
                        .OnBeforeCommand(_ => executionCount++, c => c.Expression.IsStoredProcedureQueryExpression())
                        .OnBeforeStoredProcedureCommand(_ => executionCount++, c => c.Expression.IsStoredProcedureQueryExpression())
                        .OnAfterStoredProcedureCommand(_ => executionCount++, c => c.Expression.IsStoredProcedureQueryExpression())
                        .OnAfterCommand(_ => executionCount++, c => c.Expression.IsStoredProcedureQueryExpression())
                        .OnAfterStoredProcedureComplete(_ => executionCount++, c => c.Expression.IsStoredProcedureQueryExpression())
                        .OnAfterComplete(_ => executionCount++, c => c.Expression.IsStoredProcedureQueryExpression())
                    );

            //when
            db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).Execute();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory(Skip = "Async ends up double wrapped")]
        [InlineData(10)]
        public async Task Do_all_pipeline_events_fire_when_executing_a_stored_procedure_async(int expected)
        {
            //given
            var executionCount = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                    c => c.Events
                        .OnBeforeStart(_ => executionCount++)
                        .OnBeforeStoredProcedureStart(_ => executionCount++)
                        .OnAfterStoredProcedureAssembly(_ => executionCount++)
                        .OnAfterAssembly(_ => executionCount++)
                        .OnBeforeCommand(_ => executionCount++)
                        .OnBeforeStoredProcedureCommand(_ => executionCount++)
                        .OnAfterStoredProcedureCommand(_ => executionCount++)
                        .OnAfterCommand(_ => executionCount++)
                        .OnAfterStoredProcedureComplete(_ => executionCount++)
                        .OnAfterComplete(_ => executionCount++)
                    );

            //when
            await db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).ExecuteAsync();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory(Skip = "Async ends up double wrapped")]
        [InlineData(20)]
        public async Task Do_all_pipeline_events_fire_when_executing_a_stored_procedure_async_and_event_configurations_are_repeated(int expected)
        {
            //given
            var executionCount = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                    c => c.Events
                        .OnBeforeStart(_ => executionCount++)
                        .OnBeforeStart(_ => executionCount++)

                        .OnBeforeStoredProcedureStart(_ => executionCount++)
                        .OnBeforeStoredProcedureStart(_ => executionCount++)

                        .OnAfterStoredProcedureAssembly(_ => executionCount++)
                        .OnAfterStoredProcedureAssembly(_ => executionCount++)

                        .OnAfterAssembly(_ => executionCount++)
                        .OnAfterAssembly(_ => executionCount++)

                        .OnBeforeCommand(_ => executionCount++)
                        .OnBeforeCommand(_ => executionCount++)

                        .OnBeforeStoredProcedureCommand(_ => executionCount++)
                        .OnBeforeStoredProcedureCommand(_ => executionCount++)

                        .OnAfterStoredProcedureCommand(_ => executionCount++)
                        .OnAfterStoredProcedureCommand(_ => executionCount++)

                        .OnAfterCommand(_ => executionCount++)
                        .OnAfterCommand(_ => executionCount++)

                        .OnAfterStoredProcedureComplete(_ => executionCount++)
                        .OnAfterStoredProcedureComplete(_ => executionCount++)

                        .OnAfterComplete(_ => executionCount++)
                        .OnAfterComplete(_ => executionCount++)
                    );

            //when
            await db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).ExecuteAsync();

            //then
            executionCount.Should().Be(expected);
        }

        [Theory(Skip = "Async ends up double wrapped")]
        [InlineData("9876543210")]
        public async Task Do_all_pipeline_events_fire_in_order_when_executing_a_stored_procedure_async(string expected)
        {
            //given
            var execution = "";
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                    c => c.Events
                        .OnBeforeStart(_ => execution += "9")
                        .OnBeforeStoredProcedureStart(_ => execution += "8")
                        .OnAfterStoredProcedureAssembly(_ => execution += "7")
                        .OnAfterAssembly(_ => execution += "6")
                        .OnBeforeCommand(_ => execution += "5")
                        .OnBeforeStoredProcedureCommand(_ => execution += "4")
                        .OnAfterStoredProcedureCommand(_ => execution += "3")
                        .OnAfterCommand(_ => execution += "2")
                        .OnAfterStoredProcedureComplete(_ => execution += "1")
                        .OnAfterComplete(_ => execution += "0")
                    );

            //when
            await db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input(1).ExecuteAsync();

            //then
            execution.Should().Be(expected);
        }
    }
}

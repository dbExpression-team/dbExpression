using v2019DbEx.DataService;
using FluentAssertions;
using DbExpression.MsSql.Configuration;
using DbExpression.Sql.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace DbExpression.MsSql.Test.Unit.Assembler
{
    public class AssemblyContextTests : TestBase
    {
        [Fact]
        public void Can_set_state_successfully()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var assemblyContext = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<SqlStatementAssemblyOptions>().ToAssemblyContext();

            //when
            Action setState = () => assemblyContext.SetState(new TestState());

            //then
            setState.Should().NotThrow();
        }

        [Fact]
        public void Can_retrieve_state_successfully()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var assemblyContext = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<SqlStatementAssemblyOptions>().ToAssemblyContext();
            assemblyContext.SetState(new TestState());

            //when
            var state = assemblyContext.GetState<TestState>();

            //then
            state.Should().NotBeNull();
        }

        [Fact]
        public void Can_remove_state_successfully()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var assemblyContext = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<SqlStatementAssemblyOptions>().ToAssemblyContext();
            assemblyContext.SetState(new TestState());

            //when
            var state = assemblyContext.RemoveState<TestState>();
            var shouldBeNull = assemblyContext.GetState<TestState>();

            //then
            state.Should().NotBeNull();
            shouldBeNull.Should().BeNull();
        }

        private class TestState { }
    }
}

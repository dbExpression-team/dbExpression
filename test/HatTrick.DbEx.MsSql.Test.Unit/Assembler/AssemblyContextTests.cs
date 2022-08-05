using FluentAssertions;
using HatTrick.DbEx.Sql.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Assembler
{
    public class AssemblyContextTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_set_state_successfully(int version)
        {
            //given
            var provider = ConfigureForMsSqlVersion(version);
            var assemblyContext = provider.GetRequiredService<SqlStatementAssemblerConfiguration>().ToAssemblyContext();

            //when
            Action setState = () => assemblyContext.SetState(new TestState());

            //then
            setState.Should().NotThrow();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_retrieve_state_successfully(int version)
        {
            //given
            var provider = ConfigureForMsSqlVersion(version);
            var assemblyContext = provider.GetRequiredService<SqlStatementAssemblerConfiguration>().ToAssemblyContext();
            assemblyContext.SetState(new TestState());

            //when
            var state = assemblyContext.GetState<TestState>();

            //then
            state.Should().NotBeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_remove_state_successfully(int version)
        {
            //given
            var provider = ConfigureForMsSqlVersion(version);
            var assemblyContext = provider.GetRequiredService<SqlStatementAssemblerConfiguration>().ToAssemblyContext();
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

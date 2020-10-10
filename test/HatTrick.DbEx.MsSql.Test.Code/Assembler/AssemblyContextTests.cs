using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.Sql.Assembler;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Code.Assembler
{
    public class AssemblyContextTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_resolve_field_pushed_into_stack_when_only_one_field_in_stack(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var assemblyContext = new AssemblyContext(database.AssemblerConfiguration);
            assemblyContext.PushField(dbo.Person.Id);

            //when
            var field = assemblyContext.Field;

            //then
            field.Should().Be(dbo.Person.Id);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_resolve_field_pushed_into_stack_when_one_field_and_null_in_stack(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var assemblyContext = new AssemblyContext(database.AssemblerConfiguration);
            assemblyContext.PushField(dbo.Person.Id);
            assemblyContext.PushField(null);

            //when
            var field = assemblyContext.Field;

            //then
            field.Should().Be(dbo.Person.Id);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_resolve_field_pushed_into_stack_when_other_field_is_pushed_then_popped_from_stack(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var assemblyContext = new AssemblyContext(database.AssemblerConfiguration);
            assemblyContext.PushField(dbo.Person.Id);
            assemblyContext.PushField(dbo.Person.FirstName);
            assemblyContext.PopField();

            //when
            var field = assemblyContext.Field;

            //then
            field.Should().Be(dbo.Person.Id);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void When_stack_contains_only_one_field_and_it_is_popped_does_accessing_field_return_null(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var assemblyContext = new AssemblyContext(database.AssemblerConfiguration);
            assemblyContext.PushField(dbo.Person.Id);
            assemblyContext.PopField();

            //when
            var field = assemblyContext.Field;

            //then
            field.Should().BeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_set_state_successfully(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var assemblyContext = new AssemblyContext(database.AssemblerConfiguration);

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
            var database = ConfigureForMsSqlVersion(version);
            var assemblyContext = new AssemblyContext(database.AssemblerConfiguration);
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
            var database = ConfigureForMsSqlVersion(version);
            var assemblyContext = new AssemblyContext(database.AssemblerConfiguration);
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

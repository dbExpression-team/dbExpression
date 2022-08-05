using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Configuration
{
    public class SqlStatementAssemblerConfigurationTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void An_assembler_factory_registered_via_instance_should_be_a_delegate_assembler_factory(int version)
        {
            //given
            var assembler = Substitute.For<ISqlStatementAssemblerFactory<MsSqlDb>>();
            var provider = ConfigureForMsSqlVersion(version, c => c.SqlStatements.Assembly.StatementAssembler.Use(assembler));

            //when
            var factory = provider.GetService<ISqlStatementAssemblerFactory<MsSqlDb>>();

            //then
            factory.Should().Be(assembler);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void An_assembler_factory_registered_via_service_provider_should_be_the_assembler(int version)
        {
            //given
            var assembler = Substitute.For<ISqlStatementAssemblerFactory<MsSqlDb>>();
            var provider = ConfigureForMsSqlVersion(version, c => c.SqlStatements.Assembly.StatementAssembler.Use(sp => assembler));

            //when
            var factory = provider.GetService<ISqlStatementAssemblerFactory<MsSqlDb>>();

            //then
            factory.Should().Be(assembler);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void An_assembler_factory_registered_via_delegate_should_return_the_correct_assembler(int version)
        {
            //given
            var f = new Func<IServiceProvider, Type, ISqlStatementAssembler<MsSqlDb>>((sp, t )=> null!);
            var provider = ConfigureForMsSqlVersion(version, c => c.SqlStatements.Assembly.StatementAssembler.Use(f));
            var factory = provider.GetRequiredService<ISqlStatementAssemblerFactory<MsSqlDb>>();

            //when
            var factoryAssembler = factory.CreateSqlStatementAssembler<SelectQueryExpression>();

            //then
            factoryAssembler.Should().BeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void An_assembler_registered_via_delegate_should_be_a_delegate_assembler_factory(int version)
        {
            //given
            var assembler = Substitute.For<ISqlStatementAssembler<MsSqlDb>>();
            var provider = ConfigureForMsSqlVersion(version, c => c.SqlStatements.Assembly.StatementAssembler.Use((sp, t) => assembler));

            //when
            var factory = provider.GetService<ISqlStatementAssemblerFactory<MsSqlDb>>();

            //then
            factory.Should().BeOfType<DelegateSqlStatementAssemblerFactory<MsSqlDb>>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void An_assembler_registered_via_delegate_should_return_the_correct_assembler(int version)
        {
            //given
            var f = new Func<IServiceProvider, Type, ISqlStatementAssembler<MsSqlDb>>((sp, t) => null!);
            var provider = ConfigureForMsSqlVersion(version, c => c.SqlStatements.Assembly.StatementAssembler.Use(f));
            var factory = provider.GetRequiredService<ISqlStatementAssemblerFactory<MsSqlDb>>();

            //when
            var factoryAssembler = factory.CreateSqlStatementAssembler<SelectQueryExpression>();

            //then
            factoryAssembler.Should().BeNull();
        }
    }
}

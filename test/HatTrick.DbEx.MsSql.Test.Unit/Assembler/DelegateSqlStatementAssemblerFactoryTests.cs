using FluentAssertions;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using NSubstitute;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Assembler
{
    public class DelegateSqlStatementAssemblerFactoryTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void An_assembler_factory_registered_via_delegate_should_be_a_delegate_assembler_factory(int version)
        {
            //given
            var assembler = Substitute.For<ISqlStatementAssembler>();
            var database = ConfigureForMsSqlVersion(version, postConfigure: c => c.SqlStatements.Assembly.StatementAssembler.Use(_ => assembler));

            //when
            var factory = database.StatementAssemblerFactory;

            //then
            factory.Should().BeOfType<DelegateSqlStatementAssemblerFactory>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void An_assembler_factory_registered_via_delegate_should_return_the_correct_assembler(int version)
        {
            //given
            var assembler = Substitute.For<ISqlStatementAssembler>();
            var database = ConfigureForMsSqlVersion(version, postConfigure: c => c.SqlStatements.Assembly.StatementAssembler.Use(_ => assembler));
            var factory = database.StatementAssemblerFactory;

            //when
            var factoryAssembler = factory.CreateSqlStatementAssembler(new SelectQueryExpression());

            //then
            factoryAssembler.Should().Be(assembler);
        }
    }
}

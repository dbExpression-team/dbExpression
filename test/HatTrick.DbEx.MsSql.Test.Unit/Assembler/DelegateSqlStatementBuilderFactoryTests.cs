using FluentAssertions;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using NSubstitute;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Assembler
{
    public class DelegateSqlStatementBuilderFactoryTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void A_statement_builder_factory_registered_via_delegate_should_be_a_delegate_statement_builder_factory(int version)
        {
            //given
            var Builder = Substitute.For<ISqlStatementBuilder>();
            var database = ConfigureForMsSqlVersion(version, postConfigure: c => c.SqlStatements.Assembly.StatementBuilder.Use((c,q) => Builder));

            //when
            var factory = database.StatementBuilderFactory;

            //then
            factory.Should().BeOfType<DelegateSqlStatementBuilderFactory>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void A_statement_builder_factory_registered_via_delegate_should_return_the_correct_statement_builder(int version)
        {
            //given
            var Builder = Substitute.For<ISqlStatementBuilder>();
            var database = ConfigureForMsSqlVersion(version, postConfigure: c => c.SqlStatements.Assembly.StatementBuilder.Use((c,q) => Builder));
            var factory = database.StatementBuilderFactory;

            //when
            var factoryBuilder = factory.CreateSqlStatementBuilder(database, new SelectQueryExpression());

            //then
            factoryBuilder.Should().Be(Builder);
        }
    }
}

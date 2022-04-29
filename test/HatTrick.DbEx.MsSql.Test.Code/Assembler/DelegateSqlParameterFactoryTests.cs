using FluentAssertions;
using HatTrick.DbEx.Sql.Assembler;
using NSubstitute;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Code.Assembler
{
    public class DelegateSqlParameterFactoryTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void An_parameter_builder_factory_registered_via_delegate_should_be_a_delegate_parameter_builder_factory(int version)
        {
            //given
            var builder = Substitute.For<ISqlParameterBuilder>();
            var database = ConfigureForMsSqlVersion(version, postConfigure: c => c.SqlStatements.Assembly.ParameterBuilder.Use(() => builder));

            //when
            var factory = database.ParameterBuilderFactory;

            //then
            factory.Should().BeOfType<DelegateSqlParameterBuilderFactory>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void An_parameter_builder_factory_registered_via_delegate_should_return_the_correct_parameter_builder(int version)
        {
            //given
            var builder = Substitute.For<ISqlParameterBuilder>();
            var database = ConfigureForMsSqlVersion(version, postConfigure: c => c.SqlStatements.Assembly.ParameterBuilder.Use(() => builder));
            var factory = database.ParameterBuilderFactory;

            //when
            var factoryAppender = factory.CreateSqlParameterBuilder();

            //then
            factoryAppender.Should().Be(builder);
        }
    }
}

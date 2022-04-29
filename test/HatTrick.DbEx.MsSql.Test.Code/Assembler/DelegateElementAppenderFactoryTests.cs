using FluentAssertions;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using NSubstitute;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Code.Assembler
{
    public class DelegateElementAppenderFactoryTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void An_element_appender_factory_registered_via_delegate_should_be_a_delegate_appender_factory(int version)
        {
            //given
            var appender = Substitute.For<IExpressionElementAppender>();
            var database = ConfigureForMsSqlVersion(version, postConfigure: c => c.SqlStatements.Assembly.ElementAppender.Use(_ => appender));

            //when
            var factory = database.ExpressionElementAppenderFactory;

            //then
            factory.Should().BeOfType<DelegateExpressionElementAppenderFactory>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void An_element_appender_factory_registered_via_delegate_should_return_the_correct_appender(int version)
        {
            //given
            var appender = Substitute.For<IExpressionElementAppender>();
            var database = ConfigureForMsSqlVersion(version, postConfigure: c => c.SqlStatements.Assembly.ElementAppender.Use(_ => appender));
            var factory = database.ExpressionElementAppenderFactory;

            //when
            var factoryAppender = factory.CreateElementAppender(new LiteralExpression<int>(5));

            //then
            factoryAppender.Should().Be(appender);
        }
    }
}

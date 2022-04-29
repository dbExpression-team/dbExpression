using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.Sql.Assembler;
using NSubstitute;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Assembler
{
    public class DelegateAppenderFactoryTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void An_appender_factory_registered_via_delegate_should_be_a_delegate_appender_factory(int version)
        {
            //given
            var appender = Substitute.For<IAppender>();
            var database = ConfigureForMsSqlVersion(version, postConfigure: c => c.SqlStatements.Assembly.StatementAppender.Use(() => appender));

            //when
            var factory = database.AppenderFactory;

            //then
            factory.Should().BeOfType<DelegateAppenderFactory>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void An_appender_factory_registered_via_delegate_should_return_the_correct_appender(int version)
        {
            //given
            var appender = Substitute.For<IAppender>();
            var database = ConfigureForMsSqlVersion(version, postConfigure: c => c.SqlStatements.Assembly.StatementAppender.Use(() => appender));
            var factory = database.AppenderFactory;

            //when
            var factoryAppender = factory.CreateAppender();

            //then
            factoryAppender.Should().Be(appender);
        }
    }
}

using FluentAssertions;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Configuration
{
    public class SqlStatementsConfigurationBuilderTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_for_appender_factory_using_instance_method_with_null_instance_throw_expected_exception(int version)
        {
            //given & when & then
            Assert.Throws<DbExpressionConfigurationException>(() => ConfigureForMsSqlVersion(version, builder => builder.SqlStatements.Assembly.StatementAppender.Use((IAppenderFactory)null!)));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_an_appender_factory_using_generic_use_method_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.SqlStatements.Assembly.StatementAppender.Use<NoOpAppenderFactory>());

            //when
            var matchingType = config.AppenderFactory is NoOpAppenderFactory;

            //then
            matchingType.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_an_appender_factory_using_instance_use_method_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.SqlStatements.Assembly.StatementAppender.Use(new NoOpAppenderFactory()));

            //when
            var matchingType = config.AppenderFactory is NoOpAppenderFactory;

            //then
            matchingType.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_an_appender_factory_using_default_use_method_succeed(int version)
        {
            //given

            var config = ConfigureForMsSqlVersion(version, builder => builder.SqlStatements.Assembly.StatementAppender.UseDefaultFactory());

            //when
            var matchingType = config.AppenderFactory is not null;

            //then
            matchingType.Should().BeTrue();
        }


        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_for_element_appender_factory_using_instance_method_with_null_instance_throw_expected_exception(int version)
        {
            //given & when & then
            Assert.Throws<DbExpressionConfigurationException>(() => ConfigureForMsSqlVersion(version, builder => builder.SqlStatements.Assembly.ElementAppender.Use((IExpressionElementAppenderFactory)null!)));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_an_element_appender_factory_using_generic_use_method_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.SqlStatements.Assembly.ElementAppender.Use<NoOpExpressionElementAppenderFactory>());

            //when
            var matchingType = config.ExpressionElementAppenderFactory is NoOpExpressionElementAppenderFactory;

            //then
            matchingType.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_an_element_appender_factory_using_instance_use_method_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.SqlStatements.Assembly.ElementAppender.Use(new NoOpExpressionElementAppenderFactory()));

            //when
            var matchingType = config.ExpressionElementAppenderFactory is NoOpExpressionElementAppenderFactory;

            //then
            matchingType.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_an_element_appender_factory_using_default_use_method_succeed(int version)
        {
            //given

            var config = ConfigureForMsSqlVersion(version, builder => builder.SqlStatements.Assembly.ElementAppender.UseDefaultFactory());

            //when
            var matchingType = config.ExpressionElementAppenderFactory is not null;

            //then
            matchingType.Should().BeTrue();
        }


        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_for_parameter_builder_factory_using_instance_method_with_null_instance_throw_expected_exception(int version)
        {
            //given & when & then
            Assert.Throws<DbExpressionConfigurationException>(() => ConfigureForMsSqlVersion(version, builder => builder.SqlStatements.Assembly.ParameterBuilder.Use((ISqlParameterBuilderFactory)null!)));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_an_parameter_builder_factory_using_generic_use_method_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.SqlStatements.Assembly.ParameterBuilder.Use<NoOpSqlParameterBuilderFactory>());

            //when
            var matchingType = config.ParameterBuilderFactory is NoOpSqlParameterBuilderFactory;

            //then
            matchingType.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_an_parameter_builder_factory_using_instance_use_method_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.SqlStatements.Assembly.ParameterBuilder.Use(new NoOpSqlParameterBuilderFactory()));

            //when
            var matchingType = config.ParameterBuilderFactory is NoOpSqlParameterBuilderFactory;

            //then
            matchingType.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_for_appender_output_settings_with_null_configuration_action_succeed(int version)
        {
            //given & when & then
            ConfigureForMsSqlVersion(version, builder => builder.SqlStatements.Assembly.ConfigureOutputSettings(null!));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_for_appender_output_settings_with_configuration_action_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.SqlStatements.Assembly.ConfigureOutputSettings(a => a.IdentifierDelimiter.Begin = '&'));

            //when & then
            config.AssemblerConfiguration.IdentifierDelimiter.Begin.Should().Be('&');
        }

        public class NoOpAppenderFactory : IAppenderFactory
        {
            public IAppender CreateAppender() => throw new NotImplementedException();
        }

        public class NoOpExpressionElementAppenderFactory : IExpressionElementAppenderFactory
        {
            public IExpressionElementAppender CreateElementAppender(IExpressionElement element) => throw new NotImplementedException();
        }

        public class NoOpSqlParameterBuilderFactory : ISqlParameterBuilderFactory
        {
            public ISqlParameterBuilder CreateSqlParameterBuilder() => throw new NotImplementedException();
        }
    }
}

using FluentAssertions;
using HatTrick.DbEx.Sql.Assembler;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Configuration
{
    public class AppenderConfigurationTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_for_appender_factory_using_instance_method_with_null_instance_resolve_to_null(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version, builder => builder.SqlStatements.Assembly.StatementAppender.Use(sp => (IAppender)null!));
            
            //when
            var resolved = serviceProvider.GetService<IAppender>();

            //then
            resolved.Should().BeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_for_appender_factory_using_delegate_with_null_instance_resolve_to_null(int version)
        {
            //given & when & then
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version, builder => builder.SqlStatements.Assembly.StatementAppender.Use(() => (IAppender)null!));

            //when
            var resolved = serviceProvider.GetService<IAppender>();

            resolved.Should().BeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_an_appender_factory_using_generic_use_method_succeed(int version)
        {
            //given
            var factory = Substitute.For<IAppender>();
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version, builder => builder.SqlStatements.Assembly.StatementAppender.Use<NoOpAppender>());

            //when
            var matchingType = serviceProvider.GetRequiredService<IAppender>();

            //then
            matchingType.Should().BeOfType<NoOpAppender>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void An_appender_factory_registered_via_delegate_should_be_correct_appender(int version)
        {
            //given
            var appender = Substitute.For<IAppender>();
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version, c => c.SqlStatements.Assembly.StatementAppender.Use(sp => appender));

            //when
            var resolved = serviceProvider.GetRequiredService<IAppender>();

            //then
            resolved.Should().Be(appender);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void An_appender_factory_registered_via_service_serviceProvider_should_be_correct_appender(int version)
        {
            //given
            var appender = Substitute.For<IAppender>();
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version, c => c.SqlStatements.Assembly.StatementAppender.Use(sp => appender));

            //when
            var resolved = serviceProvider.GetRequiredService<IAppender>();

            //then
            resolved.Should().Be(appender);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void An_appender_registered_via_generic_should_be_correct_appender_type(int version)
        {
            //given
            var appender = Substitute.For<IAppender>();
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version, c => c.SqlStatements.Assembly.StatementAppender.Use<Appender>());

            //when
            var resolved = serviceProvider.GetRequiredService<IAppender>();

            //then
            resolved.Should().BeOfType<Appender>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void An_appender_registered_via_generic_should_be_transient(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version, c => c.SqlStatements.Assembly.StatementAppender.Use<Appender>());

            //when
            var a1 = serviceProvider.GetRequiredService<IAppender>();
            var a2 = serviceProvider.GetRequiredService<IAppender>();

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void An_appender_registered_via_service_serviceProvider_and_instance_should_be_transient(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version, c => c.SqlStatements.Assembly.StatementAppender.Use(sp => new NoOpAppender()));

            //when
            var a1 = serviceProvider.GetRequiredService<IAppender>();
            var a2 = serviceProvider.GetRequiredService<IAppender>();

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void An_appender_registered_via_delegate_and_instance_should_be_transient(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version, c => c.SqlStatements.Assembly.StatementAppender.Use(() => new NoOpAppender()));

            //when
            var a1 = serviceProvider.GetRequiredService<IAppender>();
            var a2 = serviceProvider.GetRequiredService<IAppender>();

            //then
            a1.Should().NotBe(a2);
        }

        private class NoOpAppender : IAppender
        {
            public AppenderIndentation Indentation { get; set; } = new(null!);

            public IAppender If(bool append, params Action<Appender>[] values)
            {
                throw new NotImplementedException();
            }

            public IAppender IfNotEmpty(string? test, params Action<Appender>[] values)
            {
                throw new NotImplementedException();
            }

            public IAppender Indent()
            {
                throw new NotImplementedException();
            }

            public IAppender LineBreak()
            {
                throw new NotImplementedException();
            }

            public IAppender Write(string? value)
            {
                throw new NotImplementedException();
            }

            public IAppender Write(char value)
            {
                throw new NotImplementedException();
            }
        }
    }
}

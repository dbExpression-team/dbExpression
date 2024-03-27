using v2019DbEx.DataService;
using FluentAssertions;
using DbExpression.MsSql.Configuration;
using DbExpression.Sql.Assembler;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using System;
using Xunit;

namespace DbExpression.MsSql.Test.Unit.Configuration
{
    public class AppenderConfigurationTests : TestBase
    {
        [Fact]
        public void Does_configuration_for_appender_factory_using_instance_method_with_null_instance_resolve_to_null()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.SqlStatements.Assembly.StatementAppender.Use(sp => (IAppender)null!));
            
            //when
            var resolved = serviceProvider.GetService<IAppender>();

            //then
            resolved.Should().BeNull();
        }

        [Fact]
        public void Does_configuration_for_appender_factory_using_delegate_with_null_instance_resolve_to_null()
        {
            //given & when & then
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.SqlStatements.Assembly.StatementAppender.Use(() => (IAppender)null!));

            //when
            var resolved = serviceProvider.GetService<IAppender>();

            resolved.Should().BeNull();
        }

        [Fact]
        public void Does_configuration_of_an_appender_factory_using_generic_use_method_succeed()
        {
            //given
            var factory = Substitute.For<IAppender>();
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.SqlStatements.Assembly.StatementAppender.Use<NoOpAppender>());

            //when
            var matchingType = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IAppender>();

            //then
            matchingType.Should().BeOfType<NoOpAppender>();
        }

        [Fact]
        public void An_appender_factory_registered_via_delegate_should_be_correct_appender()
        {
            //given
            var appender = Substitute.For<IAppender>();
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.StatementAppender.Use(sp => appender));

            //when
            var resolved = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IAppender>();

            //then
            resolved.Should().Be(appender);
        }

        [Fact]
        public void An_appender_factory_registered_via_service_serviceProvider_should_be_correct_appender()
        {
            //given
            var appender = Substitute.For<IAppender>();
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.StatementAppender.Use(sp => appender));

            //when
            var resolved = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IAppender>();

            //then
            resolved.Should().Be(appender);
        }

        [Fact]
        public void An_appender_registered_via_generic_should_be_correct_appender_type()
        {
            //given
            var appender = Substitute.For<IAppender>();
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.StatementAppender.Use<Appender>());

            //when
            var resolved = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IAppender>();

            //then
            resolved.Should().BeOfType<Appender>();
        }

        [Fact]
        public void An_appender_registered_via_generic_should_be_transient()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.StatementAppender.Use<Appender>());

            //when
            var a1 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IAppender>();
            var a2 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IAppender>();

            //then
            a1.Should().NotBe(a2);
        }

        [Fact]
        public void An_appender_registered_via_service_serviceProvider_and_instance_should_be_transient()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.StatementAppender.Use(sp => new NoOpAppender()));

            //when
            var a1 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IAppender>();
            var a2 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IAppender>();

            //then
            a1.Should().NotBe(a2);
        }

        [Fact]
        public void An_appender_registered_via_delegate_and_instance_should_be_transient()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.StatementAppender.Use(() => new NoOpAppender()));

            //when
            var a1 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IAppender>();
            var a2 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IAppender>();

            //then
            a1.Should().NotBe(a2);
        }

        private class NoOpAppender : IAppender
        {
            public AppenderIndentation Indentation { get; set; } = new(null!);

            public IAppender If(bool append, params Action<IAppender>[] values)
            {
                throw new NotImplementedException();
            }

            public IAppender IfNotEmpty(string? test, params Action<IAppender>[] values)
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

            public void Dispose()
            {
            }
        }
    }
}

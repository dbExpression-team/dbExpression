using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Configuration;
using DbExpression.Sql;
using DbExpression.Sql.Assembler;
using DbExpression.Sql.Expression;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using System;
using Xunit;

namespace DbExpression.MsSql.Test.Unit.Configuration
{
    public class ExpressionElementAppenderConfigurationTests : TestBase
    {
        [Fact]
        public void Does_configuration_for_element_appender_factory_using_instance_method_with_null_instance_throw_expected_exception()
        {
            //given & when & then
            Assert.Throws<DbExpressionConfigurationException>(() => Configure<v2019MsSqlDb>(builder => builder.SqlStatements.Assembly.ElementAppender.Use((IExpressionElementAppenderFactory)null!)));
        }

        [Fact]
        public void An_element_appender_factory_registered_as_instance_should_be_the_registered_appender_factory()
        {
            //given
            var appenderFactory = Substitute.For<IExpressionElementAppenderFactory>();
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ElementAppender.Use(appenderFactory));

            //when
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<IExpressionElementAppenderFactory>();

            //then
            factory.Should().Be(appenderFactory);
        }

        [Fact]
        public void Does_configuration_of_a_default_element_appender_factory_resolve_to_the_correct_type()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var resolved = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<IExpressionElementAppenderFactory>();

            //then
            resolved.Should().BeOfType<DefaultExpressionElementAppenderFactoryWithDiscovery>();
        }

        [Fact]
        public void An_element_appender_factory_registered_via_generic_should_be_the_correct_type()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ElementAppender.Use<NoOpExpressionElementAppenderFactory>());

            //when
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<IExpressionElementAppenderFactory>();

            //then
            factory.Should().BeOfType<NoOpExpressionElementAppenderFactory>();
        }

        [Fact]
        public void An_element_appender_factory_registered_via_delegate_should_be_the_default_appender_factory()
        {
            //given
            var factory = Substitute.For<IExpressionElementAppenderFactory>();
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ElementAppender.Use(t => factory));

            //when
            var resolved = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<IExpressionElementAppenderFactory>();

            //then
            resolved.Should().Be(factory);
        }

        [Fact]
        public void An_element_appender_factory_registered_via_delegate_with_element_appender_override_registered_generically_should_resolve_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ElementAppender.Use(sp => new DelegateExpressionElementAppenderFactory(t => sp.GetRequiredService<IExpressionElementAppender<FieldExpression>>()), c => c.ForElementType<FieldExpression>().Use<FieldExpressionAppender>()));

            //when
            var resolved = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IExpressionElementAppenderFactory>();
            var appender = resolved.CreateElementAppender<FieldExpression>();

            //then
            appender.Should().BeOfType<FieldExpressionAppender>().Which.Should().NotBeNull();
        }

        [Fact]
        public void The_default_factory_registration_should_discover_the_correct_appender_for_an_unregistered_appender()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IExpressionElementAppenderFactory>();

            //when
            var appender = factory.CreateElementAppender(dbo.Person.Id.GetType());

            //then
            appender.Should().BeOfType<FieldExpressionAppender>();
        }

        [Fact]
        public void The_default_factory_registration_with_custom_appender_registered_with_instance_should_resolve_correctly()
        {
            //given
            var appender = Substitute.For<IExpressionElementAppender<SchemaExpression>>();
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ElementAppender.ForElementTypes(b => b.ForElementType<SchemaExpression>().Use(appender)));
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IExpressionElementAppenderFactory>();

            //when
            var resolved = factory.CreateElementAppender(typeof(SchemaExpression));

            //then
            factory.Should().BeOfType<DefaultExpressionElementAppenderFactoryWithDiscovery>();
            resolved.Should().Be(appender);
        }

        [Fact]
        public void The_default_factory_registration_with_custom_appender_registered_with_delegate_should_resolve_correctly()
        {
            //given
            var appender = Substitute.For<IExpressionElementAppender<SchemaExpression>>();
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ElementAppender.ForElementTypes(b => b.ForElementType<SchemaExpression>().Use(() => appender)));
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IExpressionElementAppenderFactory>();

            //when
            var resolved = factory.CreateElementAppender<SchemaExpression>();

            //then
            factory.Should().BeOfType<DefaultExpressionElementAppenderFactoryWithDiscovery>();
            resolved.Should().Be(appender);
        }

        [Fact]
        public void The_default_factory_registration_with_custom_appender_registered_with_service_serviceProvider_should_resolve_correctly()
        {
            //given
            var appender = Substitute.For<IExpressionElementAppender<SchemaExpression>>();
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ElementAppender.ForElementTypes(b => b.ForElementType<SchemaExpression>().Use(sp => appender)));
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IExpressionElementAppenderFactory>();

            //when
            var resolved = factory.CreateElementAppender(typeof(SchemaExpression));

            //then
            factory.Should().BeOfType<DefaultExpressionElementAppenderFactoryWithDiscovery>();
            resolved.Should().Be(appender);
        }

        [Fact]
        public void The_default_factory_registration_with_custom_appender_registered_generically_should_resolve_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ElementAppender.ForElementTypes(b => b.ForElementType<SchemaExpression>().Use<NoOpSchemaAppender>()));
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IExpressionElementAppenderFactory>();

            //when
            var resolved = factory.CreateElementAppender<SchemaExpression>();

            //then
            factory.Should().BeOfType<DefaultExpressionElementAppenderFactoryWithDiscovery>();
            resolved.Should().BeOfType<NoOpSchemaAppender>();
        }

        [Fact]
        public void An_element_appender_factory_registered_via_delegate_should_resolve_the_correct_appender()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ElementAppender.Use(t => new FieldExpressionAppender()));
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IExpressionElementAppenderFactory>();

            //when
            var appender = factory.CreateElementAppender(dbo.Person.Id.GetType());

            //then
            appender.Should().BeOfType<FieldExpressionAppender>();
        }

        [Fact]
        public void An_element_appender_factory_registered_via_delegate_using_service_serviceProvider_should_resolve_the_correct_appender()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ElementAppender.Use((sp, t) => new FieldExpressionAppender()));
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IExpressionElementAppenderFactory>();

            //when
            var appender = factory.CreateElementAppender(dbo.Person.Id.GetType());

            //then
            appender.Should().BeOfType<FieldExpressionAppender>();
        }

        [Fact]
        public void The_default_factory_registration_should_resolve_appenders_as_singletons()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IExpressionElementAppenderFactory>();

            //when
            var first = factory.CreateElementAppender(typeof(SchemaExpression));
            var second = factory.CreateElementAppender(typeof(SchemaExpression));

            //then
            first.Should().Be(second);
        }

        [Fact]
        public void The_default_factory_registration_with_custom_appender_registered_with_instance_should_resolve_singletons()
        {
            //given
            var appender = Substitute.For<IExpressionElementAppender<SchemaExpression>>();
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ElementAppender.ForElementTypes(b => b.ForElementType<SchemaExpression>().Use(appender)));
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IExpressionElementAppenderFactory>();

            //when
            var a1 = factory.CreateElementAppender<SchemaExpression>();
            var a2 = factory.CreateElementAppender<SchemaExpression>();

            //then
            a1.Should().Be(a2);
            a1.Should().NotBeNull();
            a2.Should().NotBeNull();
        }

        [Fact]
        public void The_default_factory_registration_with_custom_appender_registered_with_delegate_should_resolve_singletons()
        {
            //given
            var appender = Substitute.For<IExpressionElementAppender<SchemaExpression>>();
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ElementAppender.ForElementTypes(b => b.ForElementType<SchemaExpression>().Use(() => appender)));
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IExpressionElementAppenderFactory>();

            //when
            var a1 = factory.CreateElementAppender<SchemaExpression>();
            var a2 = factory.CreateElementAppender<SchemaExpression>();

            //then
            a1.Should().Be(a2);
            a1.Should().NotBeNull();
            a2.Should().NotBeNull();
        }

        [Fact]
        public void The_default_factory_registration_with_custom_appender_registered_with_service_serviceProvider_should_resolve_singletons()
        {
            //given
            var appender = Substitute.For<IExpressionElementAppender<SchemaExpression>>();
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ElementAppender.ForElementTypes(b => b.ForElementType<SchemaExpression>().Use(sp => appender)));
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IExpressionElementAppenderFactory>();

            //when
            var a1 = factory.CreateElementAppender<SchemaExpression>();
            var a2 = factory.CreateElementAppender<SchemaExpression>();

            //then
            a1.Should().Be(a2);
            a1.Should().NotBeNull();
            a2.Should().NotBeNull();
        }

        public class NoOpExpressionElementAppenderFactory : IExpressionElementAppenderFactory
        {
            public IExpressionElementAppender CreateElementAppender(Type elementType)
            {
                throw new NotImplementedException();
            }

            IExpressionElementAppender<TElement> IExpressionElementAppenderFactory.CreateElementAppender<TElement>()
            {
                throw new NotImplementedException();
            }
        }

        public class NoOpSchemaAppender : IExpressionElementAppender<SchemaExpression>
        {
            public void AppendElement(SchemaExpression element, ISqlStatementBuilder builder, AssemblyContext context)
            {
                throw new NotImplementedException();
            }

            public void AppendElement(IExpressionElement element, ISqlStatementBuilder builder, AssemblyContext context)
            {
                throw new NotImplementedException();
            }
        }
    }
}

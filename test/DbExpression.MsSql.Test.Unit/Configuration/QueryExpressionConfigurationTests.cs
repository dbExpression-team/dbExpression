using v2019DbEx.DataService;
using FluentAssertions;
using DbExpression.MsSql.Configuration;
using DbExpression.Sql;
using DbExpression.Sql.Expression;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using System;
using Xunit;

namespace DbExpression.MsSql.Test.Unit.Configuration
{
    public class QueryExpressionConfigurationTests : TestBase
    {
        [Fact]
        public void Does_setting_query_expression_factory_to_null_throw_correct_exception()
        {
            //given, when & then
            var ex = Assert.Throws<DbExpressionConfigurationException>(() => Configure<v2019MsSqlDb>(c => c.QueryExpressions.Use((Func<IServiceProvider, Type, QueryExpression>)null!)));
        }

        [Fact]
        public void Does_configuration_using_instance_method_with_null_instance_throw_expected_exception()
        {
            //given & when & then
            Assert.Throws<DbExpressionConfigurationException>(() => Configure<v2019MsSqlDb>(builder => builder.QueryExpressions.Use((Func<IServiceProvider, Type, QueryExpression>)null!)));
        }

        [Fact]
        public void Does_configuration_using_service_serviceProvider_and_type_resolve_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.QueryExpressions.Use((sp,t) => new SelectQueryExpression() { Top = 100 }));
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IQueryExpressionFactory>();

            //when
            var resolved = factory.CreateQueryExpression<SelectQueryExpression>();

            //then
            resolved.Should().NotBeNull();
            resolved.Top.Should().Be(100);
        }

        [Fact]
        public void Does_configuration_using_service_serviceProvider_and_type_with_override_for_specific_type_resolve_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.QueryExpressions.Use((sp,t) => sp.GetRequiredService<SelectQueryExpression>(), c => c.ForSelect().Use(() => new SelectQueryExpression() { Top = 100 })));
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IQueryExpressionFactory>();

            //when
            var resolved = factory.CreateQueryExpression<SelectQueryExpression>();

            //then
            resolved.Should().NotBeNull();
            resolved.Top.Should().Be(100);
        }

        [Fact]
        public void Does_configuration_of_a_query_expression_factory_using_generic_use_method_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.QueryExpressions.Use<NoOpQueryExpressionFactory>());

            //when
            var matchingType = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<IQueryExpressionFactory>() is NoOpQueryExpressionFactory;

            //then
            matchingType.Should().BeTrue();
        }

        [Fact]
        public void Does_configuration_of_a_query_expression_factory_using_delegate_method_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.QueryExpressions.Use(() => new NoOpQueryExpressionFactory()));

            //when
            var matchingType = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<IQueryExpressionFactory>() is NoOpQueryExpressionFactory;

            //then
            matchingType.Should().BeTrue();
        }

        [Fact]
        public void Does_configuration_of_a_query_expression_factory_using_service_serviceProvider_method_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.QueryExpressions.Use(sp => new NoOpQueryExpressionFactory()));

            //when
            var matchingType = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<IQueryExpressionFactory>() is NoOpQueryExpressionFactory;

            //then
            matchingType.Should().BeTrue();
        }

        [Fact]
        public void Does_configuration_of_a_query_expression_using_instance_use_method_succeed()
        {
            //given
            var factory = Substitute.For<IQueryExpressionFactory>();
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.QueryExpressions.Use(factory));

            //when
            var resolved = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<IQueryExpressionFactory>();

            //then
            resolved.Should().Be(factory);
        }

        [Fact]
        public void Does_configuration_of_a_query_expression_using_generic_method_throw_appropriate_exception_when_accessing_for_database()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.QueryExpressions.Use<NoOpQueryExpressionFactory>());

            //when & then
            Assert.Throws<NotImplementedException>(() => serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IQueryExpressionFactory>().CreateQueryExpression<SelectQueryExpression>());
        }

        [Fact]
        public void Does_configuration_of_a_schema_serviceProvider_using_instance_method_throw_appropriate_exception_when_finding_schema_metadata()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.QueryExpressions.Use(new NoOpQueryExpressionFactory()));

            //when & then
            Assert.Throws<NotImplementedException>(() => serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IQueryExpressionFactory>().CreateQueryExpression<SelectQueryExpression>());
        }

        [Fact]
        public void Does_configuration_of_a_query_expression_using_default_factory_succeed_when_creating_select_query_expression()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var exp = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IQueryExpressionFactory>().CreateQueryExpression<SelectQueryExpression>();

            //then
            exp.Should().NotBeNull();
        }

        [Fact]
        public void Does_configuration_of_a_subtyped_query_expression_using_default_factory_succeed_when_creating_select_query_expression()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.QueryExpressions.ForQueryTypes(c => c.ForQueryType<SelectQueryExpression>().Use<TestTestSelectQueryExpression>()));

            //when
            var exp = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IQueryExpressionFactory>().CreateQueryExpression<SelectQueryExpression>();

            //then
            exp.Should().NotBeNull();
            exp.Should().BeOfType<TestTestSelectQueryExpression>();
        }

        [Fact]
        public void Configuration_of_a_subtyped_query_expression_using_default_factory_when_creating_multiple_select_query_expressions_produce_transients()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.QueryExpressions.ForQueryTypes(c => c.ForQueryType<SelectQueryExpression>().Use<TestTestSelectQueryExpression>()));
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IQueryExpressionFactory>();

            //when
            var exp1 = factory.CreateQueryExpression<SelectQueryExpression>();
            var exp2 = factory.CreateQueryExpression<SelectQueryExpression>();

            //then
            exp1.Should().NotBe(exp2);
        }

        [Fact]
        public void Configuration_of_a_subtyped_query_expression_using_service_serviceProvider_and_instance_when_creating_multiple_select_query_expressions_produce_transients()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.QueryExpressions.Use((sp, t) => sp.GetRequiredService<SelectQueryExpression>(), c => c.ForSelect().Use(() => new SelectQueryExpression())));
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IQueryExpressionFactory>();

            //when
            var exp1 = factory.CreateQueryExpression<SelectQueryExpression>();
            var exp2 = factory.CreateQueryExpression<SelectQueryExpression>();

            //then
            exp1.Should().NotBe(exp2);
        }

        [Fact]
        public void Configuration_of_a_subtyped_query_expression_using_service_serviceProvider_when_creating_multiple_select_query_expressions_produce_transients()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.QueryExpressions.Use((sp, t) => sp.GetRequiredService<SelectQueryExpression>(), c => c.ForSelect().Use(sp => new SelectQueryExpression())));
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IQueryExpressionFactory>();

            //when
            var exp1 = factory.CreateQueryExpression<SelectQueryExpression>();
            var exp2 = factory.CreateQueryExpression<SelectQueryExpression>();

            //then
            exp1.Should().NotBe(exp2);
        }

        [Fact]
        public void Configuration_of_a_subtyped_query_expression_using_service_serviceProvider_and_generic_regsitration_when_creating_multiple_select_query_expressions_produce_transients()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.QueryExpressions.Use((sp, t) => sp.GetRequiredService<SelectQueryExpression>(), c => c.ForSelect().Use<SelectQueryExpression>()));
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IQueryExpressionFactory>();

            //when
            var exp1 = factory.CreateQueryExpression<SelectQueryExpression>();
            var exp2 = factory.CreateQueryExpression<SelectQueryExpression>();

            //then
            exp1.Should().NotBe(exp2);
        }

        [Fact]
        public void Does_configuration_of_a_subtyped_query_expression_using_default_factory_and_delegate_succeed_when_creating_select_query_expression()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.QueryExpressions.ForQueryTypes(c => c.ForQueryType<SelectQueryExpression>().Use(sp => new TestTestSelectQueryExpression())));

            //when
            var exp = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IQueryExpressionFactory>().CreateQueryExpression<SelectQueryExpression>();

            //then
            exp.Should().NotBeNull();
            exp.Should().BeOfType<TestTestSelectQueryExpression>();
        }

        [Fact]
        public void Does_configuration_of_a_subtyped_query_expression_using_default_factory_and_delegate_succeed_when_creating_multiple_select_query_expressions_that_should_be_transients()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.QueryExpressions.ForQueryTypes(c => c.ForQueryType<SelectQueryExpression>().Use(() => new TestTestSelectQueryExpression())));
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IQueryExpressionFactory>();

            //when
            var exp1 = factory.CreateQueryExpression<SelectQueryExpression>();
            var exp2 = factory.CreateQueryExpression<SelectQueryExpression>();

            //then
            exp1.Should().NotBe(exp2);
        }

        [Fact]
        public void Does_configuration_of_a_subtyped_query_expression_using_default_factory_and_service_serviceProvider_succeed_when_creating_multiple_select_query_expressions_that_should_be_transients()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.QueryExpressions.ForQueryTypes(c => c.ForQueryType<SelectQueryExpression>().Use(sp => new TestTestSelectQueryExpression())));
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IQueryExpressionFactory>();

            //when
            var exp1 = factory.CreateQueryExpression<SelectQueryExpression>();
            var exp2 = factory.CreateQueryExpression<SelectQueryExpression>();

            //then
            exp1.Should().NotBe(exp2);
        }

        public class NoOpQueryExpressionFactory : IQueryExpressionFactory
        {
            public QueryExpression CreateQueryExpression(Type queryType)
                => throw new NotImplementedException();

            public TQuery CreateQueryExpression<TQuery>()
                where TQuery : QueryExpression, new()
                => throw new NotImplementedException();
        }

        public class TestQueryExpressionFactory : IQueryExpressionFactory
        {
            public QueryExpression CreateQueryExpression(Type queryType)
            {
                QueryCount++;
                return new SelectQueryExpression();
            }

            public TQuery CreateQueryExpression<TQuery>()
                where TQuery : QueryExpression, new()
            {
                QueryCount++;
                return new();
            }

            public int QueryCount { get; set; }
        }

        public class TestSelectQueryExpression : SelectQueryExpression { }

        public class TestTestSelectQueryExpression : TestSelectQueryExpression { }
    }
}

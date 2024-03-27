using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Configuration;
using DbExpression.Sql;
using DbExpression.Sql.Configuration;
using DbExpression.Sql.Connection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DbExpression.MsSql.Test.Unit.Configuration
{
    public class ConnectionStringConfigurationTests : TestBase
    {
        [Fact]
        public void Does_passing_no_op_configuration_action_to_configuration_cause_expected_exception()
        {
            //given & when & then
            var services = new ServiceCollection();
            services.AddDbExpression(dbex => dbex.AddDatabase<v2019MsSqlDb>(c => { }));
            var serviceProvider = services.BuildServiceProvider();
            Assert.Throws<DbExpressionConfigurationException>(() => serviceProvider.GetRequiredService<v2019MsSqlDb>());
        }

        [Fact]
        public void Does_setting_connection_string_to_null_throw_correct_exception_when_resolved()
        {
            //given, when & then
            var ex = Assert.Throws<DbExpressionConfigurationException>(() => Configure<v2019MsSqlDb>(c => c.ConnectionString.Use((string?)null!)));
        }

        [Fact]
        public void Does_configuration_using_null_delegate_throw_expected_exception()
        {
            //given & when & then
            Assert.Throws<DbExpressionConfigurationException>(() => Configure<v2019MsSqlDb>(builder => builder.ConnectionString.Use((Func<string>)null!)));
        }

        [Fact]
        public void Does_configuration_using_delegate_returning_null_throw_expected_exception()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.ConnectionString.Use<NoOpConnectionStringFactory>());

            //when & then
            Assert.Throws<NotImplementedException>(() => serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IConnectionStringFactory>().GetConnectionString());
        }

        [Fact]
        public void Does_configuration_of_a_connection_string_factory_using_generic_rsolve_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.ConnectionString.Use<NoOpConnectionStringFactory>());

            //when
            var resolved = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<IConnectionStringFactory>();

            //then
            resolved.Should().BeOfType<NoOpConnectionStringFactory>();
        }

        [Fact]
        public void Does_configuration_of_a_connection_string_factory_using_instance_resolve_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.ConnectionString.Use("abc"));

            //when
            var resolved = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IConnectionStringFactory>().GetConnectionString();

            //then
            resolved.Should().Be("abc");
        }

        [Fact]
        public void Does_configuration_of_a_connection_string_factory_using_instance_resolve_transients()
        {
            //given
            var values = Enumerable.Range(0, 5);
            var factory = new ConnectionStringFactory(values.ToList());
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.ConnectionString.Use(sp => factory));
            var resolvedFactory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IConnectionStringFactory>();

            //when
            var resolved = new List<string>();
            for (var i = 0; i < values.Count(); i++)
                resolved.Add(resolvedFactory.GetConnectionString());

            //then
            resolved.Should().OnlyHaveUniqueItems().And.BeInAscendingOrder();
        }

        public class NoOpConnectionStringFactory : IConnectionStringFactory
        {
            public string GetConnectionString()
            {
                throw new NotImplementedException();
            }
        }

        public class ConnectionStringFactory : IConnectionStringFactory
        {
            private List<int> values;
            private int currentIndex = -1;

            public ConnectionStringFactory(List<int> values)
            {
                this.values = values;
            }

            public string GetConnectionString()
            {
                currentIndex++;
                return values[currentIndex].ToString();
            }
        }
    }
}

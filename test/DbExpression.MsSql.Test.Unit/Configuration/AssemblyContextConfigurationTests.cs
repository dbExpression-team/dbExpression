using v2019DbEx.DataService;
using FluentAssertions;
using DbExpression.MsSql.Configuration;
using DbExpression.Sql;
using DbExpression.Sql.Assembler;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace DbExpression.MsSql.Test.Unit.Configuration
{
    public class AssemblyContextConfigurationTests : TestBase
    {
        [Fact]
        public void Assembly_context_resolved_from_service_provider_should_be_transient()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var a1 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<AssemblyContext>();
            var a2 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<AssemblyContext>();

            //then
            a1.Should().NotBe(a2);
        }

        [Fact]
        public void Does_configuration_for_appender_factory_using_null_configuration_action_throw_expected_exception()
        {
            //given & when & then
            Assert.Throws<DbExpressionConfigurationException>(() => Configure<v2019MsSqlDb>(builder => builder.SqlStatements.Assembly.ConfigureAssemblyOptions(null!)));
        }

        [Fact]
        public void Does_configuration_for_appender_output_settings_with_configuration_action_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.SqlStatements.Assembly.ConfigureAssemblyOptions(a => a.IdentifierDelimiter.Begin = '&'));

            //when & then
            serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<AssemblyContext>().IdentifierDelimiter.Begin.Should().Be('&');
        }

        [Fact]
        public void Assembly_context_should_be_transient_when_resolved()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var a1 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<AssemblyContext>();
            var a2 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<AssemblyContext>();

            //then
            a1.Should().NotBe(a2);
        }

        [Fact]
        public void Assembly_context_with_custom_configuration_should_be_transient_when_resolved()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.SqlStatements.Assembly.ConfigureAssemblyOptions(a => a.IdentifierDelimiter.Begin = '&'));

            //when
            var a1 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<AssemblyContext>();
            var a2 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<AssemblyContext>();

            //then
            a1.Should().NotBe(a2);
        }
    }
}

using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Configuration
{
    public class AssemblyContextConfigurationTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Assembly_context_resolved_from_service_provider_should_be_transient(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<AssemblyContext>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<AssemblyContext>();

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_for_appender_factory_using_null_configuration_action_throw_expected_exception(int version)
        {
            //given & when & then
            Assert.Throws<DbExpressionConfigurationException>(() => Configure<MsSqlDb>().ForMsSqlVersion(version, builder => builder.SqlStatements.Assembly.ConfigureAssemblyOptions(null!)));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_for_appender_output_settings_with_configuration_action_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, builder => builder.SqlStatements.Assembly.ConfigureAssemblyOptions(a => a.IdentifierDelimiter.Begin = '&'));

            //when & then
            serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<AssemblyContext>().IdentifierDelimiter.Begin.Should().Be('&');
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Assembly_context_should_be_transient_when_resolved(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<AssemblyContext>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<AssemblyContext>();

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Assembly_context_with_custom_configuration_should_be_transient_when_resolved(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, builder => builder.SqlStatements.Assembly.ConfigureAssemblyOptions(a => a.IdentifierDelimiter.Begin = '&'));

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<AssemblyContext>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<AssemblyContext>();

            //then
            a1.Should().NotBe(a2);
        }
    }
}

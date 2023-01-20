using DbExAlt.DataService;
using DbExAlt.dboAltDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit
{
    public class MetadataProviderTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_metadata_provider_resolve_entity_metadata_successfully_for_overridden_entity_name(int version)
        {
            //given
            var (mssqldbAlt, serviceProvider) = Configure<MsSqlDbAlt>().ForMsSqlVersion(version);

            //when
            var meta = serviceProvider.GetServiceProviderFor<MsSqlDbAlt>().GetRequiredService<ISqlDatabaseMetadataProvider>().GetMetadata<ISqlMetadata>((dboAlt.PersonAlt as ISqlMetadataIdentifierProvider).Identifier);

            //then
            meta.Should().NotBeNull();
            meta!.Name.Should().Be("Person");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_metadata_provider_resolve_field_metadata_successfully_for_overridden_field_name(int version)
        {
            //given
            var (mssqldbAlt, serviceProvider) = Configure<MsSqlDbAlt>().ForMsSqlVersion(version);

            //when
            var meta = serviceProvider.GetServiceProviderFor<MsSqlDbAlt>().GetRequiredService<ISqlDatabaseMetadataProvider>().GetMetadata<ISqlMetadata>((dboAlt.PersonAlt.FirstNameAlt as ISqlMetadataIdentifierProvider).Identifier);

            //then
            meta.Should().NotBeNull();
            meta!.Name.Should().Be("FirstName");
        }
    }
}

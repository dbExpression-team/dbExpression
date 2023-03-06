using FluentAssertions;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql;
using Microsoft.Extensions.DependencyInjection;
using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit
{
    public class MetadataProviderTests : TestBase
    {
        [Fact]
        public void Can_metadata_provider_resolve_entity_metadata_successfully_for_entity_name()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var meta = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<ISqlDatabaseMetadataProvider>().GetMetadata<ISqlMetadata>((dbo.Person as ISqlMetadataIdentifierProvider).Identifier);

            //then
            meta.Should().NotBeNull();
            meta!.Name.Should().Be("Person");
        }

        [Fact]
        public void Can_metadata_provider_resolve_field_metadata_successfully_for_field_name()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var meta = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<ISqlDatabaseMetadataProvider>().GetMetadata<ISqlMetadata>((dbo.Person.FirstName as ISqlMetadataIdentifierProvider).Identifier);

            //then
            meta.Should().NotBeNull();
            meta!.Name.Should().Be("FirstName");
        }
    }
}

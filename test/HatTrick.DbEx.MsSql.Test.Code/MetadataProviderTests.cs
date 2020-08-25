using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Code
{
    public class MetadataProviderTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_resolve_metadata_for_a_schema(int version, string identifier = "MsSqlDbExTest.dbo")
        {
            //given
            var config = ConfigureForMsSqlVersion(version);

            var schemaMetadata = config.MetadataProvider.FindSchemaMetadata(identifier);

            //then
            schemaMetadata.Should().BeOfType<dboSchemaMetadata>($"'{identifier}' is a valid identifier");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_resolve_metadata_for_an_entity(int version, string identifier = "MsSqlDbExTest.dbo.Address")
        {
            //given
            var config = ConfigureForMsSqlVersion(version);

            var entityMetadata = config.MetadataProvider.FindEntityMetadata(identifier);

            //then
            entityMetadata.Should().BeOfType<AddressEntityMetadata>($"'{identifier}' is a valid identifier");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_resolve_metadata_for_an_entity_that_was_generated_with_name_override(int version, string identifier = "MsSqlDbExTest.dbo.Person_Address")
        {
            //given
            var config = ConfigureForMsSqlVersion(version);

            var entityMetadata = config.MetadataProvider.FindEntityMetadata(identifier);

            //then
            entityMetadata.Should().BeOfType<PersonAddressEntityMetadata>($"'{identifier}' is a valid identifier");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_resolve_metadata_for_a_field(int version, string identifier = "MsSqlDbExTest.dbo.Address.Id")
        {
            //given
            var config = ConfigureForMsSqlVersion(version);

            var fieldMetadata = config.MetadataProvider.FindFieldMetadata(identifier);

            //then
            fieldMetadata.Should().BeOfType<MsSqlFieldMetadata>($"'{identifier}' is a valid identifier");
        }
    }
}

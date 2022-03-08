using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.Sql;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Code.Configuration
{
    public class SchemaMetadataConfigurationBuilderTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_using_instance_method_with_null_instance_throw_expected_exception(int version)
        {
            //given & when & then
            Assert.Throws<ArgumentNullException>(() => ConfigureForMsSqlVersion(version, builder => builder.SchemaMetadata.Use(null!)));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_schema_provider_using_generic_use_method_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.SchemaMetadata.Use<NoOpSchemaMetadataProvider>());

            //when
            var matchingType = config.MetadataProvider is NoOpSchemaMetadataProvider;

            //then
            matchingType.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_schema_provider_using_instance_use_method_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.SchemaMetadata.Use(new NoOpSchemaMetadataProvider()));

            //when
            var matchingType = config.MetadataProvider is NoOpSchemaMetadataProvider;

            //then
            matchingType.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_schema_provider_using_generic_method_throw_appropriate_exception_when_accessing_for_database(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.SchemaMetadata.Use<NoOpSchemaMetadataProvider>());

            //when & then
            Assert.Throws<NotImplementedException>(() => config.MetadataProvider.Database);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_schema_provider_using_generic_method_throw_appropriate_exception_when_finding_schema_metadata(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.SchemaMetadata.Use<NoOpSchemaMetadataProvider>());

            //when & then
            Assert.Throws<NotImplementedException>(() => config.MetadataProvider.FindSchemaMetadata(nameof(dbo)));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_schema_provider_using_generic_method_throw_appropriate_exception_when_finding_entity_metadata(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.SchemaMetadata.Use<NoOpSchemaMetadataProvider>());

            //when & then
            Assert.Throws<NotImplementedException>(() => config.MetadataProvider.FindEntityMetadata((dbo.Person as ISqlMetadataIdentifierProvider).Identifier));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_schema_provider_using_generic_method_throw_appropriate_exception_when_finding_field_metadata(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.SchemaMetadata.Use<NoOpSchemaMetadataProvider>());

            //when & then
            Assert.Throws<NotImplementedException>(() => config.MetadataProvider.FindFieldMetadata((dbo.Person.Id as ISqlMetadataIdentifierProvider).Identifier));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_schema_provider_using_instance_method_throw_appropriate_exception_when_accessing_for_database(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.SchemaMetadata.Use(new NoOpSchemaMetadataProvider()));

            //when & then
            Assert.Throws<NotImplementedException>(() => config.MetadataProvider.Database);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_schema_provider_using_instance_method_throw_appropriate_exception_when_finding_schema_metadata(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.SchemaMetadata.Use(new NoOpSchemaMetadataProvider()));

            //when & then
            Assert.Throws<NotImplementedException>(() => config.MetadataProvider.FindSchemaMetadata(nameof(dbo)));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_schema_provider_using_instance_method_throw_appropriate_exception_when_finding_entity_metadata(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.SchemaMetadata.Use(new NoOpSchemaMetadataProvider()));

            //when & then
            Assert.Throws<NotImplementedException>(() => config.MetadataProvider.FindEntityMetadata((dbo.Person as ISqlMetadataIdentifierProvider).Identifier));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_schema_provider_using_instance_method_throw_appropriate_exception_when_finding_field_metadata(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.SchemaMetadata.Use(new NoOpSchemaMetadataProvider()));

            //when & then
            Assert.Throws<NotImplementedException>(() => config.MetadataProvider.FindFieldMetadata((dbo.Person.Id as ISqlMetadataIdentifierProvider).Identifier));
        }

        public class NoOpSchemaMetadataProvider : ISqlDatabaseMetadataProvider
        {
            public ISqlDatabaseMetadata Database => throw new NotImplementedException();
            public ISqlEntityMetadata FindEntityMetadata(string identifier) => throw new NotImplementedException();
            public ISqlFieldMetadata FindFieldMetadata(string identifier) => throw new NotImplementedException();
            public ISqlSchemaMetadata FindSchemaMetadata(string identifier) => throw new NotImplementedException();
            public ISqlParameterMetadata FindParameterMetadata(string identifier) => throw new NotImplementedException();
        }
    }
}

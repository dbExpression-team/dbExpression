using DbEx.dboData;
using FluentAssertions;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Mapper;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Code.Configuration
{
    public class EntitiesConfigurationBuilderTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_using_instance_method_with_null_instance_throw_expected_exception(int version)
        {
            //given & when & then
            Assert.Throws<DbExpressionConfigurationException>(() => ConfigureForMsSqlVersion(version, builder => builder.Entities.Creation.Use((IEntityFactory)null!)));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_creation_factory_using_generic_use_method_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.Entities.Creation.Use<NoOpEntityFactory>());

            //when
            var matchingType = config.EntityFactory is NoOpEntityFactory;

            //then
            matchingType.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_creation_factory_using_instance_use_method_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.Entities.Creation.Use(new NoOpEntityFactory()));

            //when
            var matchingType = config.EntityFactory is NoOpEntityFactory;

            //then
            matchingType.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_creation_factory_using_default_use_method_succeed(int version)
        {
            //given

            var config = ConfigureForMsSqlVersion(version, builder => builder.Entities.Creation.UseDefaultFactory());

            //when
            var matchingType = config.EntityFactory is not null;

            //then
            matchingType.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_type_for_entity_creation_factory_using_generic_method_return_correct_converter_of_a_type_converter_override(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.Entities.Creation.UseDefaultFactory(x => x.OverrideForEntity(() => new Person { FirstName = "UseDefaultFactory" })));

            //when
            var person = config.EntityFactory.CreateEntity<Person>();

            //then
            person.FirstName.Should().Be("UseDefaultFactory");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_mapping_factory_using_generic_use_method_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.Entities.Mapping.Use<NoOpMapperFactory>());

            //when
            var matchingType = config.MapperFactory is NoOpMapperFactory;

            //then
            matchingType.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_mapping_factory_using_instance_use_method_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.Entities.Mapping.Use(new NoOpMapperFactory()));

            //when
            var matchingType = config.MapperFactory is NoOpMapperFactory;

            //then
            matchingType.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_mapping_factory_using_default_use_method_succeed(int version)
        {
            //given

            var config = ConfigureForMsSqlVersion(version, builder => builder.Entities.Mapping.UseDefaultFactory());

            //when
            var matchingType = config.MapperFactory is not null;

            //then
            matchingType.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_type_for_entity_mapping_factory_using_generic_method_return_correct_converter_of_a_type_converter_override(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.Entities.Creation.UseDefaultFactory(x => x.OverrideForEntity(() => new Person { FirstName = "UseDefaultFactory" })));

            //when
            var person = config.EntityFactory.CreateEntity<Person>();

            //then
            person.FirstName.Should().Be("UseDefaultFactory");
        }

        public class NoOpEntityFactory : IEntityFactory
        {
            T IEntityFactory.CreateEntity<T>() => throw new NotImplementedException();
        }

        public class NoOpMapperFactory : IMapperFactory
        {
            public IExpandoObjectMapper CreateExpandoObjectMapper() => throw new NotImplementedException();

            IEntityMapper<TEntity> IMapperFactory.CreateEntityMapper<TEntity>(Table<TEntity> entity) => throw new NotImplementedException();
        }
    }
}

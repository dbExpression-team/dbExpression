using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Mapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Configuration
{
    public class EntityMapperConfigurationTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_mapper_factory_using_instance_factory_with_null_instance_throw_expected_exception(int version)
        {
            //given & when & then
            Assert.Throws<DbExpressionConfigurationException>(() => ConfigureForMsSqlVersion(version, builder => builder.Entities.Mapping.Use((IMapperFactory<MsSqlDb>)null!)));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_mapper_factory_using_generic_use_method_succeed(int version)
        {
            //given
            var provider = ConfigureForMsSqlVersion(version, builder => builder.Entities.Mapping.Use<NoOpMapperFactory>());

            //when
            var factory = provider.GetRequiredService<IMapperFactory<MsSqlDb>>() is NoOpMapperFactory;

            //then
            factory.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_mapper_factory_using_service_provider_and_new_instance_from_factory_succeed(int version)
        {
            //given
            var provider = ConfigureForMsSqlVersion(version, builder => builder.Entities.Mapping.Use(sp => new NoOpMapperFactory()));

            //when
            var factory = provider.GetRequiredService<IMapperFactory<MsSqlDb>>() is NoOpMapperFactory;

            //then
            factory.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_mapper_factory_using_service_provider_and_type_returning_new_instance_of_entity_should_succeed(int version)
        {
            //given
            var provider = ConfigureForMsSqlVersion(version, builder => builder.Entities.Mapping.Use((sp, t) => new NoOpEntityMapper<Person>()));

            //when
            var factory = provider.GetRequiredService<IMapperFactory<MsSqlDb>>().CreateEntityMapper<Person>(dbo.Person);

            //then
            factory.Should().NotBeNull().And.BeOfType<NoOpEntityMapper<Person>>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_mapping_factory_using_instance_method_resolve_correctly(int version)
        {
            //given
            var provider = ConfigureForMsSqlVersion(version, builder => builder.Entities.Mapping.Use(t => new NoOpEntityMapper<Person>()));
            var factory = provider.GetRequiredService<IMapperFactory<MsSqlDb>>();

            //when
            var matchingType = factory.CreateEntityMapper<Person>(dbo.Person) is NoOpEntityMapper<Person>;

            //then
            matchingType.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_mapping_factory_using_service_provider_and_instance_method_resolve_correctly(int version)
        {
            //given
            var provider = ConfigureForMsSqlVersion(version, builder => builder.Entities.Mapping.Use((sp, t) => new NoOpEntityMapper<Person>()));
            var factory = provider.GetRequiredService<IMapperFactory<MsSqlDb>>();

            //when
            var matchingType = factory.CreateEntityMapper<Person>(dbo.Person) is NoOpEntityMapper<Person>;

            //then
            matchingType.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_mapping_factory_using_defaults_resolve_correctly(int version)
        {
            //given
            var provider = ConfigureForMsSqlVersion(version);
            var factory = provider.GetRequiredService<IMapperFactory<MsSqlDb>>();

            //when
            var mapper = factory.CreateEntityMapper<Person>(dbo.Person);

            //then
            mapper.Should().NotBeNull().And.BeOfType<EntityMapper<Person>>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_default_entity_mapping_factory_using_service_provider_and_new_instance_from_factory_resolve_as_singleton(int version)
        {
            //given
            var provider = ConfigureForMsSqlVersion(version);

            //when
            var a1 = provider.GetRequiredService<IMapperFactory<MsSqlDb>>();
            var a2 = provider.GetRequiredService<IMapperFactory<MsSqlDb>>();

            //then
            a1.Should().Be(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_mapping_factory_using_service_provider_and_new_instance_from_factory_resolve_as_singleton(int version)
        {
            //given
            var provider = ConfigureForMsSqlVersion(version, builder => builder.Entities.Mapping.Use(sp => new EntityMapper<Person>((dbo.Person as Table<Person>).HydrateEntity)));

            //when
            var a1 = provider.GetRequiredService<IMapperFactory<MsSqlDb>>();
            var a2 = provider.GetRequiredService<IMapperFactory<MsSqlDb>>();

            //then
            a1.Should().Be(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_mapping_factory_using_service_provider_and_type_and_new_instance_from_factory_resolve_as_singleton(int version)
        {
            //given
            var provider = ConfigureForMsSqlVersion(version, builder => builder.Entities.Mapping.Use((sp, t) => new EntityMapper<Person>((dbo.Person as Table<Person>).HydrateEntity)));

            //when
            var a1 = provider.GetRequiredService<IMapperFactory<MsSqlDb>>();
            var a2 = provider.GetRequiredService<IMapperFactory<MsSqlDb>>();

            //then
            a1.Should().Be(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_mapping_factory_using_service_provider_and_new_instance_from_factory_resolve_transient_entity_mappers(int version)
        {
            //given
            var provider = ConfigureForMsSqlVersion(version, builder => builder.Entities.Mapping.Use((sp, t) => new EntityMapper<Person>((dbo.Person as Table<Person>).HydrateEntity)));
            var factory = provider.GetRequiredService<IMapperFactory<MsSqlDb>>();

            //when
            var a1 = factory.CreateEntityMapper<Person>(dbo.Person);
            var a2 = factory.CreateEntityMapper<Person>(dbo.Person);

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_default_entity_mapping_factory_using_service_provider_resolve_singleton_entity_mappers(int version)
        {
            //given
            var provider = ConfigureForMsSqlVersion(version);
            var factory = provider.GetRequiredService<IMapperFactory<MsSqlDb>>();

            //when
            var a1 = factory.CreateEntityMapper<Person>(dbo.Person);
            var a2 = factory.CreateEntityMapper<Person>(dbo.Person);

            //then
            a1.Should().Be(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_mapping_factory_using_service_provider_and_same_instance_from_factory_resolve_singleton_entity_mappers(int version)
        {
            //given
            var impl = new EntityMapper<Person>((dbo.Person as Table<Person>).HydrateEntity);
            var provider = ConfigureForMsSqlVersion(version, builder => builder.Entities.Mapping.Use((sp, t) => impl));
            var factory = provider.GetRequiredService<IMapperFactory<MsSqlDb>>();

            //when
            var a1 = factory.CreateEntityMapper<Person>(dbo.Person);
            var a2 = factory.CreateEntityMapper<Person>(dbo.Person);

            //then
            a1.Should().Be(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_default_entity_mapping_factory_using_service_provider_resolve_singleton_expando_object_mappers(int version)
        {
            //given
            var provider = ConfigureForMsSqlVersion(version);
            var factory = provider.GetRequiredService<IMapperFactory<MsSqlDb>>();

            //when
            var a1 = factory.CreateExpandoObjectMapper();
            var a2 = factory.CreateExpandoObjectMapper();

            //then
            a1.Should().Be(a2);
        }

        public class NoOpEntityMapper<TEntity> : IEntityMapper<TEntity>
            where TEntity : class, IDbEntity, new()
        {
            public Action<ISqlFieldReader, TEntity> Map { get; } = null!;
            Action<ISqlFieldReader, IDbEntity> IEntityMapper.Map { get; } = null!;
        }

        public class NoOpMapperFactory : IMapperFactory<MsSqlDb>
        {
            public IExpandoObjectMapper CreateExpandoObjectMapper()
            {
                throw new NotImplementedException();
            }

            IEntityMapper<TEntity> IMapperFactory<MsSqlDb>.CreateEntityMapper<TEntity>(Table<TEntity> entity)
            {
                throw new NotImplementedException();
            }
        }
    }
}

﻿using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Configuration;
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
            Assert.Throws<DbExpressionConfigurationException>(() => Configure<MsSqlDb>().ForMsSqlVersion(version, builder => builder.Entities.Mapping.Use((IMapperFactory)null!)));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_mapper_factory_using_generic_use_method_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, builder => builder.Entities.Mapping.Use<NoOpMapperFactory>());

            //when
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IMapperFactory>() is NoOpMapperFactory;

            //then
            factory.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_mapper_factory_using_service_serviceProvider_and_new_instance_from_factory_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, builder => builder.Entities.Mapping.Use(sp => new NoOpMapperFactory()));

            //when
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IMapperFactory>() is NoOpMapperFactory;

            //then
            factory.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_mapper_factory_using_service_serviceProvider_and_type_returning_new_instance_of_entity_should_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, builder => builder.Entities.Mapping.Use((sp, t) => new NoOpEntityMapper<Person>()));

            //when
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IMapperFactory>().CreateEntityMapper<Person>(dbo.Person);

            //then
            factory.Should().NotBeNull().And.BeOfType<NoOpEntityMapper<Person>>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_mapping_factory_using_instance_method_resolve_correctly(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, builder => builder.Entities.Mapping.Use(t => new NoOpEntityMapper<Person>()));
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IMapperFactory>();

            //when
            var matchingType = factory.CreateEntityMapper<Person>(dbo.Person) is NoOpEntityMapper<Person>;

            //then
            matchingType.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_mapping_factory_using_service_serviceProvider_and_instance_method_resolve_correctly(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, builder => builder.Entities.Mapping.Use((sp, t) => new NoOpEntityMapper<Person>()));
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IMapperFactory>();

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
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IMapperFactory>();

            //when
            var mapper = factory.CreateEntityMapper<Person>(dbo.Person);

            //then
            mapper.Should().NotBeNull().And.BeOfType<EntityMapper<Person>>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_default_entity_mapping_factory_using_service_serviceProvider_and_new_instance_from_factory_resolve_as_singleton(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IMapperFactory>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IMapperFactory>();

            //then
            a1.Should().Be(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_mapping_factory_using_service_serviceProvider_and_new_instance_from_factory_resolve_as_singleton(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, builder => builder.Entities.Mapping.Use(sp => new EntityMapper<Person>((dbo.Person as Table<Person>).HydrateEntity)));

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IMapperFactory>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IMapperFactory>();

            //then
            a1.Should().Be(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_mapping_factory_using_service_serviceProvider_and_type_and_new_instance_from_factory_resolve_as_singleton(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, builder => builder.Entities.Mapping.Use((sp, t) => new EntityMapper<Person>((dbo.Person as Table<Person>).HydrateEntity)));

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IMapperFactory>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IMapperFactory>();

            //then
            a1.Should().Be(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_mapping_factory_using_service_serviceProvider_and_new_instance_from_factory_resolve_transient_entity_mappers(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, builder => builder.Entities.Mapping.Use((sp, t) => new EntityMapper<Person>((dbo.Person as Table<Person>).HydrateEntity)));
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IMapperFactory>();

            //when
            var a1 = factory.CreateEntityMapper<Person>(dbo.Person);
            var a2 = factory.CreateEntityMapper<Person>(dbo.Person);

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_default_entity_mapping_factory_using_service_serviceProvider_resolve_singleton_entity_mappers(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IMapperFactory>();

            //when
            var a1 = factory.CreateEntityMapper<Person>(dbo.Person);
            var a2 = factory.CreateEntityMapper<Person>(dbo.Person);

            //then
            a1.Should().Be(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_mapping_factory_using_service_serviceProvider_and_same_instance_from_factory_resolve_singleton_entity_mappers(int version)
        {
            //given
            var impl = new EntityMapper<Person>((dbo.Person as Table<Person>).HydrateEntity);
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, builder => builder.Entities.Mapping.Use((sp, t) => impl));
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IMapperFactory>();

            //when
            var a1 = factory.CreateEntityMapper<Person>(dbo.Person);
            var a2 = factory.CreateEntityMapper<Person>(dbo.Person);

            //then
            a1.Should().Be(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_default_entity_mapping_factory_using_service_serviceProvider_resolve_singleton_expando_object_mappers(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IMapperFactory>();

            //when
            var a1 = factory.CreateExpandoObjectMapper();
            var a2 = factory.CreateExpandoObjectMapper();

            //then
            a1.Should().Be(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_default_entity_mapping_factory_and_override_for_entity_type_using_instance_resolve_same_instance(int version)
        {
            //given
            var impl = new EntityMapper<Person>((dbo.Person as Table<Person>).HydrateEntity);
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, builder => builder.Entities.Mapping.ForEntityTypes(c => c.ForEntityType<Person>().Use(impl)));
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IMapperFactory>();

            //when
            var a1 = factory.CreateEntityMapper<Person>(dbo.Person);

            //then
            a1.Should().Be(impl);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_default_entity_mapping_factory_and_override_for_entity_type_using_delegate_resolve_same_instance(int version)
        {
            //given
            EntityMapper<Person>? impl = null;
            Func<IEntityMapper<Person>> mapper = () => { impl = new EntityMapper<Person>((dbo.Person as Table<Person>).HydrateEntity); return impl; };
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, builder => builder.Entities.Mapping.ForEntityTypes(c => c.ForEntityType<Person>().Use(() => mapper())));
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IMapperFactory>();

            //when
            var a1 = factory.CreateEntityMapper<Person>(dbo.Person);

            //then
            a1.Should().Be(impl);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_default_entity_mapping_factory_and_override_for_entity_type_using_service_provider_resolve_same_instance(int version)
        {
            //given
            EntityMapper<Person>? impl = null;
            Func<IEntityMapper<Person>> mapper = () => { impl = new EntityMapper<Person>((dbo.Person as Table<Person>).HydrateEntity); return impl; };
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, builder => builder.Entities.Mapping.ForEntityTypes(c => c.ForEntityType<Person>().Use(sp => mapper())));
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IMapperFactory>();

            //when
            var a1 = factory.CreateEntityMapper<Person>(dbo.Person);

            //then
            a1.Should().Be(impl);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_default_entity_mapping_factory_and_override_for_entity_type_using_generic_resolve_same_type(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, builder => builder.Entities.Mapping.ForEntityTypes(c => c.ForEntityType<Person>().Use<NoOpEntityMapper<Person>>()));
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IMapperFactory>();

            //when
            var a1 = factory.CreateEntityMapper<Person>(dbo.Person);

            //then
            a1.Should().BeOfType<NoOpEntityMapper<Person>>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_default_entity_mapping_factory_and_override_for_entity_type_using_delegate_for_reader_map_correctly(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, builder => builder.Entities.Mapping.ForEntityTypes(c => c.ForEntityType<Person>().Use((reader, person) => person.FirstName = "Bob")));
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IMapperFactory>();
            var a1 = factory.CreateEntityMapper<Person>(dbo.Person);
            var person = new Person() { FirstName = "Mary" };

            //when
            a1.Map((ISqlFieldReader)null!, person);

            //then
            person.FirstName.Should().Be("Bob");
        }

        public class NoOpEntityMapper<TEntity> : IEntityMapper<TEntity>
            where TEntity : class, IDbEntity, new()
        {
            public Action<ISqlFieldReader, TEntity> Map { get; } = null!;
            Action<ISqlFieldReader, IDbEntity> IEntityMapper.Map { get; } = null!;
        }

        public class NoOpMapperFactory : IMapperFactory
        {
            public IExpandoObjectMapper CreateExpandoObjectMapper()
            {
                throw new NotImplementedException();
            }

            IEntityMapper<TEntity> IMapperFactory.CreateEntityMapper<TEntity>(Table<TEntity> entity)
            {
                throw new NotImplementedException();
            }
        }
    }
}

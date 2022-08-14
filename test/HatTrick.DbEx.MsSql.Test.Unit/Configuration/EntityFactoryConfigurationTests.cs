using DbEx.DataService;
using DbEx.dboData;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Mapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Configuration
{
    public class EntityFactoryConfigurationTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_using_instance_method_with_null_instance_throw_expected_exception(int version)
        {
            //given & when & then
            Assert.Throws<DbExpressionConfigurationException>(() => ConfigureForMsSqlVersion<MsSqlDb>(version, builder => builder.Entities.Creation.Use((IEntityFactory<MsSqlDb>)null!)));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_creation_factory_using_generic_use_method_succeed(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, builder => builder.Entities.Creation.Use<NoOpEntityFactory>());

            //when
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IEntityFactory<MsSqlDb>>() is NoOpEntityFactory;

            //then
            factory.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_creation_factory_using_service_serviceProvider_and_new_instance_from_factory_succeed(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, builder => builder.Entities.Creation.Use(sp => new NoOpEntityFactory()));

            //when
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IEntityFactory<MsSqlDb>>() is NoOpEntityFactory;

            //then
            factory.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_creation_factory_using_service_serviceProvider_and_type_returning_new_instance_of_entity_should_succeed(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, builder => builder.Entities.Creation.Use((sp, t) => new Person()));

            //when
            var entity = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IEntityFactory<MsSqlDb>>().CreateEntity<Person>();

            //then
            entity.Should().NotBeNull().And.BeOfType<Person>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_creation_factory_using_service_serviceProvider_and_type_with_additional_override_resolve_correctly(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, builder => builder.Entities.Creation.Use((sp, t) => sp.GetRequiredService<Person>(), c => c.ForEntityType<Person>().Use(() => new Person() { FirstName = "override" })));

            //when
            var entity = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IEntityFactory<MsSqlDb>>().CreateEntity<Person>();

            //then
            entity.Should().NotBeNull().And.BeOfType<Person>().Which.FirstName.Should().Be("override");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_creation_factory_using_instance_method_succeed(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, builder => builder.Entities.Creation.Use(new NoOpEntityFactory()));

            //when
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IEntityFactory<MsSqlDb>>() is NoOpEntityFactory;

            //then
            factory.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_creation_factory_using_service_serviceProvider_and_instance_method_succeed(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, builder => builder.Entities.Creation.Use(sp => new NoOpEntityFactory()));

            //when
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IEntityFactory<MsSqlDb>>() is NoOpEntityFactory;

            //then
            factory.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_creation_factory_using_default_use_method_succeed(int version)
        {
            //given

            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            //when
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IEntityFactory<MsSqlDb>>() is not null;

            //then
            factory.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_type_for_entity_creation_factory_using_generic_method_return_correct_converter_of_a_type_converter_override(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, builder => builder.Entities.Creation.ForEntityTypes(x => x.ForEntityType<Person>().Use(sp => new Person { FirstName = "UseThis" })));

            //when
            var person = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IEntityFactory<MsSqlDb>>().CreateEntity<Person>();

            //then
            person.FirstName.Should().Be("UseThis");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_mapping_factory_using_generic_use_method_succeed(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, builder => builder.Entities.Mapping.Use<NoOpMapperFactory>());

            //when
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IMapperFactory<MsSqlDb>>() is NoOpMapperFactory;

            //then
            factory.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_mapping_factory_using_instance_use_method_succeed(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, builder => builder.Entities.Mapping.Use(new NoOpMapperFactory()));

            //when
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IMapperFactory<MsSqlDb>>() is NoOpMapperFactory;

            //then
            factory.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_mapping_factory_using_default_use_method_succeed(int version)
        {
            //given

            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            //when
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IMapperFactory<MsSqlDb>>() is not null;

            //then
            factory.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_type_for_entity_mapping_factory_using_generic_method_return_correct_converter_of_a_type_converter_override(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, builder => builder.Entities.Creation.ForEntityTypes(x => x.ForEntityType<Person>().Use(sp => new Person { FirstName = "UseDefaultFactory" })));

            //when
            var person = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IEntityFactory<MsSqlDb>>().CreateEntity<Person>();

            //then
            person.FirstName.Should().Be("UseDefaultFactory");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_creation_factory_using_service_serviceProvider_and_new_instance_from_factory_resolve_as_transient(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, builder => builder.Entities.Creation.Use(sp => new NoOpEntityFactory()));

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IEntityFactory<MsSqlDb>>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IEntityFactory<MsSqlDb>>();

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_creation_factory_generically_regsistered_resolve_as_singleton(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, builder => builder.Entities.Creation.Use<NoOpEntityFactory>());

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IEntityFactory<MsSqlDb>>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IEntityFactory<MsSqlDb>>();

            //then
            a1.Should().Be(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_creation_factory_regsistered_with_instance_resolve_as_singleton(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, builder => builder.Entities.Creation.Use(new NoOpEntityFactory()));

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IEntityFactory<MsSqlDb>>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IEntityFactory<MsSqlDb>>();

            //then
            a1.Should().Be(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_entity_creation_factory_regsistered_with_factory_with_override_for_specific_entity_type_resolve_correctly_and_as_transient(int version)
        {
            //given
            var factory = new DelegateEntityFactory<MsSqlDb>(t => new Person());
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, builder => builder.Entities.Creation.Use(sp => factory, c => c.ForEntityType<Person>().Use(() => new Person { FirstName = "x" })));

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<Person>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<Person>();

            //then
            a1.Should().NotBe(a2);
            a1.FirstName.Should().Be("x");
            a2.FirstName.Should().Be("x");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void An_entity_resolved_via_service_serviceProvider_and_type_should_be_transient(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, builder => builder.Entities.Creation.Use((sp, t) => new Person()));

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IEntityFactory<MsSqlDb>>().CreateEntity<Person>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IEntityFactory<MsSqlDb>>().CreateEntity<Person>();

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void An_entity_resolved_via_override_during_factory_configuration_for_entity_type_delegate_should_be_transient(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, builder => builder.Entities.Creation.Use((sp, t) => new Person() { FirstName = "base" }, c => c.ForEntityType<Person>().Use(() => new Person() { FirstName = "override" })));

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<Person>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<Person>();

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void An_entity_resolved_via_override_for_entity_type_delegate_should_be_transient(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, builder => builder.Entities.Creation.ForEntityTypes(x => x.ForEntityType<Person>().Use(sp => new Person { FirstName = "UseThis" })));

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<Person>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<Person>();

            //then
            a1.Should().NotBe(a2);
        }

        public class NoOpEntityFactory : IEntityFactory<MsSqlDb>
        {
            T IEntityFactory<MsSqlDb>.CreateEntity<T>() => throw new NotImplementedException();
        }

        public class NoOpMapperFactory : IMapperFactory<MsSqlDb>
        {
            public IExpandoObjectMapper CreateExpandoObjectMapper() => throw new NotImplementedException();

            IEntityMapper<TEntity> IMapperFactory<MsSqlDb>.CreateEntityMapper<TEntity>(Table<TEntity> entity) => throw new NotImplementedException();
        }
    }
}

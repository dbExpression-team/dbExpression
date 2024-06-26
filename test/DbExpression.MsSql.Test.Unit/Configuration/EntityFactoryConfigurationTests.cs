using v2019DbEx.DataService;
using v2019DbEx.dboData;
using FluentAssertions;
using DbExpression.MsSql.Configuration;
using DbExpression.Sql;
using DbExpression.Sql.Mapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace DbExpression.MsSql.Test.Unit.Configuration
{
    public class EntityFactoryConfigurationTests : TestBase
    {
        [Fact]
        public void Does_configuration_using_instance_method_with_null_instance_throw_expected_exception()
        {
            //given & when & then
            Assert.Throws<DbExpressionConfigurationException>(() => Configure<v2019MsSqlDb>(builder => builder.Entities.Creation.Use((IEntityFactory)null!)));
        }

        [Fact]
        public void Does_configuration_of_a_entity_creation_factory_using_generic_use_method_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.Entities.Creation.Use<NoOpEntityFactory>());

            //when
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IEntityFactory>() is NoOpEntityFactory;

            //then
            factory.Should().BeTrue();
        }

        [Fact]
        public void Does_configuration_of_a_entity_creation_factory_using_service_serviceProvider_and_new_instance_from_factory_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.Entities.Creation.Use(sp => new NoOpEntityFactory()));

            //when
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IEntityFactory>() is NoOpEntityFactory;

            //then
            factory.Should().BeTrue();
        }

        [Fact]
        public void Does_configuration_of_a_entity_creation_factory_using_service_serviceProvider_and_type_returning_new_instance_of_entity_should_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.Entities.Creation.Use((sp, t) => new Person()));

            //when
            var entity = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IEntityFactory>().CreateEntity<Person>();

            //then
            entity.Should().NotBeNull().And.BeOfType<Person>();
        }

        [Fact]
        public void Does_configuration_of_a_entity_creation_factory_using_service_serviceProvider_and_type_with_additional_override_resolve_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.Entities.Creation.Use((sp, t) => sp.GetRequiredService<Person>(), c => c.ForEntityType<Person>().Use(() => new Person() { FirstName = "override" })));

            //when
            var entity = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IEntityFactory>().CreateEntity<Person>();

            //then
            entity.Should().NotBeNull().And.BeOfType<Person>().Which.FirstName.Should().Be("override");
        }

        [Fact]
        public void Does_configuration_of_a_entity_creation_factory_using_instance_method_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.Entities.Creation.Use(new NoOpEntityFactory()));

            //when
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IEntityFactory>() is NoOpEntityFactory;

            //then
            factory.Should().BeTrue();
        }

        [Fact]
        public void Does_configuration_of_a_entity_creation_factory_using_service_serviceProvider_and_instance_method_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.Entities.Creation.Use(sp => new NoOpEntityFactory()));

            //when
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IEntityFactory>() is NoOpEntityFactory;

            //then
            factory.Should().BeTrue();
        }

        [Fact]
        public void Does_configuration_of_a_entity_creation_factory_using_default_use_method_succeed()
        {
            //given

            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IEntityFactory>() is not null;

            //then
            factory.Should().BeTrue();
        }

        [Fact]
        public void Does_configuration_of_type_for_entity_creation_factory_using_generic_method_return_correct_converter_of_a_type_converter_override()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.Entities.Creation.ForEntityTypes(x => x.ForEntityType<Person>().Use(sp => new Person { FirstName = "UseThis" })));

            //when
            var person = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IEntityFactory>().CreateEntity<Person>();

            //then
            person.FirstName.Should().Be("UseThis");
        }

        [Fact]
        public void Does_configuration_of_a_entity_mapping_factory_using_generic_use_method_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.Entities.Mapping.Use<NoOpMapperFactory>());

            //when
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IMapperFactory>() is NoOpMapperFactory;

            //then
            factory.Should().BeTrue();
        }

        [Fact]
        public void Does_configuration_of_a_entity_mapping_factory_using_instance_use_method_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.Entities.Mapping.Use(new NoOpMapperFactory()));

            //when
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IMapperFactory>() is NoOpMapperFactory;

            //then
            factory.Should().BeTrue();
        }

        [Fact]
        public void Does_configuration_of_a_entity_mapping_factory_using_default_use_method_succeed()
        {
            //given

            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IMapperFactory>() is not null;

            //then
            factory.Should().BeTrue();
        }

        [Fact]
        public void Does_configuration_of_type_for_entity_mapping_factory_using_generic_method_return_correct_converter_of_a_type_converter_override()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.Entities.Creation.ForEntityTypes(x => x.ForEntityType<Person>().Use(sp => new Person { FirstName = "UseDefaultFactory" })));

            //when
            var person = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IEntityFactory>().CreateEntity<Person>();

            //then
            person.FirstName.Should().Be("UseDefaultFactory");
        }

        [Fact]
        public void Does_configuration_of_a_entity_creation_factory_using_service_provider_and_new_instance_from_factory_resolve_as_transient()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.Entities.Creation.Use(sp => new NoOpEntityFactory()));

            //when
            var a1 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IEntityFactory>();
            var a2 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IEntityFactory>();

            //then
            a1.Should().Be(a2);
        }

        [Fact]
        public void Does_configuration_of_a_entity_creation_factory_generically_regsistered_resolve_as_singleton()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.Entities.Creation.Use<NoOpEntityFactory>());

            //when
            var a1 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IEntityFactory>();
            var a2 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IEntityFactory>();

            //then
            a1.Should().Be(a2);
        }

        [Fact]
        public void Does_configuration_of_a_entity_creation_factory_regsistered_with_instance_resolve_as_singleton()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.Entities.Creation.Use(new NoOpEntityFactory()));

            //when
            var a1 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IEntityFactory>();
            var a2 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IEntityFactory>();

            //then
            a1.Should().Be(a2);
        }

        [Fact]
        public void Does_configuration_of_a_entity_creation_factory_regsistered_with_factory_with_override_for_specific_entity_type_resolve_correctly_and_as_transient()
        {
            //given
            var factory = new DelegateEntityFactory(t => new Person());
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.Entities.Creation.Use(sp => factory, c => c.ForEntityType<Person>().Use(() => new Person { FirstName = "x" })));

            //when
            var a1 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<Person>();
            var a2 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<Person>();

            //then
            a1.Should().NotBe(a2);
            a1.FirstName.Should().Be("x");
            a2.FirstName.Should().Be("x");
        }

        [Fact]
        public void An_entity_resolved_via_service_serviceProvider_and_type_should_be_transient()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.Entities.Creation.Use((sp, t) => new Person()));

            //when
            var a1 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IEntityFactory>().CreateEntity<Person>();
            var a2 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IEntityFactory>().CreateEntity<Person>();

            //then
            a1.Should().NotBe(a2);
        }

        [Fact]
        public void An_entity_resolved_via_override_during_factory_configuration_for_entity_type_delegate_should_be_transient()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.Entities.Creation.Use((sp, t) => new Person() { FirstName = "base" }, c => c.ForEntityType<Person>().Use(() => new Person() { FirstName = "override" })));

            //when
            var a1 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<Person>();
            var a2 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<Person>();

            //then
            a1.Should().NotBe(a2);
        }

        [Fact]
        public void An_entity_resolved_via_override_for_entity_type_delegate_should_be_transient()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(builder => builder.Entities.Creation.ForEntityTypes(x => x.ForEntityType<Person>().Use(sp => new Person { FirstName = "UseThis" })));

            //when
            var a1 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<Person>();
            var a2 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<Person>();

            //then
            a1.Should().NotBe(a2);
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

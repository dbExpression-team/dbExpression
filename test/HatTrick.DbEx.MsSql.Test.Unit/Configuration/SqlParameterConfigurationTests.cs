using v2019DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Configuration
{
    public class SqlParameterConfigurationTests : TestBase
    {
        [Fact]
        public void An_parameter_builder_registered_via_delegate_should_resolve_the_same_parameter_builder()
        {
            //given
            var builder = Substitute.For<ISqlParameterBuilder>();
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ParameterBuilder.Use(() => builder));

            //when
            var resolved = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<ISqlParameterBuilder>();

            //then
            resolved.Should().Be(builder);
        }

        [Fact]
        public void An_parameter_builder_registered_via_service_serviceProvider_should_resolve_the_same_parameter_builder()
        {
            //given
            var builder = Substitute.For<ISqlParameterBuilder>();
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ParameterBuilder.Use(sp => builder));

            //when
            var resolved = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<ISqlParameterBuilder>();

            //then
            resolved.Should().Be(builder);
        }

        [Fact]
        public void An_parameter_builder_registered_via_generic_should_resolve_the_same_parameter_builder()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ParameterBuilder.Use<NoOpSqlParameterBuilder>());

            //when
            var resolved = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<ISqlParameterBuilder>();

            //then
            resolved.Should().NotBeNull().And.BeOfType<NoOpSqlParameterBuilder>();
        }

        [Fact]
        public void An_parameter_builder_registering_an_instance_via_delegate_should_return_the_same_instance()
        {
            //given
            var builder = Substitute.For<ISqlParameterBuilder>();
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ParameterBuilder.Use(sp => builder));
            var factory = serviceProvider.GetService<ISqlParameterBuilder>();

            //when
            var a1 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<ISqlParameterBuilder>();
            var a2 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<ISqlParameterBuilder>();

            //then
            a1.Should().Be(a2);
        }

        [Fact]
        public void An_parameter_builder_registered_via_defaults_should_produce_transients()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var a1 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<ISqlParameterBuilder>();
            var a2 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<ISqlParameterBuilder>();

            //then
            a1.Should().NotBe(a2);
        }

        [Fact]
        public void An_parameter_builder_registered_via_delegate_should_produce_transients()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ParameterBuilder.Use(() => Substitute.For<ISqlParameterBuilder>()));

            //when
            var a1 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<ISqlParameterBuilder>();
            var a2 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<ISqlParameterBuilder>();

            //then
            a1.Should().NotBe(a2);
        }

        [Fact]
        public void An_parameter_builder_registered_via_service_provideer_should_produce_transients()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ParameterBuilder.Use(sp => Substitute.For<ISqlParameterBuilder>()));

            //when
            var a1 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<ISqlParameterBuilder>();
            var a2 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<ISqlParameterBuilder>();

            //then
            a1.Should().NotBe(a2);
        }

        [Fact]
        public void An_parameter_builder_registered_via_generic_should_produce_transients()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ParameterBuilder.Use<NoOpSqlParameterBuilder>());

            //when
            var a1 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<ISqlParameterBuilder>();
            var a2 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<ISqlParameterBuilder>();

            //then
            a1.Should().NotBe(a2);
        }

        [Fact]
        public void Registering_parameter_builders_via_a_delegate_should_return_the_specified_instances()
        {
            //given
            var index = -1;
            var builders = new List<ISqlParameterBuilder>
            {
                Substitute.For<ISqlParameterBuilder>(),
                Substitute.For<ISqlParameterBuilder>(),
                Substitute.For<ISqlParameterBuilder>(),
                Substitute.For<ISqlParameterBuilder>()
            };
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ParameterBuilder.Use(sp =>
            {
                index++;
                return builders[index];
            }));

            //when
            var resolved = new List<ISqlParameterBuilder>();
            for (var i = 0; i < builders.Count; i++)
                resolved.Add(serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<ISqlParameterBuilder>());

            //then
            resolved.Should().Equal(builders);
        }

        private class NoOpSqlParameterBuilder : ISqlParameterBuilder
        {
            public IList<ParameterizedExpression> Parameters { get; } = new List<ParameterizedExpression>();

            public void AddParameter(ParameterizedExpression parameter)
            {
                throw new NotImplementedException();
            }

            public ParameterizedExpression CreateInputOutputParameter<T>(T value, AssemblyContext context)
            {
                throw new NotImplementedException();
            }

            public ParameterizedExpression CreateInputOutputParameter(object value, Type valueType, AssemblyContext context)
            {
                throw new NotImplementedException();
            }

            public ParameterizedExpression CreateInputOutputParameter<T>(T value, Type declaredType, ISqlColumnMetadata meta, AssemblyContext context)
            {
                throw new NotImplementedException();
            }

            public ParameterizedExpression CreateInputOutputParameter<T>(T value, Type declaredType, ISqlParameterMetadata meta, AssemblyContext context)
            {
                throw new NotImplementedException();
            }

            public ParameterizedExpression CreateInputParameter<T>(T value, AssemblyContext context)
            {
                throw new NotImplementedException();
            }

            public ParameterizedExpression CreateInputParameter(object value, Type valueType, AssemblyContext context)
            {
                throw new NotImplementedException();
            }

            public ParameterizedExpression CreateInputParameter<T>(T value, Type declaredType, ISqlColumnMetadata meta, AssemblyContext context)
            {
                throw new NotImplementedException();
            }

            public ParameterizedExpression CreateInputParameter<T>(T value, Type declaredType, ISqlParameterMetadata meta, AssemblyContext context)
            {
                throw new NotImplementedException();
            }

            public ParameterizedExpression CreateOutputParameter(Type valueType, ISqlColumnMetadata meta, AssemblyContext context)
            {
                throw new NotImplementedException();
            }

            public ParameterizedExpression CreateOutputParameter(Type valueType, ISqlParameterMetadata meta, AssemblyContext context)
            {
                throw new NotImplementedException();
            }
        }
    }
}

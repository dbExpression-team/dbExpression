using DbEx.DataService;
using FluentAssertions;
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
        [Theory]
        [MsSqlVersions.AllVersions]
        public void An_parameter_builder_registered_via_delegate_should_resolve_the_same_parameter_builder(int version)
        {
            //given
            var builder = Substitute.For<ISqlParameterBuilder<MsSqlDb>>();
            var provider = ConfigureForMsSqlVersion(version, c => c.SqlStatements.Assembly.ParameterBuilder.Use(() => builder));

            //when
            var resolved = provider.GetService<ISqlParameterBuilder<MsSqlDb>>();

            //then
            resolved.Should().Be(builder);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void An_parameter_builder_registered_via_service_provider_should_resolve_the_same_parameter_builder(int version)
        {
            //given
            var builder = Substitute.For<ISqlParameterBuilder<MsSqlDb>>();
            var provider = ConfigureForMsSqlVersion(version, c => c.SqlStatements.Assembly.ParameterBuilder.Use(sp => builder));

            //when
            var resolved = provider.GetService<ISqlParameterBuilder<MsSqlDb>>();

            //then
            resolved.Should().Be(builder);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void An_parameter_builder_registered_via_generic_should_resolve_the_same_parameter_builder(int version)
        {
            //given
            var provider = ConfigureForMsSqlVersion(version, c => c.SqlStatements.Assembly.ParameterBuilder.Use<NoOpSqlParameterBuilder>());

            //when
            var resolved = provider.GetService<ISqlParameterBuilder<MsSqlDb>>();

            //then
            resolved.Should().NotBeNull().And.BeOfType<NoOpSqlParameterBuilder>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void An_parameter_builder_registering_an_instance_via_delegate_should_return_the_same_instance(int version)
        {
            //given
            var builder = Substitute.For<ISqlParameterBuilder<MsSqlDb>>();
            var provider = ConfigureForMsSqlVersion(version, c => c.SqlStatements.Assembly.ParameterBuilder.Use(sp => builder));
            var factory = provider.GetService<ISqlParameterBuilder<MsSqlDb>>();

            //when
            var a1 = provider.GetService<ISqlParameterBuilder<MsSqlDb>>();
            var a2 = provider.GetService<ISqlParameterBuilder<MsSqlDb>>();

            //then
            a1.Should().Be(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void An_parameter_builder_registered_via_defaults_should_produce_transients(int version)
        {
            //given
            var provider = ConfigureForMsSqlVersion(version);

            //when
            var a1 = provider.GetService<ISqlParameterBuilder<MsSqlDb>>();
            var a2 = provider.GetService<ISqlParameterBuilder<MsSqlDb>>();

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void An_parameter_builder_registered_via_delegate_should_produce_transients(int version)
        {
            //given
            var provider = ConfigureForMsSqlVersion(version, c => c.SqlStatements.Assembly.ParameterBuilder.Use(() => Substitute.For<ISqlParameterBuilder<MsSqlDb>>()));

            //when
            var a1 = provider.GetService<ISqlParameterBuilder<MsSqlDb>>();
            var a2 = provider.GetService<ISqlParameterBuilder<MsSqlDb>>();

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void An_parameter_builder_registered_via_service_provideer_should_produce_transients(int version)
        {
            //given
            var provider = ConfigureForMsSqlVersion(version, c => c.SqlStatements.Assembly.ParameterBuilder.Use(sp => Substitute.For<ISqlParameterBuilder<MsSqlDb>>()));

            //when
            var a1 = provider.GetService<ISqlParameterBuilder<MsSqlDb>>();
            var a2 = provider.GetService<ISqlParameterBuilder<MsSqlDb>>();

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void xxxAn_parameter_builder_registered_via_generic_should_produce_transients(int version)
        {
            //given
            var provider = ConfigureForMsSqlVersion(version, c => c.SqlStatements.Assembly.ParameterBuilder.Use<NoOpSqlParameterBuilder>());

            //when
            var a1 = provider.GetService<ISqlParameterBuilder<MsSqlDb>>();
            var a2 = provider.GetService<ISqlParameterBuilder<MsSqlDb>>();

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Registering_parameter_builders_via_a_delegate_should_return_the_specified_instances(int version)
        {
            //given
            var index = -1;
            var builders = new List<ISqlParameterBuilder<MsSqlDb>>
            {
                Substitute.For<ISqlParameterBuilder<MsSqlDb>>(),
                Substitute.For<ISqlParameterBuilder<MsSqlDb>>(),
                Substitute.For<ISqlParameterBuilder<MsSqlDb>>(),
                Substitute.For<ISqlParameterBuilder<MsSqlDb>>()
            };
            var provider = ConfigureForMsSqlVersion(version, c => c.SqlStatements.Assembly.ParameterBuilder.Use(sp =>
            {
                index++;
                return builders[index];
            }));

            //when
            var resolved = new List<ISqlParameterBuilder<MsSqlDb>>();
            for (var i = 0; i < builders.Count; i++)
                resolved.Add(provider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>());

            //then
            resolved.Should().Equal(builders);
        }

        private class NoOpSqlParameterBuilder : ISqlParameterBuilder<MsSqlDb>
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

            public ParameterizedExpression CreateInputOutputParameter<T>(T value, Type declaredType, ISqlFieldMetadata meta, AssemblyContext context)
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

            public ParameterizedExpression CreateInputParameter<T>(T value, Type declaredType, ISqlFieldMetadata meta, AssemblyContext context)
            {
                throw new NotImplementedException();
            }

            public ParameterizedExpression CreateInputParameter<T>(T value, Type declaredType, ISqlParameterMetadata meta, AssemblyContext context)
            {
                throw new NotImplementedException();
            }

            public ParameterizedExpression CreateOutputParameter(Type valueType, ISqlFieldMetadata meta, AssemblyContext context)
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

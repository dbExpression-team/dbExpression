using DbEx.DataService;
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
    public class SqlStatementBuilderConfigurationTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void A_statement_builder_registered_via_service_serviceProvider_should_resolve_the_correct_statement_builder(int version)
        {
            //given
            var builder = Substitute.For<ISqlStatementBuilder>();
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure: c => c.SqlStatements.Assembly.StatementBuilder.Use(sp => builder));

            //when
            var resolved = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetService<ISqlStatementBuilder>();

            //then
            resolved.Should().Be(builder);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void A_statement_builder_registered_via_generic_should_resolve_the_correct_statement_builder(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure: c => c.SqlStatements.Assembly.StatementBuilder.Use<NoOpSqlStatementBuilder>());

            //when
            var resolved = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetService<ISqlStatementBuilder>();

            //then
            resolved.Should().NotBeNull().And.BeOfType<NoOpSqlStatementBuilder>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void A_statement_builder_registered_via_delegate_should_resolve_the_correct_statement_builder(int version)
        {
            //given
            var builder = Substitute.For<ISqlStatementBuilder>();
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure: c => c.SqlStatements.Assembly.StatementBuilder.Use(() => builder));

            //when
            var resolved = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetService<ISqlStatementBuilder>();

            //then
            resolved.Should().Be(builder);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Statement_builder_resolved_from_service_serviceProvider_should_be_transient(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetService<ISqlStatementBuilder>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetService<ISqlStatementBuilder>();

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Registering_statement_builders_via_service_serviceProvider_should_return_the_specified_instances(int version)
        {
            //given
            var index = -1;
            var builders = new List<ISqlStatementBuilder>
            {
                Substitute.For<ISqlStatementBuilder>(),
                Substitute.For<ISqlStatementBuilder>(),
                Substitute.For<ISqlStatementBuilder>(),
                Substitute.For<ISqlStatementBuilder>()
            };
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.SqlStatements.Assembly.StatementBuilder.Use(sp =>
            {
                index++;
                return builders[index];
            }));

            //when
            var resolved = new List<ISqlStatementBuilder>();
            for (var i = 0; i < builders.Count; i++)
                resolved.Add(serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISqlStatementBuilder>());

            //then
            resolved.Should().Equal(builders);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Registering_statement_builders_via_generic_should_return_transients(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.SqlStatements.Assembly.StatementBuilder.Use<NoOpSqlStatementBuilder>());

            //when
            var resolved = new List<ISqlStatementBuilder>();
            for (var i = 0; i < 5; i++)
                resolved.Add(serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISqlStatementBuilder>());

            //then
            resolved.Should().AllBeOfType<NoOpSqlStatementBuilder>().And.OnlyHaveUniqueItems();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Registering_statement_builders_via_a_delegate_should_return_the_specified_instances(int version)
        {
            //given
            var index = -1;
            var builders = new List<ISqlStatementBuilder>
            {
                Substitute.For<ISqlStatementBuilder>(),
                Substitute.For<ISqlStatementBuilder>(),
                Substitute.For<ISqlStatementBuilder>(),
                Substitute.For<ISqlStatementBuilder>()
            };
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.SqlStatements.Assembly.StatementBuilder.Use(() =>
            {
                index++;
                return builders[index];
            }));

            //when
            var resolved = new List<ISqlStatementBuilder>();
            for (var i = 0; i < builders.Count; i++)
                resolved.Add(serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISqlStatementBuilder>());

            //then
            resolved.Should().Equal(builders);
        }

        private class NoOpSqlStatementBuilder : ISqlStatementBuilder
        {
            public ISqlParameterBuilder Parameters { get; }
            public IAppender Appender { get; }

            public NoOpSqlStatementBuilder()
            {
                Parameters = null!;
                Appender = null!;
            }

            public (Type ConvertedType, object? ConvertedValue) ConvertValue(object? value, Field? field)
            {
                throw new NotImplementedException();
            }

            public SqlStatement CreateSqlStatement<TQuery>(TQuery expression) where TQuery : QueryExpression
            {
                throw new NotImplementedException();
            }

            public string GetPlatformName(ISqlMetadataIdentifierProvider expression)
            {
                throw new NotImplementedException();
            }

            public ISqlColumnMetadata GetPlatformMetadata(Field field)
            {
                throw new NotImplementedException();
            }

            public ISqlParameterMetadata GetPlatformMetadata(QueryParameter parameter)
            {
                throw new NotImplementedException();
            }

            public string? ResolveTableAlias(string alias)
            {
                throw new NotImplementedException();
            }

            public string GenerateAlias()
            {
                throw new NotImplementedException();
            }

            public string? ResolveTableAlias(IExpressionElement element)
            {
                throw new NotImplementedException();
            }

            void ISqlStatementBuilder.AppendElement<T>(T element, AssemblyContext context)
            {
                throw new NotImplementedException();
            }
        }
    }
}

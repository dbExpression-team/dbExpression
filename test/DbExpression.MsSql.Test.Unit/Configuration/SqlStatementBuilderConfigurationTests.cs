using v2019DbEx.DataService;
using FluentAssertions;
using DbExpression.MsSql.Configuration;
using DbExpression.Sql;
using DbExpression.Sql.Assembler;
using DbExpression.Sql.Expression;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;

namespace DbExpression.MsSql.Test.Unit.Configuration
{
    public class SqlStatementBuilderConfigurationTests : TestBase
    {
        [Fact]
        public void A_statement_builder_registered_via_service_serviceProvider_should_resolve_the_correct_statement_builder()
        {
            //given
            var builder = Substitute.For<ISqlStatementBuilder>();
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure: c => c.SqlStatements.Assembly.StatementBuilder.Use(sp => builder));

            //when
            var resolved = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<ISqlStatementBuilder>();

            //then
            resolved.Should().Be(builder);
        }

        [Fact]
        public void A_statement_builder_registered_via_generic_should_resolve_the_correct_statement_builder()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure: c => c.SqlStatements.Assembly.StatementBuilder.Use<NoOpSqlStatementBuilder>());

            //when
            var resolved = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<ISqlStatementBuilder>();

            //then
            resolved.Should().NotBeNull().And.BeOfType<NoOpSqlStatementBuilder>();
        }

        [Fact]
        public void A_statement_builder_registered_via_delegate_should_resolve_the_correct_statement_builder()
        {
            //given
            var builder = Substitute.For<ISqlStatementBuilder>();
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(configure: c => c.SqlStatements.Assembly.StatementBuilder.Use(() => builder));

            //when
            var resolved = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<ISqlStatementBuilder>();

            //then
            resolved.Should().Be(builder);
        }

        [Fact]
        public void Statement_builder_resolved_from_service_serviceProvider_should_be_transient()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var a1 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<ISqlStatementBuilder>();
            var a2 = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<ISqlStatementBuilder>();

            //then
            a1.Should().NotBe(a2);
        }

        [Fact]
        public void Registering_statement_builders_via_service_serviceProvider_should_return_the_specified_instances()
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
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.StatementBuilder.Use(sp =>
            {
                index++;
                return builders[index];
            }));

            //when
            var resolved = new List<ISqlStatementBuilder>();
            for (var i = 0; i < builders.Count; i++)
                resolved.Add(serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<ISqlStatementBuilder>());

            //then
            resolved.Should().Equal(builders);
        }

        [Fact]
        public void Registering_statement_builders_via_generic_should_return_transients()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.StatementBuilder.Use<NoOpSqlStatementBuilder>());

            //when
            var resolved = new List<ISqlStatementBuilder>();
            for (var i = 0; i < 5; i++)
                resolved.Add(serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<ISqlStatementBuilder>());

            //then
            resolved.Should().AllBeOfType<NoOpSqlStatementBuilder>().And.OnlyHaveUniqueItems();
        }

        [Fact]
        public void Registering_statement_builders_via_a_delegate_should_return_the_specified_instances()
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
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.StatementBuilder.Use(() =>
            {
                index++;
                return builders[index];
            }));

            //when
            var resolved = new List<ISqlStatementBuilder>();
            for (var i = 0; i < builders.Count; i++)
                resolved.Add(serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<ISqlStatementBuilder>());

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

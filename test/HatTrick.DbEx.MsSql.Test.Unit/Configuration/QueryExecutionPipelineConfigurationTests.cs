using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Configuration
{
    public class QueryExecutionPipelineConfigurationTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void A_query_expression_factory_registered_via_service_serviceProvider_should_resolve_the_correct_statement_builder(int version)
        {
            //given
            var factory = Substitute.For<IQueryExpressionExecutionPipelineFactory>();
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure: c => c.SqlStatements.QueryExecution.Pipeline.Use(sp => factory));

            //when
            var resolved = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetService<IQueryExpressionExecutionPipelineFactory>();

            //then
            resolved.Should().Be(factory);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void A_query_expression_factory_registered_via_generic_should_resolve_the_correct_statement_builder(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure: c => c.SqlStatements.QueryExecution.Pipeline.Use<NoOpQueryExecutionPipelineFactory>());

            //when
            var resolved = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetService<IQueryExpressionExecutionPipelineFactory>();

            //then
            resolved.Should().NotBeNull().And.BeOfType<NoOpQueryExecutionPipelineFactory>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void A_query_expression_factory_registered_via_delegate_should_resolve_the_correct_statement_builder(int version)
        {
            //given
            var builder = Substitute.For<IQueryExpressionExecutionPipelineFactory>();
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure: c => c.SqlStatements.QueryExecution.Pipeline.Use(() => builder));

            //when
            var resolved = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetService<IQueryExpressionExecutionPipelineFactory>();

            //then
            resolved.Should().Be(builder);
        }


        [Theory]
        [MsSqlVersions.AllVersions]
        public void Query_execution_pipeline_resolved_from_service_serviceProvider_should_be_transient(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetService<ISelectQueryExpressionExecutionPipeline>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetService<ISelectQueryExpressionExecutionPipeline>();

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Default_registration_of_query_execution_pipeline_should_resolve_singletons(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IQueryExpressionExecutionPipelineFactory>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IQueryExpressionExecutionPipelineFactory>();

            //then
            a1.Should().Be(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Registration_of_query_execution_pipeline_via_delegate_should_resolve_singletons(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.SqlStatements.QueryExecution.Pipeline.Use<NoOpQueryExecutionPipelineFactory>());

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IQueryExpressionExecutionPipelineFactory>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IQueryExpressionExecutionPipelineFactory>();

            //then
            a1.Should().Be(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Registration_of_query_execution_pipeline_via_service_serviceProvider_should_resolve_singletons(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.SqlStatements.QueryExecution.Pipeline.Use(sp => Substitute.For<IQueryExpressionExecutionPipelineFactory>()));

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IQueryExpressionExecutionPipelineFactory>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IQueryExpressionExecutionPipelineFactory>();

            //then
            a1.Should().Be(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Registration_of_query_execution_pipeline_via_service_serviceProvider_and_override_via_service_serviceProvider_should_resolve_singletons_and_same_instance(int version)
        {
            //given
            IServiceProvider? serviceProvider = null;
            var factory = new DelegateQueryExpressionExecutionPipelineFactory(t => serviceProvider!.GetRequiredService<ISelectQueryExpressionExecutionPipeline>());
            serviceProvider = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.SqlStatements.QueryExecution.Pipeline.Use(sp => factory, c => c.ForSelect().Use(sp => Substitute.For<ISelectQueryExpressionExecutionPipeline>()))).serviceProvider;

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISelectQueryExpressionExecutionPipeline>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISelectQueryExpressionExecutionPipeline>();

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Registration_of_query_execution_pipeline_via_service_serviceProvider_and_override_via_delegate_should_resolve_singletons_and_same_instance(int version)
        {
            //given
            IServiceProvider? serviceProvider = null;
            var factory = new DelegateQueryExpressionExecutionPipelineFactory(t => serviceProvider!.GetRequiredService<ISelectQueryExpressionExecutionPipeline>());
            serviceProvider = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.SqlStatements.QueryExecution.Pipeline.Use(sp => factory, c => c.ForSelect().Use(() => Substitute.For<ISelectQueryExpressionExecutionPipeline>()))).serviceProvider;

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISelectQueryExpressionExecutionPipeline>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISelectQueryExpressionExecutionPipeline>();

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Registration_of_query_execution_pipeline_via_service_serviceProvider_and_override_via_generic_should_resolve_singletons_and_same_instance(int version)
        {
            //given
            IServiceProvider? serviceProvider = null;
            var factory = new DelegateQueryExpressionExecutionPipelineFactory(t => serviceProvider!.GetRequiredService<ISelectQueryExpressionExecutionPipeline>());
            serviceProvider = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.SqlStatements.QueryExecution.Pipeline.Use(sp => factory, c => c.ForSelect().Use<SelectQueryExpressionExecutionPipeline>())).serviceProvider;

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISelectQueryExpressionExecutionPipeline>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISelectQueryExpressionExecutionPipeline>();

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Registration_of_query_execution_pipeline_via_delegate_and_override_via_service_serviceProvider_should_resolve_singletons_and_same_instance(int version)
        {
            //given
            IServiceProvider? serviceProvider = null;
            var factory = new DelegateQueryExpressionExecutionPipelineFactory(t => serviceProvider!.GetRequiredService<ISelectQueryExpressionExecutionPipeline>());
            serviceProvider = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.SqlStatements.QueryExecution.Pipeline.Use(() => factory, c => c.ForSelect().Use(sp => Substitute.For<ISelectQueryExpressionExecutionPipeline>()))).serviceProvider;

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISelectQueryExpressionExecutionPipeline>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISelectQueryExpressionExecutionPipeline>();

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Registration_of_query_execution_pipeline_via_delegate_and_override_via_delegate_should_resolve_singletons_and_same_instance(int version)
        {
            //given
            IServiceProvider? serviceProvider = null;
            var factory = new DelegateQueryExpressionExecutionPipelineFactory(t => serviceProvider!.GetRequiredService<ISelectQueryExpressionExecutionPipeline>());
            serviceProvider = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.SqlStatements.QueryExecution.Pipeline.Use(() => factory, c => c.ForSelect().Use(() => Substitute.For<ISelectQueryExpressionExecutionPipeline>()))).serviceProvider;

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISelectQueryExpressionExecutionPipeline>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISelectQueryExpressionExecutionPipeline>();

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Registration_of_query_execution_pipeline_via_delegate_and_override_via_generic_should_resolve_singletons_and_same_instance(int version)
        {
            //given
            IServiceProvider? serviceProvider = null;
            var factory = new DelegateQueryExpressionExecutionPipelineFactory(t => serviceProvider!.GetRequiredService<ISelectQueryExpressionExecutionPipeline>());
            serviceProvider = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.SqlStatements.QueryExecution.Pipeline.Use(() => factory, c => c.ForSelect().Use<SelectQueryExpressionExecutionPipeline>())).serviceProvider;

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISelectQueryExpressionExecutionPipeline>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISelectQueryExpressionExecutionPipeline>();

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Registering_statement_builders_via_a_delegate_should_resolve_singletons(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.SqlStatements.QueryExecution.Pipeline.Use(() => Substitute.For<IQueryExpressionExecutionPipelineFactory>()));

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IQueryExpressionExecutionPipelineFactory>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IQueryExpressionExecutionPipelineFactory>();

            //then
            a1.Should().Be(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Registering_statement_builders_via_instance_should_resolve_singletons(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.SqlStatements.QueryExecution.Pipeline.Use(new NoOpQueryExecutionPipelineFactory()));

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IQueryExpressionExecutionPipelineFactory>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IQueryExpressionExecutionPipelineFactory>();

            //then
            a1.Should().Be(a2);
        }

        private class NoOpQueryExecutionPipelineFactory : IQueryExpressionExecutionPipelineFactory
        {
            public IDeleteQueryExpressionExecutionPipeline CreateDeleteQueryExecutionPipeline()
            {
                throw new NotImplementedException();
            }

            public IInsertQueryExpressionExecutionPipeline CreateInsertQueryExecutionPipeline()
            {
                throw new NotImplementedException();
            }

            public ISelectQueryExpressionExecutionPipeline CreateSelectQueryExecutionPipeline()
            {
                throw new NotImplementedException();
            }

            public IStoredProcedureExpressionExecutionPipeline CreateStoredProcedureExecutionPipeline()
            {
                throw new NotImplementedException();
            }

            public IUpdateQueryExpressionExecutionPipeline CreateUpdateQueryExecutionPipeline()
            {
                throw new NotImplementedException();
            }
        }
    }
}

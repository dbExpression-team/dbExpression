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
            var factory = Substitute.For<IQueryExecutionPipelineFactory>();
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure: c => c.SqlStatements.QueryExecution.Pipeline.Use(sp => factory));

            //when
            var resolved = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetService<IQueryExecutionPipelineFactory>();

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
            var resolved = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetService<IQueryExecutionPipelineFactory>();

            //then
            resolved.Should().NotBeNull().And.BeOfType<NoOpQueryExecutionPipelineFactory>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void A_query_expression_factory_registered_via_delegate_should_resolve_the_correct_statement_builder(int version)
        {
            //given
            var builder = Substitute.For<IQueryExecutionPipelineFactory>();
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, configure: c => c.SqlStatements.QueryExecution.Pipeline.Use(() => builder));

            //when
            var resolved = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetService<IQueryExecutionPipelineFactory>();

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
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetService<ISelectQueryExecutionPipeline>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetService<ISelectQueryExecutionPipeline>();

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
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IQueryExecutionPipelineFactory>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IQueryExecutionPipelineFactory>();

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
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IQueryExecutionPipelineFactory>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IQueryExecutionPipelineFactory>();

            //then
            a1.Should().Be(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Registration_of_query_execution_pipeline_via_service_serviceProvider_should_resolve_singletons(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.SqlStatements.QueryExecution.Pipeline.Use(sp => Substitute.For<IQueryExecutionPipelineFactory>()));

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IQueryExecutionPipelineFactory>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IQueryExecutionPipelineFactory>();

            //then
            a1.Should().Be(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Registration_of_query_execution_pipeline_via_service_serviceProvider_and_override_via_service_serviceProvider_should_resolve_singletons_and_same_instance(int version)
        {
            //given
            IServiceProvider? serviceProvider = null;
            var factory = new DelegateQueryExecutionPipelineFactory(t => serviceProvider!.GetRequiredService<ISelectQueryExecutionPipeline>());
            serviceProvider = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.SqlStatements.QueryExecution.Pipeline.Use(sp => factory, c => c.ForSelect().Use(sp => Substitute.For<ISelectQueryExecutionPipeline>()))).serviceProvider;

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISelectQueryExecutionPipeline>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISelectQueryExecutionPipeline>();

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Registration_of_query_execution_pipeline_via_service_serviceProvider_and_override_via_delegate_should_resolve_singletons_and_same_instance(int version)
        {
            //given
            IServiceProvider? serviceProvider = null;
            var factory = new DelegateQueryExecutionPipelineFactory(t => serviceProvider!.GetRequiredService<ISelectQueryExecutionPipeline>());
            serviceProvider = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.SqlStatements.QueryExecution.Pipeline.Use(sp => factory, c => c.ForSelect().Use(() => Substitute.For<ISelectQueryExecutionPipeline>()))).serviceProvider;

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISelectQueryExecutionPipeline>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISelectQueryExecutionPipeline>();

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Registration_of_query_execution_pipeline_via_service_serviceProvider_and_override_via_generic_should_resolve_singletons_and_same_instance(int version)
        {
            //given
            IServiceProvider? serviceProvider = null;
            var factory = new DelegateQueryExecutionPipelineFactory(t => serviceProvider!.GetRequiredService<ISelectQueryExecutionPipeline>());
            serviceProvider = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.SqlStatements.QueryExecution.Pipeline.Use(sp => factory, c => c.ForSelect().Use<SelectQueryExpressionExecutionPipeline>())).serviceProvider;

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISelectQueryExecutionPipeline>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISelectQueryExecutionPipeline>();

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Registration_of_query_execution_pipeline_via_delegate_and_override_via_service_serviceProvider_should_resolve_singletons_and_same_instance(int version)
        {
            //given
            IServiceProvider? serviceProvider = null;
            var factory = new DelegateQueryExecutionPipelineFactory(t => serviceProvider!.GetRequiredService<ISelectQueryExecutionPipeline>());
            serviceProvider = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.SqlStatements.QueryExecution.Pipeline.Use(() => factory, c => c.ForSelect().Use(sp => Substitute.For<ISelectQueryExecutionPipeline>()))).serviceProvider;

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISelectQueryExecutionPipeline>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISelectQueryExecutionPipeline>();

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Registration_of_query_execution_pipeline_via_delegate_and_override_via_delegate_should_resolve_singletons_and_same_instance(int version)
        {
            //given
            IServiceProvider? serviceProvider = null;
            var factory = new DelegateQueryExecutionPipelineFactory(t => serviceProvider!.GetRequiredService<ISelectQueryExecutionPipeline>());
            serviceProvider = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.SqlStatements.QueryExecution.Pipeline.Use(() => factory, c => c.ForSelect().Use(() => Substitute.For<ISelectQueryExecutionPipeline>()))).serviceProvider;

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISelectQueryExecutionPipeline>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISelectQueryExecutionPipeline>();

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Registration_of_query_execution_pipeline_via_delegate_and_override_via_generic_should_resolve_singletons_and_same_instance(int version)
        {
            //given
            IServiceProvider? serviceProvider = null;
            var factory = new DelegateQueryExecutionPipelineFactory(t => serviceProvider!.GetRequiredService<ISelectQueryExecutionPipeline>());
            serviceProvider = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.SqlStatements.QueryExecution.Pipeline.Use(() => factory, c => c.ForSelect().Use<SelectQueryExpressionExecutionPipeline>())).serviceProvider;

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISelectQueryExecutionPipeline>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISelectQueryExecutionPipeline>();

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Registering_statement_builders_via_a_delegate_should_resolve_singletons(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.SqlStatements.QueryExecution.Pipeline.Use(() => Substitute.For<IQueryExecutionPipelineFactory>()));

            //when
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IQueryExecutionPipelineFactory>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IQueryExecutionPipelineFactory>();

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
            var a1 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IQueryExecutionPipelineFactory>();
            var a2 = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IQueryExecutionPipelineFactory>();

            //then
            a1.Should().Be(a2);
        }

        private class NoOpQueryExecutionPipelineFactory : IQueryExecutionPipelineFactory
        {
            public IDeleteQueryExecutionPipeline CreateDeleteQueryExecutionPipeline()
            {
                throw new NotImplementedException();
            }

            public IInsertQueryExecutionPipeline CreateInsertQueryExecutionPipeline()
            {
                throw new NotImplementedException();
            }

            public ISelectQueryExecutionPipeline CreateSelectQueryExecutionPipeline()
            {
                throw new NotImplementedException();
            }

            public ISelectSetQueryExecutionPipeline CreateSelectSetQueryExecutionPipeline()
            {
                throw new NotImplementedException();
            }

            public IStoredProcedureExecutionPipeline CreateStoredProcedureExecutionPipeline()
            {
                throw new NotImplementedException();
            }

            public IUpdateQueryExecutionPipeline CreateUpdateQueryExecutionPipeline()
            {
                throw new NotImplementedException();
            }
        }
    }
}

using FluentAssertions;
using DbExpression.MsSql.Configuration;
using DbExpression.Sql;
using DbExpression.Sql.Expression;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using System.Linq;
using v2019DbEx_static.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using v2022DbEx_static.DataService;
using Xunit;
using v2019DbEx.DataService;
using v2022DbEx.DataService;
using NSubstitute.Core;

namespace DbExpression.MsSql.Test.Unit.Configuration
{
    using v2022db_static = v2022DbEx_static.DataService.db;
    using v2019db_static = v2019DbEx_static.DataService.db;
    using v2022dbo_static = v2022DbEx_static.dboDataService.dbo;
    using v2019dbo_static = v2019DbEx_static.dboDataService.dbo;
    using v2019Person_static = v2019DbEx_static.dboData.Person;
    using v2022Person_static = v2022DbEx_static.dboData.Person;

    using v2022dbo = v2022DbEx.dboDataService.dbo;
    using v2019dbo = v2019DbEx.dboDataService.dbo;
    using v2019Person = v2019DbEx.dboData.Person;
    using v2022Person = v2022DbEx.dboData.Person;

    public class MultipleDatabaseConfigurationTests : TestBase
    {
        [Fact]
        public void Does_registering_the_same_database_twice_fail_as_expected()
        {
            //given
            var services = new ServiceCollection();

            //when & then
            Assert.Throws<DbExpressionConfigurationException>(() => services.AddDbExpression(
                dbex => dbex.AddDatabase<v2019MsSqlDb>(c => c.ConnectionString.Use("foo")),
                dbex => dbex.AddDatabase<v2019MsSqlDb>(c => c.ConnectionString.Use("foo"))
            ));
        }

        [Fact]
        public void Does_accessing_a_database_statically_that_hasnt_been_initialized_fail_as_expected()
        {
            //given
            var services = new ServiceCollection();
            services.AddDbExpression(
                dbex => dbex.AddDatabase<v2019MsSqlDb_static>(c => c.ConnectionString.Use("foo")),
                dbex => dbex.AddDatabase<v2022MsSqlDb_static>(c => c.ConnectionString.Use("foo"))
            );
            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.UseStaticRuntimeFor<v2019MsSqlDb_static>();

            //when & then
            Assert.Throws<DbExpressionConfigurationException>(() => v2022db_static.SelectOne<v2022Person_static>().From(v2022dbo_static.Person));
        }

        [Fact]
        public void Does_configuration_of_multiple_databases_resolve_different_types_for_stored_procedures()
        {
            //given
            var (mssqldb, mssqldbServiceProvider) = Configure<v2019MsSqlDb_static>();
            var (mssqldbAlt, mssqldbAltServiceProvider) = Configure<v2022MsSqlDb_static>();

            mssqldbServiceProvider.UseStaticRuntimeFor<v2019MsSqlDb_static>();
            mssqldbAltServiceProvider.UseStaticRuntimeFor<v2022MsSqlDb_static>();

            //when
            var spBuilder = v2019db_static.sp.GetType();
            var spBuilderAlt = v2022db_static.sp.GetType();

            //then
            spBuilder.Should().NotBeOfType<v2022MsSqlDb_static.v2022MsSqlDb_staticStoredProcedures>();
            spBuilderAlt.Should().NotBeOfType<v2019MsSqlDb_static.v2019MsSqlDb_staticStoredProcedures>();
        }

        [Fact]
        public void Do_query_expressions_for_different_databases_build_correctly()
        {
            //given
            var (mssqldb, mssqldbServiceProvider) = Configure<v2019MsSqlDb_static>();
            var (mssqldbAlt, mssqldbAltServiceProvider) = Configure<v2022MsSqlDb_static>();

            mssqldbServiceProvider.UseStaticRuntimeFor<v2019MsSqlDb_static>();
            mssqldbAltServiceProvider.UseStaticRuntimeFor<v2022MsSqlDb_static>();

            //when
            var p1 = v2019db_static.SelectOne<v2019Person_static>().From(v2019dbo_static.Person).OrderBy(v2019dbo_static.Person.Id.Asc());
            var p2 = v2022db_static.SelectOne<v2022Person_static>().From(v2022dbo_static.Person).OrderBy(v2022dbo_static.Person.Id.Asc());

            //then
            p1.Should().NotBeNull();
            p2.Should().NotBeNull();
        }

        [Fact]
        public void Does_configuration_of_two_databases_using_different_query_expression_factories_resolve_and_use_the_correct_query_expression()
        {
            //given
            var query = Substitute.For<SelectQueryExpression>();
            var usedCount = 0;
            var (mssqldb, mssqldbServiceProvider) = Configure<v2019MsSqlDb_static>(c => c.QueryExpressions.ForQueryTypes(x => x.ForQueryType<SelectQueryExpression>().Use(() => { usedCount++; return query; })));
            var (mssqldbAlt, mssqldbAltServiceProvider) = Configure<v2022MsSqlDb_static>();

            mssqldbServiceProvider.UseStaticRuntimeFor<v2019MsSqlDb_static>();
            mssqldbAltServiceProvider.UseStaticRuntimeFor<v2022MsSqlDb_static>();

            //when
            var p1 = v2019db_static.SelectOne<v2019Person_static>().From(v2019dbo_static.Person).Expression;
            var p2 = v2022db_static.SelectOne<v2022Person_static>().From(v2022dbo_static.Person).Expression;

            //then
            p1.Should().Be(query);
            p2.Should().NotBe(query);
            usedCount.Should().Be(1);
        }

        [Fact]
        public void Does_configuration_of_two_databases_sharing_a_service_provider_build_queries_successfully()
        {
            //given
            var query = Substitute.For<SelectQueryExpression>();
            var usedCount = 0;
            var services = new ServiceCollection();
            services.AddDbExpression(
                dbex => dbex.AddDatabase<v2019MsSqlDb_static>(c => { c.ConnectionString.Use("foo"); c.QueryExpressions.ForQueryTypes(x => x.ForSelect().Use(() => { usedCount++; return query; })); }),
                dbex => dbex.AddDatabase<v2022MsSqlDb_static>(c => c.ConnectionString.Use("foo"))
            );
            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.UseStaticRuntimeFor<v2019MsSqlDb_static>();
            serviceProvider.UseStaticRuntimeFor<v2022MsSqlDb_static>();

            //when
            var p1 = v2019db_static.SelectOne<v2019Person_static>().From(v2019dbo_static.Person).Expression;
            var p2 = v2022db_static.SelectOne<v2022Person_static>().From(v2022dbo_static.Person).Expression;

            //then
            p1.Should().Be(query);
            p2.Should().NotBe(query);
            usedCount.Should().Be(1);
        }

        [Fact]
        public void Does_configuration_of_two_databases_sharing_a_service_provider_build_stored_procedure_expressions_successfully()
        {
            //given
            var services = new ServiceCollection();
            services.AddDbExpression(
                dbex => dbex.AddDatabase<v2019MsSqlDb>(c => c.ConnectionString.Use("foo")),
                dbex => dbex.AddDatabase<v2022MsSqlDb>(c => c.ConnectionString.Use("foo"))
            );
            var serviceProvider = services.BuildServiceProvider();

            var mssqldb = serviceProvider.GetRequiredService<v2019MsSqlDb>();
            var mssqldbAlt = serviceProvider.GetRequiredService<v2022MsSqlDb>();

            //when
            var p1 = mssqldb.sp.dbo.SelectPerson_As_Dynamic_With_Input(P1: 1).GetValue();
            var p2 = mssqldbAlt.sp.dbo.SelectPerson_As_Dynamic_With_Input(P1: 1).GetValue();

            //then
            p1.Should().NotBe(p2);
        }

        [Fact]
        public void Does_configuration_of_two_databases_sharing_a_service_provider_with_different_query_expressions_build_stored_procedure_expressions_successfully()
        {
            //given
            var query = Substitute.For<StoredProcedureQueryExpression>();
            var usedCount = 0;
            var services = new ServiceCollection();
            services.AddDbExpression(
                dbex => dbex.AddDatabase<v2019MsSqlDb>(c => { c.ConnectionString.Use("foo"); c.QueryExpressions.ForQueryTypes(x => x.ForQueryType<StoredProcedureQueryExpression>().Use(() => { usedCount++; return query; })); }),
                dbex => dbex.AddDatabase<v2022MsSqlDb>(c => c.ConnectionString.Use("foo"))
            );
            var serviceProvider = services.BuildServiceProvider();

            var mssqldb = serviceProvider.GetRequiredService<v2019MsSqlDb>();
            var mssqldbAlt = serviceProvider.GetRequiredService<v2022MsSqlDb>();

            //when
            var p1 = (mssqldb.sp.dbo.SelectPerson_As_Dynamic_With_Input(P1: 1).GetValue() as IQueryExpressionProvider)!.Expression;
            var p2 = (mssqldbAlt.sp.dbo.SelectPerson_As_Dynamic_With_Input(P1: 1).GetValue() as IQueryExpressionProvider)!.Expression;

            //then
            p1.Should().Be(query);
            p2.Should().NotBe(query);
            usedCount.Should().Be(1);
        }

        [Fact]
        public void Does_configuration_of_two_databases_sharing_a_service_provider_and_registration_of_root_factory_ignore_registration()
        {
            //given
            var factory = Substitute.For<IQueryExpressionFactory>();
            factory.CreateQueryExpression(typeof(UpdateQueryExpression)).Returns(new UpdateQueryExpression());

            var services = new ServiceCollection();
            services.AddDbExpression(
                dbex => dbex.AddDatabase<v2019MsSqlDb>(c => c.ConnectionString.Use("foo")),
                dbex => dbex.AddDatabase<v2022MsSqlDb>(c => c.ConnectionString.Use("foo"))
            );
            services.AddSingleton<IQueryExpressionFactory>(factory);
            var serviceProvider = services.BuildServiceProvider();

            var mssqldb = serviceProvider.GetRequiredService<v2019MsSqlDb>();
            var mssqldbAlt = serviceProvider.GetRequiredService<v2022MsSqlDb>();

            //when
            var p1 = mssqldb.Update(v2019dbo.Person.FirstName.Set("foo")).From(v2019dbo.Person);
            var p2 = mssqldbAlt.Update(v2022dbo.Person.FirstName.Set("bar")).From(v2022dbo.Person);

            //then
            factory.Received(0).CreateQueryExpression(typeof(UpdateQueryExpression));
        }
    }
}

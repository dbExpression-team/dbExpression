using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using DbExAlt.DataService;
using DbExAlt.dboAltData;
using DbExAlt.dboAltDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Configuration
{
    public class MultipleDatabaseConfigurationTests : TestBase
    {
        [Fact]
        public void Does_registering_the_same_database_twice_fail_as_expected()
        {
            //given
            var services = new ServiceCollection();

            //when & then
            Assert.Throws<DbExpressionConfigurationException>(() => services.AddDbExpression(
                dbex => dbex.AddMsSql2019Database<MsSqlDb>(c => c.ConnectionString.Use("foo")),
                dbex => dbex.AddMsSql2019Database<MsSqlDb>(c => c.ConnectionString.Use("foo"))
            ));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_accessing_a_database_statically_that_hasnt_been_initialized_fail_as_expected(int version)
        {
            //given
            var (mssqldb, mssqldbServiceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var (mssqldbAlt, mssqldbAltServiceProvider) = Configure<MsSqlDbAlt>().ForMsSqlVersion(version);

            mssqldbServiceProvider.UseStaticRuntimeFor<MsSqlDb>();

            //when & then
            Assert.Throws<DbExpressionConfigurationException>(() => dbAlt.SelectOne<PersonAlt>().From(dboAlt.PersonAlt));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_multiple_databases_resolve_different_types_for_stored_procedures(int version)
        {
            //given
            var (mssqldb, mssqldbServiceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var (mssqldbAlt, mssqldbAltServiceProvider) = Configure<MsSqlDbAlt>().ForMsSqlVersion(version);

            mssqldbServiceProvider.UseStaticRuntimeFor<MsSqlDb>();
            mssqldbAltServiceProvider.UseStaticRuntimeFor<MsSqlDbAlt>();

            //when
            var spBuilder = db.sp.GetType();
            var spBuilderAlt = dbAlt.sp.GetType();

            //then
            spBuilder.Should().NotBeOfType<MsSqlDbAlt.MsSqlDbAltStoredProcedures>();
            spBuilderAlt.Should().NotBeOfType<MsSqlDb.MsSqlDbStoredProcedures>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Do_query_expressions_for_different_databases_build_correctly(int version)
        {
            //given
            var (mssqldb, mssqldbServiceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var (mssqldbAlt, mssqldbAltServiceProvider) = Configure<MsSqlDbAlt>().ForMsSqlVersion(version);

            mssqldbServiceProvider.UseStaticRuntimeFor<MsSqlDb>();
            mssqldbAltServiceProvider.UseStaticRuntimeFor<MsSqlDbAlt>();

            //when
            var p1 = db.SelectOne<Person>().From(dbo.Person).OrderBy(dbo.Person.Id.Asc);
            var p2 = dbAlt.SelectOne<PersonAlt>().From(dboAlt.PersonAlt).OrderBy(dboAlt.PersonAlt.Id.Asc);

            //then
            p1.Should().NotBeNull();
            p2.Should().NotBeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_two_databases_using_different_query_expression_factories_resolve_and_use_the_correct_query_expression(int version)
        {
            //given
            var query = Substitute.For<SelectQueryExpression>();
            var usedCount = 0;
            var (mssqldb, mssqldbServiceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.QueryExpressions.ForQueryTypes(x => x.ForQueryType<SelectQueryExpression>().Use(() => { usedCount++; return query; })));
            var (mssqldbAlt, mssqldbAltServiceProvider) = Configure<MsSqlDbAlt>().ForMsSqlVersion(version);

            mssqldbServiceProvider.UseStaticRuntimeFor<MsSqlDb>();
            mssqldbAltServiceProvider.UseStaticRuntimeFor<MsSqlDbAlt>();

            //when
            var p1 = db.SelectOne<Person>().From(dbo.Person).Expression;
            var p2 = dbAlt.SelectOne<PersonAlt>().From(dbo.Person).Expression;

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
                dbex => dbex.AddMsSql2019Database<MsSqlDb>(c => { c.ConnectionString.Use("foo"); c.QueryExpressions.ForQueryTypes(x => x.ForSelect().Use(() => { usedCount++; return query; })); }),
                dbex => dbex.AddMsSql2019Database<MsSqlDbAlt>(c => c.ConnectionString.Use("foo"))
            );
            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.UseStaticRuntimeFor<MsSqlDb>();
            serviceProvider.UseStaticRuntimeFor<MsSqlDbAlt>();

            //when
            var p1 = db.SelectOne<Person>().From(dbo.Person).Expression;
            var p2 = dbAlt.SelectOne<PersonAlt>().From(dbo.Person).Expression;

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
                dbex => dbex.AddMsSql2019Database<MsSqlDb>(c => c.ConnectionString.Use("foo")),
                dbex => dbex.AddMsSql2019Database<MsSqlDbAlt>(c => c.ConnectionString.Use("foo"))
            );
            var serviceProvider = services.BuildServiceProvider();

            var mssqldb = serviceProvider.GetRequiredService<MsSqlDb>();
            var mssqldbAlt = serviceProvider.GetRequiredService<MsSqlDbAlt>();

            //when
            var p1 = mssqldb.sp.dbo.SelectPerson_As_Dynamic_With_Input(P1: 1).GetValue();
            var p2 = mssqldbAlt.sp.dboAlt.SelectPerson_As_Dynamic_With_InputAlt(P1Alt: 1).GetValue();

            //then
            p1.Should().NotBe(p2);
        }

        [Fact]
        public void Does_configuration_of_two_databases_sharing_a_service_provider_with_diffent_query_expressions_build_stored_procedure_expressions_successfully()
        {
            //given
            var query = Substitute.For<StoredProcedureQueryExpression>();
            var usedCount = 0;
            var services = new ServiceCollection();
            services.AddDbExpression(
                dbex => dbex.AddMsSql2019Database<MsSqlDb>(c => { c.ConnectionString.Use("foo"); c.QueryExpressions.ForQueryTypes(x => x.ForQueryType<StoredProcedureQueryExpression>().Use(() => { usedCount++; return query; })); }),
                dbex => dbex.AddMsSql2019Database<MsSqlDbAlt>(c => c.ConnectionString.Use("foo"))
            );
            var serviceProvider = services.BuildServiceProvider();

            var mssqldb = serviceProvider.GetRequiredService<MsSqlDb>();
            var mssqldbAlt = serviceProvider.GetRequiredService<MsSqlDbAlt>();

            //when
            var p1 = (mssqldb.sp.dbo.SelectPerson_As_Dynamic_With_Input(P1: 1).GetValue() as IQueryExpressionProvider)!.Expression;
            var p2 = (mssqldbAlt.sp.dboAlt.SelectPerson_As_Dynamic_With_InputAlt(P1Alt: 1).GetValue() as IQueryExpressionProvider)!.Expression;

            //then
            p1.Should().Be(query);
            p2.Should().NotBe(query);
            usedCount.Should().Be(1);
        }
    }
}

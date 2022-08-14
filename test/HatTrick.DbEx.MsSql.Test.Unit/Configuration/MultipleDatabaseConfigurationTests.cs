using DbEx.DataService;
using DbExAlt.DataService;
using DbExAlt.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using System.Linq;
using Xunit;

using Person = DbEx.dboData.Person;
using PersonAlt = DbExAlt.dboData.Person;

namespace HatTrick.DbEx.MsSql.Test.Unit.Configuration
{
    public class MultipleDatabaseConfigurationTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_accessing_a_database_statically_that_hasnt_been_initialized_fail_as_expected(int version)
        {
            //given
            var (mssqldb, mssqldbServiceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);
            var (mssqldbAlt, mssqldbAltServiceProvider) = ConfigureForMsSqlVersion<MsSqlDbAlt>(version);

            mssqldbServiceProvider.UseStaticRuntimeFor<MsSqlDb>();

            //when & then
            Assert.Throws<DbExpressionConfigurationException>(() => dbAlt.SelectOne<Person>().From(dbo.Person));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_multiple_databases_resolve_different_types_for_stored_procedures(int version)
        {
            //given
            var (mssqldb, mssqldbServiceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);
            var (mssqldbAlt, mssqldbAltServiceProvider) = ConfigureForMsSqlVersion<MsSqlDbAlt>(version);

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
            var (mssqldb, mssqldbServiceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);
            var (mssqldbAlt, mssqldbAltServiceProvider) = ConfigureForMsSqlVersion<MsSqlDbAlt>(version);

            mssqldbServiceProvider.UseStaticRuntimeFor<MsSqlDb>();
            mssqldbAltServiceProvider.UseStaticRuntimeFor<MsSqlDbAlt>();

            //when
            var p1 = db.SelectOne<Person>().From(dbo.Person).OrderBy(dbo.Person.Id.Asc);
            var p2 = dbAlt.SelectOne<PersonAlt>().From(dbo.Person).OrderBy(dbo.Person.Id.Asc);

            //then
            p1.Should().NotBeNull();
            p2.Should().NotBeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Do_queries_from_different_databases_execute_successfully_using_static_versions_of_database(int version)
        {
            //given
            var (mssqldb, mssqldbServiceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);
            var (mssqldbAlt, mssqldbAltServiceProvider) = ConfigureForMsSqlVersion<MsSqlDbAlt>(version);

            mssqldbServiceProvider.UseStaticRuntimeFor<MsSqlDb>();
            mssqldbAltServiceProvider.UseStaticRuntimeFor<MsSqlDbAlt>();

            //when
            var p1 = db.SelectOne<Person>().From(dbo.Person).OrderBy(dbo.Person.Id.Asc).Execute();
            var p2 = dbAlt.SelectOne<PersonAlt>().From(dbo.Person).OrderBy(dbo.Person.Id.Asc).Execute();

            //then
            p1.Should().NotBeNull();
            p2.Should().NotBeNull();
            p1!.Id.Should().Be(p2!.Id);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Do_queries_from_different_databases_execute_successfully_when_using_instance_versions_of_database(int version)
        {
            //given
            var query = Substitute.For<SelectQueryExpression>();
            var usedCount = 0;
            var (mssqldb, mssqldbServiceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, c => c.QueryExpressions.ForQueryTypes(x => x.ForQueryType<SelectQueryExpression>().Use(() => { usedCount++; return query; })));
            var (mssqldbAlt, mssqldbAltServiceProvider) = ConfigureForMsSqlVersion<MsSqlDbAlt>(version);

            //when
            var p1 = mssqldb.SelectOne<Person>().From(dbo.Person).OrderBy(dbo.Person.Id.Asc).Execute();
            var p2 = mssqldbAlt.SelectOne<PersonAlt>().From(dbo.Person).OrderBy(dbo.Person.Id.Asc).Execute();

            //then
            p1.Should().NotBeNull();
            p2.Should().NotBeNull();
            p1!.Id.Should().Be(p2!.Id);
            usedCount.Should().Be(1);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Do_queries_from_different_databases_execute_successfully_when_one_uses_static_version_of_database_and_one_uses_instance_version_of_database(int version)
        {
            //given
            var (mssqldb, mssqldbServiceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);
            var (mssqldbAlt, mssqldbAltServiceProvider) = ConfigureForMsSqlVersion<MsSqlDbAlt>(version);

            mssqldbServiceProvider.UseStaticRuntimeFor<MsSqlDb>();

            //when
            var p1 = db.SelectOne<Person>().From(dbo.Person).OrderBy(dbo.Person.Id.Asc).Execute();
            var p2 = mssqldbAlt.SelectOne<PersonAlt>().From(dbo.Person).OrderBy(dbo.Person.Id.Asc).Execute();

            //then
            p1.Should().NotBeNull();
            p2.Should().NotBeNull();
            p1!.Id.Should().Be(p2!.Id);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_two_databases_using_different_query_expression_factories_resolve_and_use_the_correct_query_expression(int version)
        {
            //given
            var query = Substitute.For<SelectQueryExpression>();
            var usedCount = 0;
            var (mssqldb, mssqldbServiceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, c => c.QueryExpressions.ForQueryTypes(x => x.ForQueryType<SelectQueryExpression>().Use(() => { usedCount++; return query; })));
            var (mssqldbAlt, mssqldbAltServiceProvider) = ConfigureForMsSqlVersion<MsSqlDbAlt>(version);

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
        public void Does_configuration_of_two_databases_sharing_a_service_provider_execute_queries_successfully()
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
    }
}

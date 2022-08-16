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

namespace HatTrick.DbEx.MsSql.Test.Integration.Configuration
{
    public class MultipleDatabaseConfigurationTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Do_queries_from_different_databases_execute_successfully_using_static_versions_of_database(int version)
        {
            //given
            var (mssqldb, mssqldbServiceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var (mssqldbAlt, mssqldbAltServiceProvider) = Configure<MsSqlDbAlt>().ForMsSqlVersion(version);

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
            var (mssqldb, mssqldbServiceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.QueryExpressions.ForQueryTypes(x => x.ForQueryType<SelectQueryExpression>().Use(() => { usedCount++; return query; })));
            var (mssqldbAlt, mssqldbAltServiceProvider) = Configure<MsSqlDbAlt>().ForMsSqlVersion(version);

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
            var (mssqldb, mssqldbServiceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var (mssqldbAlt, mssqldbAltServiceProvider) = Configure<MsSqlDbAlt>().ForMsSqlVersion(version);

            mssqldbServiceProvider.UseStaticRuntimeFor<MsSqlDb>();

            //when
            var p1 = db.SelectOne<Person>().From(dbo.Person).OrderBy(dbo.Person.Id.Asc).Execute();
            var p2 = mssqldbAlt.SelectOne<PersonAlt>().From(dbo.Person).OrderBy(dbo.Person.Id.Asc).Execute();

            //then
            p1.Should().NotBeNull();
            p2.Should().NotBeNull();
            p1!.Id.Should().Be(p2!.Id);
        }
    }
}

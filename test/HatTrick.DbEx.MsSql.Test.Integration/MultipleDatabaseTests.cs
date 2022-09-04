using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using DbExAlt.DataService;
using DbExAlt.dboAltData;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;
using NSubstitute;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    public class MultipleDatabaseTests : ExecutorTestBase
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

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Do_stored_procedures_from_different_databases_execute_successfully_when_using_instance_versions_of_database(int version)
        {
            //given
            var (mssqldb, mssqldbServiceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var (mssqldbAlt, mssqldbAltServiceProvider) = Configure<MsSqlDbAlt>().ForMsSqlVersion(version);

            //when
            int? p1 = mssqldb.sp.dbo.SelectPerson_As_Dynamic_With_Input(P1: 1).GetValue().Execute()?.Id;
            int? p2 = mssqldbAlt.sp.dboAlt.SelectPerson_As_Dynamic_With_InputAlt(P1Alt: 1).GetValue().Execute()?.Id;

            //then
            p1.Should().NotBeNull();
            p2.Should().NotBeNull();
            p1.Should().Be(p2);
        }
    }
}

using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using v2022DbEx.DataService;
using v2022DbEx.dboData;
using v2022DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using DbExpression.Sql.Expression;
using NSubstitute;
using System.Linq;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    using v2022db = v2022DbEx.DataService.db;
    using v2019db = v2019DbEx.DataService.db;
    using v2022dbo = v2022DbEx.dboDataService.dbo;
    using v2019dbo = v2019DbEx.dboDataService.dbo;
    using v2019Person = v2019DbEx.dboData.Person;
    using v2022Person = v2022DbEx.dboData.Person;    
    
    public class MultipleDatabaseTests : ResetDatabaseNotRequired
    {
        [Fact]
        public void Do_queries_from_different_databases_execute_successfully_using_static_versions_of_database()
        {
            //given
            var (mssqldb, mssqldbServiceProvider) = Configure<v2019MsSqlDb>();
            var (mssqldbAlt, mssqldbAltServiceProvider) = Configure<v2022MsSqlDb>();

            mssqldbServiceProvider.UseStaticRuntimeFor<v2019MsSqlDb>();
            mssqldbAltServiceProvider.UseStaticRuntimeFor<v2022MsSqlDb>();

            //when
            var p1 = v2019db.SelectOne<v2019Person>().From(v2019dbo.Person).OrderBy(v2019dbo.Person.Id.Asc()).Execute();
            var p2 = v2022db.SelectOne<v2022Person>().From(v2022dbo.Person).OrderBy(v2022dbo.Person.Id.Asc()).Execute();

            //then
            p1.Should().NotBeNull();
            p2.Should().NotBeNull();
            p1!.Id.Should().Be(p2!.Id);
        }

        [Fact]
        public void Do_queries_from_different_databases_execute_successfully_when_using_instance_versions_of_database()
        {
            //given
            var query = Substitute.For<SelectQueryExpression>();
            var usedCount = 0;
            var (mssqldb, mssqldbServiceProvider) = Configure<v2019MsSqlDb>(c => c.QueryExpressions.ForQueryTypes(x => x.ForQueryType<SelectQueryExpression>().Use(() => { usedCount++; return query; })));
            var (mssqldbAlt, mssqldbAltServiceProvider) = Configure<v2022MsSqlDb>();

            //when
            var p1 = mssqldb.SelectOne<v2019Person>().From(v2019dbo.Person).OrderBy(v2019dbo.Person.Id.Asc()).Execute();
            var p2 = mssqldbAlt.SelectOne<v2022Person>().From(v2022dbo.Person).OrderBy(v2022dbo.Person.Id.Asc()).Execute();

            //then
            p1.Should().NotBeNull();
            p2.Should().NotBeNull();
            p1!.Id.Should().Be(p2!.Id);
            usedCount.Should().Be(1);
        }

        [Fact]
        public void Do_queries_from_different_databases_execute_successfully_when_one_uses_static_version_of_database_and_one_uses_instance_version_of_database()
        {
            //given
            var (mssqldb, mssqldbServiceProvider) = Configure<v2019MsSqlDb>();
            var (mssqldbAlt, mssqldbAltServiceProvider) = Configure<v2022MsSqlDb>();

            mssqldbServiceProvider.UseStaticRuntimeFor<v2019MsSqlDb>();

            //when
            var p1 = v2019db.SelectOne<v2019Person>().From(v2019dbo.Person).OrderBy(v2019dbo.Person.Id.Asc()).Execute();
            var p2 = mssqldbAlt.SelectOne<v2022Person>().From(v2022dbo.Person).OrderBy(v2022dbo.Person.Id.Asc()).Execute();

            //then
            p1.Should().NotBeNull();
            p2.Should().NotBeNull();
            p1!.Id.Should().Be(p2!.Id);
        }

        [Fact]
        public void Do_stored_procedures_from_different_databases_execute_successfully_when_using_instance_versions_of_database()
        {
            //given
            var (mssqldb, mssqldbServiceProvider) = Configure<v2019MsSqlDb>();
            var (mssqldbAlt, mssqldbAltServiceProvider) = Configure<v2022MsSqlDb>();

            //when
            int? p1 = mssqldb.sp.dbo.SelectPerson_As_Dynamic_With_Input(P1: 1).GetValue().Execute()?.Id;
            int? p2 = mssqldbAlt.sp.dbo.SelectPerson_As_Dynamic_With_Input(P1: 1).GetValue().Execute()?.Id;

            //then
            p1.Should().NotBeNull();
            p2.Should().NotBeNull();
            p1.Should().Be(p2);
        }
    }
}

using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.Sql;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Code.Configuration
{
    public class RuntimeSqlDatabaseConfigurationTests : TestBase
    {
        [Fact]
        public void Does_bypassing_configuring_for_a_sql_server_version_return_non_null_configuration()
        {
            //given
            var dbInstance = new db();

            //when
            var config = (dbInstance as IRuntimeSqlDatabase).Configuration;

            //then
            config.Should().NotBeNull();
        }

        [Fact]
        public void Does_bypassing_configuring_for_a_sql_server_version_throw_correct_exception_on_query_execution()
        {
            //given
            static Person exec() => db.SelectOne<Person>().From(dbo.Person).Execute();

            //when
            var ex = Assert.Throws<ArgumentNullException>(exec);

            //then
            ex.Should().BeOfType<ArgumentNullException>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_setting_query_expression_factory_to_null_throw_correct_exception(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            database.QueryExpressionFactory = null;
            static Person exec() => db.SelectOne<Person>().From(dbo.Person).Execute();

            //when
            var ex = Assert.Throws<ArgumentNullException>(exec);

            //then
            ex.Should().BeOfType<ArgumentNullException>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_setting_metadata_provider_to_null_throw_correct_exception(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            database.MetadataProvider = null;
            static Person exec() => db.SelectOne<Person>().From(dbo.Person).Execute();

            //when
            var ex = Assert.Throws<ArgumentNullException>(exec);

            //then
            ex.Should().BeOfType<ArgumentNullException>();
        }
    }
}

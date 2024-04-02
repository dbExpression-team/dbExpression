using FluentAssertions;
using DbExpression.MsSql.Configuration;
using DbExpression.Sql.Assembler;
using Microsoft.Extensions.DependencyInjection;
using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using Xunit;

namespace DbExpression.MsSql.Test.Unit.Assembler
{
    public class SyntheticAliasTests : TestBase
    {
        [Fact]
        public void Can_a_synthetic_alias_be_created_successfully()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var builder = (SqlStatementBuilder)serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<ISqlStatementBuilder>();

            //when
            var alias = builder.ResolveTableAlias(dbo.Person);

            //then
            alias.Should().Be("t0");
        }

        [Fact]
        public void Can_multiple_synthetic_aliases_be_created_successfully()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var builder = (SqlStatementBuilder)serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<ISqlStatementBuilder>();

            //when
            var alias1 = builder.ResolveTableAlias(dbo.Person);
            var alias2 = builder.ResolveTableAlias(dbo.Address);
            var alias3 = builder.ResolveTableAlias(dbo.PersonAddress);

            //then
            alias1.Should().Be("t0");
            alias2.Should().Be("t1");
            alias3.Should().Be("t2");
        }

        [Fact]
        public void Does_alias_of_table_continue_to_return_the_same_alias()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var builder = (SqlStatementBuilder)serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<ISqlStatementBuilder>();

            //when
            var alias1 = builder.ResolveTableAlias(dbo.Person);
            var alias2 = builder.ResolveTableAlias(dbo.Address);
            var alias3 = builder.ResolveTableAlias(dbo.Person);

            //then
            alias1.Should().Be("t0");
            alias2.Should().Be("t1");
            alias3.Should().Be("t0");
        }

        [Fact]
        public void Does_exceeding_initial_alias_cache_produce_new_aliases()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var builder = (SqlStatementBuilder)serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<ISqlStatementBuilder>();

            //when
            for (var i = 0; i < 20; i++)
            {
                builder.ResolveTableAlias($"xyz{i}");
            }
            var alias = builder.ResolveTableAlias(dbo.Person);

            //then
            alias.Should().Be("t20");
        }

        [Fact]
        public void Does_exceeding_initial_alias_cache_produce_new_aliases_and_continue_to_return_the_same_alias_for_the_same_table()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var builder = (SqlStatementBuilder)serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<ISqlStatementBuilder>();

            //when
            var alias1 = builder.ResolveTableAlias(dbo.Person);
            for (var i = 0; i < 40; i++)
            {
                builder.ResolveTableAlias($"xyz{i}");
            }
            var alias2 = builder.ResolveTableAlias(dbo.Person);

            //then
            alias1.Should().Be("t0");
            alias2.Should().Be(alias1);
        }
    }
}

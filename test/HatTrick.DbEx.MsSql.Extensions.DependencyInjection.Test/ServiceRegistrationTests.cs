using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Xunit;

namespace HatTrick.DbEx.MsSql.Extensions.DependencyInjection.Tests
{
    public class ServiceRegistrationTests
    {
        [Fact]
        public void Can_a_query_expression_factory_be_registered_and_resolved()
        {
            //given
            var services = new ServiceCollection();
            var queryFactory = Substitute.For<IQueryExpressionFactory<MsSqlDb>>();
            DbExpressionConfigurationException? exception = null;

            //when
            try
            {
                services.AddDbExpression(
                    dbex =>
                    {

                        dbex.AddMsSql2019Database<MsSqlDb>(
                            c => c.QueryExpressions.Use(queryFactory)
                        );
                    }
                );
            }
            catch (DbExpressionConfigurationException ex)
            {
                exception = ex;
            }

            //then
            exception.Should().BeNull();
        }

        [Fact]
        public void Can_a_select_query_expression_be_registered_and_resolved()
        {
            //given
            var services = new ServiceCollection();
            var queryFactory = Substitute.For<IQueryExpressionFactory<MsSqlDb>>();
            DbExpressionConfigurationException? exception = null;

            //when
            try
            {
                services.AddDbExpression(
                    dbex =>
                    {

                        dbex.AddMsSql2019Database<MsSqlDb>(
                            c => c.QueryExpressions.Use((sp, t) => queryFactory.CreateQueryExpression(t))
                        );
                    }
                );
            }
            catch (DbExpressionConfigurationException ex)
            {
                exception = ex;
            }

            //then
            exception.Should().BeNull();
        }

        [Fact]
        public void Can_a_no_op_config_register_with_no_exception()
        {
            //given
            var services = new ServiceCollection();
            var queryFactory = Substitute.For<IQueryExpressionFactory<MsSqlDb>>();
            DbExpressionConfigurationException? exception = null;

            //when
            try
            {
                services.AddDbExpression(
                    dbex =>
                    {

                        dbex.AddMsSql2019Database<MsSqlDb>(
                            c => { }
                        );
                    }
                );
            }
            catch (DbExpressionConfigurationException ex)
            {
                exception = ex;
            }

            //then
            exception.Should().BeNull();
        }
    }
}
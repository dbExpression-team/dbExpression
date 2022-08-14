using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Xunit;

namespace HatTrick.DbEx.MsSql.Extensions.DependencyInjection.Tests
{
    public class ServiceResolutionTests
    {
        [Fact]
        public void Does_a_registered_instance_query_expression_factory_get_resolved_correctly()
        {
            //given
            var services = new ServiceCollection();
            var queryFactory = Substitute.For<IQueryExpressionFactory<MsSqlDb>>();

            services.AddDbExpression(
                dbex => {

                    dbex.AddMsSql2019Database<MsSqlDb>(c => 
                        {
                            c.QueryExpressions.Use(queryFactory);
                        });
                }
            );

            var provider = services.BuildServiceProvider();

            //when
            var resolved = provider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IQueryExpressionFactory<MsSqlDb>>();

            //then
            resolved?.Should().Be(queryFactory);
        }

        [Fact]
        public void Does_a_generically_registered_query_expression_factory_get_resolved_correctly()
        {
            //given
            var services = new ServiceCollection();

            services.AddDbExpression(
                dbex => {

                    dbex.AddMsSql2019Database<MsSqlDb>(c => c.ConnectionString.Use("foo"));
                }
            );

            var provider = services.BuildServiceProvider();
            
            //when
            var db = provider.GetRequiredService<MsSqlDb>();
            var resolved = provider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IQueryExpressionFactory<MsSqlDb>>();

            //then
            resolved.Should().NotBeNull();
        }

        [Fact]
        public void Does_a_registered_factory_for_query_expression_factory_get_resolved_correctly()
        {
            //given
            var services = new ServiceCollection();
            SelectQueryExpression exp = new();

            services.AddDbExpression(
                dbex => {

                    dbex.AddMsSql2019Database<MsSqlDb>(c =>
                    {
                        c.QueryExpressions.ForQueryTypes(x => x.ForQueryType<SelectQueryExpression>().Use(sp => exp));
                    });
                }
            );

            var provider = services.BuildServiceProvider();

            //when
            var factory = provider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IQueryExpressionFactory<MsSqlDb>>();
            var resolved = factory.CreateQueryExpression<SelectQueryExpression>();

            //then
            resolved?.Should().Be(exp);
        }
    }
}
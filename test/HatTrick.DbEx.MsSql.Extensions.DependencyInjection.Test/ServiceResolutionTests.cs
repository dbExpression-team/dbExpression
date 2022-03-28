using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Xunit;

namespace HatTrick.DbEx.MsSql.Extensions.DependencyInjection.Tests
{
    public class ServiceResolutionTests
    {
        [Fact]
        public void Does_a_database_registered_service_get_resolved_correctly()
        {
            //given
            var services = new ServiceCollection();
            var queryFactory = Substitute.For<IQueryExpressionFactory>();

            services.AddDbExpression(
                dbex => {

                    dbex.AddMsSql2019Database<MsSqlDb>(
                        (serviceProvider, database) => { },
                        databaseServiceCollection: services => services.AddSingleton(sp => queryFactory)
                    );
                }
            );

            var serviceProvider = services.BuildServiceProvider();

            //when
            var iocService = serviceProvider.GetService<DatabaseService<MsSqlDb, IQueryExpressionFactory>>();

            //then
            iocService?.Service.Should().Be(queryFactory);
        }

        [Fact]
        public void Does_a_database_registered_service_get_ignored_when_resolving_at_root()
        {
            //given
            var services = new ServiceCollection();
            var queryFactory = Substitute.For<IQueryExpressionFactory>();

            services.AddDbExpression(
                dbex => {

                    dbex.AddMsSql2019Database<MsSqlDb>(
                        (serviceProvider, database) => { },
                        databaseServiceCollection: services => services.AddSingleton(sp => queryFactory)
                    );
                }
            );

            var serviceProvider = services.BuildServiceProvider();

            //when
            var iocService = serviceProvider.GetService<IQueryExpressionFactory>();

            //then
            iocService.Should().NotBe(queryFactory);
        }

        [Fact]
        public void Does_a_database_registered_service_override_a_root_registered_service()
        {
            //given
            var services = new ServiceCollection();
            var rootQueryFactory = Substitute.For<IQueryExpressionFactory>();
            var dbQueryFactory = Substitute.For<IQueryExpressionFactory>();

            services.AddSingleton(rootQueryFactory);
            services.AddDbExpression(
                dbex => {

                    dbex.AddMsSql2019Database<MsSqlDb>(
                        (serviceProvider, database) => { },
                        databaseServiceCollection: services => services.AddSingleton(sp => dbQueryFactory)
                    );
                }
            );

            var serviceProvider = services.BuildServiceProvider();

            //when
            var iocService = serviceProvider.GetService<DatabaseService<MsSqlDb, IQueryExpressionFactory>>();

            //then
            iocService?.Service.Should().Be(dbQueryFactory);
        }
    }
}
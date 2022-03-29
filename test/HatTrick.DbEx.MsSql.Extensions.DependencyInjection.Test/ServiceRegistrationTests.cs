using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Xunit;

namespace HatTrick.DbEx.MsSql.Extensions.DependencyInjection.Tests
{
    public class ServiceRegistrationTests
    {
        [Theory]
        [InlineData(ServiceLifetime.Transient)]
        public void Does_registering_a_database_transient_service_succeed_when_lifetime_of_db_is_less_than_or_equal_to_transient(ServiceLifetime dbLifetime)
        {
            //given
            var services = new ServiceCollection();
            var queryFactory = Substitute.For<IQueryExpressionFactory>();
            DbExpressionConfigurationException? exception = null;

            //when
            try
            {
                services.AddDbExpression(
                    dbex =>
                    {

                        dbex.AddMsSql2019Database<MsSqlDb>(
                            (serviceProvider, database) => { },
                            lifetime: dbLifetime,
                            databaseServiceCollection: services => services.AddTransient(sp => queryFactory)
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

        [Theory]
        [InlineData(ServiceLifetime.Transient)]
        [InlineData(ServiceLifetime.Scoped)]
        public void Does_registering_a_database_scoped_service_succeed_when_lifetime_of_db_is_less_than_or_equal_to_scoped(ServiceLifetime dbLifetime)
        {
            //given
            var services = new ServiceCollection();
            var queryFactory = Substitute.For<IQueryExpressionFactory>();
            DbExpressionConfigurationException? exception = null;

            //when
            try
            {
                services.AddDbExpression(
                    dbex =>
                    {

                        dbex.AddMsSql2019Database<MsSqlDb>(
                            (serviceProvider, database) => { },
                            lifetime: dbLifetime,
                            databaseServiceCollection: services => services.AddScoped(sp => queryFactory)
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

        [Theory]
        [InlineData(ServiceLifetime.Transient)]
        [InlineData(ServiceLifetime.Scoped)]
        [InlineData(ServiceLifetime.Singleton)]
        public void Does_registering_a_database_singleton_service_succeed_when_lifetime_of_db_is_less_than_or_equal_to_singleton(ServiceLifetime dbLifetime)
        {
            //given
            var services = new ServiceCollection();
            var queryFactory = Substitute.For<IQueryExpressionFactory>();
            DbExpressionConfigurationException? exception = null;

            //when
            try
            {
                services.AddDbExpression(
                    dbex =>
                    {

                        dbex.AddMsSql2019Database<MsSqlDb>(
                            (serviceProvider, database) => { },
                            lifetime: dbLifetime,
                            databaseServiceCollection: services => services.AddSingleton(sp => queryFactory)
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

        [Theory]
        [InlineData(ServiceLifetime.Scoped)]
        [InlineData(ServiceLifetime.Singleton)]
        public void Does_registering_a_database_transient_service_fail_when_lifetime_of_db_is_greater_than_transient(ServiceLifetime dbLifetime)
        {
            //given
            var services = new ServiceCollection();
            var queryFactory = Substitute.For<IQueryExpressionFactory>();
            DbExpressionConfigurationException? exception = null;

            //when
            try
            {
                services.AddDbExpression(
                    dbex =>
                    {

                        dbex.AddMsSql2019Database<MsSqlDb>(
                            (serviceProvider, database) => { },
                            lifetime: dbLifetime,
                            databaseServiceCollection: services => services.AddTransient(sp => queryFactory)
                        );
                    }
                );
            }
            catch (DbExpressionConfigurationException ex)
            {
                exception = ex;
            }

            //then
            exception.Should().NotBeNull();
        }

        [Theory]
        [InlineData(ServiceLifetime.Singleton)]
        public void Does_registering_a_database_transient_service_fail_when_lifetime_of_db_is_greater_than_scoped(ServiceLifetime dbLifetime)
        {
            //given
            var services = new ServiceCollection();
            var queryFactory = Substitute.For<IQueryExpressionFactory>();
            DbExpressionConfigurationException? exception = null;

            //when
            try
            {
                services.AddDbExpression(
                    dbex =>
                    {

                        dbex.AddMsSql2019Database<MsSqlDb>(
                            (serviceProvider, database) => { },
                            lifetime: dbLifetime,
                            databaseServiceCollection: services => services.AddScoped(sp => queryFactory)
                        );
                    }
                );
            }
            catch (DbExpressionConfigurationException ex)
            {
                exception = ex;
            }

            //then
            exception.Should().NotBeNull();
        }
    }
}
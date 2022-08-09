using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NSubstitute;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Configuration
{
    public class dbExpressionConfigurationTests : TestBase
    {

        [Fact]
        public void Does_singleton_registration_resolve_correctly()
        {
            //given
            var provider = dbExpression.Initialize(
                services => services.AddSingleton<SelectQueryExpression>(),
                dbex => {

                    dbex.AddMsSql2019Database<MsSqlDb>(c => c.ConnectionString.Use("foo"));

                }
            );

            //when
            var a1 = provider.GetService<SelectQueryExpression>();
            var a2 = provider.GetService<SelectQueryExpression>();

            //then
            a1.Should().Be(a2);
        }

        [Fact]
        public void Does_second_registration_of_singleton_using_add_resolve_second_registration()
        {
            //given
            var exp = Substitute.For<SelectQueryExpression>();
            var provider = dbExpression.Initialize(
                services =>
                {
                    services.AddSingleton<SelectQueryExpression>();
                    services.AddSingleton<SelectQueryExpression>(exp);
                },
                dbex => {

                    dbex.AddMsSql2019Database<MsSqlDb>(c => c.ConnectionString.Use("foo"));

                }
            );

            //when
            var resolved = provider.GetService<SelectQueryExpression>();

            //then
            resolved.Should().Be(exp);
        }

        [Fact]
        public void Does_second_registration_of_singleton_using_try_add_resolve_first_registration()
        {
            //given
            var exp = Substitute.For<SelectQueryExpression>();
            var provider = dbExpression.Initialize(
                services =>
                {
                    services.AddSingleton<SelectQueryExpression>();
                    services.TryAddSingleton<SelectQueryExpression>(exp);
                },
                dbex => {

                    dbex.AddMsSql2019Database<MsSqlDb>(c => c.ConnectionString.Use("foo"));

                }
            );

            //when
            var resolved = provider.GetService<SelectQueryExpression>();

            //then
            resolved.Should().NotBe(exp).And.NotBeNull().And.BeOfType<SelectQueryExpression>();
        }

        [Fact]
        public void Does_transient_registration_resolve_correctly()
        {
            //given
            var provider = dbExpression.Initialize(
                services => services.AddTransient<SelectQueryExpression>(),
                dbex => {

                    dbex.AddMsSql2019Database<MsSqlDb>(c => c.ConnectionString.Use("foo"));

                }
            );

            //when
            var a1 = provider.GetService<SelectQueryExpression>();
            var a2 = provider.GetService<SelectQueryExpression>();

            //then
            a1.Should().NotBe(a2);
        }

        [Fact]
        public void Does_second_registration_of_transient_using_add_resolve_second_registration()
        {
            //given
            var exp = Substitute.For<SelectQueryExpression>();
            var provider = dbExpression.Initialize(
                services => {
                    services.AddTransient<SelectQueryExpression>();
                    services.AddTransient<SelectQueryExpression>(sp => exp);
                },
                dbex => {

                    dbex.AddMsSql2019Database<MsSqlDb>(c => c.ConnectionString.Use("foo"));

                }
            );

            //when
            var resolved = provider.GetService<SelectQueryExpression>();

            //then
            resolved.Should().Be(exp);
        }

        [Fact]
        public void Does_second_registration_of_transient_using_try_add_resolve_first_registration()
        {
            //given
            var exp = Substitute.For<SelectQueryExpression>();
            var provider = dbExpression.Initialize(
                services => {
                    services.AddTransient<SelectQueryExpression>();
                    services.TryAddTransient<SelectQueryExpression>(sp => exp);
                },
                dbex => {

                    dbex.AddMsSql2019Database<MsSqlDb>(c => c.ConnectionString.Use("foo"));

                }
            );

            //when
            var resolved = provider.GetService<SelectQueryExpression>();

            //then
            resolved.Should().NotBe(exp).And.NotBeNull().And.BeOfType<SelectQueryExpression>();
        }
    }
}

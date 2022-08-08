using FluentAssertions;
using HatTrick.DbEx.Sql.Assembler;
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
            var services = dbExpression.CreateServiceCollection();
            services.AddSingleton<SelectQueryExpression>();
            var provider = dbExpression.BuildServiceProvider();
            
            //when
            var resolved = provider.GetService<SelectQueryExpression>();

            resolved.Should().NotBeNull();
        }

        [Fact]
        public void Does_second_registration_of_singleton_using_add_resolve_second_registration()
        {
            //given
            var exp = Substitute.For<SelectQueryExpression>();
            var services = dbExpression.CreateServiceCollection();
            services.AddSingleton<SelectQueryExpression>();
            services.AddSingleton<SelectQueryExpression>(exp);
            var provider = dbExpression.BuildServiceProvider();

            //when
            var resolved = provider.GetService<SelectQueryExpression>();

            resolved.Should().Be(exp);
        }

        [Fact]
        public void Does_second_registration_of_singleton_using_try_add_resolve_first_registration()
        {
            //given
            var exp = Substitute.For<SelectQueryExpression>();
            var services = dbExpression.CreateServiceCollection();
            services.AddSingleton<SelectQueryExpression>();
            services.TryAddSingleton<SelectQueryExpression>(exp);
            var provider = dbExpression.BuildServiceProvider();

            //when
            var resolved = provider.GetService<SelectQueryExpression>();

            resolved.Should().NotBe(exp).And.NotBeNull().And.BeOfType<SelectQueryExpression>();
        }

        [Fact]
        public void Does_transient_registration_resolve_correctly()
        {
            //given
            var services = dbExpression.CreateServiceCollection();
            services.AddTransient<SelectQueryExpression>();
            var provider = dbExpression.BuildServiceProvider();

            //when
            var resolved = provider.GetService<SelectQueryExpression>();

            resolved.Should().NotBeNull();
        }

        [Fact]
        public void Does_second_registration_of_transient_using_add_resolve_second_registration()
        {
            //given
            var exp = Substitute.For<SelectQueryExpression>();
            var services = dbExpression.CreateServiceCollection();
            services.AddTransient<SelectQueryExpression>();
            services.AddTransient<SelectQueryExpression>(sp => exp);
            var provider = dbExpression.BuildServiceProvider();

            //when
            var resolved = provider.GetService<SelectQueryExpression>();

            resolved.Should().Be(exp);
        }

        [Fact]
        public void Does_second_registration_of_transient_using_try_add_resolve_first_registration()
        {
            //given
            var exp = Substitute.For<SelectQueryExpression>();
            var services = dbExpression.CreateServiceCollection();
            services.AddTransient<SelectQueryExpression>();
            services.TryAddTransient<SelectQueryExpression>(sp => exp);
            var provider = dbExpression.BuildServiceProvider();

            //when
            var resolved = provider.GetService<SelectQueryExpression>();

            resolved.Should().NotBe(exp).And.NotBeNull().And.BeOfType<SelectQueryExpression>();
        }
    }
}

using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Code.Configuration
{
    public class QueryExpressiononfigurationBuilderTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_using_instance_method_with_null_instance_throw_expected_exception(int version)
        {
            //given & when & then
            Assert.Throws<ArgumentNullException>(() => ConfigureForMsSqlVersion(version, builder => builder.QueryExpressions.Use((IQueryExpressionFactory)null)));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_query_expression_factory_using_generic_use_method_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.QueryExpressions.Use<NoOpQueryExpressionFactory>());

            //when
            var matchingType = config.QueryExpressionFactory is NoOpQueryExpressionFactory;

            //then
            matchingType.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_query_expression_using_instance_use_method_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.QueryExpressions.Use(new NoOpQueryExpressionFactory()));

            //when
            var matchingType = config.QueryExpressionFactory is NoOpQueryExpressionFactory;

            //then
            matchingType.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_query_expression_using_generic_method_throw_appropriate_exception_when_accessing_for_database(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.QueryExpressions.Use<NoOpQueryExpressionFactory>());

            //when & then
            Assert.Throws<NotImplementedException>(() => config.QueryExpressionFactory.CreateQueryExpression<SelectQueryExpression>());
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_schema_provider_using_instance_method_throw_appropriate_exception_when_finding_schema_metadata(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.QueryExpressions.Use(new NoOpQueryExpressionFactory()));

            //when & then
            Assert.Throws<NotImplementedException>(() => config.QueryExpressionFactory.CreateQueryExpression<SelectQueryExpression>());
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_query_expression_using_default_method_throw_appropriate_exception_when_accessing_for_database(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.QueryExpressions.UseDefaultFactory());

            //when
            var exp = config.QueryExpressionFactory.CreateQueryExpression<SelectQueryExpression>();

            //tthen
            exp.Should().NotBeNull();
        }

        public class NoOpQueryExpressionFactory : IQueryExpressionFactory
        {
            public T CreateQueryExpression<T>() where T : QueryExpression, new() => throw new NotImplementedException();
        }
    }
}

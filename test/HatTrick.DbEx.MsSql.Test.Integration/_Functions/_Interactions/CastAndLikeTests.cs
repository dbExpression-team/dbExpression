using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System.Collections.Generic;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "CAST")]
    [Trait("Operation", "LIKE")]
    public partial class CastAndLikeTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(1)]
        public void Does_where_clause_using_cast_of_decimal_and_like_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    dbo.Product.Id
                ).From(dbo.Product)
                .Where(db.fx.Cast(dbo.Product.Price).AsVarChar(12).Like("7.8%"));

            //when               
            IEnumerable<int> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(2)]
        public void Does_where_clause_using_cast_of_nullable_decimal_and_like_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    dbo.Product.Id
                ).From(dbo.Product)
                .Where(db.fx.Cast(dbo.Product.Height).AsVarChar(12).Like("12.%"));

            //when               
            IEnumerable<int> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }
    }
}

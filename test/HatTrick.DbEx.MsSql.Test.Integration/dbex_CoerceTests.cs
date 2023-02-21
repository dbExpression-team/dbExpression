using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
#pragma warning disable IDE1006 // Naming Styles
    public class dbex_CoerceTests : ResetDatabaseNotRequired
#pragma warning restore IDE1006 // Naming Styles
    {
        [Theory]
        [Trait("Pattern", "LEFT JOIN NULL PATTERN")]
        [Trait("Operation", "LEFT JOIN")]
        [InlineData(44)]
        public void Does_left_joining_a_non_null_value_making_it_null_succeed_with_coerce(int count)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var values = db.SelectMany(
                dbo.Person.Id,
                dbex.Coerce(dbo.Purchase.Id).As("PurchaseId")
            )
            .From(dbo.Person)
            .LeftJoin(dbo.Purchase).On(dbo.Person.Id == dbo.Purchase.PersonId)
            .Where(dbo.Purchase.Id == dbex.Null)
            .Execute();

            //then
            values.Should().HaveCount(count);
        }
    }
}

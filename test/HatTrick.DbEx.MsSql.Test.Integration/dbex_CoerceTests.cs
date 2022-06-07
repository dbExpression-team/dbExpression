using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    public class dbex_CoerceTests : ExecutorTestBase
    {
        [Theory]
        [Trait("Pattern", "LEFT JOIN NULL PATTERN")]
        [Trait("Operation", "LEFT JOIN")]
        [MsSqlVersions.AllVersions]
        public void Does_left_joining_a_non_null_value_making_it_null_succeed_with_coerce(int version, int count = 44)
        {
            //given
            ConfigureForMsSqlVersion(version);

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

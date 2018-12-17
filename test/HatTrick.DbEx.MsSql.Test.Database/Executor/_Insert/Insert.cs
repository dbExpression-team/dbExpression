using Data;
using Data.dbo;
using DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Extensions.Builder;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Statement", "INSERT")]
    public partial class Insert : ExecutorTestBase
    {
        [Theory]
        [InlineData(2014)]
        public void Can_an_address_be_inserted(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.Insert(
                new Address
                {
                    Id = -1,
                    AddressType = AddressType.Mailing,
                    Line1 = "123 Main St",
                    City = "Anywhere",
                    State = "TX",
                    Zip = "65432",
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                })
                .Into(dbo.Address);

            //when               
            exp.Execute();

            //then
            var lastAddress = dbo.Address.As("last_insert");

            var address = db.SelectOne<Address>()
                .From(dbo.Address)
                .InnerJoin(
                    db.SelectOne<int>(
                        db.Max(lastAddress.Id).As("identity")
                    )
                    .From(lastAddress)
                ).On(dbo.Address.Id == lastAddress.Id.As("identity"))
                .Execute();

            address.Should().NotBeNull();
            address.Line1.Should().Be("123 Main St");
        }
    }
}

using Data;
using Data.dbo;
using DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Extensions.Builder;
using System;
using System.Threading.Tasks;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Statement", "INSERT")]
    public partial class Insert : ExecutorTestBase
    {
        [Theory]
        [InlineData(2012)]
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
            var t1 = dbo.Address.As("a");
            var address = db.SelectOne<Address>()
                .From(t1)
                .InnerJoin(
                    db.SelectOne<int>(
                        db.Max(dbo.Address.Id).As("identity")
                    )
                    .From(dbo.Address)
                ).As("last_insert").On(t1.Id == dbo.Address.As("last_insert").Id.As("identity"))
                .Execute();

            address.Should().NotBeNull();
            address.Line1.Should().Be("123 Main St");
        }

        [Theory]
        [InlineData(2014)]
        public void Foo(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //then
            var t1 = dbo.Address.As("a");
            var address = db.SelectOne<Address>()
                .From(t1)
                .InnerJoin(
                    db.SelectOne<int>(
                        db.Max(dbo.Address.Id).As("identity")
                    )
                    .From(dbo.Address)
                ).As("last_insert").On(t1.Id == dbo.Address.As("last_insert").Id.As("identity"))
                .Execute();

            address.Should().NotBeNull();
        }
    }
}

using DbEx.Data;
using DbEx.Data.dbo;
using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Builder;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Statement", "DELETE")]
    public partial class Delete : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_an_personaddress_be_deleted(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.Delete()
                .From(dbo.PersonAddress)
                .Where(dbo.PersonAddress.AddressId == 1);

            //when               
            exp.Execute();

            //then
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_an_personaddress_be_deleted_joining_thru_address(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.Delete()
                .From(dbo.PersonAddress)
                .InnerJoin(dbo.Address).On(dbo.PersonAddress.AddressId == dbo.Address.Id)
                .Where(dbo.Address.Id == 1);

            //when               
            exp.Execute();

            //then
        }

    }
}

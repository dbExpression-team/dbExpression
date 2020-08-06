using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Statement", "DELETE")]
    public partial class Delete : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_an_personaddress_be_deleted(int version, int expected = 14)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.Delete()
                .From(dbo.PersonAddress)
                .Where(dbo.PersonAddress.AddressId == 1);

            //when               
            var recordsAffected = exp.Execute();

            //then
            recordsAffected.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_an_personaddress_be_deleted_joining_thru_address(int version, int expected = 14)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.Delete()
                .From(dbo.PersonAddress)
                .InnerJoin(dbo.Address).On(dbo.PersonAddress.AddressId == dbo.Address.Id)
                .Where(dbo.Address.Id == 1);

            //when               
            var recordsAffected = exp.Execute();

            //then
            recordsAffected.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_an_personaddress_be_deleted_for_person_lastname(int version, string lastName = "Broflovski", int expected = 6)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.Delete()
                .From(dbo.PersonAddress)
                .InnerJoin(dbo.Person).On(dbo.PersonAddress.PersonId == dbo.Person.Id)
                .Where(dbo.Person.LastName == lastName);

            //when               
            var recordsAffected = exp.Execute();

            //then
            recordsAffected.Should().Be(expected);
        }

    }
}

using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "DELETE")]
    public class DeleteTests : ResetDatabaseAfterEveryTest
    {
        [Theory]
        [InlineData(14)]
        public void Can_a_personaddress_be_deleted(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.Delete()
                .From(dbo.PersonAddress)
                .Where(dbo.PersonAddress.AddressId == 1);

            //when               
            var recordsAffected = exp.Execute();

            //then
            recordsAffected.Should().Be(expected);
        }

        [Theory]
        [InlineData(14)]
        public void Can_a_personaddress_be_deleted_joining_thru_address(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
        [InlineData("Broflovski", 6)]
        public void Can_a_personaddress_be_deleted_for_person_lastname(string lastName, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.Delete()
                .From(dbo.PersonAddress)
                .InnerJoin(dbo.Person).On(dbo.PersonAddress.PersonId == dbo.Person.Id)
                .Where(dbo.Person.LastName == lastName);

            //when               
            var recordsAffected = exp.Execute();

            //then
            recordsAffected.Should().Be(expected);
        }

        [Theory]
        [InlineData(1)]
        public void Can_a_purchaseline_be_deleted_using_top_be_deleted_and_return_correct_records_affected(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.Delete()
                .Top(1)
                .From(dbo.PurchaseLine);

            //when               
            var recordsAffected = exp.Execute();

            //then
            recordsAffected.Should().Be(expected);
        }

        [Theory]
        [InlineData(17)]
        public void Can_a_purchaseline_be_deleted_using_top_be_deleted_and_return_correct_record_count(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            db.Delete()
                .Top(1)
                .From(dbo.PurchaseLine)
                .Execute();

            //then
            var recordsAffected = db.SelectOne(db.fx.Count()).From(dbo.PurchaseLine).Execute();
            recordsAffected.Should().Be(expected);
        }

    }
}

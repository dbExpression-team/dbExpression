using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Statement", "DELETE")]
    public class DeleteTests : ResetDatabaseAfterEveryTest
    {
        [Theory]
        [InlineData(true, 14)]
        [InlineData(false, 14)]
        public void Can_a_personaddress_be_deleted(bool useSyntheticAliases, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

            var exp = db.Delete()
                .From(dbo.PersonAddress)
                .Where(dbo.PersonAddress.AddressId == 1);

            //when               
            var recordsAffected = exp.Execute();

            //then
            recordsAffected.Should().Be(expected);
        }

        [Theory]
        [InlineData(true, 14)]
        [InlineData(false, 14)]
        public void Can_a_personaddress_be_deleted_joining_thru_address(bool useSyntheticAliases, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

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
        [InlineData(true, "Broflovski", 6)]
        [InlineData(false, "Broflovski", 6)]
        public void Can_a_personaddress_be_deleted_for_person_lastname(bool useSyntheticAliases, string lastName, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

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
        [InlineData(true, 1)]
        [InlineData(false, 1)]
        public void Can_a_purchaseline_be_deleted_using_top_be_deleted_and_return_correct_records_affected(bool useSyntheticAliases, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

            var exp = db.Delete()
                .Top(1)
                .From(dbo.PurchaseLine);

            //when               
            var recordsAffected = exp.Execute();

            //then
            recordsAffected.Should().Be(expected);
        }

        [Theory]
        [InlineData(true, 17)]
        [InlineData(false, 17)]
        public void Can_a_purchaseline_be_deleted_using_top_be_deleted_and_return_correct_record_count(bool useSyntheticAliases, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

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

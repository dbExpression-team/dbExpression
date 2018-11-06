using Data;
using DataService;
using FluentAssertions;
using HatTrick.DbEx.Sql.Extensions.Builder;
using System.Linq;
using Xunit;
using db = HatTrick.DbEx.MsSql.Builder.MsSqlExpressionBuilder;

namespace HatTrick.DbEx.MsSql.Test.Executor
{
    public class SelectAllPersonTests : ExecutorTestBase
    {
        [Theory]
        [InlineData(2014)]
        public void Are_there_50_person_records(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectAll(dbo.Person.Id)
               .From(dbo.Person);               

            //when               
            var persons = exp.Execute();

            //then
            persons.Should().HaveCount(50);
        }

        public class InnerJoin : ExecutorTestBase
        {
            [Theory]
            [InlineData(2014)]
            public void Does_persons_with_addresses_have_52_records(int version)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(dbo.Person.Id)
                    .From(dbo.Person)
                    .InnerJoin(dbo.Person_Address).On(dbo.Person.Id == dbo.Person_Address.PersonId);

                //when               
                var persons = exp.Execute();

                //then
                persons.Should().HaveCount(52);
            }

            [Theory]
            [InlineData(2014)]
            public void Does_filtering_by_billing_addresstype_equal_to_billing_have_35_records(int version)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(dbo.Person.Id)
                    .From(dbo.Person)
                    .InnerJoin(dbo.Person_Address).On(dbo.Person.Id == dbo.Person_Address.PersonId)
                    .InnerJoin(dbo.Address).On(dbo.Person_Address.AddressId == dbo.Address.Id)
                    .Where(dbo.Address.AddressType == AddressType.Billing);

                //when               
                var persons = exp.Execute();

                //then
                persons.Should().HaveCount(35);
            }

            [Theory]
            [InlineData(2014)]
            public void Does_filtering_by_address_id_equal_to_1_have_14_records(int version)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(dbo.Person.Id)
                    .From(dbo.Person)
                    .InnerJoin(dbo.Person_Address).On(dbo.Person.Id == dbo.Person_Address.PersonId)
                    .InnerJoin(dbo.Address).On(dbo.Person_Address.AddressId == dbo.Address.Id)
                    .Where(dbo.Address.Id == 1);

                //when               
                var persons = exp.Execute();

                //then
                persons.Should().HaveCount(14);
            }

            [Theory]
            [InlineData(2014)]
            public void Does_filtering_by_addresstype_equal_to_billing_and_address_id_not_equal_to_1_have_35_records(int version)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(dbo.Person.Id)
                    .From(dbo.Person)
                    .InnerJoin(dbo.Person_Address).On(dbo.Person.Id == dbo.Person_Address.PersonId)
                    .InnerJoin(dbo.Address).On(dbo.Person_Address.AddressId == dbo.Address.Id)
                    .Where(dbo.Address.AddressType == AddressType.Billing & dbo.Address.Id != 1);

                //when               
                var persons = exp.Execute();

                //then
                persons.Should().HaveCount(35);
            }

            [Theory]
            [InlineData(2014)]
            public void Does_address_count_by_person_have_correct_record_counts(int version)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(
                        dbo.Person.Id, 
                        dbo.Address.Id.Count().As("AddressCount")
                    )
                    .From(dbo.Person)
                    .InnerJoin(dbo.Person_Address).On(dbo.Person.Id == dbo.Person_Address.PersonId)
                    .InnerJoin(dbo.Address).On(dbo.Person_Address.AddressId == dbo.Address.Id)
                    .GroupBy(dbo.Person.Id);

                //when               
                var persons = exp.Execute();

                //then
                persons.Should().HaveCount(35);
                persons.Count(a => a.AddressCount == 1).Should().Be(18);
                persons.Count(a => a.AddressCount == 2).Should().Be(17);
            }

            [Theory]
            [InlineData(2014)]
            public void Does_address_count_by_person_having_count_greater_than_1_have_18_records(int version)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(
                        dbo.Person.Id,
                        dbo.Address.Id.Count().As("AddressCount")
                    )
                    .From(dbo.Person)
                    .InnerJoin(dbo.Person_Address).On(dbo.Person.Id == dbo.Person_Address.PersonId)
                    .InnerJoin(dbo.Address).On(dbo.Person_Address.AddressId == dbo.Address.Id)
                    .GroupBy(dbo.Person.Id)
                    .Having(dbo.Address.Id.Count() > 1);

                //when               
                var persons = exp.Execute();

                //then
                persons.Should().HaveCount(17);
            }

            [Theory]
            [InlineData(2014)]
            public void Does_address_count_by_person_having_count_greater_than_1_and_less_than_3_have_18_records(int version)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(
                        dbo.Person.Id,
                        dbo.Address.Id.Count().As("AddressCount")
                    )
                    .From(dbo.Person)
                    .InnerJoin(dbo.Person_Address).On(dbo.Person.Id == dbo.Person_Address.PersonId)
                    .InnerJoin(dbo.Address).On(dbo.Person_Address.AddressId == dbo.Address.Id)
                    .GroupBy(dbo.Person.Id)
                    //basically equal to 2, testing composite having statement
                    .Having(dbo.Address.Id.Count() > 1 & dbo.Address.Id.Count() < 3);

                //when               
                var persons = exp.Execute();

                //then
                persons.Should().HaveCount(17);
            }

            [Theory]
            [InlineData(2014)]
            public void Does_address_count_by_person_having_count_equal_to_1_2_or_3_have_35_records(int version)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(
                        dbo.Person.Id,
                        dbo.Address.Id.Count().As("AddressCount")
                    )
                    .From(dbo.Person)
                    .InnerJoin(dbo.Person_Address).On(dbo.Person.Id == dbo.Person_Address.PersonId)
                    .InnerJoin(dbo.Address).On(dbo.Person_Address.AddressId == dbo.Address.Id)
                    .GroupBy(dbo.Person.Id)
                    //testing composite having statement with 3 parts
                    .Having(dbo.Address.Id.Count() == 1 | dbo.Address.Id.Count() == 2 | dbo.Address.Id.Count() == 3);

                //when               
                var persons = exp.Execute();

                //then
                persons.Should().HaveCount(35);
            }
        }
    }
}

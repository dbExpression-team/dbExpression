using HatTrick.DbEx.Sql;
using ServerSideBlazorApp.Data;
using ServerSideBlazorApp.dboData;
using ServerSideBlazorApp.DataService;
using ServerSideBlazorApp.dboDataService;
using s = ServerSideBlazorApp.secData;
using ServerSideBlazorApp.secDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSideBlazorApp.Service
{
    public class PersonService
    {
        public IEnumerable<Person> GetPeople(int offset, int length, string nameStartsWith)
        {
            return db.SelectMany<Person>()
             .From(dbo.Person)
             .Where((dbo.Person.FirstName + " " + dbo.Person.LastName).Like(nameStartsWith + "%"))
             .Execute();
        }

        public IEnumerable<Person> GetLegalAgeVIPPeopleWithinZip(string zip, int offset, int length)
        {
            var p = dbo.Person;
            var pa = dbo.PersonAddress;
            var a = dbo.Address;
            var ptpv = dbo.PersonTotalPurchasesView;

            IEnumerable<Person> people = db.SelectMany<Person>()
                .From(p)
                .InnerJoin(pa).On(pa.PersonId == p.Id)
                .InnerJoin(a).On(a.Id == pa.AddressId)
                .InnerJoin(ptpv).On(ptpv.Id == p.Id)
                .Skip(offset).Limit(length)
                .Where(
                    p.BirthDate <= DateTime.Now.Date.AddYears(-21)
                    & a.AddressType == AddressType.Mailing
                    & a.Zip.Like(zip + "%")
                    & ptpv.TotalPurchases > 1500 //VIP
                ).Execute();

            return people;
        }

        public int? GetCreditLimitBySSN(string ssn)
        {
            int? creditLimit = db.SelectOne(dbo.Person.CreditLimit)
                .From(dbo.Person)
                .InnerJoin(sec.Person).On(sec.Person.Id == dbo.Person.Id)
                .Where(sec.Person.SSN == ssn)
                .Execute();

            return creditLimit;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTL.MsSql.MsSqlTest.dbo.DataService;
using d = HTL.MsSql.MsSqlTest.dbo.Data;
using HTL.MsSql.MsSqlTest.sec.DataService;
using s = HTL.MsSql.MsSqlTest.sec.Data;

namespace HTL.MsSql.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            int personCount = dbo.Person.Query().Where(dbo.Person.Id > 0).GetValue<int>(dbo.Person.Id.Count());

            string ssn = sec.Person.Query()
                .InnerJoin(dbo.Person.As("dboP")).On(dbo.Person.Correlate("dboP").Id == sec.Person.PersonId)
                .Where(dbo.Person.Correlate("dboP").Id == 1)
                .GetValue<string>(sec.Person.SSN);

            List<d.Person> Js = dbo.Person.Query()
                .Where(dbo.Person.FirstName.Like("J%"))
                .GetList();

            var texasNames = dbo.Person.Query()
                .InnerJoin(dbo.Person_Address).On(dbo.Person_Address.PersonId == dbo.Person.Id)
                .InnerJoin(dbo.Address).On(dbo.Address.Id == dbo.Person_Address.AddressId)
                .Select(dbo.Person.FirstName + " " + dbo.Person.LastName)
                .Where(dbo.Address.State == "TX")
                .GetDynamicList();

            decimal personOne25PercentCommissionOnUpsell = dbo.Purchase.Query()
                .InnerJoin(dbo.Product).On(dbo.Product.Id == dbo.Purchase.ProductId)
                .Where(dbo.Purchase.PersonId == 1)
                .GetValue<decimal>((dbo.Purchase.PurchasePrice.Sum() - dbo.Product.Price.Sum()) * .25);
        }
    }
}

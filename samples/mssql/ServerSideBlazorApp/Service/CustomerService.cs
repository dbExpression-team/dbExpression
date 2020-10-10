﻿using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;
using ServerSideBlazorApp.Data;
using ServerSideBlazorApp.DataService;
using ServerSideBlazorApp.dboData;
using ServerSideBlazorApp.dboDataService;
using ServerSideBlazorApp.Models;
using ServerSideBlazorApp.secDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSideBlazorApp.Service
{
    public class CustomerService
    {
        public async Task<IEnumerable<(int,decimal)>> GetPurchaseValueByYear(int customerId)
        {
            IEnumerable<dynamic> metrics = await

                db.SelectMany(
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate).As("Year"),
                    db.fx.Sum(dbo.Purchase.TotalPurchaseAmount)
                )
                .From(dbo.Purchase)
                .Where(dbo.Purchase.PersonId == customerId)
                .GroupBy(
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate)
                )

                .ExecuteAsync();

            return metrics.Select(x => ((int,decimal))(x.Year, x.TotalPurchaseAmount));
        }

        public async Task<PageResponseModel<CustomerSummaryModel>> GetSummaryPageAsync(PageModel model)
        {
            var customers = await
                db.SelectMany(
                    dbo.Person.Id,
                    (dbo.Person.FirstName + " " + dbo.Person.LastName).As("Name"),
                    db.fx.IsNull(dbo.PersonTotalPurchasesView.TotalAmount, 0m).As("LifetimeValue"),
                    db.fx.Floor(db.fx.DateDiff(DateParts.Day, dbo.Person.BirthDate, db.fx.GetUtcDate()) / 365.25).As("CurrentAge")
                )
                .From(dbo.Person)
                .Where(string.IsNullOrWhiteSpace(model.SearchPhrase) ? null : (dbo.Person.FirstName + " " + dbo.Person.LastName).Like(model.SearchPhrase + '%'))
                .LeftJoin(dbo.PersonTotalPurchasesView).On(dbo.Person.Id == dbo.PersonTotalPurchasesView.Id)
                .OrderBy(
                    dbo.Person.FirstName + " " + dbo.Person.LastName
                )
                .Skip(model.Offset).Limit(model.Limit)
                .ExecuteAsync(row =>
                    new CustomerSummaryModel
                    {
                        Id = row.ReadField().GetValue<int>(),
                        Name = row.ReadField().GetValue<string>(),
                        LifetimeValue = row.ReadField().GetValue<decimal?>() ?? 0,
                        CurrentAge = row.ReadField().GetValue<short?>()
                    }
                );

            var countOfCustomers = await
                db.SelectOne(
                    db.fx.Count()
                )
                .From(dbo.Person)
                .LeftJoin(dbo.PersonTotalPurchasesView).On(dbo.Person.Id == dbo.PersonTotalPurchasesView.Id)
                .Where(string.IsNullOrWhiteSpace(model.SearchPhrase) ? null : (dbo.Person.FirstName + " " + dbo.Person.LastName).Like(model.SearchPhrase + '%'))
                .ExecuteAsync();

            return new PageResponseModel<CustomerSummaryModel>(
                model.Offset, 
                model.Limit, 
                model.SearchPhrase, 
                customers,
                countOfCustomers
            );
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
                    & ptpv.TotalAmount > 1500 //VIP
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

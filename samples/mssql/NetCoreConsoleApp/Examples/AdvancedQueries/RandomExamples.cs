using System;
using System.Collections.Generic;
using System.Linq;
using DbExpression.Sql;
using SimpleConsole.Data;
using SimpleConsole.DataService;
using SimpleConsole.dboData;
using SimpleConsole.dboDataService;
using SimpleConsole.secDataService;

namespace NetCoreConsoleApp
{
	public class RandomExamples : IExecute
	{
		#region execute
		public void Execute()
		{
			int cnt1 = this.DeleteProductsNeverPurchased();
			int cnt2 = this.UpdateCreditLimitForAllGenderMatchWithinZip(GenderType.Female, "80440", 1500);
			var resp1 = this.GetPageOfPeopleGreaterThan18YrsOldWithinZipCodeSet(
				2, 
				5, 
				new string[] { "02101", "02124", "02446", "02801", "03820", "08053", "80456" }
			);
			var resp2 = this.FindAllPeopleHavingMoreThanOneAddress();
			var resp3 = this.GetFullNameOfPeopleWithinZipCode("80456");
			var resp4 = this.FindAllPeopleInfoHavingMoreThanOneAddress();
			var resp5 = this.GetCompleteBillingAddressInfoByPersonId(2);
			var resp6 = this.GetAllPersonPurchaseCountAndTotalPurchasePriceInfoByZipCode("80456");
		}
		#endregion

		#region cross table delete (join based deletes)
		public int DeleteProductsNeverPurchased()
		{
			//delete dbo.Product 
			//from dbo.Product
			//left join dbo.PurchaseLine on dbo.PurchaseLine.ProductId = dbo.Product.Id
			//left join dbo.Purchase on dbo.Purchase.Id = dbo.PurchaseLine.PurchaseId
			//where dbo.Purchase.Id is null;
			int count = db.Delete()
				.From(dbo.Product)
				.LeftJoin(dbo.PurchaseLine).On(dbo.PurchaseLine.ProductId == dbo.Product.Id)
				.LeftJoin(dbo.Purchase).On(dbo.Purchase.Id == dbo.PurchaseLine.PurchaseId)
				.Where(dbo.Purchase.Id == (int?)null)
				.Execute();

			return count;
		}
		#endregion

		#region cross table update (join based update), server side arithmetic
		public int UpdateCreditLimitForAllGenderMatchWithinZip(GenderType gender, string zip, int increase)
		{
			//update dbo.Person
			//set
			//	dbo.Person.CreditLimit = (dbo.Person.CreditLimit + {increase}), 
			//	dbo.Person.YearOfLastCreditLimitReview = DATEPART(year, GETDATE())
			//from dbo.Person
			//inner join dbo.Person_Address on dbo.Person_Address.PersonId = dbo.Person.Id
			//inner join dbo.Address on dbo.Address.Id = dbo.Person_Address.AddressId
			//where dbo.Address.Zip = {zip} and dbo.Person.GenderType = {gender};
			int rowCount = db.Update(
					dbo.Person.CreditLimit.Set(dbo.Person.CreditLimit + increase), //server side arithmetic
					dbo.Person.YearOfLastCreditLimitReview.Set(DateTime.Now.Year)
				)
				.From(dbo.Person)
				.InnerJoin(dbo.PersonAddress).On(dbo.PersonAddress.PersonId == dbo.Person.Id)
				.InnerJoin(dbo.Address).On(dbo.Address.Id == dbo.PersonAddress.AddressId)
				.Where(dbo.Address.Zip == zip & dbo.Person.GenderType == gender)
				.Execute();

			return rowCount;
		}
		#endregion

		#region select many entity, offset/limit, inner join, order by, complex filter
		public IEnumerable<Person> GetPageOfPeopleGreaterThan18YrsOldWithinZipCodeSet(int pageIndex, int pageCount, params string[] zipCodes)//(2, 5)
		{
			//select
			//dbo.Person.*
			//from dbo.Person
			//inner join dbo.Person_Address on dbo.Person_Address.PersonId = dbo.Person.Id
			//inner join dbo.Address on dbo.Address.Id = dbo.Person_Address.AddressId
			//where dbo.Person.BirthDate < DATEADD(y, -18, GETDATE()) and dbo.Address.Zip in ('02101', '02124', '02446', '02801', '03820', '08053', '80456')
			//order by dbo.Person.LastName desc
			//offset 10 rows fetch next 5 rows only;
			var pageOfPeopleOver18 = db.SelectMany<Person>()
				.From(dbo.Person)
				.InnerJoin(dbo.PersonAddress).On(dbo.PersonAddress.PersonId == dbo.Person.Id)
				.InnerJoin(dbo.Address).On(dbo.Address.Id == dbo.PersonAddress.AddressId)
				.Where(dbo.Person.BirthDate < DateTime.Now.AddYears(-18).Date & dbo.Address.Zip.In(zipCodes))
				.OrderBy(dbo.Person.LastName.Desc())
				.Offset(pageIndex * pageCount)
				.Limit(pageCount)
				.Execute();

			return pageOfPeopleOver18;
		}
		#endregion

		#region select many entity, inner join, group by, having
		public IEnumerable<Person> FindAllPeopleHavingMoreThanOneAddress()
		{
			//select
			//dbo.Person.*
			//from dbo.Person
			//inner join dbo.Person_Address on dbo.Person_Address.PersonId = dbo.Person.Id
			//inner join dbo.[Address] on dbo.Address.Id = dbo.Person_Address.AddressId
			//group by dbo.Person.Id, 
			//		 dbo.Person.FirstName, 
			//		 dbo.Person.LastName, 
			//		 dbo.Person.BirthDate, 
			//		 dbo.Person.GenderType, 
			//		 dbo.Person.CreditLimit, 
			//		 dbo.Person.YearOfLastCreditLimitReview, 
			//		 dbo.Person.DateCreated, 
			//		 dbo.Person.DateUpdated
			//having count(dbo.Address.Id) > 1;
			var peopleWithMultiAddresses = db.SelectMany<Person>()
			   .From(dbo.Person)
			   .InnerJoin(dbo.PersonAddress).On(dbo.PersonAddress.PersonId == dbo.Person.Id)
			   .InnerJoin(dbo.Address).On(dbo.Address.Id == dbo.PersonAddress.AddressId)
			   .GroupBy(
                    dbex.SelectAllFor(dbo.Person).Cast<AnyGroupByExpression>()
				)
			   .Having(db.fx.Count(dbo.Address.Id) > 1)
			   .Execute();

			return peopleWithMultiAddresses;
		}
		#endregion

		#region select many projection, concat, inner join, complex filter
		public IEnumerable<string> GetFullNameOfPeopleWithinZipCode(string zip) //80456
		{
			//select
			//CONCAT(dbo.Person.FirstName, ' ', dbo.Person.LastName)
			//from dbo.Person
			//inner join dbo.Person_Address on dbo.Person_Address.PersonId = dbo.Person.Id
			//inner join dbo.[Address] on dbo.[Address].Id = dbo.Person_Address.AddressId
			//where dbo.[Address].Zip = {zip};
			IEnumerable<string> namesInZip = db.SelectMany(
					db.fx.Concat(
						dbo.Person.FirstName, " ", dbo.Person.LastName
					)
				).From(dbo.Person)
				.InnerJoin(dbo.PersonAddress).On(dbo.PersonAddress.PersonId == dbo.Person.Id)
				.InnerJoin(dbo.Address).On(dbo.Address.Id == dbo.PersonAddress.AddressId)
				.Where(dbo.Address.Zip == zip & (dbo.Address.AddressType == AddressType.Shipping | dbo.Address.AddressType == AddressType.Mailing))
				.Execute();

			return namesInZip;
		}
		#endregion

		#region select many projection, aggregate count, column aliasing, inner join, group by, having
		public IEnumerable<dynamic> FindAllPeopleInfoHavingMoreThanOneAddress()
		{
			//select
			//dbo.Person.Id,
			//dbo.Person.FirstName,
			//dbo.Person.LastName,
			//count(dbo.[Address].Id) as AddressCount
			//from dbo.Person
			//inner join dbo.Person_Address on dbo.Person_Address.PersonId = dbo.Person.Id
			//inner join dbo.[Address] on dbo.Address.Id = dbo.Person_Address.AddressId
			//group by dbo.Person.Id, dbo.Person.FirstName, dbo.Person.LastName
			//having count(dbo.Address.Id) > 1;
			var peopleWithMultiAddresses = db.SelectMany(
					dbo.Person.Id.As("PersonId"),
					dbo.Person.FirstName,
					dbo.Person.LastName,
					db.fx.Count(dbo.Address.Id).As("AddressCount")
				)
				.From(dbo.Person)
				.InnerJoin(dbo.PersonAddress).On(dbo.PersonAddress.PersonId == dbo.Person.Id)
				.InnerJoin(dbo.Address).On(dbo.Address.Id == dbo.PersonAddress.AddressId)
				.GroupBy(dbo.Person.Id, dbo.Person.FirstName, dbo.Person.LastName)
				.Having(db.fx.Count(dbo.Address.Id) > 1)
				.Execute();

			return peopleWithMultiAddresses;
		}
		#endregion

		#region select on projection, concat, column aliasing, inner join
		public dynamic GetCompleteBillingAddressInfoByPersonId(int personId)
		{
			//select
			//Concat(dbo.Person.FirstName, ' ', dbo.Person.LastName) as FullName,
			//Concat(dbo.Address.Line1, dbo.Address.Line2) as Street,
			//dbo.Address.City,
			//dbo.Address.State,
			//dbo.Address.Zip
			//from dbo.Person
			//inner join dbo.Person_Address on dbo.Person_Address.PersonId = dbo.Person.Id
			//inner join dbo.Address on dbo.Address.Id = dbo.Person_Address.AddressId
			//where dbo.Person.Id = {personId} and dbo.Address.AddressType = 2;
			var addressInfo = db.SelectOne(
					db.fx.Concat(dbo.Person.FirstName, " ", dbo.Person.LastName).As("FullName"),
					db.fx.Concat(dbo.Address.Line1, " ", dbo.Address.Line2).As("Street"),
					dbo.Address.City,
					dbo.Address.State,
					dbo.Address.Zip
				)
				.From(dbo.Person)
				.InnerJoin(dbo.PersonAddress).On(dbo.PersonAddress.PersonId == dbo.Person.Id)
				.InnerJoin(dbo.Address).On(dbo.Address.Id == dbo.PersonAddress.AddressId)
				.Where(dbo.Person.Id == personId & dbo.Address.AddressType == AddressType.Billing)
				.Execute();

			return addressInfo;
		}
		#endregion

		#region select many projection, concat, aggregate count, aggregate sum, column aliasing, inner join, group by
		public IEnumerable<dynamic> GetAllPersonPurchaseCountAndTotalPurchasePriceInfoByZipCode(string zip)
		{
			//select
			//dbo.Person.Id,
			//concat(dbo.Person.FirstName, ' ', dbo.Person.LastName) as FullName,
			//dbo.Person.DateCreated as CustomerSince,
			//Count(dbo.Purchase.Id) as PurchaseCount,
			//Sum(dbo.Purchase.TotalPurchaseAmount) as TotalPurchaseAmount
			//from dbo.Person
			//inner join dbo.Purchase on dbo.Purchase.PersonId = dbo.Person.Id
			//inner join dbo.Person_Address on dbo.Person_Address.PersonId = dbo.Person.Id
			//inner join dbo.Address on dbo.Address.Id = dbo.Person_Address.AddressId
			//where dbo.Address.Zip = '{zip}'
			//group by dbo.Person.Id, dbo.Person.FirstName, dbo.Person.LastName, dbo.Person.DateCreated
			var info = db.SelectMany(
					dbo.Person.Id,
					db.fx.Concat(dbo.Person.FirstName, " ", dbo.Person.LastName).As("FullName"),
					dbo.Person.DateCreated.As("CustomerSince"),
					db.fx.Count(dbo.Purchase.Id).As("PurchaseCount"),
					db.fx.Sum(dbo.Purchase.TotalPurchaseAmount).As("TotalPurchaseAmount")
				)
				.From(dbo.Person)
				.InnerJoin(dbo.Purchase).On(dbo.Purchase.PersonId == dbo.Person.Id)
				.InnerJoin(dbo.PersonAddress).On(dbo.PersonAddress.PersonId == dbo.Person.Id)
				.InnerJoin(dbo.Address).On(dbo.Address.Id == dbo.PersonAddress.AddressId)
				.Where(dbo.Address.Zip == zip)
				.GroupBy(dbo.Person.Id, dbo.Person.FirstName, dbo.Person.LastName, dbo.Person.DateCreated)
				.Execute();

			return info;
		}
		#endregion
	}
}

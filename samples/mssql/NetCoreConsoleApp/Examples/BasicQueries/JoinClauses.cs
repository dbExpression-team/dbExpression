using System;
using System.Collections.Generic;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.MsSql.Expression;
using SimpleConsole.Data;
using SimpleConsole.DataService;
using SimpleConsole.dboData;
using SimpleConsole.dboDataService;

namespace NetCoreConsoleApp
{
	public class JoinClauses : IExecute
	{
		#region execute
		public void Execute()
		{
			//inner
			string desc= this.GetPurchaseLineProductDescriptionByPurchaseLineId(2);
			Address address = this.GetBillingAddressForPersonByPersonId(2);

			//left
			IList<Person> xPurchase = this.GetPeopleWhoHaveNotCompletedAPurchase();

			//right
			IList<dynamic> history = GetPersonCreditInfoForZipCode("94043");

			//full
			IList<dynamic> purchases = GetPeoplePurchaseInfo();

			//cross
			IList<dynamic> possible = GetAllTwoProductPurchaseVariations();
		}
		#endregion

		#region inner join
		public string GetPurchaseLineProductDescriptionByPurchaseLineId(int id)
		{
			//select
			//dbo.Product.Description
			//from dbo.PurchaseLine
			//inner join dbo.Product on dbo.Product.Id = dbo.PurchaseLine.ProductId
			//where dbo.PurchaseLine.Id = {id};
			string desc = db.SelectOne(dbo.Product.Description)
				.From(dbo.PurchaseLine)
				.InnerJoin(dbo.Product).On(dbo.Product.Id == dbo.PurchaseLine.ProductId)
				.Where(dbo.PurchaseLine.Id == id)
				.Execute();

			return desc;
		}

		public Address GetBillingAddressForPersonByPersonId(int personId)
		{
			//select
			//dbo.Address.*
			//from dbo.Address
			//inner join dbo.Person_Address on dbo.Person_Address.AddressId = dbo.Address.Id
			//inner join dbo.Person on dbo.Person.Id = dbo.Person_Address.PersonId
			//where dbo.Address.AddressType = 2 and dbo.Person.Id = {personId}
			var billing = db.SelectOne<Address>()
				.From(dbo.Address)
				.InnerJoin(dbo.PersonAddress).On(dbo.PersonAddress.AddressId == dbo.Address.Id)
				.InnerJoin(dbo.Person).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
				.Where(dbo.Address.AddressType == AddressType.Billing & dbo.Person.Id == personId)
				.Execute();

			return billing;
		}
		#endregion

		#region left join
		public IList<Person> GetPeopleWhoHaveNotCompletedAPurchase()
		{
			//select
			//dbo.Person.*
			//from dbo.Person
			//left join dbo.Purchase on dbo.Purchase.PersonId = dbo.Person.Id
			//where dbo.Purchase.Id IS NULL;
			IList<Person> peopleNoPurchase = db.SelectMany<Person>()
				.From(dbo.Person)
				.LeftJoin(dbo.Purchase).On(dbo.Purchase.PersonId == dbo.Person.Id)
				.Where(dbo.Purchase.Id == (int?)null)
				.Execute();

			return peopleNoPurchase;
		}
		#endregion

		#region right join
		public IList<dynamic> GetPersonCreditInfoForZipCode(string zip)
		{
			//select
			//dbo.Person.Id,
			//dbo.Person.FirstName,
			//dbo.Person.LastName,
			//dbo.Person.CreditLimit,
			//dbo.Person.YearOfLastCreditLimitReview
			//from dbo.Address
			//right join dbo.Person_Address on dbo.Person_Address.AddressId = dbo.Address.Id
			//right join dbo.Person on dbo.Person.Id = dbo.Person_Address.AddressId
			//where dbo.Address.Zip = '{zip}' and dbo.Address.AddressType = 1;
			var info = db.SelectMany(
					dbo.Person.Id,
					dbo.Person.FirstName,
					dbo.Person.LastName,
					dbo.Person.CreditLimit,
					dbo.Person.YearOfLastCreditLimitReview
				).From(dbo.Address)
				.RightJoin(dbo.PersonAddress).On(dbo.PersonAddress.AddressId == dbo.Address.Id)
				.RightJoin(dbo.Person).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
				.Where(dbo.Address.Zip == zip & dbo.Address.AddressType == AddressType.Billing)
				.Execute();

			return info;
		}
		#endregion

		#region full join
		public IList<dynamic> GetPeoplePurchaseInfo()
		{
			//select
			//dbo.Person.Id,
			//dbo.Person.FirstName,
			//dbo.Person.LastName,
			//IsNull(dbo.Purchase.OrderNumber, '') as OrderNumber,
			//IsNull(dbo.Purchase.TotalPurchaseAmount, 0.0) as TotalPurchaseAmount
			//from dbo.Person
			//full join dbo.Purchase on dbo.Purchase.PersonId = dbo.Person.Id
			var purchases = db.SelectMany(
					dbo.Person.Id,
					dbo.Person.FirstName,
					dbo.Person.LastName,
					db.fx.IsNull(dbo.Purchase.OrderNumber, string.Empty).As("OrderNumber"),
					db.fx.IsNull(dbex.Coerce(dbo.Purchase.TotalPurchaseAmount), 0.0).As("TotalPurchaseAmount")
				)
				.From(dbo.Person)
				.FullJoin(dbo.Purchase).On(dbo.Purchase.PersonId == dbo.Person.Id)
				.Execute();
			//TODO: @P1 order number declared as char(8000) 
			return purchases;
		}
		#endregion

		#region cross join
		public IList<dynamic> GetAllTwoProductPurchaseVariations()
		{
			//select
			//p1.Name as Product1,
			//p2.Name as Product2,
			//(p1.Price + p2.Price) as Price
			//from dbo.Product p1
			//cross join dbo.Product p2
			//where p1.Id <> p2.Id
			IList<dynamic> result = db.SelectMany(
				dbo.Product.As("p1").Name.As("Product1"),
				dbo.Product.As("p2").Name.As("Product2"),
				(dbo.Product.As("p1").Price + dbo.Product.As("p2").Price).As("Price")
			)
			.From(dbo.Product.As("p1"))
			.CrossJoin(dbo.Product.As("p2"))
			.Where(dbo.Product.As("p1").Id != dbo.Product.As("p2").Id)
			.Execute();

			return result;
		}
		#endregion
	}
}

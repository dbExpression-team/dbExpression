using System;
using System.Collections.Generic;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.MsSql;
using SimpleConsole.Data;
using SimpleConsole.DataService;
using SimpleConsole.dboData;
using SimpleConsole.dboDataService;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql.Connection;

namespace NetCoreConsoleApp
{
	public class SelectExpressions
	{
		#region select one (table based or view based) object
		public Person SelectPersonById(int id)
		{
			//select * from dbo.Person where dbo.Person.Id = {id};
			var p = db.SelectOne<Person>().From(dbo.Person).Where(dbo.Person.Id == id).Execute();

			return p;
		}

		public Person SelectPersonByFirstNameLastNameAndBirthdate(string firstName, string lastName, DateTime birthdate)
		{
			//select * from dbo.Person 
			//where dbo.Person.FirstName = {firstName} and dbo.Person.LastName = {lastName} & dbo.Person.BirthDate = {birthdate};
			var p = db.SelectOne<Person>()
				.From(dbo.Person)
				.Where(dbo.Person.FirstName == firstName 
				     & dbo.Person.LastName == lastName 
					 & dbo.Person.BirthDate == birthdate.Date)
				.Execute();

			return p;
		}

		public PersonTotalPurchasesView SelectTotalPurchaseViewByPersonId(int id)
		{
			//select * from dbo.PersonTotalPurchaseView where dbo.PersonTotalPurchaseView.Id = {id};
			var tpv = db.SelectOne<PersonTotalPurchasesView>()
				.From(dbo.PersonTotalPurchasesView)
				.Where(dbo.PersonTotalPurchasesView.Id == id)
				.Execute();

			return tpv;
		}
		#endregion

		#region select one value (simple)
		public string SelectProductNameByid(int id)
		{
			//select * from dbo.Product where dbo.Product.Id = {id};
			string name = db.SelectOne(dbo.Product.Name)
				.From(dbo.Product)
				.Where(dbo.Product.Id == id)
				.Execute();

			return name;
		}

		public string GetProductDescriptionByNameAndPrice(string name, double price)
		{
			//select dbo.Product.Description from dbo.Product where dbo.Product.Name = {name} and dbo.Product.Price = {price};
			string desc = db.SelectOne(dbo.Product.Description)
				.From(dbo.Product)
				.Where(dbo.Product.Name == name & dbo.Product.Price == price)
				.Execute();

			return desc;
		}
		#endregion

		#region get one value (concatenation)
		public string GetPersonFullNameById(int id)
		{
			//select CONCAT(dbo.Person.FirstName, ' ', dbo.Person.LastName) from dbo.Person where id = 3;
			string fullName = db.SelectOne(
					db.fx.Concat(dbo.Person.FirstName, " ", dbo.Person.LastName)
				).From(dbo.Person)
				.Where(dbo.Person.Id == id)
				.Execute();

			return fullName;
		}

		public string GetFullAddressById(int id)
		{
			//select
			//dbo.Address.Line1 + ' ' + dbo.Address.Line2
			//+ (CHAR(13) + CHAR(10))
			//+ dbo.Address.City + ', ' + dbo.Address.State + ' ' + dbo.Address.Zip
			//from dbo.Address
			//where dbo.Address.Id = {id};
			string fullAddress = db.SelectOne(
				dbo.Address.Line1 + " " + dbo.Address.Line2
				+ Environment.NewLine
				+ dbo.Address.City + ", " + dbo.Address.State + " " + dbo.Address.Zip
				).From(dbo.Address)
				.Where(dbo.Address.Id == id)
				.Execute();

			return fullAddress;
		}
		#endregion

		#region get one or many values (arithmetic)
		public double GetTotalValueOfProductOnHandById(int id)
		{
			//select (dbo.Product.Quantity * dbo.Product.Price) 
			//from dbo.Product where dbo.Product.Id = {id};
			double value = db.SelectOne(dbo.Product.Quantity * dbo.Product.Price)
				.From(dbo.Product)
				.Where(dbo.Product.Id == id)
				.Execute();

			return value;
		}

        public IList<double> GetTotalValueOfAllProductsOnHand()
        {
            //select (dbo.Product.Quantity * dbo.Product.Price) from dbo.Product;
            IList<double> values = db.SelectMany(dbo.Product.Quantity * dbo.Product.Price)
                .From(dbo.Product)
                .Execute();

            return values;
        }
        #endregion

        #region get one value (aggregation functions)
        public double GetAvgProductPrice()
		{
			//select AVG(dbo.Product.Price) from dbo.Product;
			double avg = db.SelectOne(db.fx.Avg(dbo.Product.Price))
				.From(dbo.Product)
				.Execute();

			return avg;
		}

		public double GetTotalPurchaseRevenue()
		{
			//select SUM(dbo.Purchase.TotalPurchaseAmount) from dbo.Purchase;
			double revenue = db.SelectOne(db.fx.Sum(dbo.Purchase.TotalPurchaseAmount))
				.From(dbo.Purchase)
				.Execute();

			return revenue;
		}

		public decimal GetMaxPurchaseLinePriceForAProductById(int id)
		{
			//select MAX(dbo.PurchaseLine.PurchasePrice) from dbo.Purchase;
			decimal max = db.SelectOne(db.fx.Max(dbo.PurchaseLine.PurchasePrice))
				.From(dbo.PurchaseLine)
				.Where(dbo.PurchaseLine.ProductId == id)
				.Execute();

			return max;
		}

		public int GetCountOfPurchaseLinesForProductId(int productId)
		{
			//select
			//count(dbo.PurchaseLine.Id)
			//from dbo.PurchaseLine
			//where dbo.PurchaseLine.ProductId = {id};
			int count = db.SelectOne(db.fx.Count(dbo.PurchaseLine.Id))
				.From(dbo.PurchaseLine)
				.Where(dbo.PurchaseLine.ProductId == productId)
				.Execute();

			return count;
		}
		#endregion

		#region select many (table based or view based) objects
		public IList<Person> GetPeopleOverAge25()
		{
			//select * from dbo.Person where dbo.Person.BirthDate < DATEADD(yy, -25, GETDATE());
			var people = db.SelectMany<Person>()
				.From(dbo.Person)
				.Where(dbo.Person.BirthDate < DateTime.Now.AddYears(-25))
				.Execute();

			return people;
		}

		public IList<Product> GetProductsWithListPriceAtLeast20DollarsButLessThan30()
		{
			//select * from dbo.Product where dbo.Product.ListPrice >= 20.0 and dbo.Product.ListPrice < 30.0;
			var products = db.SelectMany<Product>()
				.From(dbo.Product).Where(dbo.Product.ListPrice >= 20.0 & dbo.Product.ListPrice < 30.0)
				.Execute();

			return products;
		}

		public IList<Address> GetAllAddressesWithinZip(string zip)
		{
			//select * from dbo.Address where dbo.Address.Zip = {zip};
			var addresses = db.SelectMany<Address>()
				.From(dbo.Address)
				.Where(dbo.Address.Zip == zip)
				.Execute();

			return addresses;
		}
		#endregion

		#region select one or many (table, view or value) with join clause
		public string GetPurchaseLineProductDescriptionByPurchaseLineId(int id)
		{
			//select
			//dbo.Product.Description
			//from dbo.PurchaseLine
			//inner join dbo.Product on dbo.Product.Id = dbo.PurchaseLine.ProductId
			//where dbo.PurchaseLine.Id = { int};
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
			var shippingAddress = db.SelectOne<Address>()
				.From(dbo.Address)
				.InnerJoin(dbo.PersonAddress).On(dbo.PersonAddress.AddressId == dbo.Address.Id)
				.InnerJoin(dbo.Person).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
				.Where(dbo.Address.AddressType == AddressType.Billing & dbo.Person.Id == personId)
				.Execute();

			return shippingAddress;
		}

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

		public IList<string> GetFullNameOfPeopleWithinZipCode(string zip) //80456
		{
			//select
			//CONCAT(dbo.Person.FirstName, ' ', dbo.Person.LastName)
			//from dbo.Person
			//inner join dbo.Person_Address on dbo.Person_Address.PersonId = dbo.Person.Id
			//inner join dbo.[Address] on dbo.[Address].Id = dbo.Person_Address.AddressId
			//where dbo.[Address].Zip = {zip};
			IList<string> namesInZip = db.SelectMany(
					db.fx.Concat(
						dbo.Person.FirstName, " ", dbo.Person.LastName
					)
				).From(dbo.Person)
				.InnerJoin(dbo.PersonAddress).On(dbo.PersonAddress.PersonId == dbo.Person.Id)
				.InnerJoin(dbo.Address).On(dbo.Address.Id == dbo.PersonAddress.AddressId)
				.Where(dbo.Address.Zip == zip)
				.Execute();

			return namesInZip;
		}
		#endregion

		#region select many (table, view or value) with skip/limit, order by, group by, having
		public IList<Person> PaginateAllPeopleGreaterThan18YrsOldWithinZipCodeSet(int pageIndex, int pageCount, params string[] zipCodes)//(2, 5)
		{
            //select
            //dbo.Person.*
            //from dbo.Person
            //inner join dbo.Person_Address on dbo.Person_Address.PersonId = dbo.Person.Id
            //inner join dbo.Address on dbo.Address.Id = dbo.Person_Address.AddressId
            //where dbo.Person.BirthDate < DATEADD(y, -18, GETDATE()) and dbo.Address.Zip in ('02101', '02124', '02446', '02801', '03820', '08053', '80456')
            //order by dbo.Person.LastName desc
            //OFFSET 10 ROWS FETCH NEXT 5 ROWS ONLY;
            var pageOfPeopleOver18 = db.SelectMany<Person>()
				.From(dbo.Person)
                .InnerJoin(dbo.PersonAddress).On(dbo.PersonAddress.PersonId == dbo.Person.Id)
                .InnerJoin(dbo.Address).On(dbo.Address.Id == dbo.PersonAddress.AddressId)
				.Where(dbo.Person.BirthDate < DateTime.Now.AddYears(-18).Date & dbo.Address.Zip.In(zipCodes))
				.OrderBy(dbo.Person.LastName.Desc)
				.Skip(pageIndex * pageCount)
				.Limit(pageCount)
				.Execute();

			return pageOfPeopleOver18;
		}

		public IList<Person> FindAllPeopleHavingMoreThanOneAddress()
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
					dbo.Person.Id,
					dbo.Person.FirstName,
					dbo.Person.LastName,
					dbo.Person.BirthDate,
					dbo.Person.GenderType,
					dbo.Person.CreditLimit,
					dbo.Person.YearOfLastCreditLimitReview,
					dbo.Person.DateCreated,
					dbo.Person.DateUpdated)
			   .Having(db.fx.Count(dbo.Address.Id) > 1)
			   .Execute();

			return peopleWithMultiAddresses;
		}
		#endregion

		#region complex filters (controlling  precedence with (parenthesis), Like operator)
		public IList<Person> FindAllPeopleWithLastNameStartingWith(char c)//P
		{
			//select * from dbo.Person where dbo.Person.LastName like('{c}%') order by dbo.Person.LastName Asc;
			var peopleLastNameStartsWithChar = db.SelectMany<Person>()
				.From(dbo.Person)
				.Where(dbo.Person.LastName.Like($"{c}%"))
				.OrderBy(dbo.Person.LastName.Asc)
				.Execute();

			return peopleLastNameStartsWithChar;
		}

		public IList<string> GetAllLastNamesOfPeopleWhereSecondPositionOfLastNameIsChar(char c)//t
		{
			//select * from dbo.Person where dbo.Person.LastName Like('_{c}%') order by dbo.Person.BirthDate Asc;
			var result = db.SelectMany(dbo.Person.LastName)
				.From(dbo.Person)
				.Where(dbo.Person.LastName.Like($"_{c}%"))
				.OrderBy(dbo.Person.BirthDate.Asc)
				.Execute();

			return result;
		}

		public IList<Person> GetPeopleByComplexGenderAndZipFilter()
		{
			//select
			//dbo.Person.*
			//from dbo.Person
			//inner join dbo.Person_Address on dbo.Person_Address.PersonId = dbo.Person.Id
			//inner join dbo.[Address] on dbo.Address.Id = dbo.Person_Address.AddressId
			//where
			//(
			//	(dbo.Person.GenderType = 1 and(dbo.[Address].Zip = '80456' or dbo.[Address].Zip = '94043'))
			//	or
			//	(dbo.Person.GenderType = 2 and(dbo.[Address].Zip = '10002' or dbo.[Address].Zip = '02801'))
			//)
			//order by dbo.Person.GenderType Asc;
			IList<Person> result = db.SelectMany<Person>()
				.From(dbo.Person)
				.InnerJoin(dbo.PersonAddress).On(dbo.PersonAddress.PersonId == dbo.Person.Id)
				.InnerJoin(dbo.Address).On(dbo.Address.Id == dbo.PersonAddress.AddressId)
				.Where
				(
					(
						(dbo.Person.GenderType == GenderType.Male & (dbo.Address.Zip == "80456" | dbo.Address.Zip == "94043"))
						|
						(dbo.Person.GenderType == GenderType.Female & (dbo.Address.Zip == "10002" | dbo.Address.Zip == "02801"))
					)
				)
				.OrderBy(dbo.Person.GenderType.Asc)
				.Execute();

			return result;
		}
		#endregion

		#region select projections (column aliasing)
		public IList<dynamic> FindAllPeopleInfoHavingMoreThanOneAddress()
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
            //where dbo.Person.Id = {id} and dbo.Address.AddressType = {type};
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

		public IList<dynamic> GetAllPersonPurchaseCountAndTotalPurchasePriceInfoByZipCode(string zip)
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

		#region complex sub queries
		public object SelectPersonTotalPurchaseToCreditLimitReport()
		{
			//select
			//	p.id as PersonId,
			//	p.LastName + ', ' + p.FirstName as FullName,
			//	isNull(t0.TotalPurchaseAmount, 0) as TotalPurchaseAmount,
			//	p.YearOfLastCreditLimitReview,
			//	p.CreditLimit
			//from dbo.Person p
			//left join
			//(
			//	select
			//	pu.PersonId,
			//	sum(pu.TotalPurchaseAmount) as TotalPurchaseAmount
			//	from dbo.Purchase pu
			//	group by pu.PersonId
			//) t0 on t0.PersonId = p.Id
			//order by p.LastName asc;
			var rpt = db.SelectMany(
					dbo.Person.Id.As("PersonId"),
					db.fx.Concat(dbo.Person.LastName, ", ", dbo.Person.FirstName).As("FullName"),
					db.fx.IsNull(dbex.alias("t0", "TotalPurchaseAmount"), 0).As("TotalPurchaseAmount"),
					dbo.Person.YearOfLastCreditLimitReview,
					dbo.Person.CreditLimit
				).From(dbo.Person)
				.LeftJoin(
					db.SelectMany(
						dbo.Purchase.PersonId, 
						db.fx.Sum(dbo.Purchase.TotalPurchaseAmount).As("TotalPurchaseAmount")
					)
					.From(dbo.Purchase)
					.GroupBy(dbo.Purchase.PersonId))
					.As("t0")
				.On(dbex.alias("t0", "PersonId") == dbo.Person.Id)
				.OrderBy(dbo.Person.LastName.Asc)
				.Execute();

			return rpt;
		}

		public object SelectVIPByPurchaseCountAndYear(int purchaseCount, int year)
		{
			//select
			//	[dbo].[Person].[Id] AS [PersonId],
			//	[vips].[PurchaseCount],
			//	[vips].[PurchaseYear],
			//	[dbo].[Person].[LastName] + ', ' + [dbo].[Person].[FirstName] as [FullName]
			//from
			//[dbo].[Person]
			//inner join (
			//		select
			//			[dbo].[Purchase].[PersonId],
			//			datepart(year, [dbo].[Purchase].[PurchaseDate]) AS [PurchaseYear],
			//			count([dbo].[Purchase].[Id]) AS [PurchaseCount]
			//		from
			//			[dbo].[Purchase]
			//		group by
			//			[dbo].[Purchase].[PersonId], datepart(year, [dbo].[Purchase].[PurchaseDate])
			//		having 
			//			(count([dbo].[Purchase].[PurchaseDate]) >= 3 AND datepart(year, [dbo].[Purchase].[PurchaseDate]) = 2017)
			//) as [vips] on [dbo].[Person].[Id]=[vips].[PersonId]
			//order by
			//[dbo].[Person].[LastName] asc, [vips].[PurchaseCount] desc

			var vip = db.SelectMany(
				dbo.Person.Id.As("PersonId"), 
				dbex.alias("vips", "PurchaseCount"), 
				dbex.alias("vips", "PurchaseYear"), 
				(dbo.Person.FirstName + " " + dbo.Person.LastName).As("FullName"))
				.From(dbo.Person)
				.InnerJoin(
					db.SelectMany(
						dbo.Purchase.PersonId, 
						db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate).As("PurchaseYear"), 
						db.fx.Count(dbo.Purchase.Id).As("PurchaseCount")
						)
					.From(dbo.Purchase)
					.GroupBy(dbo.Purchase.PersonId, db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate))
					.Having(
							db.fx.Count(dbo.Purchase.Id) >= purchaseCount 
							& db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate) == year)
					).As("vips")
				.On(dbo.Person.Id == dbex.alias("vips", "PersonId"))
				.OrderBy(dbo.Person.Id.Asc, dbex.alias("vips", "PurchaseCount").Desc)
				.Execute();

			return vip;
		}
		#endregion
	}
}


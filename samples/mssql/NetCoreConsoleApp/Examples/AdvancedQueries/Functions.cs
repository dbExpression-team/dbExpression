using System;
using System.Collections.Generic;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.MsSql.Expression;
using SimpleConsole.Data;
using SimpleConsole.DataService;
using SimpleConsole.dboData;
using SimpleConsole.dboDataService;
using System.Linq;

namespace NetCoreConsoleApp
{
	public class Functions : IExecute
	{
		#region execute
		public void Execute()
		{
			double avg = this.GetAvgProductPrice();
			double revenue = this.GetTotalPurchaseRevenue();
			decimal max = this.GetMaxPurchaseLinePriceForAProductById(1);
			int count = this.GetCountOfPurchaseLinesForProductId(1);
			Stats stats = this.GetPurchaseStatistics(DateTime.Parse("2018-01-01"), DateTime.Parse("2021-03-01"));
			string fullName = this.GetFullName(6);
			IEnumerable<(int, int)> personIdCreditLimit = this.GetCreditLimitForPersonSet(1, 2, 3, 4, 5, 6, 8, 9, 10);
			DateTimeOffset lastActivity = this.GetLastActivityTimestamp(5);
			(decimal, decimal) maxAndMin = this.GetMaxAndMinProductHeightsRoundedToNearestTenth(9);
			this.SetYearOfLastCreditReviewToCurrentYear(5);
			decimal avgPrice = this.GetAvgProductListPrice();
			decimal? difference = this.GetAbsoluteDifferenceBetweenProductWidthAndHeight(1);
			IEnumerable<Person> persons = this.GetPersonsWithFirstNameStartingWith("K");
			this.UpdateAddressLine2WithAbbreviation("Apartment", "Apt.");
			var lines = this.GetFormattedAddressLinesUsingTrim();
			lines = this.GetFormattedAddressLinesUsingLTrim();
			lines = this.GetFormattedAddressLinesUsingRTrim();
		}
		#endregion

		#region stats class
		public class Stats
		{
			public double Max { get; set; }
			public double Min { get; set; }
			public double Sum { get; set; }
			public double Avg { get; set; }
			public double Count { get; set; }
			public double StDev { get; set; }
			public double StDevP { get; set; }
			public double Var { get; set; }
			public double VarP { get; set; }
		}
		#endregion

		#region aggregates (Max, Min, Sum, Avg, Count, StDev, StDevP, Var, VarP)
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
			//where dbo.PurchaseLine.ProductId = {productId};
			int count = db.SelectOne(db.fx.Count(dbo.PurchaseLine.Id))
				.From(dbo.PurchaseLine)
				.Where(dbo.PurchaseLine.ProductId == productId)
				.Execute();

			return count;
		}

		public Stats GetPurchaseStatistics(DateTime from, DateTime to)
		{
			//select
			//Max(dbo.Purchase.TotalPurchaseAmount) As[Max],
			//Min(dbo.Purchase.TotalPurchaseAmount) As[Min],
			//Sum(dbo.Purchase.TotalPurchaseAmount) As[Sum],
			//Avg(dbo.Purchase.TotalPurchaseAmount) AS[Avg],
			//Count(dbo.Purchase.TotalPurchaseAmount) As[Count],
			//StDev(dbo.Purchase.TotalPurchaseAmount) As[StDev],
			//StDevP(dbo.Purchase.TotalPurchaseAmount) As[StDevP],
			//Var(dbo.Purchase.TotalPurchaseAmount) As[Var],
			//VarP(dbo.Purchase.TotalPurchaseAmount) As[VarP]
			//from dbo.Purchase
			//where dbo.Purchase.PurchaseDate >= {from} and dbo.Purchase.PurchaseDate <= {to};
			var x = db.SelectOne(
					db.fx.Max(dbo.Purchase.TotalPurchaseAmount).As("Max"),
					db.fx.Min(dbo.Purchase.TotalPurchaseAmount).As("Min"),
					db.fx.Sum(dbo.Purchase.TotalPurchaseAmount).As("Sum"),
					db.fx.Avg(dbo.Purchase.TotalPurchaseAmount).As("Avg"),
					db.fx.Count(dbo.Purchase.TotalPurchaseAmount).As("Count"),
					db.fx.StDev(dbo.Purchase.TotalPurchaseAmount).As("StDev"),
					db.fx.StDevP(dbo.Purchase.TotalPurchaseAmount).As("StDevP"),
					db.fx.Var(dbo.Purchase.TotalPurchaseAmount).As("Var"),
					db.fx.VarP(dbo.Purchase.TotalPurchaseAmount).As("VarP")
					)
				.From(dbo.Purchase)
				.Where(dbo.Purchase.PurchaseDate >= from & dbo.Purchase.PurchaseDate <= to)
				.Execute();

			var stats = new Stats()
			{
				Max		= x.Max,
				Min		= x.Min,
				Sum		= x.Sum,
				Avg		= x.Avg,
				Count	= x.Count,
				StDev	= x.StDev,
				StDevP	= x.StDevP,
				Var		= x.Var,
				VarP	= x.VarP,
			};

			return stats;
		}
		#endregion

		#region concat
		public string GetFullName(int personId)
		{
			//select
			//CONCAT(dbo.Person.FirstName, ' ', dbo.Person.LastName)
			//from dbo.Person
			//where dbo.Person.Id = {personId};
			string name = db.SelectOne(
					db.fx.Concat(dbo.Person.FirstName, " ", dbo.Person.LastName)
				)
				.From(dbo.Person)
				.Where(dbo.Person.Id == personId)
				.Execute();

			return name;
		}
		#endregion

		#region isnull, coalesce
		public IEnumerable<(int, int)> GetCreditLimitForPersonSet(params int[] personIds)
		{
			//select
			//dbo.Person.Id,
			//ISNULL(dbo.Person.CreditLimit, 0) as CreditLimit
			//from dbo.Person
			//where dbo.Person.Id in ({personIds});
			IEnumerable<dynamic> creditLimits = db.SelectMany(
					dbo.Person.Id,
					db.fx.IsNull(dbo.Person.CreditLimit, 0).As("CreditLimit"))
				.From(dbo.Person)
				.Where(dbo.Person.Id.In(personIds))
				.Execute();

			return (creditLimits as List<dynamic>).ConvertAll<(int, int)>(cl => (cl.Id, cl.CreditLimit));
		}

		public DateTimeOffset GetLastActivityTimestamp(int personId)
		{
			//select
			//Coalesce(dbo.Person.LastLoginDate, dbo.Person.RegistrationDate)
			//from dbo.Person
			//where dbo.Person.Id = {personId});
			DateTimeOffset? timestamp = db.SelectOne(
					db.fx.Coalesce<DateTimeOffset?>(
						dbo.Person.LastLoginDate, 
						dbo.Person.RegistrationDate)
					)
				.From(dbo.Person)
				.Where(dbo.Person.Id == personId)
				.Execute();

			return timestamp.Value;
		}
		#endregion

		#region isnull, floor, ceiling
		public (decimal, decimal) GetMaxAndMinProductHeightsRoundedToNearestTenth(int personId)
		{
			//select
			//ISNULL(CEILING(MAX(dbo.Person.CreditLimit)), 0) as [Max],
			//ISNULL(FLOOR(MIN(dbo.Person.CreditLimit)), 0) as [Min]
			//from dbo.Product
			//inner join dbo.PurchaseLine on dbo.Product.Id = dbo.PurchaseLine.ProductId
			//inner join dbo.Purchase on dbo.PurchaseLine.PurchaseId = dbo.Purchase.Id
			//where dbo.Purchase.PersonId = {personId};
			var result = db.SelectOne(
					db.fx.IsNull(db.fx.Ceiling(db.fx.Max(dbo.Product.Height)), 0.1m).As("Max"),
					db.fx.IsNull(db.fx.Floor(db.fx.Min(dbo.Product.Height)), 0.1m).As("Min")
					)
				.From(dbo.Product)
				.InnerJoin(dbo.PurchaseLine).On(dbo.Product.Id == dbo.PurchaseLine.ProductId)
				.InnerJoin(dbo.Purchase).On(dbo.PurchaseLine.PurchaseId == dbo.Purchase.Id)
				.Where(dbo.Purchase.PersonId == personId)
				.Execute();

			return (result.Max, result.Min);
		}
		#endregion

		#region cast
		public decimal GetAvgProductListPrice()
		{
			decimal avgPrice = db.SelectOne(
					db.fx.Avg(db.fx.Cast(dbo.Product.ListPrice).AsDecimal(12,2))
					)
				.From(dbo.Product)
				.Execute();

			return avgPrice;
		}
		#endregion

		#region dateadd, datepart, datediff, current_timestamp, getdate, getutcdate, sysdatetime, sysdatetimeoffset, sysutcdatetime
		public void SetYearOfLastCreditReviewToCurrentYear(int personId)
		{
			//update
			//dbo.Person
			//set dbo.Person.YearOfLastCreditLimitReview = DATEPART(year, GETDATE())
			//from dbo.Person
			//where dbo.Person.Id = {personId};
			int _ = db.Update(
				dbo.Person.YearOfLastCreditLimitReview.Set(
						db.fx.DatePart(DateParts.Year, db.fx.GetDate())
						)
				)
			.From(dbo.Person)
			.Where(dbo.Person.Id == personId)
			.Execute();
		}

		//TODO: examples
		#endregion

		#region newid
		//TODO: examples
		#endregion

		//abs, substring, replace, trim, ltrim, rtrim, len, charindex, patindex, right left

		#region abs, substring, replace, trim, ltrim, rtrim
		public decimal? GetAbsoluteDifferenceBetweenProductWidthAndHeight(int productId)
		{
			/*
			SELECT
				ABS([dbo].[Product].[Width] - [dbo].[Product].[Height])
			FROM
				[dbo].[Product]
			WHERE
				[dbo].[Product].[Id] = 1
			*/

			decimal? difference = db.SelectOne(
						db.fx.Abs(dbo.Product.Width - dbo.Product.Height)
					)
					.From(dbo.Product)
					.Where(dbo.Product.Id == productId)
					.Execute();

			return difference;
		}

		public IEnumerable<Person> GetPersonsWithFirstNameStartingWith(string startsWith)
		{
			/*
			SELECT
				*
			FROM
				[dbo].[Person]
			WHERE
				SUBSTRING([dbo].[Person].[FirstName], 1, 1) = 'K'
			 */

			IEnumerable<Person> persons = db.SelectMany<Person>()
				.From(dbo.Person)
				.Where(db.fx.Substring(dbo.Person.FirstName, 1, startsWith.Length) == startsWith)
				.Execute();

			return persons;
		}

		public void UpdateAddressLine2WithAbbreviation(string full, string abbreviation)
		{
			/*
			UPDATE
				[dbo].[Address]
			SET
				[Line2] = REPLACE([Line2], 'Apartment', 'Apt.')
			FROM
				[dbo].[Address]
			WHERE
				LEFT([dbo].[Address].[Line2], 9) = 'Apartment'
			*/

			int _ = db.Update(
					dbo.Address.Line2.Set(db.fx.Replace(dbo.Address.Line2, full, abbreviation))
				)
				.From(dbo.Address)
				.Where(db.fx.Left(dbo.Address.Line2, full.Length) == full)
				.Execute();
		}

		public IEnumerable<string> GetFormattedAddressLinesUsingTrim()
		{
			/*
			SELECT
				TRIM([dbo].[Address].[Line1] + ' ' + ISNULL([dbo].[Address].[Line2], ' '))
			FROM
				[dbo].[Address]
			*/

			var formatted = db.SelectMany(
					db.fx.Trim(dbo.Address.Line1 + " " + db.fx.IsNull(dbo.Address.Line2, " "))
				)
				.From(dbo.Address)
				.Execute();

			return formatted;
		}

		public IEnumerable<string> GetFormattedAddressLinesUsingLTrim()
		{
			/*
			SELECT
				LTRIM([dbo].[Address].[Line1] + ' ' + ISNULL([dbo].[Address].[Line2], ''))
			FROM
				[dbo].[Address]
			*/

			var formatted = db.SelectMany(
					db.fx.LTrim(dbo.Address.Line1 + " " + db.fx.IsNull(dbo.Address.Line2, string.Empty))
				)
				.From(dbo.Address)
				.Execute();

			return formatted;
		}

		public IEnumerable<string> GetFormattedAddressLinesUsingRTrim()
		{
			/*
			SELECT
				RTRIM([dbo].[Address].[Line1] + ' ' + ISNULL([dbo].[Address].[Line2], ''))
			FROM
				[dbo].[Address]
			*/

			var formatted = db.SelectMany(
					db.fx.RTrim(dbo.Address.Line1 + " " + db.fx.IsNull(dbo.Address.Line2, string.Empty))
				)
				.From(dbo.Address)
				.Execute();

			return formatted;
		}

		//TODO: len, charindex, patindex, right left
		#endregion
	}
}

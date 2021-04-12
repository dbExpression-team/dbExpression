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
			IList<(int, int)> personIdCreditLimit = this.GetCreditLimitForPersonSet(1, 2, 3, 4, 5, 6, 8, 9, 10);
			DateTimeOffset lastActivity = this.GetLastActivityTimestamp(5);
			(double, double) maxAndMin = this.GetMaxAndMinPurchasesRoundedToNearestDollar(9);
			this.SetYearOfLastCreditReviewToCurrentYear(5);
			decimal avgPrice = this.GetAvgProductListPrice();
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
		public IList<(int, int)> GetCreditLimitForPersonSet(params int[] personIds)
		{
			//select
			//dbo.Person.Id,
			//ISNULL(dbo.Person.CreditLimit, 0) as CreditLimit
			//from dbo.Person
			//where dbo.Person.Id in ({personIds});
			IList<dynamic> creditLimits = db.SelectMany(
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
					db.fx.Coalesce(
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
		public (double, double) GetMaxAndMinPurchasesRoundedToNearestDollar(int personId)
		{
			//select
			//ISNULL(CEILING(MAX(dbo.Purchase.TotalPurchaseAmount)), 0.0) as [Max],
			//ISNULL(FLOOR(MIN(dbo.Purchase.TotalPurchaseAmount)), 0.0) as [Min]
			//from dbo.Purchase
			//where dbo.Purchase.PersonId = {personId};
			var result = db.SelectOne(
					db.fx.IsNull(db.fx.Ceiling(db.fx.Max(dbo.Purchase.TotalPurchaseAmount)), 0.0).As("Max"),
					db.fx.IsNull(db.fx.Floor(db.fx.Min(dbo.Purchase.TotalPurchaseAmount)), 0.0).As("Min")
					)
				.From(dbo.Purchase)
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
	}
}

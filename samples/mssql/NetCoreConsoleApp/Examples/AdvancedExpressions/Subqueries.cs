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
	public class SubQueries : IExecute
	{
		#region execute
		public void Execute()
		{
			var o1 = this.SelectPersonTotalPurchaseToCreditLimitReport();
			var o2 = this.SelectVIPByPurchaseCountAndYear(3, 2020);
		}
		#endregion

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
					db.fx.IsNull(dbex.Alias("t0", "TotalPurchaseAmount"), 0).As("TotalPurchaseAmount"),
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
				.On(dbex.Alias("t0", "PersonId") == dbo.Person.Id)
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
				dbex.Alias("vips", "PurchaseCount"),
				dbex.Alias("vips", "PurchaseYear"),
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
				.On(dbo.Person.Id == dbex.Alias("vips", "PersonId"))
				.OrderBy(dbo.Person.Id.Asc, dbex.Alias("vips", "PurchaseCount").Desc)
				.Execute();

			return vip;
		}
	}
}

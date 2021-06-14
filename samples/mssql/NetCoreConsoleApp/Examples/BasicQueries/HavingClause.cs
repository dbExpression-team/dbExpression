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
	public class HavingClause : IExecute
	{
		#region execute
		public void Execute()
		{
			IList<dynamic> vips = this.GetPeopleWithTotalSalesAboveLimit(40.00);
		}
		#endregion

		#region having
		public IList<dynamic> GetPeopleWithTotalSalesAboveLimit(double limit)
		{
			//select
			//dbo.Person.Id as PersonId,
			//CONCAT(dbo.Person.FirstName, ' ', dbo.Person.LastName) as FullName,
			//SUM(dbo.Purchase.TotalPurchaseAmount) as TotalPurchaseAmount
			//from dbo.Person
			//inner join dbo.Purchase on dbo.Purchase.PersonId = dbo.Person.Id
			//group by
			//	dbo.Person.Id, 
			//	dbo.Person.FirstName, 
			//	dbo.Person.LastName
			//Having SUM(dbo.Purchase.TotalPurchaseAmount) > {limit};
			IList<dynamic> vip = db.SelectMany(
					dbo.Person.Id.As("PersonId"),
					db.fx.Concat(dbo.Person.FirstName, " ", dbo.Person.LastName).As("FullName"),
					db.fx.Sum(dbo.Purchase.TotalPurchaseAmount).As("TotalPurchaseAmount")
				)
				.From(dbo.Person)
				.InnerJoin(dbo.Purchase).On(dbo.Purchase.PersonId == dbo.Person.Id)
				.GroupBy(dbo.Person.Id, dbo.Person.FirstName, dbo.Person.LastName)
				.Having(db.fx.Sum(dbo.Purchase.TotalPurchaseAmount) > limit)
				.Execute();

			return vip;
		}
		#endregion
	}
}

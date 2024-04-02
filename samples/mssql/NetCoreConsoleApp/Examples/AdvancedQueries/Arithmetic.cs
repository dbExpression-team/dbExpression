using System;
using System.Collections.Generic;
using DbExpression.Sql;
using DbExpression.MsSql.Expression;
using SimpleConsole.Data;
using SimpleConsole.DataService;
using SimpleConsole.dboData;
using SimpleConsole.dboDataService;
using SimpleConsole.secDataService;
using System.Linq;

namespace NetCoreConsoleApp
{
	public class Arithmetic : IExecute
	{
		#region execute
		public void Execute()
		{
			double value = this.GetTotalValueOfProductOnHandById(1);
			IEnumerable<double> values = this.GetTotalValueOfAllProductsOnHandForIdSet(1, 2, 3, 4, 5);
			InventoryStats[] stats = this.GetBasicInventoryStats();
			this.DecrementQuantityOnHand(8);
			this.IncreaseCreditLimit(5, 20);
		}
		#endregion

		#region stats class
		public class InventoryStats
		{
			public int ProductId { get; set; }
			public string ProductName { get; set; }
			public int QuantityOnHand { get; set; }
			public double InventoryCost { get; set; }
			public double ProjectedMargin{ get; set; }
		}
		#endregion

		#region server side arithmetic select
		public double GetTotalValueOfProductOnHandById(int id)
		{
			//select 
			//(dbo.Product.Quantity * dbo.Product.Price) 
			//from dbo.Product where dbo.Product.Id = {id};
			double value = db.SelectOne(dbo.Product.Quantity * dbo.Product.Price)
				.From(dbo.Product)
				.Where(dbo.Product.Id == id)
				.Execute();

			return value;
		}

		public IEnumerable<double> GetTotalValueOfAllProductsOnHandForIdSet(params int[] productIds)
		{
			//select
			//(dbo.Product.Quantity * dbo.Product.Price)
			//from dbo.Product
			//where dbo.Product.Id in ({productIds});
			IEnumerable<double> values = db.SelectMany(dbo.Product.Quantity * dbo.Product.Price)
				.From(dbo.Product)
				.Where(dbo.Product.Id.In(productIds))
				.Execute();

			return values;
		}

		public InventoryStats[] GetBasicInventoryStats()
		{
			//select
			//dbo.Product.Id,
			//dbo.Product.Name,
			//dbo.Product.Quantity as QuantityOnHand,
			//(dbo.Product.Quantity * dbo.Product.Price) as InventoryCost,
			//((dbo.Product.Quantity * dbo.Product.ListPrice) - (dbo.Product.Quantity * dbo.Product.Price)) as ProjectedMargin
			//from dbo.Product;
			var stats = db.SelectMany(
					dbo.Product.Id,
					dbo.Product.Name,
					dbo.Product.Quantity.As("QuantityOnHand"),
					(dbo.Product.Quantity * dbo.Product.Price).As("InventoryCost"),
					((dbo.Product.Quantity * dbo.Product.ListPrice) - (dbo.Product.Quantity * dbo.Product.Price)).As("ProjectedMargin")
				)
				.From(dbo.Product)
				.Execute()
				.ToList();

			var inventory = new InventoryStats[stats.Count()];
			for (int i = 0; i < stats.Count(); i++)
			{
				var s = stats[i];
				var x = new InventoryStats();
				x.ProductId = s.Id;
				x.ProductName = s.Name;
				x.QuantityOnHand = s.QuantityOnHand;
				x.InventoryCost = s.InventoryCost;
				x.ProjectedMargin = s.ProjectedMargin;
				inventory[i] = x;
			}

			return inventory;
		}
		#endregion

		#region server side increment / decrement
		public void DecrementQuantityOnHand(int productId)
		{
			//update
			//dbo.Product
			//set dbo.Product.Quantity = (dbo.Product.Quantity - 1)
			//from dbo.Product
			//where dbo.Product.id = {productId};
			int _ = db.Update(
					dbo.Product.Quantity.Set(dbo.Product.Quantity - 1)
					)
				.From(dbo.Product)
				.Where(dbo.Product.Id == productId)
				.Execute();
		}

		public void IncreaseCreditLimit(int personId, int percent)
		{
			//update
			//dbo.Person
			//set dbo.Person.CreditLimit = dbo.Person.CreditLimit + (dbo.Person.CreditLimit * (({percent} + 0.0) / 100))
			//from dbo.Person
			//where dbo.Person.Id = {personId};
			int _ = db.Update(
					dbo.Person.CreditLimit.Set(
							dbo.Person.CreditLimit + db.fx.Cast(
								 dbo.Person.CreditLimit * ((decimal)(percent + 0.0) / 100)
								).AsInt()
						)
					)
				.From(dbo.Person)
				.Where(dbo.Person.Id == personId)
				.Execute();
		}
		#endregion
	}
}

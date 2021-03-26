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
	public class SelectScalarValues : IExecute
	{
		#region execute
		public void Execute()
		{
			string name = this.SelectProductNameByid(1);
			string desc = this.GetProductDescriptionByNameAndPrice("LEGO City Advent Calendar", 22.99);
			IList<string> distinctZips = this.SelectDistinctZipCodes();
		}
		#endregion

		#region select one scalar value (simple)
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

		#region select many scalar values
		public IList<string> SelectDistinctZipCodes()
		{
			//select
			//distinct
			//dbo.Address.Zip
			//from dbo.Address;
			IList<string> zips = db.SelectMany(dbo.Address.Zip).Distinct().From(dbo.Address).Execute();
			return zips;
		}
		#endregion
	}
}

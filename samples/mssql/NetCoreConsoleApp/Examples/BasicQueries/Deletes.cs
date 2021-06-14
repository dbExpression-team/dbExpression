using System;
using System.Collections.Generic;
using HatTrick.DbEx.Sql;
using SimpleConsole.DataService;
using SimpleConsole.dboDataService;
using SimpleConsole.secDataService;

namespace NetCoreConsoleApp
{
	public class Deletes : IExecute
	{
		#region execute
		public void Execute()
		{
			int cnt1 = this.DeleteProduct(9);
			int cnt2 = this.DeleteProductSet(1000, 1001, 1002, 1003, 1004, 1005);
		}
		#endregion

		#region simple delete
		public int DeleteProduct(int id)
		{
			//delete from dbo.Product where dbo.Product.Id = {id};
			return db.Delete().From(dbo.Product).Where(dbo.Product.Id == id).Execute();
		}
		#endregion

		#region delete set
		public int DeleteProductSet(params int[] ids)
		{
			//delete from dbo.Product where dbo.Product.Id in ({ids};
			return db.Delete().From(dbo.Product).Where(dbo.Product.Id.In(ids)).Execute();
		}
		#endregion
	}
}

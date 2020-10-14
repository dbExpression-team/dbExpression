using System;
using System.Collections.Generic;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.MsSql;
using SimpleConsole.Data;
using SimpleConsole.DataService;
using SimpleConsole.dboData;
using SimpleConsole.dboDataService;
using s = SimpleConsole.secData;
using SimpleConsole.secDataService;

namespace NetCoreConsoleApp
{
	public class DeleteExpressions
	{
		#region simple delete
		public void DeleteProductById(int id)
		{
			//delete from dbo.Product where dbo.Product.Id = {id};
			db.Delete().From(dbo.Product).Where(dbo.Product.Id == id).Execute();
		}
		#endregion

		#region cross table delete (join based deletes)
		public int DeleteProductsNeverPurchased()
		{
			//delete dbo.Product from dbo.Product
			//left join dbo.PurchaseLine on dbo.PurchaseLine.ProductId = dbo.Product.Id
			//left join dbo.Purchase on dbo.Purchase.Id = dbo.PurchaseLine.PurchaseId
			//where dbo.Purchase.Id is null;
			int count = db.Delete().From(dbo.Product)
				.LeftJoin(dbo.PurchaseLine).On(dbo.PurchaseLine.ProductId == dbo.Product.Id)
				.LeftJoin(dbo.Purchase).On(dbo.Purchase.Id == dbo.PurchaseLine.PurchaseId)
				.Where(dbo.Purchase.Id == (int?)null)
				.Execute();

			return count;
		}
		#endregion

		#region transactional deletes
		public void DeleteAPersonAndAllAssociatedDataById(int personId)
		{
			//select dbo.Address.Id
			//into #AddressIds
			//from dbo.Address
			//inner join dbo.Person_Address on dbo.Person_Address.AddressId = dbo.Address.Id
			//where dbo.Person_Address.PersonId = {id};

			//set xact_abort on;
			//begin transaction;
			//delete dbo.PurchaseLine from dbo.PurchaseLine
			//inner join dbo.Purchase on dbo.Purchase.Id = dbo.PurchaseLine.PurchaseId
			//where dbo.Purchase.PersonId = {id};

			//delete dbo.Purchase where dbo.Purchase.PersonId = {id};

			//delete dbo.Person_Address where dbo.Person_Address.AddressId in (select id from #AddressIds);

			//delete dbo.Address from dbo.Address 
			//where dbo.Address.id in (select id from #AddressIds);

			//delete sec.Person where sec.Person.Id = {id};

			//delete from dbo.Person where dbo.Person.Id = {id};
			//commit transaction;

			//drop table #AddressIds;

			IList<int> addressIds = db.SelectMany(dbo.Address.Id)
				.From(dbo.Address)
				.InnerJoin(dbo.PersonAddress).On(dbo.PersonAddress.AddressId == dbo.Address.Id)
				.Where(dbo.PersonAddress.PersonId == personId)
				.Execute();

			var tran = db.GetConnection().BeginTransaction();
			try
			{
				db.Delete().From(dbo.PurchaseLine)
					.InnerJoin(dbo.Purchase).On(dbo.Purchase.Id == dbo.PurchaseLine.PurchaseId)
					.Where(dbo.Purchase.PersonId == personId)
					.Execute(tran);

				db.Delete().From(dbo.Purchase).Where(dbo.Purchase.PersonId == personId).Execute(tran);

				db.Delete().From(dbo.PersonAddress).Where(dbo.PersonAddress.AddressId.In(addressIds)).Execute(tran);

				db.Delete().From(dbo.Address)
					.Where(dbo.Address.Id.In(addressIds))
					.Execute(tran);

				db.Delete().From(sec.Person).Where(sec.Person.Id == personId).Execute(tran);

				db.Delete().From(dbo.Person).Where(dbo.Person.Id == personId).Execute(tran);
				
				tran.CommitTransaction();
			}
			catch(Exception ex)
			{
				tran.RollbackTransaction();
			}
		}
		#endregion
	}
}
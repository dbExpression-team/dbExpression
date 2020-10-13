using System;
using System.Collections.Generic;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.MsSql;
using SimpleConsole.Data;
using SimpleConsole.DataService;
using SimpleConsole.dboData;
using SimpleConsole.dboDataService;

namespace NetCoreConsoleApp
{
	public class InsertExpressions
	{
		#region simple insert
		public void SimpleInsertPerson(Person p)
		{
			/* Ther person table has and identity column as PK.  After insert the Person Id column will be populated
			 * with the identity value gererated. */
			db.Insert(p).Into(dbo.Person).Execute();

			//p.Id should now have a value...
		}
		#endregion

		#region transactional insert person and address
		public void TransactionalInsertPersonAndAddress(Person p, Address a)
		{
			//grab a connection and start a transaction
			var conn = db.GetConnection().BeginTransaction();
			try
			{
				db.Insert(p).Into(dbo.Person).Execute(conn);
				db.Insert(a).Into(dbo.Address).Execute(conn);

				//both p and a have identity PKs, so the Id's of each should now be populated
				var pa = new PersonAddress()
				{ PersonId = p.Id, AddressId = a.Id, DateCreated = DateTime.Now };

				db.Insert(pa).Into(dbo.PersonAddress).Execute(conn);

				//commit the transaction
				conn.CommitTransaction();
			}
			catch(Exception ex)
			{
				//on error, ensure transaction rollback
				conn.RollbackTransaction();
			}
		}
		#endregion

		#region batch insert people
		public void BatchInsertPeople(params Person[] people)
		{
			db.InsertMany(people).Into(dbo.Person).Execute();
		}
		#endregion
	}
}

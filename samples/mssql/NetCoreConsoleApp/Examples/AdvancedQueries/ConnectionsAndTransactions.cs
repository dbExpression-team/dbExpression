using System;
using System.Collections.Generic;
using DbExpression.Sql;
using DbExpression.MsSql.Expression;
using SimpleConsole.Data;
using SimpleConsole.DataService;
using SimpleConsole.dboData;
using SimpleConsole.dboDataService;
using SimpleConsole.secDataService;
using DbExpression.Sql.Connection;

namespace NetCoreConsoleApp
{
	public class ConnectionsAndTransactions : IExecute
	{
		#region execute
		public void Execute()
		{
			(Person, Address, string) personInfo = this.GetPersonBillingAddressAndSSN(5);

			this.DeleteAPersonAndAllAssociatedDataById(3);

			this.UpdateNameAndBillingAddressTransactional(
				2,
				"Butters2",
				"Scotch2",
				new Address()
				{ Line1 = "111 Main St", Line2 = "Suite 200", City = "Dallas", State = "TX", Zip = "75001" }
			);

			//transactional person / address set insert
			{
				Person p = new Person();
				p.FirstName = "John";
				p.LastName = "Doe";
				p.BirthDate = DateTime.Parse("2000-01-01");
				p.GenderType = GenderType.Male;
				p.CreditLimit = 100000;
				p.YearOfLastCreditLimitReview = 2020;
				p.RegistrationDate = DateTime.Parse("2019-01-01");
				p.LastLoginDate = DateTime.Parse("2020-12-31");

				Address bill = new Address();
				bill.AddressType = AddressType.Billing;
				bill.Line1 = "111 Main St.";
				bill.Line2 = null;
				bill.City = "Dallas";
				bill.State = "TX";
				bill.Zip = "75000";

				Address ship = new Address();
				ship.AddressType = AddressType.Billing;
				ship.Line1 = "125 Riverside Dr.";
				ship.Line2 = "Suite 200";
				ship.City = "Dallas";
				ship.State = "TX";
				ship.Zip = "75000";

				this.CreatePerson(p, bill, ship);
			}
		}
		#endregion

		#region manual connection mgmt
		public (Person, Address, string) GetPersonBillingAddressAndSSN(int personId)
		{
			Person p = null;
			Address a = null;
			string ssn = null;
			using (ISqlConnection c = db.GetConnection())
			{
				c.Open();//optional, execution pipeline will ensure connection open on first usage...

				p = db.SelectOne<Person>()
					.From(dbo.Person)
					.Where(dbo.Person.Id == personId)
					.Execute(c);

				a = db.SelectOne<Address>()
					.From(dbo.Address)
					.InnerJoin(dbo.PersonAddress).On(dbo.PersonAddress.AddressId == dbo.Address.Id)
					.Where(dbo.PersonAddress.PersonId == personId & dbo.Address.AddressType == AddressType.Billing)
					.Execute(c);

				ssn = db.SelectOne(sec.Person.SSN)
					.From(sec.Person)
					.Where(sec.Person.Id == personId)
					.Execute(c);

				c.Close();//optional, the end using scope will close the connection...
			}

			return (p, a, ssn);
		}
		#endregion

		#region transaction mgmt
		public void CreatePerson(Person person, params Address[] addresses)
		{
			using (ISqlConnection c = db.GetConnection())
			{
				try
				{
					c.Open();
					c.BeginTransaction();

					//provide the connection on each 'Execute' to enroll the expression into the connection's transaction

					db.Insert(person).Into(dbo.Person).Execute(c);

					if (addresses != null)
					{
						foreach (Address a in addresses)
						{
							db.Insert(a).Into(dbo.Address).Execute(c);
							db.Insert(new PersonAddress { PersonId = person.Id, AddressId = a.Id }).Into(dbo.PersonAddress).Execute(c);
						}
					}

					c.CommitTransaction(); //commit all inserts
					c.Close(); //optional when inside using 
				}
				catch
				{
					c.RollbackTransaction(); //something went wrong, roll back all pending inserts
				}
			}
		}

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

			IEnumerable<int> addressIds = db.SelectMany(dbo.Address.Id)
				.From(dbo.Address)
				.InnerJoin(dbo.PersonAddress).On(dbo.PersonAddress.AddressId == dbo.Address.Id)
				.Where(dbo.PersonAddress.PersonId == personId)
				.Execute();

			using (var conn = db.GetConnection())
			{
				conn.Open();
				try
				{
					conn.BeginTransaction();
					db.Delete().From(dbo.PurchaseLine)
						.InnerJoin(dbo.Purchase).On(dbo.Purchase.Id == dbo.PurchaseLine.PurchaseId)
						.Where(dbo.Purchase.PersonId == personId)
						.Execute(conn);

					db.Delete().From(dbo.Purchase).Where(dbo.Purchase.PersonId == personId).Execute(conn);

					db.Delete().From(dbo.PersonAddress).Where(dbo.PersonAddress.AddressId.In(addressIds)).Execute(conn);

					db.Delete().From(dbo.Address)
						.Where(dbo.Address.Id.In(addressIds))
						.Execute(conn);

					db.Delete().From(sec.Person).Where(sec.Person.Id == personId).Execute(conn);

					db.Delete().From(dbo.AccessAuditLog).Where(dbo.AccessAuditLog.PersonId == personId).Execute(conn);

					db.Delete().From(dbo.Person).Where(dbo.Person.Id == personId).Execute(conn);

					conn.CommitTransaction();
				}
				catch (Exception ex)
				{
					var msg = ex.Message;
					conn.RollbackTransaction();
				}
			}
		}

		public void UpdateNameAndBillingAddressTransactional(int personId, string firstName, string lastName, Address billing)
		{
			//set xact_abort on;
			//begin transaction;

			//update dbo.Person
			//set
			//	dbo.Person.FirstName = {firstName},
			//	dbo.Person.LastName = {lastName}
			//from dbo.Person
			//where dbo.Person.Id = {personId};

			//update dbo.Address
			//set
			//	dbo.Address.Line1 = {billing.Line1},
			//	dbo.Address.Line2 = {billing.Line2},
			//	dbo.Address.City = {billing.City},
			//	dbo.Address.State = {billing.State},
			//	dbo.Address.Zip = {billing.Zip}
			//from dbo.Address
			//inner join dbo.Person_Address on dbo.Person_Address.AddressId = dbo.Address.Id
			//where dbo.Person_Address.PersonId = {personId} and dbo.Address.AddressType = 1

			//commit transaction;

			using (var conn = db.GetConnection())
			{
				conn.Open();
				try
				{
					conn.BeginTransaction();

					db.Update(
							dbo.Person.FirstName.Set(firstName),
							dbo.Person.LastName.Set(lastName)
						)
						.From(dbo.Person)
						.Where(dbo.Person.Id == personId)
						.Execute(conn);//pass in connection to execute within transaction

					db.Update(
						   dbo.Address.Line1.Set(billing.Line1),
						   dbo.Address.Line2.Set(billing.Line2),
						   dbo.Address.City.Set(billing.City),
						   dbo.Address.State.Set(billing.State),
						   dbo.Address.Zip.Set(billing.Zip)
					   )
					   .From(dbo.Address)
					   .InnerJoin(dbo.PersonAddress).On(dbo.PersonAddress.AddressId == dbo.Address.Id)
					   .Where(dbo.PersonAddress.PersonId == personId & dbo.Address.AddressType == AddressType.Billing)
					   .Execute(conn);//pass in connection to execute within transaction

					conn.CommitTransaction();
				}
				catch
				{
					conn.RollbackTransaction();
				}
			}
		}
		#endregion
	}
}

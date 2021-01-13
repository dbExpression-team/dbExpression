using System;
using HatTrick.DbEx.Sql;
using SimpleConsole.Data;
using SimpleConsole.DataService;
using SimpleConsole.dboData;
using SimpleConsole.dboDataService;

namespace NetCoreConsoleApp
{
	public class UpdateExpressions
	{
		#region simple update
		public void SimpleUpdatePersonSetCreditScore(int personId, int creditLimit)
		{
			//update dbo.Person
			//set 
			//	dbo.Person.CreditLimit = {creditLimit}, 
			//	dbo.Person.YearOfLastCreditLimitReview = DATEPART(year, GETDATE())
			//from dbo.Person
			//where dbo.Person.Id = {personId};
			db.Update(
					dbo.Person.CreditLimit.Set(creditLimit), 
					dbo.Person.YearOfLastCreditLimitReview.Set(DateTime.Now.Year)
				)
				.From(dbo.Person)
				.Where(dbo.Person.Id == personId)
				.Execute();
		}
		#endregion

		#region cross table update (join based updates)
		public int UpdateCreditLimitForAllGenderMatchWithinZip(GenderType gender, string zip, int increase)
		{
			//update dbo.Person
			//set
			//	dbo.Person.CreditLimit = (dbo.Person.CreditLimit + {increase}), 
			//	dbo.Person.YearOfLastCreditLimitReview = DATEPART(year, GETDATE())
			//from dbo.Person
			//inner join dbo.Person_Address on dbo.Person_Address.PersonId = dbo.Person.Id
			//inner join dbo.Address on dbo.Address.Id = dbo.Person_Address.AddressId
			//where dbo.Address.Zip = {zip} and dbo.Person.GenderType = {gender};
			int rowCount = db.Update(
					dbo.Person.CreditLimit.Set(dbo.Person.CreditLimit + increase), //server side arithmetic
					dbo.Person.YearOfLastCreditLimitReview.Set(DateTime.Now.Year)
				)
				.From(dbo.Person)
				.InnerJoin(dbo.PersonAddress).On(dbo.PersonAddress.PersonId == dbo.Person.Id)
				.InnerJoin(dbo.Address).On(dbo.Address.Id == dbo.PersonAddress.AddressId)
				.Where(dbo.Address.Zip == zip & dbo.Person.GenderType == gender)
				.Execute();

			return rowCount;
		}
		#endregion

		#region transactional updates
		public void UpdatePersonNameAndBillingAddressTransactional(int personId, string firstName, string lastName, Address billingAddress)
		{
			//set xact_abort on;
			//begin transaction;

			//update dbo.Person
			//set
			//	dbo.Person.FirstName = '',
			//	dbo.Person.LastName = ''
			//from dbo.Person
			//where dbo.Person.Id = 0;

			//update dbo.Address
			//set
			//	dbo.Address.Line1 = '',
			//	dbo.Address.Line2 = '',
			//	dbo.Address.City = '',
			//	dbo.Address.State = '',
			//	dbo.Address.Zip = ''
			//from dbo.Address
			//inner join dbo.Person_Address on dbo.Person_Address.AddressId = dbo.Address.Id
			//where dbo.Person_Address.PersonId = 0 and dbo.Address.AddressType = 1

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
						.Execute(conn);

					db.Update(
						   dbo.Address.Line1.Set(billingAddress.Line1),
						   dbo.Address.Line2.Set(billingAddress.Line2),
						   dbo.Address.City.Set(billingAddress.City),
						   dbo.Address.State.Set(billingAddress.State),
						   dbo.Address.Zip.Set(billingAddress.Zip)
					   )
					   .From(dbo.Address)
					   .InnerJoin(dbo.PersonAddress).On(dbo.PersonAddress.AddressId == dbo.Address.Id)
					   .Where(dbo.PersonAddress.PersonId == personId & dbo.Address.AddressType == AddressType.Billing)
					   .Execute(conn);

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
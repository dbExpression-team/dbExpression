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
	public class UpdateExpressions
	{
		#region simple update person credit score
		public void SimpleUpdatePersonSetCreditScore(int personId, int creditLimit)
		{
			db.Update(
					dbo.Person.CreditLimit.Set(creditLimit), 
					dbo.Person.YearOfLastCreditLimitReview.Set(DateTime.Now.Year),
					dbo.Person.DateUpdated.Set(DateTime.Now)
				)
				.From(dbo.Person)
				.Where(dbo.Person.Id == personId)
				.Execute();
		}
		#endregion

		#region update credit limit for all females within zip
		public int UpdateCreditLimitForAllGenderMatchWithinZip(GenderType gender, string zip, int increase)
		{
			int rowCount = db.Update(
					dbo.Person.CreditLimit.Set(dbo.Person.CreditLimit + increase),
					dbo.Person.YearOfLastCreditLimitReview.Set(DateTime.Now.Year),
					dbo.Person.DateUpdated.Set(DateTime.Now)
				)
				.From(dbo.Person)
				.InnerJoin(dbo.PersonAddress).On(dbo.PersonAddress.PersonId == dbo.Person.Id)
				.InnerJoin(dbo.Address).On(dbo.Address.Id == dbo.PersonAddress.AddressId)
				.Where(dbo.Address.Zip == zip & dbo.Person.GenderType == gender)
				.Execute();

			return rowCount;
		}
		#endregion

		#region update credit limit for all females within zip
		public void UpdatePersonNameAndBillingAddressTransactional(int personId, string firstName, string lastName, Address billingAddress)
		{
			var conn = db.GetConnection().BeginTransaction();
			try
			{
				db.Update(
						dbo.Person.FirstName.Set(firstName),
						dbo.Person.LastName.Set(lastName),
						dbo.Person.DateUpdated.Set(DateTime.Now)
					)
					.From(dbo.Person)
					.InnerJoin(dbo.PersonAddress).On(dbo.PersonAddress.PersonId == dbo.Person.Id)
					.InnerJoin(dbo.Address).On(dbo.Address.Id == dbo.PersonAddress.AddressId)
					.Where(dbo.Person.Id == personId)
					.Execute(conn);

				db.Update(
					   dbo.Address.Line1.Set(billingAddress.Line1),
					   dbo.Address.Line1.Set(billingAddress.Line2),
					   dbo.Address.City.Set(billingAddress.City),
					   dbo.Address.State.Set(billingAddress.State),
					   dbo.Address.Zip.Set(billingAddress.Zip),
					   dbo.Address.DateUpdated.Set(DateTime.Now)
				   )
				   .From(dbo.Person)
				   .InnerJoin(dbo.PersonAddress).On(dbo.PersonAddress.AddressId == dbo.Address.Id)
				   .Where(dbo.PersonAddress.PersonId == personId)
				   .Execute(conn);

				conn.CommitTransaction();
			}
			catch
			{
				conn.RollbackTransaction();
			}
			
		}
		#endregion
	}
}
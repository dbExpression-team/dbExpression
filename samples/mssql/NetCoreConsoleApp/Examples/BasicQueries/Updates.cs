using System;
using DbExpression.Sql;
using SimpleConsole.Data;
using SimpleConsole.DataService;
using SimpleConsole.dboData;
using SimpleConsole.dboDataService;
namespace NetCoreConsoleApp
{
	public class Updates : IExecute
	{
		#region execute
		public void Execute()
		{
			int cnt1 = this.UpdateLastLoginDate(8);
			int cnt2 = this.UpdateCreditScore(1, 50000);
		}
		#endregion

		#region simple updates
		public int UpdateLastLoginDate(int personId)
		{
			//update dbo.Person
			//set 
			//	dbo.Person.LastLoginDate = SYSDATETIMEOFFSET(), 
			//from dbo.Person
			//where dbo.Person.Id = {personId};
			return db.Update(dbo.Person.LastLoginDate.Set(DateTimeOffset.Now))
				.From(dbo.Person)
				.Where(dbo.Person.Id == personId)
				.Execute();
		}

		public int UpdateCreditScore(int personId, int creditLimit)
		{
			//update dbo.Person
			//set 
			//	dbo.Person.CreditLimit = {creditLimit}, 
			//	dbo.Person.YearOfLastCreditLimitReview = DATEPART(year, GETDATE())
			//from dbo.Person
			//where dbo.Person.Id = {personId};
			return db.Update(
					dbo.Person.CreditLimit.Set(creditLimit),
					dbo.Person.YearOfLastCreditLimitReview.Set(DateTime.Now.Year)
				)
				.From(dbo.Person)
				.Where(dbo.Person.Id == personId)
				.Execute();
		}
		#endregion
	}
}

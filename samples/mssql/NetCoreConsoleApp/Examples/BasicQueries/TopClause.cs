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
	public class TopClause : IExecute
	{
		#region execute
		public void Execute()
		{
			IList<Person> people = this.GetPeopleTop10CreditLimits();

			//update all people to a minimum of 1000 credit limit limit 5 per db request
			int updated = 0;
			do
			{
				updated = this.EnsureMininumCreditLimts(1000, 5);
			} while (updated > 0);

			//purge access audit records older than 6 months limited to 25 records per db request
			int purged = 0;
			DateTime olderThan = DateTime.Now.Date.AddMonths(-6);
			do
			{
				purged = this.PurgePurchaseLines(olderThan, 25);
			} while (purged > 0);
		}
		#endregion

		#region select top
		public IList<Person> GetPeopleTop10CreditLimits()
		{
			//select
			//top 10 *
			//from dbo.Person
			//order by dbo.Person.CreditLimit desc
			IList<Person> people = db.SelectMany<Person>()
				.Top(10)
				.From(dbo.Person)
				.OrderBy(dbo.Person.CreditLimit.Desc())
				.Execute();

			return people;
		}
		#endregion

		#region update top
		public int EnsureMininumCreditLimts(int minimumCreditLimit, int updateSetLimit)
		{
			//update
			//top({updateSetLimit})
			//dbo.Person
			//set dbo.Person.CreditLimit = {minimumCreditLimit}
			//from dbo.Person
			//where dbo.Person.CreditLimit < {minimumCreditLimit};
			int cnt = db.Update(dbo.Person.CreditLimit.Set(minimumCreditLimit))
				.Top(updateSetLimit)
				.From(dbo.Person)
				.Where(dbo.Person.CreditLimit < minimumCreditLimit)
				.Execute();

			return cnt;
		}
		#endregion

		#region delete top
		public int PurgePurchaseLines(DateTime olderThan, int purgeSetLimit)
		{
			//delete
			//top({purgeSetLimit})
			//dbo.AccessAuditLog
			//from dbo.AccessAuditLog
			//where dbo.AccessAuditLog.DateCreated < {olderThan};
			int deleted = db.Delete()
				.Top(purgeSetLimit)
				.From(dbo.AccessAuditLog)
				.Where(dbo.AccessAuditLog.DateCreated < olderThan)
				.Execute();

			return deleted;
		}
		#endregion
	}
}

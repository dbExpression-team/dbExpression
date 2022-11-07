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
	public class OrderByClause : IExecute
	{
		#region execute
		public void Execute()
		{
			IList<Person> people = this.GetRecentlyActivePeopleWithCreditLimitAbove(10000);
		}
		#endregion

		#region order by
		public IList<Person> GetRecentlyActivePeopleWithCreditLimitAbove(int creditLimit)
		{
			//select
			//*
			//from dbo.Person
			//where dbo.Person.CreditLimit >= {creditLimit}
			//order by creditlimit desc, dbo.Person.LastName asc, dbo.Person.FirstName asc
			IList<Person> people = db.SelectMany<Person>()
				.From(dbo.Person)
				.Where(dbo.Person.CreditLimit >= creditLimit)
				.OrderBy(dbo.Person.CreditLimit.Desc(), dbo.Person.LastName.Asc(), dbo.Person.FirstName.Asc())
				.Execute();

			return people;
		}
		#endregion
	}
}

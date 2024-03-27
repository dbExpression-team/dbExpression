using System;
using System.Collections.Generic;
using DbExpression.Sql;
using DbExpression.MsSql.Expression;
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
			IEnumerable<Person> people = this.GetRecentlyActivePeopleWithCreditLimitAbove(10000);
		}
		#endregion

		#region order by
		public IEnumerable<Person> GetRecentlyActivePeopleWithCreditLimitAbove(int creditLimit)
		{
			//select
			//*
			//from dbo.Person
			//where dbo.Person.CreditLimit >= {creditLimit}
			//order by creditlimit desc, dbo.Person.LastName asc, dbo.Person.FirstName asc
			IEnumerable<Person> people = db.SelectMany<Person>()
				.From(dbo.Person)
				.Where(dbo.Person.CreditLimit >= creditLimit)
				.OrderBy(dbo.Person.CreditLimit.Desc(), dbo.Person.LastName.Asc(), dbo.Person.FirstName.Asc())
				.Execute();

			return people;
		}
		#endregion
	}
}

using System;
using System.Collections.Generic;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.MsSql.Expression;
using SimpleConsole.Data;
using SimpleConsole.DataService;
using SimpleConsole.dboData;
using SimpleConsole.dboDataService;
using System.Linq;

namespace NetCoreConsoleApp
{
	public class GroupByClause : IExecute
	{
		#region execute
		public void Execute()
		{
			IEnumerable<string> uniqueLastNames = this.GetUniqueLastNames();
			IEnumerable<(string, string)> uniqueFullNames = this.GetUniqueFullNames();
		}
		#endregion

		#region group by
		public IEnumerable<string> GetUniqueLastNames()
		{
			//select
			//dbo.Person.LastName
			//from dbo.Person
			//group by dbo.Person.LastName
			IEnumerable<string> lastNames = db.SelectMany(dbo.Person.LastName)
				.From(dbo.Person)
				.GroupBy(dbo.Person.LastName)
				.Execute();

			return lastNames;
		}

		public IEnumerable<(string, string)> GetUniqueFullNames()
		{
			//select
			//dbo.Person.FirstName,
			//dbo.Person.LastName
			//from dbo.Person
			//group by dbo.Person.FirstName, dbo.Person.LastName
			IEnumerable<dynamic> names = db.SelectMany(
					dbo.Person.FirstName,
					dbo.Person.LastName
					)
				.From(dbo.Person)
				.GroupBy(dbo.Person.FirstName, dbo.Person.LastName)
				.Execute();

			return (names as List<dynamic>).ConvertAll<(string, string)>(x => (x.FirstName, x.LastName));
		}
		#endregion
	}
}

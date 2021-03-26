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
			IList<string> uniqueLastNames = this.GetUniqueLastNames();
			IList<(string, string)> uniqueFullNames = this.GetUniqueFullNames();
		}
		#endregion

		#region group by
		public IList<string> GetUniqueLastNames()
		{
			IList<string> lastNames = db.SelectMany(dbo.Person.LastName)
				.From(dbo.Person)
				.GroupBy(dbo.Person.LastName)
				.Execute();

			return lastNames;
		}

		public IList<(string, string)> GetUniqueFullNames()
		{
			IList<dynamic> names = db.SelectMany(
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

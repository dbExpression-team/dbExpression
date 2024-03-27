using System;
using System.Collections.Generic;
using DbExpression.Sql;
using DbExpression.MsSql.Expression;
using SimpleConsole.Data;
using SimpleConsole.DataService;
using SimpleConsole.dboData;
using SimpleConsole.dboDataService;
using System.Linq;

namespace NetCoreConsoleApp
{
	public class Pagination : IExecute
	{
		#region execute
		public void Execute()
		{
			//page through all Person records 10 at a time
			int pageNum = 0;
			int pageSize = 10;
            IEnumerable<Person> page;
            do
			{
				page = GetPeople(pageSize, pageNum++, dbo.Person.Id.Desc());
			} while (page.Count() > 0);
		}
		#endregion

		#region get people
		public static IEnumerable<Person> GetPeople(int pageSize, int pageNum, AnyOrderByExpression orderBy)
		{
			//select
			//*
			//from dbo.Person
			//order by dbo.Person.Id desc
			//offset {pageSize * pageNum} rows
			//fetch next {pageSize} rows only;
			IEnumerable<Person> people = db.SelectMany<Person>()
				.From(dbo.Person)
				.OrderBy(orderBy ?? dbo.Person.Id.Desc())
				.Offset(pageSize * pageNum)
				.Limit(pageSize)
				.Execute();

			return people;
		}
		#endregion
	}
}

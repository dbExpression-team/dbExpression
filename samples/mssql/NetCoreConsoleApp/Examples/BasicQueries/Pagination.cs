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
	public class Pagination : IExecute
	{
		#region execute
		public void Execute()
		{
			//page through all Person records 10 at a time
			int pageNum = 0;
			int pageSize = 10;
            IList<Person> page;
            do
			{
				page = GetPeople(pageSize, pageNum++, dbo.Person.Id.Desc());
			} while (page.Count > 0);
		}
		#endregion

		#region get people
		public static IList<Person> GetPeople(int pageSize, int pageNum, AnyOrderByExpression orderBy)
		{
			//select
			//*
			//from dbo.Person
			//order by dbo.Person.Id desc
			//offset {pageSize * pageNum} rows
			//fetch next {pageSize} rows only;
			IList<Person> people = db.SelectMany<Person>()
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

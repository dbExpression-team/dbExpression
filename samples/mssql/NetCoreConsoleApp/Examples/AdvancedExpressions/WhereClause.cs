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
	public class WhereClause : IExecute
	{
		#region execute
		public void Execute()
		{
			IList<Person> people = this.FindAllPeopleWithLastNameStartingWith('P');
			IList<string> names = this.GetAllLastNamesOfPeopleWhereSecondPositionOfLastNameIsChar('t');
			IList<Person> byZip = this.GetPeopleByComplexGenderAndZipFilter();
		}
		#endregion

		#region like
		public IList<Person> FindAllPeopleWithLastNameStartingWith(char c)//P
		{
			//select * from dbo.Person where dbo.Person.LastName like('{c}%') order by dbo.Person.LastName Asc;
			var peopleLastNameStartsWithChar = db.SelectMany<Person>()
				.From(dbo.Person)
				.Where(dbo.Person.LastName.Like($"{c}%"))
				.OrderBy(dbo.Person.LastName.Asc)
				.Execute();

			return peopleLastNameStartsWithChar;
		}

		public IList<string> GetAllLastNamesOfPeopleWhereSecondPositionOfLastNameIsChar(char c)//t
		{
			//select * from dbo.Person where dbo.Person.LastName Like('_{c}%') order by dbo.Person.BirthDate Asc;
			var result = db.SelectMany(dbo.Person.LastName)
				.From(dbo.Person)
				.Where(dbo.Person.LastName.Like($"_{c}%"))
				.OrderBy(dbo.Person.BirthDate.Asc)
				.Execute();

			return result;
		}
		#endregion

		#region precedence control with (parenthesis)
		public IList<Person> GetPeopleByComplexGenderAndZipFilter()
		{
			//select
			//dbo.Person.*
			//from dbo.Person
			//inner join dbo.Person_Address on dbo.Person_Address.PersonId = dbo.Person.Id
			//inner join dbo.[Address] on dbo.Address.Id = dbo.Person_Address.AddressId
			//where
			//(
			//	(dbo.Person.GenderType = 1 and(dbo.[Address].Zip = '80456' or dbo.[Address].Zip = '94043'))
			//	or
			//	(dbo.Person.GenderType = 2 and(dbo.[Address].Zip = '10002' or dbo.[Address].Zip = '02801'))
			//)
			//order by dbo.Person.GenderType Asc;
			IList<Person> result = db.SelectMany<Person>()
				.From(dbo.Person)
				.InnerJoin(dbo.PersonAddress).On(dbo.PersonAddress.PersonId == dbo.Person.Id)
				.InnerJoin(dbo.Address).On(dbo.Address.Id == dbo.PersonAddress.AddressId)
				.Where
				(
					(
						(dbo.Person.GenderType == GenderType.Male & (dbo.Address.Zip == "80456" | dbo.Address.Zip == "94043"))
						|
						(dbo.Person.GenderType == GenderType.Female & (dbo.Address.Zip == "10002" | dbo.Address.Zip == "02801"))
					)
				)
				.OrderBy(dbo.Person.GenderType.Asc)
				.Execute();

			return result;
		}
		#endregion
	}
}

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
	public class SelectDynamicProjections : IExecute
	{
		#region execute
		public void Execute()
		{
			dynamic info = this.SelectPersonBasicInfo(3);
			IList<dynamic> infoSet = this.SelectRecentlyActivePeopleBasicInfo(DateTime.Now.Date.AddDays(-7));
		}
		#endregion

		#region select one dynamic projection
		public dynamic SelectPersonBasicInfo(int personId)
		{
			//select 
			//dbo.Person.Id, dbo.Person.FirstName, dbo.Person.LastName, dbo.Person.GenderType
			//from dbo.Person
			//where dbo.Person.Id = {personId}
			var info = db.SelectOne(
					dbo.Person.Id, dbo.Person.FirstName, dbo.Person.LastName, dbo.Person.GenderType
					)
				.From(dbo.Person)
				.Where(dbo.Person.Id == personId)
				.Execute();

			return info;
		}
		#endregion

		#region select many dynamic projections
		public dynamic SelectRecentlyActivePeopleBasicInfo(DateTime lastLogin)
		{
			//select 
			//dbo.Person.Id, dbo.Person.FirstName, dbo.Person.LastName, dbo.Person.GenderType
			//from dbo.Person
			//where dbo.Person.LastLoginDate > {lastLoginDate}
			var info = db.SelectMany(
					dbo.Person.Id, dbo.Person.FirstName, dbo.Person.LastName, dbo.Person.GenderType
					)
				.From(dbo.Person)
				.Where(dbo.Person.LastLoginDate > lastLogin)
				.Execute();

			return info;
		}
		#endregion
	}
}

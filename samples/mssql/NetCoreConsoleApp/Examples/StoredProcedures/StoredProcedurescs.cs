using System;
using System.Collections.Generic;
using HatTrick.DbEx.Sql;
using SimpleConsole.DataService;
using SimpleConsole.dboDataService;
using SimpleConsole.secDataService;

namespace NetCoreConsoleApp
{
	public class StoredProcedures : IExecute
	{
		#region execute
		public void Execute()
		{
			UpdatePersonCreditLimitAndReturnPerson();
			UpdatePersonCreditLimitWithOutputParametersAndReturnPerson();
		}
		#endregion

		private void UpdatePersonCreditLimitAndReturnPerson()
		{
			db.sp.dbo.UpdatePersonCreditLimitAndReturnPerson(1, 1).Execute();
		}

		private void UpdatePersonCreditLimitWithOutputParametersAndReturnPerson()
		{
			Action<IList<ISqlOutputParameter>> map = values =>
			{
				foreach (var param in values)
					Console.WriteLine(param.Name + "\t" + param.RawValue);
			};

			db.sp.dbo.UpdatePersonCreditLimitWithOutputParametersAndReturnPerson(1, 1, map).Execute();
		}
	}
}

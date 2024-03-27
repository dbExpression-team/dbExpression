using DbExpression.Sql;
using SimpleConsole.DataService;
using System;
using System.Collections.Generic;

namespace NetCoreConsoleApp
{
    public class StoredProcedures : IExecute
	{
		#region execute
		public void Execute()
		{
			UpdatePersonCreditLimit();
			UpdatePersonCreditLimitWithOutputParametersAndReturnPerson();
		}
		#endregion

		private void UpdatePersonCreditLimit()
		{
			db.sp.dbo.UpdatePersonCreditLimit_With_Inputs(1, 2000).Execute();
		}

		private void UpdatePersonCreditLimitWithOutputParametersAndReturnPerson()
		{
			Action<IEnumerable<ISqlOutputParameter>> map = values =>
			{
				foreach (var param in values)
					Console.WriteLine(param.Name + "\t" + param.RawValue);
			};

			db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input_And_Output(1, map).Execute();
		}
	}
}

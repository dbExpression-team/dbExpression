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
	public class StringConcatenation : IExecute
	{
		#region execute
		public void Execute()
		{
			string address = this.GetFullAddress(10);
		}
		#endregion

		#region +
		public string GetFullAddress(int addressId)
		{
			//select
			//dbo.Address.Line1 + ' ' + ISNULL(dbo.Address.Line2, '')
			//+ (CHAR(13) + CHAR(10))
			//+ dbo.Address.City + ', ' + dbo.Address.State + ' ' + dbo.Address.Zip
			//from dbo.Address
			//where dbo.Address.Id = {addressId};
			string address = db.SelectOne(
				dbo.Address.Line1 + " " + db.fx.IsNull(dbo.Address.Line2, string.Empty) 
				+ Environment.NewLine 
				+ dbo.Address.City + ", " + dbo.Address.State + " " + dbo.Address.Zip 
				).From(dbo.Address)
				.Where(dbo.Address.Id == addressId)
				.Execute();
			//TODO: invalid concat.. prob need another signature on + op overload...
			return address;
		}
		#endregion
	}
}

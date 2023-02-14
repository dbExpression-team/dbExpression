using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using DbEx.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace MsSql.DocumentationExamples.Reference.Mssql.Functions
{
	///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/string-concatenation</summary>
	public class String_Concatenation : IDocumentationExamples
	{
		private readonly ILogger<String_Concatenation> logger;

		public String_Concatenation(ILogger<String_Concatenation> logger)
		{
			this.logger = logger;
		}

		public void ExecuteExamples()
		{
			String_Concatenation_line_no_8();
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/string-concatenation at line 8</summary>
		private void String_Concatenation_line_no_8()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string-concatenation at line 8");

			//select person's full billing address
			string? fullAddress = db.SelectOne(
			        dbo.Address.Line1 + " " + db.fx.IsNull(dbo.Address.Line2, " ")
			        + Environment.NewLine
			        + dbo.Address.City + ", " + db.fx.Cast(dbo.Address.State).AsVarChar(2) + " " + dbo.Address.Zip
			    ).From(dbo.Address)
			    .InnerJoin(dbo.PersonAddress).On(dbo.PersonAddress.AddressId == dbo.Address.Id)
			    .Where(dbo.PersonAddress.PersonId == 1 & dbo.Address.AddressType == AddressType.Billing)
			    .Execute();

			/*
			exec sp_executesql N'SELECT TOP(1)
				([dbo].[Address].[Line1] + @P1 + ISNULL([dbo].[Address].[Line2], @P2) + @P3 + [dbo].[Address].[City] + @P4 + [dbo].[Address].[State] + @P5 + [dbo].[Address].[Zip])
			FROM
				[dbo].[Address]
				INNER JOIN [dbo].[Person_Address] ON [dbo].[Person_Address].[AddressId] = [dbo].[Address].[Id]
			WHERE
				[dbo].[Person_Address].[PersonId] = @P6
				AND
				[dbo].[Address].[AddressType] = @P7;',N'@P1 char(1),@P2 char(1),@P3 char(2),@P4 char(2),@P5 char(1),@P6 int,@P7 int',@P1=' ',@P2=' ',@P3='
			',@P4=', ',@P5=' ',@P6=1,@P7=2
			*/
		}

	}
}

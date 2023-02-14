using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using DbEx.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace MsSql.DocumentationExamples.Reference.Mssql.Functions.String
{
	///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/string/concat</summary>
	public class Concat : IDocumentationExamples
	{
		private readonly ILogger<Concat> logger;

		public Concat(ILogger<Concat> logger)
		{
			this.logger = logger;
		}

		public void ExecuteExamples()
		{
			Concat_line_no_64();
			Concat_line_no_82();
			Concat_line_no_103();
			Concat_line_no_130();
			Concat_line_no_158();
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/concat at line 64</summary>
		private void Concat_line_no_64()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/concat at line 64");

			IEnumerable<string> result = db.SelectMany(
					db.fx.Concat(dbo.Address.City, ", ", db.fx.Cast(dbo.Address.State).AsVarChar(2))
				)
				.From(dbo.Address)
				.Execute();

			/*
			exec sp_executesql N'SELECT
				CONCAT([dbo].[Address].[City], @P1, [dbo].[Address].[State])
			FROM
				[dbo].[Address];',N'@P1 char(2)',@P1=', '
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/concat at line 82</summary>
		private void Concat_line_no_82()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/concat at line 82");

			IEnumerable<int> result = db.SelectMany(
					dbo.Address.Id
				)
				.From(dbo.Address)
			    .Where(db.fx.Concat(dbo.Address.Line1, dbo.Address.Line2) != dbo.Address.Line1)
				.Execute();

			/*
			SELECT
				[dbo].[Address].[Id]
			FROM
				[dbo].[Address]
			WHERE
				CONCAT([dbo].[Address].[Line1], [dbo].[Address].[Line2]) <> [dbo].[Address].[Line1];
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/concat at line 103</summary>
		private void Concat_line_no_103()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/concat at line 103");

			IEnumerable<Address> addresses = db.SelectMany<Address>()
			    .From(dbo.Address)
			    .OrderBy(db.fx.Concat(dbo.Address.City, ", ", db.fx.Cast(dbo.Address.State).AsVarChar(2)))
			    .Execute();

			/*
			exec sp_executesql N'SELECT
				[dbo].[Address].[Id],
				[dbo].[Address].[AddressType],
				[dbo].[Address].[Line1],
				[dbo].[Address].[Line2],
				[dbo].[Address].[City],
				[dbo].[Address].[State],
				[dbo].[Address].[Zip],
				[dbo].[Address].[DateCreated],
				[dbo].[Address].[DateUpdated]
			FROM
				[dbo].[Address]
			ORDER BY
				CONCAT([dbo].[Address].[City], @P1, [dbo].[Address].[State]) ASC;',N'@P1 char(2)',@P1=', '
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/concat at line 130</summary>
		private void Concat_line_no_130()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/concat at line 130");

			IEnumerable<dynamic> values = db.SelectMany(
			        dbo.Address.AddressType,
			        db.fx.Concat(dbo.Address.City, ", ", db.fx.Cast(dbo.Address.State).AsVarChar(2)).As("formatted_city_state")
			    )
			    .From(dbo.Address)
			    .GroupBy(
			        dbo.Address.AddressType,
			        db.fx.Concat(dbo.Address.City, ", ", db.fx.Cast(dbo.Address.State).AsVarChar(2))
			    )
			    .Execute();

			/*
			exec sp_executesql N'SELECT
				[dbo].[Address].[AddressType],
				CONCAT([dbo].[Address].[City], @P1, [dbo].[Address].[State]) AS [formatted_city_state]
			FROM
				[dbo].[Address]
			GROUP BY
				[dbo].[Address].[AddressType],
				CONCAT([dbo].[Address].[City], @P1, [dbo].[Address].[State]);',N'@P1 char(2)',@P1=', '
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/concat at line 158</summary>
		private void Concat_line_no_158()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/concat at line 158");

			IEnumerable<dynamic> values = db.SelectMany(
			        db.fx.Count().As("count"),
			        dbo.Address.AddressType
			    )
			    .From(dbo.Address)
			    .GroupBy(
			        dbo.Address.AddressType,
			        db.fx.Concat(dbo.Address.City, ", ", db.fx.Cast(dbo.Address.State).AsVarChar(2))
			    )
			    .Having(
			        db.fx.Concat(dbo.Address.City, ", ", db.fx.Cast(dbo.Address.State).AsVarChar(2)).Like("%y, A%")
			    )
			    .Execute();

			/*
			exec sp_executesql N'SELECT
				COUNT(@P1) AS [count],
				[dbo].[Address].[AddressType]
			FROM
				[dbo].[Address]
			GROUP BY
				[dbo].[Address].[AddressType],
				PATINDEX((@P2 + [dbo].[Address].[State] + @P2), [dbo].[Address].[Line1])
			HAVING
				PATINDEX((@P2 + [dbo].[Address].[State] + @P2), [dbo].[Address].[Line1]) > @P3;',N'@P1 nchar(1),@P2 char(1),@P3 bigint',@P1=N'*',@P2='%',@P3=0
			*/
		}

	}
}

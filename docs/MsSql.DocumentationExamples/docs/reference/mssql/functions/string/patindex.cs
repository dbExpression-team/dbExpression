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
	///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/string/patindex</summary>
	public class PatIndex : IDocumentationExamples
	{
		private readonly ILogger<PatIndex> logger;

		public PatIndex(ILogger<PatIndex> logger)
		{
			this.logger = logger;
		}

		public void ExecuteExamples()
		{
			PatIndex_line_no_67();
			PatIndex_line_no_87();
			PatIndex_line_no_108();
			PatIndex_line_no_135();
			PatIndex_line_no_162();
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/patindex at line 67</summary>
		private void PatIndex_line_no_67()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/patindex at line 67");

			IEnumerable<long> result = db.SelectMany(
					db.fx.PatIndex("%" + dbo.Address.State + "%", dbo.Address.City)
				)
				.From(dbo.Address)
				.Execute();

			/*
			exec sp_executesql N'SELECT
				PATINDEX((@P1 + [dbo].[Address].[State] + @P2), [dbo].[Address].[City])
			FROM
				[dbo].[Address];',N'@P1 char(1),@P2 char(1)',@P1='%',@P2='%'
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/patindex at line 87</summary>
		private void PatIndex_line_no_87()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/patindex at line 87");

			IEnumerable<int> result = db.SelectMany(
					dbo.Address.Id
				)
				.From(dbo.Address)
				.Where(db.fx.PatIndex(dbo.Address.Line1, dbo.Address.City) == 1)
				.Execute();

			/*
			exec sp_executesql N'SELECT
				[dbo].[Address].[Id]
			FROM
				[dbo].[Address]
			WHERE
				PATINDEX([dbo].[Address].[Line1], [dbo].[Address].[City]) = @P1;',N'@P1 bigint',@P1=1
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/patindex at line 108</summary>
		private void PatIndex_line_no_108()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/patindex at line 108");

			IEnumerable<Address> addresses = db.SelectMany<Address>()
			    .From(dbo.Address)
			    .OrderBy(db.fx.PatIndex("%" + dbo.Address.State + "%", dbo.Address.City))
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
				PATINDEX((@P1 + [dbo].[Address].[State] + @P2), [dbo].[Address].[City]) ASC;',N'@P1 char(1),@P2 char(1)',@P1='%',@P2='%'
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/patindex at line 135</summary>
		private void PatIndex_line_no_135()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/patindex at line 135");

			IEnumerable<dynamic> values = db.SelectMany(
					db.fx.Count().As("count"),
					dbo.Address.AddressType
				)
				.From(dbo.Address)
				.GroupBy(
					dbo.Address.AddressType,
					db.fx.PatIndex("%" + dbo.Address.State + "%", dbo.Address.City)
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
				PATINDEX((@P2 + [dbo].[Address].[State] + @P2), [dbo].[Address].[City]);',N'@P1 nchar(1),@P2 char(1)',@P1=N'*',@P2='%'
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/patindex at line 162</summary>
		private void PatIndex_line_no_162()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/patindex at line 162");

			IEnumerable<dynamic> values = db.SelectMany(
					db.fx.Count().As("count"),
					dbo.Address.AddressType
				)
				.From(dbo.Address)
				.GroupBy(
					dbo.Address.AddressType,
					db.fx.PatIndex("%" + dbo.Address.State + "%", dbo.Address.Line1)
				)
				.Having(
					db.fx.PatIndex("%" + dbo.Address.State + "%", dbo.Address.Line1) > 0
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

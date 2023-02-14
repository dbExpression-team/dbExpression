using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using DbEx.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace MsSql.DocumentationExamples.Core_concepts.Stored_procedures
{
	///<summary>Code examples from https://dbexpression.com/docs/core-concepts/stored-procedures/execution</summary>
	public class Executing_Stored_Procedures : IDocumentationExamples
	{
		private readonly ILogger<Executing_Stored_Procedures> logger;

		public Executing_Stored_Procedures(ILogger<Executing_Stored_Procedures> logger)
		{
			this.logger = logger;
		}

		public void ExecuteExamples()
		{
			Executing_Stored_Procedures_line_no_47();
			Executing_Stored_Procedures_line_no_71();
			Executing_Stored_Procedures_line_no_98();
			Executing_Stored_Procedures_line_no_129();
			Executing_Stored_Procedures_line_no_161();
			Executing_Stored_Procedures_line_no_187();
			Executing_Stored_Procedures_line_no_217();
			Executing_Stored_Procedures_line_no_250();
		}

		///<summary>https://dbexpression.com/docs/core-concepts/stored-procedures/execution at line 47</summary>
		private void Executing_Stored_Procedures_line_no_47()
		{
			logger.LogDebug("https://dbexpression.com/docs/core-concepts/stored-procedures/execution at line 47");

			//get the max credit limit for all persons when the credit limit is less than 1,000,000.
			int maxCreditLimt = db.sp.dbo.GetMaxCreditLimitLessThan(1000000).GetValue<int>().Execute();

			/*
			exec [dbo].[GetMaxCreditLimitLessThan] @CreditLimit=1000000;
			*/
		}

		///<summary>https://dbexpression.com/docs/core-concepts/stored-procedures/execution at line 71</summary>
		private void Executing_Stored_Procedures_line_no_71()
		{
			logger.LogDebug("https://dbexpression.com/docs/core-concepts/stored-procedures/execution at line 71");

			//get all person ids where the person has a credit limit less than 20000
			IEnumerable<int> personIds = db.sp.dbo.GetPersonsWithCreditLimitLessThan(20000).GetValues<int>().Execute();

			/*
			exec [dbo].[GetPersonsWithCreditLimitLessThan] @CreditLimit=20000;
			*/
		}

		///<summary>https://dbexpression.com/docs/core-concepts/stored-procedures/execution at line 98</summary>
		private void Executing_Stored_Procedures_line_no_98()
		{
			logger.LogDebug("https://dbexpression.com/docs/core-concepts/stored-procedures/execution at line 98");

			Person? person = db.sp.dbo.GetPersonById(1).GetValue(
			    row => new Person
			    {
			        Id = row.ReadField()!.GetValue<int>(),
			        FirstName = row.ReadField()!.GetValue<string>(),
			        LastName = row.ReadField()!.GetValue<string>()
			    }).Execute();

			/*
			exec [dbo].[GetPersonById] @Id=1;
			*/
		}

		///<summary>https://dbexpression.com/docs/core-concepts/stored-procedures/execution at line 129</summary>
		private void Executing_Stored_Procedures_line_no_129()
		{
			logger.LogDebug("https://dbexpression.com/docs/core-concepts/stored-procedures/execution at line 129");

			IEnumerable<Person> persons = db.sp.dbo.GetPersonById(1).GetValues(
			    row => new Person
			    {
			        Id = row.ReadField()!.GetValue<int>(),
			        FirstName = row.ReadField()!.GetValue<string>(),
			        LastName = row.ReadField()!.GetValue<string>()
			    }).Execute();

			/*
			exec [dbo].[GetPersonsWithCreditLimitLessThan] @CreditLimit=20000;
			*/
		}

		///<summary>https://dbexpression.com/docs/core-concepts/stored-procedures/execution at line 161</summary>
		private void Executing_Stored_Procedures_line_no_161()
		{
			logger.LogDebug("https://dbexpression.com/docs/core-concepts/stored-procedures/execution at line 161");

			//get all persons where the person has a credit limit less than 20000
			IEnumerable<dynamic> persons = db.sp.dbo.GetPersonsWithCreditLimitLessThan(20000).GetValues().Execute();

			/*
			exec [dbo].[GetPersonsWithCreditLimitLessThan] @CreditLimit=20000;
			*/
		}

		///<summary>https://dbexpression.com/docs/core-concepts/stored-procedures/execution at line 187</summary>
		private void Executing_Stored_Procedures_line_no_187()
		{
			logger.LogDebug("https://dbexpression.com/docs/core-concepts/stored-procedures/execution at line 187");

			//get all persons where the person has a credit limit less than 20000
			IEnumerable<dynamic> persons = db.sp.dbo.GetPersonsWithCreditLimitLessThan(20000).GetValues().Execute();

			/*
			exec [dbo].[GetPersonsWithCreditLimitLessThan] @CreditLimit=20000;
			*/
		}

		///<summary>https://dbexpression.com/docs/core-concepts/stored-procedures/execution at line 217</summary>
		private void Executing_Stored_Procedures_line_no_217()
		{
			logger.LogDebug("https://dbexpression.com/docs/core-concepts/stored-procedures/execution at line 217");

			var persons = new Dictionary<int,string>();
			
			db.sp.dbo.GetPersonsWithCreditLimitLessThan(20000).MapValues(
			    row =>
			    {
			        var id = row.ReadField()!.GetValue<int>();
			        var firstName = row.ReadField()!.GetValue<string>();
			        var lastName = row.ReadField()!.GetValue<string>();
			        persons.Add(id, $"{firstName} {lastName}");
			    }
			).Execute();

			/*
			exec [dbo].[GetPersonsWithCreditLimitLessThan] @CreditLimit=20000;
			*/
		}

		///<summary>https://dbexpression.com/docs/core-concepts/stored-procedures/execution at line 250</summary>
		private void Executing_Stored_Procedures_line_no_250()
		{
			logger.LogDebug("https://dbexpression.com/docs/core-concepts/stored-procedures/execution at line 250");

			//update the person with an id of 1 to have a credit limit of 20,000
			db.sp.dbo.SetCreditLimitForPerson(1, 20000).Execute();

			/*
			exec [dbo].[SetCreditLimitForPerson] @Id=1, @CreditLimit=20000;
			*/
		}

	}
}

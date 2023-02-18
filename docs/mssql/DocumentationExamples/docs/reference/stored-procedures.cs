using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Reference
{
    ///<summary>Code examples from https://dbexpression.com/docs/reference/stored-procedures</summary>
    public class Executing_Stored_Procedures : IDocumentationExamples
    {
        private readonly ILogger<Executing_Stored_Procedures> logger;

        public Executing_Stored_Procedures(ILogger<Executing_Stored_Procedures> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Executing_Stored_Procedures_line_no_30();
            Executing_Stored_Procedures_line_no_54();
            Executing_Stored_Procedures_line_no_81();
            Executing_Stored_Procedures_line_no_112();
            Executing_Stored_Procedures_line_no_144();
            Executing_Stored_Procedures_line_no_170();
            Executing_Stored_Procedures_line_no_200();
            Executing_Stored_Procedures_line_no_233();
        }

        ///<summary>https://dbexpression.com/docs/reference/stored-procedures at line 30</summary>
        private void Executing_Stored_Procedures_line_no_30()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/stored-procedures at line 30");

            //get the max credit limit for all persons when the credit limit is less than 1,000,000.
            int maxCreditLimt = db.sp.dbo.GetMaxCreditLimitLessThan(1000000).GetValue<int>().Execute();

            /*
            exec [dbo].[GetMaxCreditLimitLessThan] @CreditLimit=1000000;
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/stored-procedures at line 54</summary>
        private void Executing_Stored_Procedures_line_no_54()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/stored-procedures at line 54");

            //get all person ids where the person has a credit limit less than 20000
            IEnumerable<int> personIds = db.sp.dbo.GetPersonsWithCreditLimitLessThan(20000).GetValues<int>().Execute();

            /*
            exec [dbo].[GetPersonsWithCreditLimitLessThan] @CreditLimit=20000;
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/stored-procedures at line 81</summary>
        private void Executing_Stored_Procedures_line_no_81()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/stored-procedures at line 81");

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

        ///<summary>https://dbexpression.com/docs/reference/stored-procedures at line 112</summary>
        private void Executing_Stored_Procedures_line_no_112()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/stored-procedures at line 112");

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

        ///<summary>https://dbexpression.com/docs/reference/stored-procedures at line 144</summary>
        private void Executing_Stored_Procedures_line_no_144()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/stored-procedures at line 144");

            //get all persons where the person has a credit limit less than 20000
            IEnumerable<dynamic> persons = db.sp.dbo.GetPersonsWithCreditLimitLessThan(20000).GetValues().Execute();

            /*
            exec [dbo].[GetPersonsWithCreditLimitLessThan] @CreditLimit=20000;
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/stored-procedures at line 170</summary>
        private void Executing_Stored_Procedures_line_no_170()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/stored-procedures at line 170");

            //get all persons where the person has a credit limit less than 20000
            IEnumerable<dynamic> persons = db.sp.dbo.GetPersonsWithCreditLimitLessThan(20000).GetValues().Execute();

            /*
            exec [dbo].[GetPersonsWithCreditLimitLessThan] @CreditLimit=20000;
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/stored-procedures at line 200</summary>
        private void Executing_Stored_Procedures_line_no_200()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/stored-procedures at line 200");

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

        ///<summary>https://dbexpression.com/docs/reference/stored-procedures at line 233</summary>
        private void Executing_Stored_Procedures_line_no_233()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/stored-procedures at line 233");

            //update the person with an id of 1 to have a credit limit of 20,000
            db.sp.dbo.SetCreditLimitForPerson(1, 20000).Execute();

            /*
            exec [dbo].[SetCreditLimitForPerson] @Id=1, @CreditLimit=20000;
            */
        }

    }
}

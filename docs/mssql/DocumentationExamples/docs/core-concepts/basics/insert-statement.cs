using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using DbExpression.MsSql.Expression;
using DbExpression.Sql;
using DbExpression.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Core_concepts.Basics
{
    ///<summary>Code examples from https://dbexpression.com/docs/core-concepts/basics/insert-statement</summary>
    public class Insert_Statements : IDocumentationExamples
    {
        private readonly ILogger<Insert_Statements> logger;

        public Insert_Statements(ILogger<Insert_Statements> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Insert_Statements_line_no_24();
            Insert_Statements_line_no_110();
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/insert-statement at line 24</summary>
        private void Insert_Statements_line_no_24()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/insert-statement at line 24");

            var charlie = new Person()
            {
                FirstName = "Charlie",
                LastName = "Brown",
                BirthDate = new DateTime(1950, 10, 2),
                GenderType = GenderType.Male,
                CreditLimit = 45000,
                YearOfLastCreditLimitReview = 2021,
                RegistrationDate = DateTimeOffset.Now,
                LastLoginDate = null,
            };
            // The person table relies on an identity specification
            // for the Id field (PK).  At this point, charlie.Id will be 0
            // Person also contains a DateCreated column that is set via
            // a server side default binding of: GETDATE()
            
            db.Insert(charlie).Into(dbo.Person).Execute();
            
            // after the insert is executed, charlie.Id will contain
            // the identity generated on the database server
            // charlie.DateCreated will contain the result of the
            // default constraint applied to the column

            /*
            exec sp_executesql N'SET NOCOUNT ON;
            MERGE [dbo].[Person] USING (
            VALUES
            	(@P1, @P2, @P3, @P4, @P5, @P6, @P7, NULL, 0)
            ) AS [__values] (
            	[FirstName],
            	[LastName],
            	[BirthDate],
            	[GenderType],
            	[CreditLimit],
            	[YearOfLastCreditLimitReview],
            	[RegistrationDate],
            	[LastLoginDate],
            	[__ordinal]
            ) ON 1 != 1
            WHEN NOT MATCHED THEN
            INSERT (
            	[FirstName],
            	[LastName],
            	[BirthDate],
            	[GenderType],
            	[CreditLimit],
            	[YearOfLastCreditLimitReview],
            	[RegistrationDate],
            	[LastLoginDate]
            ) VALUES (
            	[__values].[FirstName],
            	[__values].[LastName],
            	[__values].[BirthDate],
            	[__values].[GenderType],
            	[__values].[CreditLimit],
            	[__values].[YearOfLastCreditLimitReview],
            	[__values].[RegistrationDate],
            	[__values].[LastLoginDate]
            	)
            OUTPUT
            	[__values].[__ordinal],
            	[inserted].[Id],
            	[inserted].[FirstName],
            	[inserted].[LastName],
            	[inserted].[BirthDate],
            	[inserted].[GenderType],
            	[inserted].[CreditLimit],
            	[inserted].[YearOfLastCreditLimitReview],
            	[inserted].[RegistrationDate],
            	[inserted].[LastLoginDate],
            	[inserted].[DateCreated],
            	[inserted].[DateUpdated];',
            	N'@P1 varchar(20),@P2 varchar(20),@P3 date,@P4 int,@P5 int,@P6 int,@P7 datetimeoffset(7),
            	@P8 datetimeoffset(7)',@P1='Charlie',@P2='Brown',@P3='1950-10-02',@P4=1,@P5=45000,@P6=2021,
            	@P7=NULL,@P8=NULL
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/insert-statement at line 110</summary>
        private void Insert_Statements_line_no_110()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/insert-statement at line 110");

            var sally = new Person()
            {
                FirstName = "Sally",
                LastName = "Brown",
                BirthDate = new DateTime(1959, 5, 26),
                GenderType = GenderType.Female,
                CreditLimit = 42000,
                YearOfLastCreditLimitReview = 2021,
                RegistrationDate = DateTimeOffset.Now,
                LastLoginDate = null,
            };
            
            var linus = new Person()
            {
                FirstName = "Linus",
                LastName = "van Pelt",
                BirthDate = new DateTime(1952, 7, 14),
                GenderType = GenderType.Male,
                CreditLimit = 42000,
                YearOfLastCreditLimitReview = 2021,
                RegistrationDate = DateTimeOffset.Now,
                LastLoginDate = null,
            };
            
            var lucy = new Person()
            {
                FirstName = "Lucy",
                LastName = "Van Pelt",
                BirthDate = new DateTime(1952, 3, 3),
                GenderType = GenderType.Female,
                CreditLimit = 42000,
                YearOfLastCreditLimitReview = 2021,
                RegistrationDate = DateTimeOffset.Now,
                LastLoginDate = null,
            };
            
            db.InsertMany(sally, linus, lucy).Into(dbo.Person).Execute();
            
            // all properties based on identity column specifications,
            // default constraints or computed columns
            // will be populated on execution.

            /*
            exec sp_executesql N'SET NOCOUNT ON;
            MERGE [dbo].[Person] USING (
            VALUES
            	(@P1, @P2, @P3, @P4, @P5, @P6, @P7, NULL, 0),
            	(@P8, @P9, @P10, @P11, @P5, @P6, @P12, NULL, 1),
            	(@P13, @P14, @P15, @P16, @P5, @P6, @P17, NULL, 2)
            ) AS [__values] (
            	[FirstName],
            	[LastName],
            	[BirthDate],
            	[GenderType],
            	[CreditLimit],
            	[YearOfLastCreditLimitReview],
            	[RegistrationDate],
            	[LastLoginDate],
            	[__ordinal]
            ) ON 1 != 1
            WHEN NOT MATCHED THEN
            INSERT (
            	[FirstName],
            	[LastName],
            	[BirthDate],
            	[GenderType],
            	[CreditLimit],
            	[YearOfLastCreditLimitReview],
            	[RegistrationDate],
            	[LastLoginDate]
            ) VALUES (
            	[__values].[FirstName],
            	[__values].[LastName],
            	[__values].[BirthDate],
            	[__values].[GenderType],
            	[__values].[CreditLimit],
            	[__values].[YearOfLastCreditLimitReview],
            	[__values].[RegistrationDate],
            	[__values].[LastLoginDate]
            	)
            OUTPUT
            	[__values].[__ordinal],
            	[inserted].[Id],
            	[inserted].[FirstName],
            	[inserted].[LastName],
            	[inserted].[BirthDate],
            	[inserted].[GenderType],
            	[inserted].[CreditLimit],
            	[inserted].[YearOfLastCreditLimitReview],
            	[inserted].[RegistrationDate],
            	[inserted].[LastLoginDate],
            	[inserted].[DateCreated],
            	[inserted].[DateUpdated];',N'@P1 varchar(20),@P2 varchar(20),@P3 date,@P4 int,@P5 int,@P6 int,@P7 datetimeoffset(7),@P8 varchar(20),@P9 varchar(20),@P10 date,@P11 int,@P12 datetimeoffset(7),@P13 varchar(20),@P14 varchar(20),@P15 date,@P16 int,@P17 datetimeoffset(7)',@P1='Sally',@P2='Brown',@P3='1959-05-26',@P4=2,@P5=42000,@P6=2021,@P7='2022-06-10 10:23:59.1748700 -05:00',@P8='Linus',@P9='van Pelt',@P10='1952-07-14',@P11=1,@P12='2022-06-10 10:23:59.1750456 -05:00',@P13='Lucy',@P14='Van Pelt',@P15='1952-03-03',@P16=2,@P17='2022-06-10 10:23:59.1750510 -05:00'
            */
        }

    }
}

using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Reference.Mssql.Functions
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
                ([_t0].[Line1] + @P1 + ISNULL([_t0].[Line2], @P2) + @P3 + [_t0].[City] + @P4 + CAST([_t0].[State] AS VarChar(2)) + @P5 + [_t0].[Zip])
            FROM
                [dbo].[Address] AS [_t0]
                INNER JOIN [dbo].[Person_Address] AS [_t1] ON [_t1].[AddressId] = [_t0].[Id]
            WHERE
                [_t1].[PersonId] = @P6
                AND
                [_t0].[AddressType] = @P7;',N'@P1 char(1),@P2 char(1),@P3 char(2),@P4 char(2),@P5 char(1),@P6 int,@P7 int',@P1=' ',@P2=' ',@P3='
            ',@P4=', ',@P5=' ',@P6=1,@P7=2
            */
        }

    }
}

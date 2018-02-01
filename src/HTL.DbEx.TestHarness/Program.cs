using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using HTL.DbEx.Sql;
using HTL.DbEx.MsSql;
using HTL.DbEx.Sql.Expression;
using HTL.DbEx.MsSql.Expression;

namespace HTL.DbEx.TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            DBExpressionEntity person = new DBExpressionEntity("dbo", "Person");
            DBExpressionField<int> id = new DBExpressionField<int>(person, "Id");
            DBExpressionField<string> firstName = new DBExpressionField<string>(person, "FirstName");
            DBExpressionField<string> lastName = new DBExpressionField<string>(person, "LastName");
            DBExpressionField<DateTime> createdAt = new DBExpressionField<DateTime>(person, "CreatedAt");

            DBFilterExpressionSet filter = createdAt > DateTime.Now.AddDays(-1) & firstName.Like("Jer%") & id < 500;

            DBFilterExpressionSet filter2 = createdAt > DateTime.Now.AddDays(-1) & (firstName.Like("Jer%") & id < 500);

            MsSqlConnection conn = new MsSqlConnection("htl.dbexpression.mssql");


            List<DbParameter> parms = new List<DbParameter>();
            string sql = filter.ToParameterizedString(parms, conn);

            List<DbParameter> parms2 = new List<DbParameter>();
            string sql2 = filter2.ToParameterizedString(parms2, conn);
        }
    }
}

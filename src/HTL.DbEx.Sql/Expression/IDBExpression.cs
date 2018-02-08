using System.Collections.Generic;
using System.Data.Common;

namespace HTL.DbEx.Sql.Expression
{
    public interface IDBExpression
    {
        string ToParameterizedString(IList<DbParameter> parameters, SqlConnection dbService);
    }
}

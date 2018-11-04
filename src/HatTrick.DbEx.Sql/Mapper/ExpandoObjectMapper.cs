using HatTrick.DbEx.Sql.Executor;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Mapper
{
    public class ExpandoObjectMapper : IExpandoObjectMapper
    {
        public Action<ExpandoObject, SqlStatementExecutionResultSet.Row> Map { get; } = new Action<ExpandoObject, SqlStatementExecutionResultSet.Row>((e, o) =>
        {
            var expando = e as IDictionary<string, object>;
            for (int i = 0; i < o.Fields.Count(); i++)
                expando.Add(o.Fields[i].Name, o.Fields[i].Value);
        });
    }
}

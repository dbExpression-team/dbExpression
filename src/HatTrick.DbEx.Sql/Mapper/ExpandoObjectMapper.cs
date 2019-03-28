using HatTrick.DbEx.Sql.Executor;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Mapper
{
    public class ExpandoObjectMapper : IExpandoObjectMapper
    {
        public Action<ExpandoObject, ISqlRow> Map { get; } = new Action<ExpandoObject, ISqlRow>((e, o) =>
        {
            var expando = e as IDictionary<string, object>;
            ISqlField field = null;
            while ((field = o.ReadField()) != null)
                expando.Add(field.Name, field.Value);
        });
    }
}

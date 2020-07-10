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
            {
                if (string.IsNullOrWhiteSpace(field.Name))
                {
                    throw new DbExpressionException("A field name or alias is missing and consequently the retrieved value can't be mapped to a property of the dynamic object as the property name is unknown.");
                }
                expando.Add(field.Name, field.Value);
            }
        });
    }
}

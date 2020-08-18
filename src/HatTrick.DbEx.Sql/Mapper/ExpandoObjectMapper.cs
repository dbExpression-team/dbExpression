using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Executor;
using System.Collections.Generic;
using System.Dynamic;

namespace HatTrick.DbEx.Sql.Mapper
{
    public class ExpandoObjectMapper : IExpandoObjectMapper
    {
        public void Map(ExpandoObject expandoObject, ISqlRow row, FieldExpressionConverters set)
        {
            var expando = expandoObject as IDictionary<string, object>;
            ISqlField field;
            while ((field = row.ReadField()) is object)
            {
                if (string.IsNullOrWhiteSpace(field.Name))
                {
                    throw new DbExpressionException("A field name or alias is missing and consequently the retrieved value can't be mapped to a property of the dynamic object as the property name is unknown.");
                }
                var converter = set[field.Index];
                expando.Add(field.Name, converter.Convert<object>(field.Value));
            }
        }
    }
}

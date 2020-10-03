using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Executor;
using System.Collections.Generic;
using System.Dynamic;

namespace HatTrick.DbEx.Sql.Mapper
{
    public class ExpandoObjectMapper : IExpandoObjectMapper
    {
        public void Map(ExpandoObject expandoObject, ISqlRow row, IValueConverterFinder finder)
        {
            var expando = expandoObject as IDictionary<string, object>;
            ISqlField field;
            while ((field = row.ReadField()) is object)
            {
                if (string.IsNullOrWhiteSpace(field.Name))
                {
                    throw new DbExpressionException($"A field name or alias has not been supplied for field index {field.Index}, therefore the retrieved value can't be mapped to a property of the dynamic object.");
                }
                var converter = finder.FindConverter(field.Index) ?? finder.FindConverter(field.DataType);
                if (converter is object)
                {
                    expando.Add(field.Name, converter.ConvertFromDatabase(field.Value));
                }
                else
                {
                    expando.Add(field.Name, field.Value);
                }
            }
        }
    }
}


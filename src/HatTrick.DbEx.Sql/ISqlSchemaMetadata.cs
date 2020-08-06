using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.DbEx.Sql
{
    public interface ISqlSchemaMetadata : ISqlMetadata
    {
        ISqlDatabaseMetadata Database { get; }
        IDictionary<string, ISqlEntityMetadata> Entities { get; }
    }
}

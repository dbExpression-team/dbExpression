using System.Collections.Generic;

namespace HatTrick.DbEx.Tools.Model
{
    public interface ISqlEntityModel
    {
        SchemaModel Schema { get; }
        string Name { get; }
        string TypeIdentifier { get; }
        IDictionary<string,string> Properties { get; }
        IList<(string, IDictionary<string, string>)> Indexes { get; }
    }
}

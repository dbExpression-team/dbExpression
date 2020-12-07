using HatTrick.DbEx.Tools.Service;
using HatTrick.Model.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Tools.Model
{
    public class ViewModel : ISqlEntityModel
    {
        public SchemaModel Schema { get; }
        public string Name { get; }
        public string TypeIdentifier => "view";
        public IDictionary<string,string> Properties { get; }
        public IList<(string, IDictionary<string, string>)> Indexes { get; }

        public ViewModel(SchemaModel schema, MsSqlView view)
        {
            Schema = schema;
            Properties = new Dictionary<string,string> { { "name", view.Name } };
            Indexes = Enumerable.Empty<(string, IDictionary<string, string>)>().ToList();
            Name = view.Name;
        }
    }
}

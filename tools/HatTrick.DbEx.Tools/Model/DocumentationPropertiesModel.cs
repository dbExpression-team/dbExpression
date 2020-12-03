using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Tools.Model
{
    public class DocumentationPropertiesModel
    {
        public IDictionary<string, string> Properties { get; }
        public IEnumerable<(string,IDictionary<string, string>)> Indexes { get; }

        public DocumentationPropertiesModel(IDictionary<string, string> properties)
            : this(properties, Enumerable.Empty<(string, IDictionary<string, string>)>())
        {

        }

        public DocumentationPropertiesModel(IDictionary<string, string> properties, IEnumerable<(string, IDictionary<string, string>)> indexes)
        {
            Properties = properties ?? throw new ArgumentNullException(nameof(properties));
            Indexes = indexes ?? throw new ArgumentNullException(nameof(indexes));
        }
    }
}

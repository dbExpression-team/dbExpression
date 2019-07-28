using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace HatTrick.DbEx.Tools.Service
{
    public class DbExConfig
    {
        public Source Source { get; set; }

        public string RootNamespaceOverride { get; set; }

        public string OutputDirectory { get; set; }

        public Meta[] Meta { get; set; }
    }

    public class Source
    {
        public string Type { get; set; }

        public string ReferenceKey { get; set; }

        public ConnectionString ConnectionString { get; set; }
    }

    public class ConnectionString
    {
        public string Value { get; set; }
    }

    public class Meta
    {
        public string Path { get; set; }

        public Apply Apply { get; set; }
    }

    public class Apply
    {
        public bool Ignore { get; set; }

        public string DataTypeOverride { get; set; }

        public string FieldTypeOverride { get; set; }

        public string NameOverride { get; set; }

        public string AsString()
        {
            List<string> vals = new List<string>();
            if (this.Ignore)
            {
                vals.Add("ignore: true");
            }
            if (this.DataTypeOverride != null)
            {
                vals.Add($"dataTypeOverride: {this.DataTypeOverride}");
            }
            if (this.FieldTypeOverride != null)
            {
                vals.Add($"fieldTypeOverride: {this.FieldTypeOverride}");
            }
            if (this.NameOverride != null)
            {
                vals.Add($"nameOverride: {this.NameOverride}");
            }
            string val = string.Join(", ", vals);
            return val;
        }
    }

    public enum SourceTypeCode
    {
        Unknown = 0,
        MsSqlDb = 1,
        MySqlDb = 2,
    }
}

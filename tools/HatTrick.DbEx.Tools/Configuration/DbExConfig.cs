using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace HatTrick.DbEx.Tools.Configuration
{
    public class DbExConfig
    {
        public Source Source { get; set; }

        public string RootNamespace { get; set; }

        public string TypeName { get; set; }

        public string OutputDirectory { get; set; }

        public Meta[] Meta { get; set; }
    }

    public class Source
    {
        public string Type { get; set; }

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

        public string DataType { get; set; }

        public bool IsEnum { get; set; }

        public string Name { get; set; }

        public string AsString()
        {
            List<string> vals = new List<string>();
            if (this.Ignore)
            {
                vals.Add("ignore: true");
            }
            if (this.DataType != null)
            {
                vals.Add($"dataType: {this.DataType}");
            }
            vals.Add($"isEnum: {this.IsEnum}");
            if (this.Name != null)
            {
                vals.Add($"name: {this.Name}");
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

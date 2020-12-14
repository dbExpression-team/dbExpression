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

        public string RootNamespace { get; set; } = "DbEx";

        public string WorkingDirectory { get; set; }

        public string OutputDirectory { get; set; }

        public string[] Enums { get; set; }

        public Override[] Overrides { get; set; }
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

    public class Override
    {
        public Apply Apply { get; set; }
    }

    public class Apply
    {
        public bool Ignore { get; set; }

        public string Name { get; set; }

        public string ClrType { get; set; }

        public string[] Interfaces { get; set; }

        public bool? AllowInsert { get; set; }

        public bool? AllowUpdate { get; set; }

        public ApplyTo To { get; set; }

        public string ToJson()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }
    }

    public class ApplyTo
    {
        public string Path { get; set; }

        public ObjectType ObjectType { get; set; }

        public Dictionary<string, object> Match { get; set; }
    }

    public enum SourceTypeCode
    {
        Unknown = 0,
        MsSqlDb = 1,
        //MySqlDb = 2,
    }

    public enum ObjectType
    {
        Any,
        Schema,
        Table,
        View,
        Procedure,
        Relationship,
        Index,
        Column, //table or view
        TableColumn,
        ViewColumn,
        Parameter
    }
}

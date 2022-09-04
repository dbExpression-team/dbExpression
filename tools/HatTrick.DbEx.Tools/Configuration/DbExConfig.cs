#region license
// Copyright (c) HatTrick Labs, LLC.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// The latest version of this file can be found at https://github.com/HatTrickLabs/db-ex
#endregion

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace HatTrick.DbEx.Tools.Configuration
{
    public class DbExConfig
    {
        public Source? Source { get; set; }

        public string? RootNamespace { get; set; }

        public string DatabaseAccessor { get; set; } = "db";

        public string? WorkingDirectory { get; set; }

        public string? OutputDirectory { get; set; }

        public NullableFeature? Nullable { get; set; }

        public string[] Enums { get; set; } = Array.Empty<string>();

        public Override[] Overrides { get; set; } = Array.Empty<Override>();
    }

    public class Source
    {
        public Platform? Platform { get; set; }
        public ConnectionString? ConnectionString { get; set; }
    }

    public class Platform
    {
        public string Key { get; set; } = "MsSql";
        public string? Version { get; set; }
    }

    public class ConnectionString
    {
        public string? Value { get; set; }
    }

    public class Override
    {
        public Apply Apply { get; set; } = new();

        public override string? ToString()
        {
            return $"{Apply}";
        }
    }

    public class Apply
    {
        public bool Ignore { get; set; }

        public string? Name { get; set; }

        public string? ClrType { get; set; }

        public string[] Interfaces { get; set; } = Array.Empty<string>();

        public bool? AllowInsert { get; set; }

        public bool? AllowUpdate { get; set; }

        public string? Direction { get; set; }

        public ApplyTo To { get; set; } = new();

        public string ToJson()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }

        public override string? ToString()
        {
            return $"{To}, name: {Name}";
        }
    }

    public class ApplyTo
    {
        public string? Path { get; set; }

        public ObjectType ObjectType { get; set; } = Configuration.ObjectType.Any;

        public Dictionary<string, object> Match { get; set; } = new();

        public override string? ToString()
        {
            return $"path: {Path}, objectType: {ObjectType}, match: {Match.Keys.Aggregate(string.Empty, (s, k) => s += $",{k}", s => s.TrimStart(','))}";
        }
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

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

using System;
using System.Text.Json;

namespace HatTrick.DbEx.Tools.Configuration
{
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
            string json = JsonSerializer.Serialize(this);
            return json;
        }

        public override string? ToString()
        {
            return $"{To}, name: {Name}";
        }
    }
}

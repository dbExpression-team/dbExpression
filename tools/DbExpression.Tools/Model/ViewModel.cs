#region license
// Copyright (c) dbExpression.  All rights reserved.
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
// The latest version of this file can be found at https://github.com/dbexpression-team/dbexpression
#endregion

﻿using DbExpression.Tools.Service;
using HatTrick.Model.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DbExpression.Tools.Model
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

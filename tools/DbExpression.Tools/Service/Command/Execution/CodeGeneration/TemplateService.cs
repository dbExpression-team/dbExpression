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

using DbExpression.Tools.Model;
using HatTrick.Model.Sql;
using HatTrick.Text.Templating;
using System.Collections;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

using ResourceAccessor = DbExpression.Tools.Resources.ResourceAccessor;

namespace DbExpression.Tools.Service
{
    public class TemplateService
    {
        #region internals
        private readonly ITemplateModelService _helpers;
        private readonly string _randomNameSeed = "dbex";
        #endregion

        #region constructors
        public TemplateService(ITemplateModelService helpers)
        {
            _helpers = helpers;
        }
        #endregion

        #region methods
        public string? ToLower(string? value)
        {
            return value is not null ? value.ToLower() : value;
        }

        public string? ToCamelCase(string? val)
        {
            return val is not null && val.Length > 0
                ? (val.Trim()[..1].ToLower() + val[1..])
                : val;
        }

        public string? ToCamelCase(INamedMeta namedMeta)
        {
            string val = _helpers.ResolveName(namedMeta);
            return ToCamelCase(val);
        }

        public string? InsertSpaceOnCapitalization(string? value)
        {
            if (value is not null)
            {
                value = value.Trim();
                MatchCollection matches = Regex.Matches(value, "[A-Z]");
                int adj = 0;
                foreach (Match m in matches.Where(ma => ma is not null))
                {
                    if (!(m.Index == 0))
                    {
                        value = value.Insert(m.Index + adj, " ");
                        adj++;
                    }
                }
            }
            return value;
        }

        public string? InsertSpaceOnCapitalizationAndToLower(string? value)
        {
            return InsertSpaceOnCapitalization(value)?.ToLower();
        }

        public string? Concat(string? item1, string? item2)
        {
            if (item1 is null || item2 is null)
                return item1 ?? item2;
            return item1 + item2;
        }

        public string Join(string? separator, params object[] items)
        {
            if (separator is null)
                separator = "";
            return string.Join(separator, items) ?? string.Empty;
        }

        public string? Replace(string? item1, string? item2, string? replace)
        {
            if (item1 is null && item2 is null && replace is null)
                return item1;
            return item1?.Replace(item2 ?? string.Empty, replace ?? string.Empty);
        }

        public string? TrimStart(string? value, string? ifValueStartsWith)
        {
            if (value is null) return null;
            if (ifValueStartsWith is null) return value;
            return value.Length > ifValueStartsWith.Length && value.StartsWith(ifValueStartsWith) ? value[ifValueStartsWith.Length..] : value;
        }

        public string? TrimEnd(string? value, string? ifValueEndsWith)
        {
            if (value is null) return null;
            if (ifValueEndsWith is null) return value;
            return value.Length > ifValueEndsWith.Length && value.EndsWith(ifValueEndsWith) ? value[..^ifValueEndsWith.Length] : value;
        }

        public bool EndsWith(string target, string value)
        {
            return target.EndsWith(value);
        }

        public object? FirstOrDefault(IEnumerable set)
        {
            var enumerator = set.GetEnumerator();
            return enumerator.MoveNext() ? enumerator.Current : null;
        }

        public Iterator Iterator()
        {
            return new Iterator();
        }

        public string? GetTemplatePartial(string? shortName)
        {
            if (shortName is null) return null;
            var resource = ResourceAccessor.GetTemplatePartial(shortName);
            return resource.Value;
        }

        public string? CS8981PragmaWarning(string disable, string value)
        {
            if (!IsLowercase(value))
                return null;

            TemplateEngine engine = new TemplateEngine(GetTemplatePartial("CS8981PragmaWarning"));
            engine.TrimWhitespace = true;

            return engine.Merge(new { Disable = disable, Code = "CS8981", Description = "The type name only contains lower-cased ascii characters" });
        }

        public string GetSchemaArgName(string name, SchemaExpressionModel schema)
            => $"{_randomNameSeed}_{name}";

        public string GetEntityArgName(string name, EntityExpressionModel entity)
            => $"{_randomNameSeed}_{name}";

        public string GetFieldArgName(string name, FieldExpressionModel field)
            => $"{_randomNameSeed}_{name}";

        public bool IsLowercase(string value)
        {
            foreach (var c in value)
            {
                if (c < 97 || c > 122)
                    return false;
            }
            return true;
        }
        #endregion
    }

    public class Iterator
    {
        private int _current;

        public int Current => _current++;
    }
}

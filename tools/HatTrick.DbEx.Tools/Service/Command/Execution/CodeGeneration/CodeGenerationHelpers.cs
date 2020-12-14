using HatTrick.DbEx.Tools.Configuration;
using HatTrick.DbEx.Tools.Model;
using HatTrick.Model.MsSql;
using HatTrick.Reflection;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HatTrick.DbEx.Tools.Service
{
    public class CodeGenerationHelpers
    {
        #region internals
        private DbExConfig _config;
        private Dictionary<INamedMeta, object> _meta;
        #endregion

        #region constructors
        public CodeGenerationHelpers(DbExConfig config)
        {
            _config = config;
            _meta = new Dictionary<INamedMeta, object>();
        }
        #endregion

        #region resolve root namespace
        public string ResolveRootNamespace()
        {
            return _config.RootNamespace.TrimEnd('.') + '.';
        }
        #endregion

        #region to lower
        public string ToLower(string value)
        {
            return value is object ? value.ToLower() : value;
        }
        #endregion

        #region to camel case
        public string ToCamelCase(string val)
        {
            return val is object && val.Length > 0
                ? (val.Trim().Substring(0, 1).ToLower() + val.Substring(1))
                : val;
        }

        public string ToCamelCase(INamedMeta namedMeta)
        {
            string val = this.ResolveName(namedMeta);
            return this.ToCamelCase(val);
        }
        #endregion

        #region insert space on capitalization
        public string InsertSpaceOnCapitalization(string value)
        {
            if (value is object)
            {
                value = value.Trim();
                MatchCollection matches = Regex.Matches(value, "[A-Z]");
                int adj = 0;
                foreach (Match m in matches)
                {
                    if (!(m.Index == 0))
                    {
                        value = value.Insert((m.Index + adj), " ");
                        adj++;
                    }
                }
            }
            return value;
        }
        #endregion

        #region insert space on capitalization and to lower
        public string InsertSpaceOnCapitalizationAndToLower(string value)
        {
            return this.InsertSpaceOnCapitalization(value).ToLower();
        }
        #endregion

        #region concat
        public string Concat(string item1, string item2)
        {
            return item1 + item2;
        }
        #endregion

        #region resolve name
        public string ResolveName(INamedMeta namedMeta)
        {
            return this.TryResolveMeta(namedMeta, "Name", out string nameOverride) ? nameOverride : namedMeta.Name;
        }
        #endregion

        #region resolve interfaces
        public string[] ResolveAppliedInterfaces(INamedMeta namedMeta)
        {
            return this.TryResolveMeta(namedMeta, "Interfaces", out string[] interfaces) ? interfaces : new string[0];
        }
        #endregion

        #region has clr type override
        public string GetClrTypeOverride(INamedMeta namedMeta)
        {
            return this.TryResolveMeta(namedMeta, "ClrType", out string dataTypeOverride) ? dataTypeOverride : null;
        }

        public bool HasClrTypeOverride(INamedMeta namedMeta, out string dataTypeOverride)
        {
            return this.TryResolveMeta(namedMeta, "ClrType", out dataTypeOverride);
        }
        #endregion

        #region is enum
        public bool IsEnum(INamedMeta namedMeta)
        {
            bool isEnum = false;
            if (this.HasClrTypeOverride(namedMeta, out string dataTypeOverride))
            {
                var trimmed = dataTypeOverride.TrimEnd('?');
                isEnum = _config.Enums.Contains(trimmed);
            }
            return isEnum;
        }
        #endregion

        #region is ignored
        public bool IsIgnored(INamedMeta namedMeta)
        {
            this.TryResolveMeta(namedMeta, "Ignore", out bool isIgnored);
            return isIgnored;
        }
        #endregion

        #region allow insert
        public bool AllowInsert(MsSqlColumn column)
        {
            if (this.TryResolveMeta(column, "AllowInsert", out bool? allowInsert))
                return allowInsert.Value;

            return true;
        }
        #endregion

        #region allow update
        public bool AllowUpdate(MsSqlColumn column)
        {
            if (this.TryResolveMeta(column, "AllowUpdate", out bool? allowUpdate))
                return allowUpdate.Value;

            return true;
        }
        #endregion

        #region try resolve meta
        private bool TryResolveMeta<T>(INamedMeta namedMeta, string key, out T value)
        {
            value = default(T);
            if (string.IsNullOrEmpty(namedMeta.Meta))
                return false;

            _meta.TryGetValue(namedMeta, out var meta);
            if (meta is null)
            {
                meta = JsonConvert.DeserializeObject<Apply>(namedMeta.Meta);
                _meta.Add(namedMeta, meta);
            }

            value = meta.ReflectItem<T>(key, false);

            return value is object;
        }
        #endregion

        #region first or default
        public object FirstOrDefault(IEnumerable set)
        {
            var enumerator = set.GetEnumerator();
            return enumerator.MoveNext() ? enumerator.Current : null;
        }
        #endregion

        #region enums
        public IList<string> GetDeclaredEnumerationTypes()
            => _config.Enums;
        #endregion

        #region get template partial
        public string GetTemplatePartial(string shortName)
        {
            var resources = new ResourceAccessor();
            var resource = resources.GetTemplatePartial(shortName);
            return resource.Value;
        }
        #endregion
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using HatTrick.DbEx.Tools.Configuration;
using HatTrick.Model.MsSql;
using HatTrick.Reflection;
using svc = HatTrick.DbEx.Tools.Service.ServiceDispatch;
using Newtonsoft.Json;
using System.Linq;

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

        public string InsertSpaceOnCapitalizationAndToLower(INamedMeta namedMeta)
        {
            string val = this.ResolveName(namedMeta);
            return this.InsertSpaceOnCapitalization(val).ToLower();
        }
        #endregion

        #region resolve name
        //this method takes into account override via metadata
        public string ResolveName(INamedMeta namedMeta)
        {
            string name = null;
            if (this.HasNameOverride(namedMeta, out string nameOverride))
            {
                name = nameOverride;
            }
            else
            {
                name = namedMeta.Name;
            }
            return name;
        }
        #endregion

        #region resolve strict name
        //this method does NOT take into account override via metadata
        public string ResolveStrictName(INamedMeta namedMeta)
        {
            string name = namedMeta?.Name;
            return name;
        }
        #endregion

        #region resolve clr type name
        //This method takes into account override via metadata
        public string ResolveClrTypeName(MsSqlColumn column, bool allowNullableType)
        {
            string name = null;
            if (this.HasClrTypeOverride(column, out string dataTypeOverride))
            {
                name = dataTypeOverride.EndsWith("?") && !allowNullableType ? dataTypeOverride.Substring(0, dataTypeOverride.Length - 1) : dataTypeOverride;
            }
            else
            {
                name = svc.TypeMap.GetAssemblyTypeShortName(column.SqlType, allowNullableType);
            }
            return name;
        }
        #endregion

        #region resolve strict clr type name
        //this method does NOT take into account override via metadata
        public string ResolveStrictAssemblyTypeName(MsSqlColumn column)
        {
            string name = null;
            name = svc.TypeMap.GetAssemblyTypeShortName(column.SqlType, column.IsNullable);
            return name;
        }
        #endregion

        #region is nullable type
        public bool IsNullableType(MsSqlColumn column)
        {
            string name = null;
            if (this.IsEnum(column))
            {
                name = this.ResolveClrTypeName(column, column.IsNullable);
                return name.EndsWith("?");
            }
            else
            {
                name = svc.TypeMap.GetAssemblyTypeShortName(column.SqlType, column.IsNullable);
            }
            return name.EndsWith("?");
        }
        #endregion

        #region resolve field expression type name
        public string ResolveFieldExpressionTypeName(MsSqlColumn column, bool allowNullableType)
        {
            if (this.IsEnum(column))
            {
                var name = this.ResolveClrTypeName(column, allowNullableType);
                return $"{(name.EndsWith("?") ? "Nullable" : string.Empty)}EnumFieldExpression";
            }
            else if (this.HasClrTypeOverride(column, out string dataTypeOverride))
            {
                return $"{(column.IsNullable ? "Nullable" : string.Empty)}{svc.TypeMap.GetTypeNameFromAlias(dataTypeOverride)}FieldExpression";
            }
            return $"{(column.IsNullable ? "Nullable" : string.Empty)}{svc.TypeMap.GetAssemblyTypeName(column.SqlType)}FieldExpression";
        }
        #endregion

        #region resolve element type name
        public string ResolveElementTypeName(MsSqlColumn column)
        {
            if (this.IsEnum(column))
            {
                var name = this.ResolveClrTypeName(column, false);
                return $"{(name.EndsWith("?") ? "Nullable" : string.Empty)}EnumElement<{this.ResolveClrTypeName(column, false)}>";
            }
            else if (this.HasClrTypeOverride(column, out string dataTypeOverride))
            {
                return $"{svc.TypeMap.GetTypeNameFromAlias(dataTypeOverride)}Element";
            }
            return $"{svc.TypeMap.GetAssemblyTypeName(column.SqlType)}Element";
        }
        #endregion

        #region resolve interfaces
        public string[] ResolveAppliedInterfaces(INamedMeta namedMeta)
        {
            this.TryResolveMeta<string[]>(namedMeta, "Interfaces", out string[] interfaces);
            return interfaces;
        }
        #endregion

        #region has name override
        public bool HasNameOverride(INamedMeta namedMeta, out string nameOverride)
        {
            return this.TryResolveMeta(namedMeta, "Name", out nameOverride);
        }
        #endregion

        #region has clr type override
        public bool HasClrTypeOverride(INamedMeta namedMeta)
        {
            return this.HasClrTypeOverride(namedMeta, out string _);
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

        #region is last
        public bool IsLast(IEnumerable<MsSqlColumn> columnSet, MsSqlColumn column)
        {
            bool isLast = false;
            if (columnSet is object)
            {
                var set = columnSet.ToList();
                int idxLast = set.Count - 1;
                isLast = set[idxLast] == column;
            }
            return isLast;
        }
        #endregion

        #region resolve consolidated tables and views
        public IList<INamedMeta> ResolveConsolidatedTablesAndViews(MsSqlSchema schema)
        {
            List<INamedMeta> set = new List<INamedMeta>();
            foreach (string t in schema.Tables.Keys)
            {
                set.Add(schema.Tables[t]);
            }
            foreach (string v in schema.Views.Keys)
            {
                set.Add(schema.Views[v]);
            }
            return set;
        }
        #endregion

        #region is ms sql table
        public bool IsMsSqlTable(INamedMeta namedMeta)
        {
            return namedMeta is MsSqlTable;
        }
        #endregion

        #region is ms sql view
        public bool IsMsSqlView(INamedMeta namedMeta)
        {
            return namedMeta is MsSqlView;
        }
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

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using HatTrick.Model.MsSql;
using svc = HatTrick.DbEx.Tools.Service.ServiceDispatch;

namespace HatTrick.DbEx.Tools.Service
{
    public class CodeGenerationHelpers
    {
        #region constructors
        public CodeGenerationHelpers()
        {
        }
        #endregion

        #region to lower
        public string ToLower(string value)
        {
            return value != null ? value.ToLower() : value;
        }
        #endregion

        #region to camel case
        public string ToCamelCase(string val)
        {
            return val != null && val.Length > 0
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
            if (value != null)
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

        #region resolve assembly type name
        //This method takes into account override via metadata
        public string ResolveAssemblyTypeName(MsSqlColumn column)
        {
            string name = null;
            if (this.HasDataTypeOverride(column, out string dataTypeOverride))
            {
                name = dataTypeOverride;
            }
            else
            {
                name = svc.TypeMap.GetAssemblyTypeShortName(column.SqlType, column.IsNullable);
            }
            return name;
        }
        #endregion

        #region resolve strict assembly type name
        //this method does NOT take into account override via metadata
        public string ResolveStrictAssemblyTypeName(MsSqlColumn column)
        {
            string name = null;
            name = svc.TypeMap.GetAssemblyTypeShortName(column.SqlType, column.IsNullable);
            return name;
        }
        #endregion

        #region resolve field expression type name
        public string ResolveFieldExpressionTypeName(MsSqlColumn column)
        {
            string name = null;
            if (this.HasFieldTypeOverride(column, out string fieldTypeOverride))
            {
                bool isNullable = false;
                if (fieldTypeOverride.EndsWith("?"))
                {
                    isNullable = true;
                    fieldTypeOverride = fieldTypeOverride.TrimEnd('?');
                }
                string nullability = isNullable ? "Nullable" : string.Empty;
                name = $"{nullability}{fieldTypeOverride}FieldExpression";
            }
            else
            {
                name = svc.TypeMap.GetFieldExpressionTypeName(column.SqlType, column.IsNullable);
            }
            return name;
        }
        #endregion

        #region field requires typed parameter
        public bool FieldRequiresTypedParameter(MsSqlColumn column)
        {
            string fieldName = this.ResolveFieldExpressionTypeName(column);
            bool isRequired = fieldName.Contains("Enum", StringComparison.CurrentCultureIgnoreCase);
            return isRequired;
        }
        #endregion

        #region name represents last touched timestamp
        public bool NameRepresentsLastTouchedTimestamp(string name)
        {
            name = name.Replace("-", string.Empty).Replace("_", string.Empty);

            if (string.Compare(name, "DateUpdated", true) == 0)
                return true;
            if (string.Compare(name, "LastUpdated", true) == 0)
                return true;
            if (string.Compare(name, "UpdatedAt", true) == 0)
                return true;
            if (string.Compare(name, "LastUpdatedAt", true) == 0)
                return true;
            if (string.Compare(name, "Updated", true) == 0)
                return true;

            return false;
        }
        #endregion

        #region has name override
        public bool HasNameOverride(INamedMeta namedMeta, out string nameOverride)
        {
            return this.TryResolveMeta(namedMeta, "nameOverride", out nameOverride);
        }
        #endregion

        #region has type override
        public bool HasDataTypeOverride(INamedMeta namedMeta)
        {
            return this.HasDataTypeOverride(namedMeta, out string _);
        }

        public bool HasDataTypeOverride(INamedMeta namedMeta, out string dataTypeOverride)
        {
            return this.TryResolveMeta(namedMeta, "dataTypeOverride", out dataTypeOverride);
        }
        #endregion

        #region has field type override
        public bool HasFieldTypeOverride(INamedMeta namedMeta)
        {
            return this.HasFieldTypeOverride(namedMeta, out string _);
        }

        public bool HasFieldTypeOverride(INamedMeta namedMeta, out string fieldTypeOverride)
        {
            return this.TryResolveMeta(namedMeta, "fieldTypeOverride", out fieldTypeOverride);
        }
        #endregion

        #region is ignored
        public bool IsIgnored(INamedMeta namedMeta)
        {
            bool isIgnored = false;

            if (this.TryResolveMeta(namedMeta, "ignore", out string ignore))
            {
                isIgnored = string.Compare(ignore, "true", true) == 0;
            }
            return isIgnored;
        }
        #endregion

        #region try resolve meta
        private bool TryResolveMeta(INamedMeta namedMeta, string name, out string value)
        {
            value = null;
            string json = namedMeta.Meta;
            if (json == null)
            {
                return false;
            }

            char[] delimiters = new char[] { ' ', '{', ':', ',', '}', '\t', '\n', '\r' };

            Tokenizer t = new Tokenizer(delimiters);

            bool found = false;
            bool set = false;
            string val = null;
            t.Emit = (tkn) =>
            {
                if (!found)
                {
                    if (tkn == name)
                    {
                        found = true;
                    }
                }
                else
                {
                    if (!set)
                    {
                        val = tkn;
                        set = true;
                    }
                }
            };

            t.Parse(json);

            value = val;

            return (found && set);
        }
        #endregion

        #region is last
        public bool IsLast(EnumerableNamedMetaSet<MsSqlColumn> columnSet, MsSqlColumn column)
        {
            bool isLast = false;
            if (columnSet != null)
            {
                int idxLast = columnSet.Count - 1;
                isLast = columnSet[idxLast] == column;
            }
            return isLast;
        }
        #endregion

        #region resolve consolidated tables and views
        public EnumerableNamedMetaSet<INamedMeta> ResolveConsolidatedTablesAndViews(MsSqlSchema schema)
        {
            EnumerableNamedMetaSet<INamedMeta> set = new EnumerableNamedMetaSet<INamedMeta>();
            foreach (MsSqlTable t in schema.Tables)
            {
                set.Add(t);
            }
            foreach (MsSqlView v in schema.Views)
            {
                set.Add(v);
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
    }
}

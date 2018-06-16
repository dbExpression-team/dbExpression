using System;
using System.Collections.Generic;
using System.Linq;
using HTL.DbEx.Utility;
using HTL.DbEx.ObjectMap;

namespace HTL.DbEx.Sql.ObjectMap
{
    public class SqlField : Field
    {
        #region internals
        protected readonly ColumnInfo _column;
        protected bool _isKnownSqlType;
        #endregion

        #region interface properties
        public int ColumnId { get { return _column.ColumnId; } }

        public bool IsPrimaryKey { get; set; }

        public bool UnSigned { get; set; }
        #endregion

        #region constructors
        public SqlField(ColumnInfo column, List<SqlRelationship> relationships)
        {
            _column = column;

            if (relationships != null)
            {
                foreach (SqlRelationship r in relationships)
                {
                    base.Relationships.Add(r);
                }
            }
            
            this.Extract();
            this.ApplyExtendedProperties();
        }
        #endregion

        #region methods
        protected virtual void Extract()
        {
            base.Name = _column.ColumnName;
            base.IsRequired = !_column.IsNullable;
            base.IsIdentity = _column.IsIdentity;
            base.SqlTypeDefinition = _column.DataType;
            base.IsIgnored = false;
            base.IsComputed = _column.IsComputed;
            this.UnSigned = _column.UnSigned;
        }

        private void ApplyExtendedProperties()
        {
            Dictionary<string, string> extendedProps = _column.ExtendedProperties;
            if (extendedProps.Keys.Contains("htl"))
            {
                string delimitedProps = extendedProps["htl"].ToString().Replace(" ", string.Empty);
                string[] propArray = delimitedProps.Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < propArray.Length; i++)
                {
                    string p = propArray[i].Trim();

                    if (p.ToLower() == "ignore")
                    {
                        base.IsIgnored = true;
                    }
                    else if (p.ToLower().StartsWith("type="))
                    {
                        string val = p.Substring(5, (p.Length - 5));
                        base.AssemblyTypeOverride = TypeUtility.GetAssemblyTypeFromTypeText(val);
                        if (base.AssemblyTypeOverride == null) //possible enum
                        {
                            base.UnknownAssemblyTypeOverride = val;
                        }
                    }
                    else if (p.ToLower().StartsWith("alias="))
                    {
                        string val = p.Substring(6, (p.Length - 6));
                        base.AliasName = val;
                    }
                    else if (p.ToLower().StartsWith("attr="))
                    {
                        string val = p.Substring(5, (p.Length - 5));
                        base.AttributeDefinitions = val;
                    }
                    
                }
            }
        }
        #endregion
    }
}

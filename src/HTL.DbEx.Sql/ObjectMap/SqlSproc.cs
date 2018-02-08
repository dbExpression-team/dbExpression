using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HTL.DbEx.Utility;
using HTL.DbEx.ObjectMap;

namespace HTL.DbEx.Sql.ObjectMap
{
    public class SqlSproc
    {
        #region internals
        protected readonly SprocInfo _sprocInfo;
        #endregion

        #region interface
        public string Name { get; private set; }
        public string SchemaOwner { get; private set; }
        public bool IsStartupSproc { get; private set; }
        public Type ReturnAssemblyType { get; private set; }
        public string UnknownReturnAssemblyTypeOverride  { get; private set; }
        public bool IsIgnored { get; private set; }
        public List<SqlParameter> Parameters { get; private set; }
        #endregion

        #region constructors
        public SqlSproc(SprocInfo sprocInfo)
        {
            _sprocInfo = sprocInfo;
            this.Extract();
            this.ApplyExtendedProperties(_sprocInfo.ExtendedProperties);
        }
        #endregion

        protected virtual void Extract()
        {
            this.Name = _sprocInfo.Name;
            this.SchemaOwner = _sprocInfo.SchemaOwner;
            this.IsStartupSproc = _sprocInfo.IsStartupSproc;
            this.ReturnAssemblyType = null;

            this.Parameters = new List<SqlParameter>();
            foreach (ParameterInfo p in _sprocInfo.Parameters)
            {
                SqlParameter sqlParam = new SqlParameter(p);
            }
        }

        #region apply extended properties
        private void ApplyExtendedProperties(Dictionary<string, string> extendedProperties)
        {
            if (extendedProperties.Keys.Contains("htl"))
            {
                string delimitedProps = extendedProperties["htl"].ToString().Replace(" ", string.Empty);
                string[] propArray = delimitedProps.Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string p in propArray)
                {
                    if (p.Trim().ToLower() == "ignore")
                    {
                        this.IsIgnored = true;
                        continue;
                    };

                    if (p.Trim().ToLower().StartsWith("returnListOf="))
                    {
                        string val = p.Substring(7, (p.Length - 7));
                        this.ReturnAssemblyType = TypeUtility.GetAssemblyTypeFromTypeText(val);
                        if (this.ReturnAssemblyType == null) //possible enum
                        {
                            this.UnknownReturnAssemblyTypeOverride = val;
                        }
                        continue;
                    };
                }
            }
        }
        #endregion
    }
}

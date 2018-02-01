using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HTL.DbEx.Utility;

namespace HTL.DbEx.Sql.ObjectMap
{
    public class SqlParameter
    {
        #region internals
        protected ParameterInfo _parameterInfo;
        #endregion

        #region interface
        public string Name
        { get; private set; }

        public Type AssemblyType
        { get; protected set; }

        public Type AssemblyTypeOverride
        { get; protected set; }

        public string UnknownAssemblyTypeOverride
        { get; protected set; }

        public string AssemblyTypeShorthandText
        {
            get
            {
                return (this.AssemblyTypeOverride != null)
                    ? TypeUtility.GetAssemblyTypeShorthandText(this.AssemblyTypeOverride)
                    : (this.UnknownAssemblyTypeOverride != null)
                        ? this.UnknownAssemblyTypeOverride
                        : TypeUtility.GetAssemblyTypeShorthandText(this.AssemblyType);
            }
        }

        public byte Precision
        { get; protected set; }

        public byte Scale
        { get; protected set; }

        public int MaxLength
        { get; protected set; }

        public string SqlTypeDefinition
        { get; protected set; }

        public bool IsOutputParameter
        { get; protected set; }

        public bool IsIgnored
        { get; protected set; }
        #endregion

        #region constructors
        public SqlParameter(ParameterInfo parameterInfo)
        {
            _parameterInfo = parameterInfo;
            this.Extract();
            this.ApplyExtendedProperties(_parameterInfo.ExtendedProperties); //TODO: JRod, sql server currently does not support ext props on params
        }

        protected virtual void Extract()
        {
            this.Name = _parameterInfo.Name;
        }
        #endregion

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

                    if (p.Trim().ToLower().StartsWith("type="))
                    {
                        string val = p.Substring(5, (p.Length - 5));
                        this.AssemblyTypeOverride = TypeUtility.GetAssemblyTypeFromTypeText(val);
                        if (this.AssemblyTypeOverride == null) //possible enum
                        {
                            this.UnknownAssemblyTypeOverride = val;
                        }
                        continue;
                    };
                }
            }
        }
        #endregion
    }
}

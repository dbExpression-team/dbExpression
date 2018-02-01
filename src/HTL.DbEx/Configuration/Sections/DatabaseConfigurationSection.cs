using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Xml;

namespace HTL.DbEx.Configuration
{
    public class DatabaseConfigurationSection
    {
        #region internals
        private string _defaultDatabase;
        #endregion

        #region interface
        public string DefaultDatabase
        {
            get
            {
                if (string.IsNullOrEmpty(_defaultDatabase))
                {
                    throw new ConfigurationErrorsException("Attribute 'defaultDatabase' not found within the databaseConfiguration config section.");
                }
                return _defaultDatabase;
            }
        }
        #endregion

        #region constructors
        public DatabaseConfigurationSection(object parent, object configContext, XmlNode section)
        {
            this.ParseValues(parent, configContext, section);
        }
        #endregion

        #region methods
        private void ParseValues(object parent, object configContext, XmlNode section)
        {
            if (section.Attributes["defaultDatabase"] != null)
            {
                _defaultDatabase = section.Attributes["defaultDatabase"].Value;
            }
        }
        #endregion
    }
}

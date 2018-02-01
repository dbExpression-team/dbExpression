using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Xml;

namespace HTL.DbEx.Configuration
{
    public class MongoDBConfigurationSection
    {
        #region interface
        public string DefaultConnection { get; private set; }
        #endregion

        #region constructors
        public MongoDBConfigurationSection(object parent, object configContext, XmlNode section)
        {
            this.ParseValues(parent, configContext, section);
        }
        #endregion

        #region methods
        private void ParseValues(object parent, object configContext, XmlNode section)
        {
            if (section.Attributes["defaultConnection"] != null)
            {
                this.DefaultConnection = section.Attributes["defaultConnection"].Value;
            }
        }
        #endregion
    }
}

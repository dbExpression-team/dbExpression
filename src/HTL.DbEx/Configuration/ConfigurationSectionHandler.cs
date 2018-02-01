using System; 
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace HTL.DbEx.Configuration
{
    public class ConfigurationSectionHandler : IConfigurationSectionHandler
    {
        #region create
        public object Create(object parent, object configContext, XmlNode section)
        {
            switch (section.Name)
            {
                case "databaseConfiguration":
                    return new DatabaseConfigurationSection(parent, configContext, section);
                case "mongoDB":
                    return new MongoDBConfigurationSection(parent, configContext, section);
                default:
                    string errorMessage = string.Format("Encountered unknown configuration section name: {0}", section.Name);
                    throw new ConfigurationErrorsException(errorMessage);
            }
            
        }
        #endregion
    }
}

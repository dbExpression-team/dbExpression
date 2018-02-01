using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace HTL.DbEx.Configuration
{
    public class ConfigurationService
    {
        #region database
        public static DatabaseConfigurationSection Database
        {
            get
            {
                DatabaseConfigurationSection section = (DatabaseConfigurationSection)ConfigurationManager.GetSection("htl/databaseConfiguration");
                return section;
            }
        }
        #endregion

        #region mongo db
        public static MongoDBConfigurationSection MongoDB
        {
            get
            {
                MongoDBConfigurationSection section = (MongoDBConfigurationSection)ConfigurationManager.GetSection("htl/mongoDb");
                return section;
            }
        }
        #endregion
    }
}

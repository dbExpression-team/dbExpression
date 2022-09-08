using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.DbEx.Tools.Model
{
    public class PlatformModel
    {
        public string Key { get; set; }
        public string Version { get; set; }

        public PlatformModel(string key, string version)
        {
            Key = key;
            Version = version;
        }
    }
}

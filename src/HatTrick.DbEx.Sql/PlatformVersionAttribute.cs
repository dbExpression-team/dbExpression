using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace HatTrick.DbEx.Sql
{
#if !NET7_0_OR_GREATER
    public class PlatformVersionAttribute : System.Attribute
    {
        public string PlatformVersion { get; }

        public PlatformVersionAttribute(string platformVersion)
        {
            if (string.IsNullOrWhiteSpace(platformVersion))
                throw new ArgumentException($"{nameof(platformVersion)} version is required.");
            PlatformVersion = platformVersion;
        }
    }
#endif
}

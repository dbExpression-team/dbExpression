using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace HatTrick.DbEx.Tools
{
    #region resource accessor
    public class ResourceAccessor
    {
        #region get template short names
        public string[] GetTemplateShortNames()
        {
            Assembly assem = Assembly.GetExecutingAssembly();
            string[] names = assem.GetManifestResourceNames().ToList()
                .FindAll(n => n.StartsWith("HatTrick.DbEx.Tools.Resources.Templates") && !n.Contains(".Partials"))
                .ToArray(); ;

            for (int i = 0; i < names.Length; i++)
            {
                names[i] = this.ParseShortName(names[i]);
            }
            return names;
        }
        #endregion

        #region parse short name
        private string ParseShortName(string fullName)
        {
            //HatTrick.DbEx.Tools.Resources.Templates.{name}.htt
            //HatTrick.DbEx.Tools.Resources.Templates.Partials.{name}.htt
            int idx1 = fullName.LastIndexOf('.');
            int idx2 = fullName.LastIndexOf('.', idx1 - 1);
            string shortName = fullName.Substring(++idx2, (idx1 - idx2));

            return shortName;
        }
        #endregion

        #region get template
        public Resource GetTemplate(string shortName)
        {
            string fullName = $"HatTrick.DbEx.Tools.Resources.Templates.{shortName}.htt";
            return this.Get(fullName);
        }
        #endregion

        #region get template partial
        public Resource GetTemplatePartial(string shortName)
        {
            string fullName = $"HatTrick.DbEx.Tools.Resources.Templates.Partials.{shortName}.htt";
            return this.Get(fullName);
        }
        #endregion

        #region get
        public Resource Get(string fullName)
        {
            Assembly assem = Assembly.GetExecutingAssembly();

            string shortName = this.ParseShortName(fullName);

            string output = null;
            using (Stream stream = assem.GetManifestResourceStream(fullName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    output = reader.ReadToEnd();
                }
            }
            var resource = new Resource()
            {
                Name = shortName,
                FullName = fullName,
                Value = output
            };
            return resource;
        }
        #endregion
    }
    #endregion

    #region resource
    public class Resource
    {
        #region interface
        public string Name { get; set; }

        public string FullName { get; set; }

        public string Value { get; set; }
        #endregion
    }
    #endregion
}
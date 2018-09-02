using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace HatTrick.DbEx.ObjectMap.Assembly
{
    public class AssemblyModel : Model
    {
        #region internals
        private System.Reflection.Assembly _assembly;
        private string _namespace;
        private List<Enumeration> _enums;
        #endregion

        #region interface
        #endregion

        #region constructors
        public AssemblyModel(System.Reflection.Assembly assembly)
        {
            _assembly = assembly;
            _enums = new List<Enumeration>();

            this.ExtractModel();
        }

        public AssemblyModel(System.Reflection.Assembly assembly, string nameSpace)
        {
            _assembly = assembly;
            _namespace = nameSpace;
            _enums = new List<Enumeration>();

            this.ExtractModel();
        }
        #endregion

        #region methods
        private void ExtractModel()
        {
            base.Name = _assembly.FullName;

            Type[] types;
            try
            {
                types = (from t in _assembly.GetTypes() orderby t.Name select t).ToArray();
            }
            catch (ReflectionTypeLoadException e)
            {
                types = (from t in e.Types where t != null orderby t.Name select t).ToArray();
            }


            foreach (Type t in types)
            {
                if (!string.IsNullOrEmpty(_namespace) && t.Namespace != _namespace)
                {
                    continue;
                }
                if (t.IsSubclassOf(typeof(Enum)))
                {
                    AssemblyEnumeration en = new AssemblyEnumeration(t);
                    _enums.Add(en);
                }
                else
                {
                    AssemblyEntity ae = new AssemblyEntity(t);
                    if (ae.HasAttribute(typeof(GenIgnoreAttribute))) { continue; }
                    base.AddEntity(ae);
                }
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }
}

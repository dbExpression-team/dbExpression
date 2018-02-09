using HTL.DbEx.ObjectMap;

namespace HTL.DbEx.Sql.ObjectMap
{
    public class SqlEnumeration : Enumeration
    {
        #region internals
        protected readonly TypeCodeInfo _typeCodeInfo;
        #endregion

        #region interface
        #endregion

        #region constructors
        public SqlEnumeration(TypeCodeInfo typeCodeInfo)
        {
            _typeCodeInfo = typeCodeInfo;
            this.ExtractEnumeration();
        }
        #endregion

        #region methods
        private void ExtractEnumeration()
        {
            base.Name = _typeCodeInfo.Name;
            base.IntegralType = typeof(int);
            foreach (TypeCodeItemInfo tii in _typeCodeInfo.TypeCodeItems)
            {
                base.AddItem(new SqlEnumerationItem(tii));
            }
        }
        #endregion
    }
}

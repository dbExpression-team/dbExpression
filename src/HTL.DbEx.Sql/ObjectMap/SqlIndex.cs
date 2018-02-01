using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using HTL.DbEx.ObjectMap;

namespace HTL.DbEx.Sql.ObjectMap
{
    public class SqlIndex : Index
    {
        #region internals
        protected List<IndexInfo> _indexInfos;
        #endregion

        #region constructors
        public SqlIndex(List<IndexInfo> indexInfo)
        {
            _indexInfos = indexInfo;
            this.ExtractIndex();
        }
        #endregion

        #region methods
        private void ExtractIndex()
        {
            base.EntityName = _indexInfos[0].TableName;
            foreach (IndexInfo idx in _indexInfos)
            {
                base.AddAffectedField(new SqlIndexedField(idx));
            }

            base.IsClustered = (_indexInfos[0].IndexTypeCode == 1); //1 = clustered, 2 = nonclustered
            base.IsUnique = _indexInfos[0].IsUnique;
            base.IsPrimaryKey = _indexInfos[0].IsPrimaryKey;
            base.ModelRefKey = _indexInfos[0].IndexName;
        }
        #endregion
    }
}

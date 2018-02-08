using System;
using System.Collections.Generic;
using System.Linq;
using HTL.DbEx.ObjectMap;

namespace HTL.DbEx.Sql.ObjectMap
{
    public class SqlEntity : Entity
    {
        #region internals
        protected readonly EntityInfo _tableInfo;
        protected readonly List<ColumnInfo> _columns;
        protected readonly List<IndexInfo> _indexes;
        protected readonly List<SqlRelationship> _relationships;
        #endregion

        #region interface
        public EntityType SqlEntityType { get; private set; }

        public new IList<SqlField> Fields
        {
            get { return base.Fields.ToList().ConvertAll(f => f as SqlField); }
        }
        #endregion

        #region constructors
        public SqlEntity(EntityInfo entityInfo, List<ColumnInfo> columns, List<SqlRelationship> relationships, List<IndexInfo> indexes)
        {
            _tableInfo = entityInfo;
            _columns = columns;
            _relationships = relationships;
            _indexes = indexes;
            this.SqlEntityType = entityInfo.EntityType;
            this.Extract();
            this.ApplyExtendedProperties();
        }
        #endregion

        #region methods
        protected virtual void Extract()
        {
            base.Name = _tableInfo.Name;
            base.Schema = _tableInfo.SchemaOwner;
        }

        private void ApplyExtendedProperties()
        {
            Dictionary<string, string> extendedProps = _tableInfo.ExtendedProperties;
            if (extendedProps.Keys.Contains("htl"))
            {
                string delimitedProps = extendedProps["htl"].ToString().Replace(" ", string.Empty);
                string[] propArray = delimitedProps.Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string p in propArray)
                {
                    if (p.Trim().ToLower() == "ignore") 
                    { 
                        base.IsIgnored = true; 
                        continue; 
                    };
                }
            }
        }
        #endregion
    }
}

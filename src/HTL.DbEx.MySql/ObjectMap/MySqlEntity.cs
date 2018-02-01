using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTL.DbEx.Sql.ObjectMap;

namespace HTL.DbEx.MySql.ObjectMap
{
    public class MySqlEntity : SqlEntity
    {
        #region constructors
        public MySqlEntity(EntityInfo entityInfo, List<ColumnInfo> columns, List<SqlRelationship> relationships, List<IndexInfo> indexes) : base(entityInfo, columns, relationships, indexes)
        {
        }
        #endregion

        #region extract
        protected override void Extract()
        {
            base.Extract();

            //extract fields
            MySqlField field;
            foreach (ColumnInfo c in base._columns)
            {
                field = new MySqlField(c, null);
                base.AddField(field);
            }
        }
        #endregion
    }
}

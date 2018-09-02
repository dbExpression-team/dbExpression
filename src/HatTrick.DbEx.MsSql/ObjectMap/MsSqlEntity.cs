using System.Collections.Generic;
using System.Linq;
using HatTrick.DbEx.Sql.ObjectMap;

namespace HatTrick.DbEx.MsSql.ObjectMap
{
    public class MsSqlEntity : SqlEntity
    {
        #region constructors
        public MsSqlEntity(EntityInfo entityInfo, List<ColumnInfo> columns, List<SqlRelationship> relationships, List<IndexInfo> indexes) : base(entityInfo, columns, relationships, indexes)
        {
        }
        #endregion

        #region extract
        protected override void Extract()
        {
            base.Extract();

            //extract fields
            MsSqlField field;
            List<SqlRelationship> colRel;
            foreach (ColumnInfo c in base._columns)
            {
                colRel = (from r in _relationships where (r.LocalEntityId == _tableInfo.Id && r.LocalField == c.ColumnName) select r).ToList<SqlRelationship>();
                field = new MsSqlField(c, colRel);
                base.AddField(field);
            }

            //select distinct index ids
            string[] distinctIds = (from i in base._indexes select i.IndexId).Distinct().ToArray();

            foreach (string distinctId in distinctIds)
            {
                List<IndexInfo> distinctIdxInfo = (from i in base._indexes where i.IndexId == distinctId select i).ToList();
                base.AddIndex(new SqlIndex(distinctIdxInfo));
                IndexInfo pk = distinctIdxInfo.FirstOrDefault(i => i.IsPrimaryKey);
                if (pk != null)
                {
                    ColumnInfo column = _columns.FirstOrDefault(c => c.ColumnName == pk.ColumnName);
                    MsSqlField pkField = base.Fields.ToList().ConvertAll(f => f as MsSqlField).FirstOrDefault(f => f.ColumnId == pk.ColumnId);
                    if (pkField != null)
                    {
                        pkField.IsPrimaryKey = true;
                    }
                }
            }
        }
        #endregion
    }
}

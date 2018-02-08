using System.Collections.Generic;
using System.Linq;
using HTL.DbEx.ObjectMap;

namespace HTL.DbEx.Sql.ObjectMap
{
    public class SqlModel : Model
    {
        #region interface
        public string ConnectionStringName { get; protected set; }

        public new IList<SqlEntity> Entities { get { return base.Entities.ToList().ConvertAll(e => e as SqlEntity); } }

        public List<SqlSproc> Sprocs { get; private set; } = new List<SqlSproc>();

        public List<Enumeration> Enums { get; private set; } = new List<Enumeration>(); 
        #endregion
    }
}

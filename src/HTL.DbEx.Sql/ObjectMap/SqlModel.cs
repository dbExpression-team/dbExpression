using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTL.DbEx.ObjectMap;

namespace HTL.DbEx.Sql.ObjectMap
{
    public class SqlModel : Model
    {
        #region internals
        #endregion

        #region interface
        public string ConnectionStringName
        { get; protected set; }

        public new List<SqlEntity> Entities
        { get { return base.Entities.ConvertAll<SqlEntity>(e => e as SqlEntity); } }

        public List<SqlSproc> Sprocs
        { get; private set; }

        public List<Enumeration> Enums
        { get; private set; } 
        #endregion

        #region constructors
        public SqlModel()
        {
            this.Sprocs = new List<SqlSproc>();
            this.Enums = new List<Enumeration>();
        }
        #endregion
    }
}

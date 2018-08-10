using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace HTL.DbEx.Sql.Expression
{
    public class DBExpressionTable
    {
        #region interface
        public string Name
        {
            get
            {
                return _name;
            }
        }
        #endregion

        #region internals
        private string _name = string.Empty;
        #endregion

        #region methods
        public DBExpressionTable(string tableName)
        {
            _name = tableName;
        }

        public DBJoinExpression Join(DBExpressionJoinType joinType, DBFilterExpression joinCondition)
        {
            return new DBJoinExpression(joinType, this, joinCondition);
        }

        public virtual string ToParameterizedString(List<DbParameter> parameterList, SqlDbClient dbService)
        {
            return this.ToString();
        }

        public override string ToString()
        {
            return "[" + Name + "]";
        }

        public override bool Equals(object obj)
        {
            DBExpressionTable table = obj as DBExpressionTable;
            return table != null && table.Name == Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}

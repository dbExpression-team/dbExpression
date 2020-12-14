using HatTrick.Model.MsSql;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Tools.Model
{
    public class DatabasePairModel
    { 
        public MsSqlModel Database { get; set; }
        public DatabaseExpressionModel DatabaseExpression { get; set; }
        public IList<SchemaPairModel> Items { get; set; } = new List<SchemaPairModel>();
        public DocumentationItemsModel Documentation { get; set; }

        public DatabasePairModel(MsSqlModel database, DatabaseExpressionModel databaseExpression)
        {
            Database = database ?? throw new ArgumentNullException(nameof(database));
            DatabaseExpression = databaseExpression ?? throw new ArgumentNullException(nameof(databaseExpression));
        }
    }
}
